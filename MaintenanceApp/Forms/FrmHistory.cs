using ClosedXML.Excel;
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
        private DataTable dtHistory=new DataTable();

        public FrmHistory(Services.MaintenanceService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string machine = string.IsNullOrWhiteSpace(txtMachineID.Text)
        ? null : txtMachineID.Text;

            string user = string.IsNullOrWhiteSpace(txtUserID.Text)
                ? null : txtUserID.Text;

            string result = string.IsNullOrWhiteSpace(cbbResult.Text)
                ? null : cbbResult.Text;

            DateTime? from = dtpFrom.Checked ? dtpFrom.Value : null;
            DateTime? to = dtpTo.Checked ? dtpTo.Value : null;



             dtHistory.Rows.Clear();
             dtHistory = _service.SearchHistory(machine, user, result, from, to);

            // Xóa dữ liệu cũ
            dgvHistory.Rows.Clear();
            if (dtHistory.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào");
                return;
            }

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


        public void ExportToExcel(DataTable dt)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Maintenance");

            ws.Style.Font.FontName = "Times New Roman";
            ws.Style.Font.FontSize = 11;

            int row = 1;

            // ===== HEADER =====
            ws.Cell(row, 1).Value = "MAINTENANCE CHECK SHEET";
            ws.Range(row, 1, row, 7).Merge().Style
                .Font.SetBold()
                .Font.SetFontSize(16)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            row += 2;

            // ===== INFO =====
            ws.Cell(row, 1).Value = "Machine:";
            ws.Cell(row, 2).Value = dt.Rows[0]["machine_code"]?.ToString();

            ws.Cell(row, 4).Value = "User:";
            ws.Cell(row, 5).Value = dt.Rows[0]["user_id"]?.ToString();

            ws.Cell(row, 6).Value = "Date:";
            ws.Cell(row, 7).Value = Convert.ToDateTime(dt.Rows[0]["check_date"])
                                        .ToString("yyyy-MM-dd");

            row += 2;

            // ===== TABLE HEADER =====
            int headerRow = row;

            ws.Cell(row, 1).Value = "Bộ phận";
            ws.Cell(row, 2).Value = "Nội dung";
            ws.Cell(row, 3).Value = "Tiêu chuẩn";
            ws.Cell(row, 4).Value = "Phương pháp";
            ws.Cell(row, 5).Value = "OK";
            ws.Cell(row, 6).Value = "Clean/Adjust";
            ws.Cell(row, 7).Value = "Replace";

            ws.Range(row, 1, row, 7).Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.LightGray)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            row++;

            int dataStartRow = row;

            // ===== DATA =====
            foreach (DataRow dr in dt.Rows)
            {
                ws.Cell(row, 1).Value = dr["part_name"]?.ToString();
                ws.Cell(row, 2).Value = dr["item_name"]?.ToString();
                ws.Cell(row, 3).Value = dr["standard"]?.ToString();
                ws.Cell(row, 4).Value = dr["method"]?.ToString();

                string result = dr["result"]?.ToString();

                ws.Cell(row, 5).Value = result == "OK" ? "✔" : "";
                ws.Cell(row, 6).Value = result == "Clean/Adjust" ? "✔" : "";
                ws.Cell(row, 7).Value = result == "Replace" ? "✔" : "";

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
            ws.Columns(2, 4).Style.Alignment.WrapText = true;

            ws.Columns(5, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // ===== BORDER =====
            ws.Range(headerRow, 1, lastRow, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Range(headerRow, 1, lastRow, 7).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // ===== AUTO WIDTH =====
            ws.Columns().AdjustToContents();
            //===Căn giữa=======
            ws.Columns(5, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Columns(5, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Rows().AdjustToContents();



            // ===== PAGE SETUP =====
            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
            ws.PageSetup.PageOrientation = XLPageOrientation.Portrait;
            ws.PageSetup.Margins.Top = 0.5;
            ws.PageSetup.Margins.Bottom = 0.5;
           

            // ===== SAVE =====
            string path = $"Maintenance_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
            wb.SaveAs(path);

            MessageBox.Show("Export thành công!");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(dtHistory.Rows.Count==0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }    
            ExportToExcel(dtHistory);
        }
    }
}
