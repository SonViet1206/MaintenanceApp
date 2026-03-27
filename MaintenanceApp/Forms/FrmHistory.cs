using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MaintenanceApp.Forms
{
    public partial class FrmHistory : Form
    {
        Services.MaintenanceService _service;
        private DataTable dtHistory = new DataTable();

        public FrmHistory(Services.MaintenanceService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {

        }
        DialogResult _dr;
        private List<IGrouping<object, DataRow>> _pages;
        private int _currentPage = 0;
        private void btnFind_Click(object sender, EventArgs e)
        {
            string machine = string.IsNullOrWhiteSpace(txtMachineID.Text)
        ? null : txtMachineID.Text;

            string user = string.IsNullOrWhiteSpace(txtUserID.Text)
                ? null : txtUserID.Text;

            string result = string.IsNullOrWhiteSpace(cbbResult.Text)
                ? null : cbbResult.Text;
            if(machine==null)
            {
                MessageBox.Show("Vui lòng nhập mã máy để tìm kiếm");
                return;
            }    
            DateTime? from = dtpFrom.Checked ? dtpFrom.Value : null;
            DateTime? to = dtpTo.Checked ? dtpTo.Value : null;



            dtHistory.Rows.Clear();
            //thông báo : chỉ tìm kiếm ngày gần nhất hay tất cả
            _dr = MessageBox.Show("Chỉ tìm ngày gần nhất đúng chứ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            DateTime time = DateTime.Now;
            bool isNew = false;
            if (_dr == DialogResult.Yes)
            {
                dtHistory = _service.SearchHistory(machine, user, result, from, to);
                lblPage.Visible = false;
                btnNext.Visible = false;
                btnPrev.Visible = false;
                isNew=true;
            }
            else
            {
                dtHistory = _service.GetHistory(machine, from, to);
                _pages = dtHistory.AsEnumerable()
                .GroupBy(x => x["sheet_id"])
                .OrderByDescending(g => g.Max(x => x.Field<DateTime>("check_date")))
                .ToList();

                _currentPage = 0;
                lblPage.Text = $"Page {_currentPage + 1} / {_pages.Count}";
                lblPage.Visible = true;
                btnNext.Visible = true;
                btnPrev.Visible = true;
            }
            //MessageBox.Show($"{DateTime.Now - time}");


            // Xóa dữ liệu cũ
            dgvHistory.Rows.Clear();
            if (dtHistory.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào");
                return;
            }
            if (_service.GetMachineTypeName($"{txtMachineID.Text}").ToUpper().Contains("PEKO"))
            {
                btnKhongkhi.Visible = true;
            }
            else
            {
                btnKhongkhi.Visible = false;
            }
            
            if(isNew)
            {
                foreach (DataRow dr in dtHistory.Rows)
                {
                    int rowIndex = dgvHistory.Rows.Add();

                    var row = dgvHistory.Rows[rowIndex];

                    row.Cells["MachineCode"].Value = dr["machine_code"]?.ToString();
                    row.Cells["userID"].Value = dr["user_id"]?.ToString();
                    row.Cells["TypeMachineName"].Value = dr["machine_type_name"]?.ToString();
                    row.Cells["PartName"].Value = dr["part_name"]?.ToString();
                    row.Cells["ItemName"].Value = dr["item_name"]?.ToString();
                    row.Cells["Standard"].Value = dr["standard"]?.ToString();
                    row.Cells["Method"].Value = dr["method"]?.ToString();
                    row.Cells["ng_solution"].Value = dr["ng_solution"]?.ToString();
                    row.Cells["Time"].Value = Convert.ToDateTime(dr["check_date"]).ToString("yyyy-MM-dd HH:mm");

                    string resultValue = dr["result"]?.ToString();

                    row.Cells["OK"].Value = resultValue == "OK";
                    row.Cells["Clean"].Value = resultValue == "Clean/Adjust";
                    row.Cells["Replace"].Value = resultValue == "Replace";
                }
            }
            else
                LoadPage(_currentPage);
            
        }
        private void LoadPage(int pageIndex)
        {
            if (_pages == null || _pages.Count == 0) return;

            dgvHistory.Rows.Clear();

            var page = _pages[pageIndex];

            foreach (var dr in page)
            {
                int rowIndex = dgvHistory.Rows.Add();
                var row = dgvHistory.Rows[rowIndex];

                row.Cells["MachineCode"].Value = dr["machine_code"]?.ToString();
                row.Cells["userID"].Value = dr["user_id"]?.ToString();
                row.Cells["TypeMachineName"].Value = dr["machine_type_name"]?.ToString();
                row.Cells["PartName"].Value = dr["part_name"]?.ToString();
                row.Cells["ItemName"].Value = dr["item_name"]?.ToString();
                row.Cells["Standard"].Value = dr["standard"]?.ToString();
                row.Cells["Method"].Value = dr["method"]?.ToString();
                row.Cells["ng_solution"].Value = dr["ng_solution"]?.ToString();
                row.Cells["Time"].Value = Convert.ToDateTime(dr["check_date"])
                    .ToString("yyyy-MM-dd HH:mm");

                string resultValue = dr["result"]?.ToString();

                row.Cells["OK"].Value = resultValue == "OK";
                row.Cells["Clean"].Value = resultValue == "Clean/Adjust";
                row.Cells["Replace"].Value = resultValue == "Replace";
            }
        }

        public void ExportToExcel(DataTable dt)
        {

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Maintenance");

            ws.Style.Font.FontName = "Times New Roman";
            ws.Style.Font.FontSize = 11;

            int row = 1;

            // ===== HEADER =====
            ws.Cell(row, 1).Value = "PHIẾU BẢO DƯỠNG";
            ws.Range(row, 1, row, 8).Merge().Style
                .Font.SetBold()
                .Font.SetFontSize(16)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            row += 2;

            // ===== INFO =====
            ws.Range("A3:B3").Merge();
            ws.Range("E3:F3").Merge();
            ws.Range("G3:H3").Merge();

            ws.Cell(row, 1).Value = "Machine ID: " + dt.Rows[0]["machine_code"]?.ToString();
            //ws.Cell(row, 2).Value = 

            ws.Cell(row, 5).Value = "Person ID:" + dt.Rows[0]["user_id"]?.ToString();
            //ws.Cell(row, 5).Value = ;

            ws.Cell(row, 7).Value = "Date:" + Convert.ToDateTime(dt.Rows[0]["check_date"])
                                        .ToString("yyyy-MM-dd");
            //ws.Cell(row, 7).Value = Convert.ToDateTime(dt.Rows[0]["check_date"])
            //                            .ToString("yyyy-MM-dd");

            if (btnKhongkhi.Visible)
            {
                row += 2;
                var airData = _service.GetAir(txtMachineID.Text, dtpFrom.Value, dtpTo.Value);
                var latestRow = airData.AsEnumerable()
                .OrderByDescending(r => r.Field<DateTime>("created_at"))
                .FirstOrDefault(); // Lấy dòng đầu tiên hoặc null nếu bảng trống

                if (latestRow != null)
                {
                    // Ví dụ: Lấy giá trị ngày của dòng đó
                    DateTime lastDate = latestRow.Field<DateTime>("created_at");
                }
                ws.Range("A5:B5").Merge();
                ws.Range("A6:B6").Merge();
                ws.Range("A7:B7").Merge();
                ws.Cell(row++, 1).Value = $"Giá trị không khí 1:{latestRow[1].ToString()}";
                ws.Cell(row++, 1).Value = $"Giá trị không khí 2:{latestRow[2].ToString()}";
                ws.Cell(row++, 1).Value = $"Giá trị không khí 3:{latestRow[3].ToString()}";
                ws.Range(5, 1, 7, 2).Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);



            }


            row += 1;

            // ===== TABLE HEADER =====
            int headerRow = row;

            ws.Cell(row, 1).Value = "Bộ phận";
            ws.Cell(row, 2).Value = "Nội dung";
            ws.Cell(row, 3).Value = "Tiêu chuẩn";
            ws.Cell(row, 4).Value = "Phương pháp";
            ws.Cell(row, 5).Value = "Phương pháp NG";
            ws.Cell(row, 6).Value = "OK";
            ws.Cell(row, 7).Value = "Clean/Adjust";
            ws.Cell(row, 8).Value = "Replace";

            ws.Range(row, 1, row, 8).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.LightGray)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            row++;

            int dataStartRow = row;

            // ===== DATA =====
            foreach (DataRow dr in dt.Rows)
            {
                ws.Cell(row, 1).Value = dr["part_name"]?.ToString().TrimEnd();
                ws.Cell(row, 2).Value = dr["item_name"]?.ToString().TrimEnd();
                ws.Cell(row, 3).Value = dr["standard"]?.ToString().TrimEnd();
                ws.Cell(row, 4).Value = dr["method"]?.ToString().TrimEnd();
                ws.Cell(row, 5).Value = dr["ng_solution"]?.ToString().TrimEnd();
                string result = dr["result"]?.ToString();

                ws.Cell(row, 6).Value = result == "OK" ? "✔" : "";
                ws.Cell(row, 7).Value = result == "Clean/Adjust" ? "✔" : "";
                ws.Cell(row, 8).Value = result == "Replace" ? "✔" : "";

                row++;
            }

            int lastRow = row - 1;

            // ===== MERGE PART =====

            int currentRow = dataStartRow;

            while (currentRow <= lastRow)
            {
                string currentPart = ws.Cell(currentRow, 1).GetString();

                int mergeStart = currentRow;
                int mergeEnd = currentRow;

                while (mergeEnd + 1 <= lastRow &&
                       ws.Cell(mergeEnd + 1, 1).GetString() == currentPart)
                {
                    mergeEnd++;
                }

                if (mergeEnd > mergeStart)
                {
                    ws.Range(mergeStart, 1, mergeEnd, 1).Merge();

                    ws.Range(mergeStart, 1, mergeEnd, 1).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                currentRow = mergeEnd + 1;
            }

            // ===== STYLE =====
            ws.Columns(2, 5).Style.Alignment.WrapText = true;

            ws.Columns(6, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // ===== BORDER =====
            ws.Range(headerRow, 1, lastRow, 8).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(headerRow, 1, lastRow, 8).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== AUTO WIDTH =====
            ws.Columns().AdjustToContents();
            //===Căn giữa=======
            ws.Columns(2, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Columns(2, 8).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            //căn giữa cho hàng
            ws.Columns(2, 8).Style.Alignment.WrapText = true;
            ws.Columns(2, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Columns(2, 8).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            //chỉnh chiều cao của hàng sao cho vừa đủ nội dung
            ws.Columns(2, 8).AdjustToContents();
            ws.Range("D3:E3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
            ws.Range("F3:G3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

            //ws.Rows().AdjustToContents();
            //ws.Columns(2, 4).Style.Alignment.WrapText = true;



            // ===== PAGE SETUP =====
            //ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            //ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            //ws.PageSetup.Margins.Top = 0.5;
            //ws.PageSetup.Margins.Bottom = 0.5;



            // ===== SAVE =====
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 1. Thiết lập các bộ lọc định dạng file
            saveFileDialog.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "Chọn nơi lưu tài liệu của bạn";
            saveFileDialog.DefaultExt = "xlsx";

            // 2. Thiết lập tên file mặc định (nếu muốn)
            saveFileDialog.FileName = $"{txtMachineID.Text}_" + DateTime.Now.ToString("ddMMyyyyHHmmss");

            // 3. Hiển thị cửa sổ diagram thư mục
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đầy đủ mà người dùng đã chọn
                string filePath = saveFileDialog.FileName;
                wb.SaveAs(filePath);



                MessageBox.Show("Export thành công!");

            }


        }
        public void ExportToExcel_depenOn_time(DataTable dt)
        {
            var latestSheets = dt.AsEnumerable()
                .GroupBy(x => new
                {
                    Year = Convert.ToDateTime(x["check_date"]).Year,
                    Month = Convert.ToDateTime(x["check_date"]).Month
                })
                .Select(g =>
                {
                    // lấy sheet mới nhất trong tháng
                    return g
                        .GroupBy(x => x["sheet_id"])
                        .OrderByDescending(x => Convert.ToDateTime(x.First()["check_date"]))
                        .First();
                })
                .SelectMany(g => g)
                .CopyToDataTable();
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Matrix");

            ws.Style.Font.FontName = "Times New Roman";
            ws.Style.Font.FontSize = 11;

            int row = 1;



            row += 2;

            // ===== INFO =====
            string machine = dt.Rows[0]["machine_code"]?.ToString();
            string user = dt.Rows[0]["user_id"]?.ToString();

            ws.Cell(row, 1).Value = $"Machine: {machine}";
            ws.Cell(row++, 5).Value = $"o:OK";
            ws.Cell(row++, 5).Value = $"∆:Vệ sinh,điều chỉnh(清掃、調整)";
            ws.Cell(row++, 5).Value = "x:Thay thế(交換する)";


            row += 2;

            int headerRow = row;

            // ===== HEADER TRÁI =====
            ws.Cell(row, 1).Value = "Bộ phận";
            ws.Cell(row, 2).Value = "Nội dung";
            ws.Cell(row, 3).Value = "Tiêu chuẩn";
            ws.Cell(row, 4).Value = "Phương pháp";
            ws.Cell(row, 5).Value = "Phương pháp NG";

            // ===== LẤY DANH SÁCH SHEET =====
            var sheets = latestSheets.AsEnumerable()
                .GroupBy(x => x["sheet_id"])
                .Select(g => new
                {
                    SheetId = g.Key,
                    Date = Convert.ToDateTime(g.First()["check_date"]),
                    UserId = g.First()["user_id"]?.ToString()
                })
                .OrderBy(x => x.Date)
                .ToList();

            int col = 6;

            // ===== HEADER NGANG =====
            foreach (var s in sheets)
            {
                ws.Cell(row, col).Value = s.Date.ToString("MM/dd/yy") + $"\r\n{s.UserId}";
                ws.Column(col).Width = 8;
                col++;
            }

            ws.Range(row, 1, row, col - 1).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.LightGray)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            row++;

            int dataStartRow = row;

            // ===== LẤY ITEM =====
            var items = latestSheets.AsEnumerable()
                .GroupBy(x => x["item_id"])
                .Select(g => g.First())
                .OrderBy(x => x["display_order"])
                .ToList();

            // ===== DATA =====
            foreach (var item in items)
            {
                ws.Cell(row, 1).Value = item["part_name"]?.ToString().Trim();
                ws.Cell(row, 2).Value = item["item_name"]?.ToString().Trim();
                ws.Cell(row, 3).Value = item["standard"]?.ToString().Trim();
                ws.Cell(row, 4).Value = item["method"]?.ToString().Trim();
                ws.Cell(row, 5).Value = item["ng_solution"]?.ToString().Trim();
                col = 6;

                foreach (var s in sheets)
                {
                    var found = dt.AsEnumerable().FirstOrDefault(x =>
                        x["sheet_id"].Equals(s.SheetId) &&
                        x["item_id"].Equals(item["item_id"])
                    );

                    string result = found?["result"]?.ToString();

                    string symbol = result switch
                    {
                        "OK" => "o",
                        "Clean/Adjust" => "∆",
                        "Replace" => "x",
                        _ => ""
                    };

                    ws.Cell(row, col).Value = symbol;

                    // tô màu
                    if (symbol == "x")
                        ws.Cell(row, col).Style.Font.FontColor = XLColor.Red;

                    col++;
                }

                row++;
            }

            int lastRow = row - 1;
            int lastCol = col - 1;

            // ===== MERGE PART =====
            int currentRow = dataStartRow;

            while (currentRow <= lastRow)
            {
                string part = ws.Cell(currentRow, 1).GetString();

                int start = currentRow;
                int end = currentRow;

                while (end + 1 <= lastRow &&
                       ws.Cell(end + 1, 1).GetString() == part)
                {
                    end++;
                }

                if (end > start)
                {
                    ws.Range(start, 1, end, 1).Merge();

                    ws.Range(start, 1, end, 1).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                currentRow = end + 1;
            }
            // ===== HEADER =====
            ws.Cell(1, 1).Value = "PHIẾU BẢO DƯỠNG";
            ws.Range(1, 1, 1, lastCol).Merge().Style
                .Font.SetBold()
                .Font.SetFontSize(16)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            // ===== STYLE =====
            ws.Columns(2, 4).Style.Alignment.WrapText = true;

            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment
                .SetVertical(XLAlignmentVerticalValues.Center);
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment
                .SetHorizontal(XLAlignmentHorizontalValues.Center);

            //ws.Columns(2, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            // ===== BORDER =====
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== WRAP TEXT (QUAN TRỌNG NHẤT) =====
            ws.Columns().Style.Alignment.WrapText = true;

            // ===== AUTO WIDTH =====
            ws.Columns().AdjustToContents();

            // ===== GIỚI HẠN WIDTH =====
            foreach (var _col in ws.Columns())
            {
                if (_col.Width > 40)
                    _col.Width = 40;
            }

            // ===== AUTO HEIGHT =====
            //ws.Rows().AdjustToContents();

            // ===== PRINT =====
            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.FitToPages(1, 1);
            ws.PageSetup.CenterHorizontally = true;

            // ===== SAVE =====
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 1. Thiết lập các bộ lọc định dạng file
            saveFileDialog.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "Chọn nơi lưu tài liệu của bạn";
            saveFileDialog.DefaultExt = "xlsx";

            // 2. Thiết lập tên file mặc định (nếu muốn)
            saveFileDialog.FileName = $"{txtMachineID.Text}_" + DateTime.Now.ToString("ddMMyyyyHHmmss");

            // 3. Hiển thị cửa sổ diagram thư mục
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đầy đủ mà người dùng đã chọn
                string filePath = saveFileDialog.FileName;
                wb.SaveAs(filePath);
                if (btnKhongkhi.Visible)
                {
                    var airData = _service.GetAir(txtMachineID.Text, dtpFrom.Value, dtpTo.Value);

                    ExportAirQualityMonths(airData, filePath.Replace(".xlsx", "_AirQuality.xlsx"));
                }
                MessageBox.Show("Export thành công!");

            }
        }
        public void ExportToExcel_12Months(DataTable dt)
        {
            if (dt.Rows.Count == 0) return;

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Matrix");

            ws.Style.Font.FontName = "Times New Roman";
            ws.Style.Font.FontSize = 11;

            int row = 1;

            // ===== HEADER =====
            ws.Cell(row, 1).Value = "PHIẾU BẢO DƯỠNG";
            ws.Range(row, 1, row, 17).Merge().Style
                .Font.SetBold()
                .Font.SetFontSize(16)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            row += 2;

            // ===== INFO =====
            string machine = dt.Rows[0]["machine_code"]?.ToString();

            ws.Cell(row, 1).Value = $"Machine: {machine}";
            ws.Range(row, 1, row, 2).Merge();
            ws.Cell(row++, 5).Value = $"o:OK";
            ws.Cell(row++, 5).Value = $"∆:Vệ sinh,điều chỉnh(清掃、調整)";
            ws.Cell(row++, 5).Value = "x:Thay thế(交換する)";
            row += 2;

            int headerRow = row;

            // ===== HEADER TRÁI =====
            ws.Cell(row, 1).Value = "Bộ phận";
            ws.Cell(row, 2).Value = "Nội dung";
            ws.Cell(row, 3).Value = "Tiêu chuẩn";
            ws.Cell(row, 4).Value = "Phương pháp";
            ws.Cell(row, 5).Value = "Phương pháp NG";

            // ===== LẤY sheet mới nhất theo tháng =====
            var monthSheets = dt.AsEnumerable()
                .GroupBy(x => new
                {
                    Year = Convert.ToDateTime(x["check_date"]).Year,
                    Month = Convert.ToDateTime(x["check_date"]).Month
                })
                .ToDictionary(
                    g => g.Key.Month,
                    g => g
                        .GroupBy(x => x["sheet_id"])
                        .OrderByDescending(x => Convert.ToDateTime(x.First()["check_date"]))
                        .First()
                );

            int col = 6;

            // ===== HEADER 12 THÁNG =====
            for (int m = 1; m <= 12; m++)
            {
                if (monthSheets.ContainsKey(m))
                {
                    var sheet = monthSheets[m].First();
                    var date = Convert.ToDateTime(sheet["check_date"]);
                    var user = sheet["user_id"]?.ToString();

                    ws.Cell(row, col).Value = $"{date:MM/dd}\n{user}";
                }
                else
                {
                    ws.Cell(row, col).Value = $"{m:00}";
                }

                ws.Column(col).Width = 8;
                col++;
            }

            ws.Range(row, 1, row, col - 1).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.LightGray)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Alignment.SetWrapText(true);

            ws.Row(row).Height = 30;

            row++;

            int dataStartRow = row;

            // ===== LẤY ITEM =====
            var items = dt.AsEnumerable()
                .GroupBy(x => new
                {
                    Part = x["part_name"],
                    Item = x["item_id"]
                })
                .Select(g => g.First())
                .OrderBy(x => x["display_order"])
                .ToList();

            // ===== DATA =====
            foreach (var item in items)
            {
                ws.Cell(row, 1).Value = item["part_name"]?.ToString().Trim();
                ws.Cell(row, 2).Value = item["item_name"]?.ToString().Trim();
                ws.Cell(row, 3).Value = item["standard"]?.ToString().Trim();
                ws.Cell(row, 4).Value = item["method"]?.ToString().Trim();
                ws.Cell(row, 5).Value = item["ng_solution"]?.ToString().Trim();

                col = 6;

                for (int m = 1; m <= 12; m++)
                {
                    if (monthSheets.ContainsKey(m))
                    {
                        var sheet = monthSheets[m];

                        var found = sheet.FirstOrDefault(x =>
                            x["item_id"].Equals(item["item_id"])
                        );

                        string result = found?["result"]?.ToString();

                        string symbol = result switch
                        {
                            "OK" => "o",
                            "Clean/Adjust" => "∆",
                            "Replace" => "x",
                            _ => ""
                        };

                        ws.Cell(row, col).Value = symbol;

                        if (symbol == "x")
                            ws.Cell(row, col).Style.Font.FontColor = XLColor.Red;
                    }

                    col++;
                }

                row++;
            }

            int lastRow = row - 1;
            int lastCol = col - 1;

            // ===== MERGE PART =====
            int currentRow = dataStartRow;

            while (currentRow <= lastRow)
            {
                string part = ws.Cell(currentRow, 1).GetString();

                int start = currentRow;
                int end = currentRow;

                while (end + 1 <= lastRow &&
                       ws.Cell(end + 1, 1).GetString() == part)
                {
                    end++;
                }

                if (end > start)
                {
                    ws.Range(start, 1, end, 1).Merge();

                    ws.Range(start, 1, end, 1).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                currentRow = end + 1;
            }

            // ===== STYLE =====
            ws.Columns().Style.Alignment.WrapText = true;

            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment
                .SetVertical(XLAlignmentVerticalValues.Center);
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            //ws.Columns(2, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            // ===== BORDER =====
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== AUTO SIZE =====
            ws.Columns().AdjustToContents();

            foreach (var c in ws.Columns())
            {
                if (c.Width > 40) c.Width = 40;
            }

            //ws.Rows().AdjustToContents();

            // ===== PRINT =====
            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.FitToPages(1, 1);

            // ===== SAVE =====
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 1. Thiết lập các bộ lọc định dạng file
            saveFileDialog.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.Title = "Chọn nơi lưu tài liệu của bạn";
            saveFileDialog.DefaultExt = "xlsx";

            // 2. Thiết lập tên file mặc định (nếu muốn)
            saveFileDialog.FileName = $"{txtMachineID.Text}_" + DateTime.Now.ToString("ddMMyyyyHHmmss");

            // 3. Hiển thị cửa sổ diagram thư mục
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đầy đủ mà người dùng đã chọn
                string filePath = saveFileDialog.FileName;
                wb.SaveAs(filePath);
                if (btnKhongkhi.Visible)
                {
                    var airData = _service.GetAir(txtMachineID.Text, dtpFrom.Value, dtpTo.Value);

                    ExportAirQuality12Months(airData, filePath.Replace(".xlsx", "_AirQuality.xlsx"));
                }
                MessageBox.Show("Export thành công!");

            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtHistory.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            if (_dr == DialogResult.Yes)
                ExportToExcel(dtHistory);
            else
            {
                var dr = MessageBox.Show("Hiển thị luôn 12 tháng không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    ExportToExcel_12Months(dtHistory);

                }
                else
                {
                    ExportToExcel_depenOn_time(dtHistory);
                }

            }


        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpFrom.Value.Date;

            // Kiểm tra để tránh vòng lặp vô tận khi gán lại giá trị
            if (dtpFrom.Value != selectedDate)
            {
                dtpFrom.Value = selectedDate;
            }
        }

        private void btnKhongkhi_Click(object sender, EventArgs e)
        {
            FrmKhongKhi frmKhongKhi = new FrmKhongKhi(_service.GetAir(txtMachineID.Text, dtpFrom.Value, dtpTo.Value));
            frmKhongKhi.Show();
        }
        public void ExportAirQuality12Months(DataTable dt, string path)
        {
            DataTable dtKetQua = dt.AsEnumerable().GroupBy(r => new
            {
                Nam = r.Field<DateTime>("created_at").Year,
                Thang = r.Field<DateTime>("created_at").Month
            })
    // 2. Với mỗi nhóm (mỗi tháng), chọn ra dòng có Ngày lớn nhất
    .Select(g => g.OrderByDescending(x => x.Field<DateTime>("created_at")).First())
    // 3. Chuyển kết quả về lại DataTable
    .CopyToDataTable();

            if (dtKetQua.Rows.Count == 0) return;

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("AirQuality");

            ws.Style.Font.FontName = "Times New Roman";
            ws.Style.Font.FontSize = 11;

            int row = 1;

            // ===== HEADER =====
            ws.Cell(row, 1).Value = "AIR QUALITY MEASUREMENT SHEET";
            ws.Range(row, 1, row, 14).Merge().Style
                .Font.SetBold()
                .Font.SetFontSize(16)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            row += 2;

            // ===== INFO =====
            string machine = dtKetQua.Rows[0]["machine_code"]?.ToString();

            ws.Cell(row, 1).Value = $"Machine: {machine}";
            ws.Range(row, 1, row, 2).Merge();


            row += 2;

            int headerRow = row;

            // ===== HEADER =====
            ws.Cell(row, 1).Value = "Chỉ số";

            // ===== GROUP THEO THÁNG =====
            var monthData = dtKetQua.AsEnumerable()
                .GroupBy(x => new
                {
                    Year = Convert.ToDateTime(x["created_at"]).Year,
                    Month = Convert.ToDateTime(x["created_at"]).Month
                })
                .ToDictionary(
                    g => g.Key.Month,
                    g => g.OrderByDescending(x => Convert.ToDateTime(x["created_at"])).First()
                );

            int col = 2;

            // ===== HEADER 12 THÁNG =====
            for (int m = 1; m <= 12; m++)
            {
                ws.Cell(row, col).Value =
                    System.Globalization.CultureInfo.CurrentCulture
                    .DateTimeFormat.GetAbbreviatedMonthName(m);

                ws.Column(col).Width = 10;
                col++;
            }

            ws.Range(row, 1, row, 13).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.LightGray)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            row++;

            // ===== DATA =====
            string[] labels = { "Value 1", "Value 2", "Value 3" };
            string[] cols = { "measure_value1", "measure_value2", "measure_value3" };

            for (int i = 0; i < 3; i++)
            {
                ws.Cell(row, 1).Value = labels[i];

                col = 2;

                for (int m = 1; m <= 12; m++)
                {
                    if (monthData.ContainsKey(m))
                    {
                        var data = monthData[m];

                        ws.Cell(row, col).Value = data[cols[i]]?.ToString();
                    }

                    col++;
                }

                row++;
            }

            int lastRow = row - 1;
            int lastCol = 13;

            // ===== STYLE =====
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment
                .SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            // ===== BORDER =====
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== WIDTH =====
            ws.Column(1).Width = 20;

            // ===== AUTO HEIGHT =====
            ws.Rows().AdjustToContents();

            // ===== PRINT =====
            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.FitToPages(1, 1);

            // ===== SAVE =====

            wb.SaveAs(path);


        }
        public void ExportAirQualityMonths(DataTable dt, string path)
        {
            if (dt.Rows.Count == 0) return;

            // ===== LẤY DÒNG MỚI NHẤT THEO THÁNG =====
            DataTable dtKetQua = dt.AsEnumerable()
                .GroupBy(r => new
                {
                    Nam = r.Field<DateTime>("created_at").Year,
                    Thang = r.Field<DateTime>("created_at").Month
                })
                .Select(g => g.OrderByDescending(x => x.Field<DateTime>("created_at")).First())
                .CopyToDataTable();

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("AirQuality");

            ws.Style.Font.FontName = "Times New Roman";
            ws.Style.Font.FontSize = 11;

            int row = 1;

            // ===== HEADER =====
            ws.Cell(row, 1).Value = "AIR QUALITY MEASUREMENT SHEET";


            row += 2;

            // ===== INFO =====
            string machine = dtKetQua.Rows[0]["machine_code"]?.ToString();

            ws.Cell(row, 1).Value = $"Machine: {machine}";
            ws.Range(row, 1, row, 3).Merge();

            row += 2;

            int headerRow = row;

            // ===== HEADER TRÁI =====
            ws.Cell(row, 1).Value = "Chỉ số";

            // ===== GROUP THEO THÁNG =====
            var monthData = dtKetQua.AsEnumerable()
                .GroupBy(x => new
                {
                    Year = x.Field<DateTime>("created_at").Year,
                    Month = x.Field<DateTime>("created_at").Month
                })
                .Select(g => g.OrderByDescending(x => x.Field<DateTime>("created_at")).First())
                .OrderBy(x => x.Field<DateTime>("created_at"))
                .ToList();

            int col = 2;

            // ===== HEADER THEO THÁNG CÓ DATA =====
            foreach (var m in monthData)
            {
                var date = m.Field<DateTime>("created_at");

                ws.Cell(row, col).Value = date.ToString("MM/yyyy"); // hoặc "MMM"
                ws.Column(col).Width = 12;

                col++;
            }

            ws.Range(row, 1, row, col - 1).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.LightGray)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            row++;
            ws.Range(1, 1, 1, col).Merge().Style
                .Font.SetBold()
                .Font.SetFontSize(16)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            // ===== DATA =====
            string[] labels = { "Value 1", "Value 2", "Value 3" };
            string[] cols = { "measure_value1", "measure_value2", "measure_value3" };

            for (int i = 0; i < 3; i++)
            {
                ws.Cell(row, 1).Value = labels[i];

                col = 2;

                foreach (var m in monthData)
                {
                    ws.Cell(row, col).Value = m[cols[i]]?.ToString();
                    col++;
                }

                row++;
            }

            int lastRow = row - 1;
            int lastCol = col - 1;

            // ===== STYLE =====
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment
                .SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            // ===== BORDER =====
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(headerRow, 1, lastRow, lastCol).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== WIDTH =====
            ws.Column(1).Width = 20;

            // ===== AUTO HEIGHT =====
            ws.Rows().AdjustToContents();

            // ===== PRINT =====
            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            ws.PageSetup.FitToPages(1, 1);
            ws.PageSetup.CenterHorizontally = true;

            // ===== SAVE =====
            wb.SaveAs(path);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _pages.Count - 1)
            {
                _currentPage++;
                LoadPage(_currentPage);
            }
            lblPage.Text = $"Page {_currentPage + 1} / {_pages.Count}";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                LoadPage(_currentPage);
            }
            lblPage.Text = $"Page {_currentPage + 1} / {_pages.Count}";
        }
    }
}
