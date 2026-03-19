using MaintenanceApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintenanceApp.Forms
{
    public partial class FrmSetup : Form
    {
        MaintenanceService _service;
        int selectedTypeId = 0;
        public FrmSetup(MaintenanceService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnAddMachineType_Click(object sender, EventArgs e)
        {
            _service.AddMachineType(txt_tab1_MachineType.Text);

            MessageBox.Show("Added successfully");
            FrmSetup_Shown(null, null);
        }

        private void btnAddMachinePart_Click(object sender, EventArgs e)
        {
            _service.AddMachinePart((int)cbb_tab2_MachineType.SelectedValue, txt_tab2_MachinePart.Text, (int)txt_tab2_DisplayOrder.Value);

            MessageBox.Show("Added successfully");
            LoadMachinePartsForType();
            cbb_tab3_MachineType_SelectedIndexChanged(null, null);
        }
        private void LoadMachineTypes()
        {
            dgvMachineType.DataSource = _service.GetMachineTypes();
            dgvMachineType.Columns["id"].Visible = false;
            dgvMachineType.Columns["MachineTypeName"].HeaderText = "Kiểu máy";

        }
        void LoadMachinePartsForType()
        {
            int typeId = (int)cbb_tab2_MachineType.SelectedValue;
            dgvListPart.DataSource = _service.GetPartsForType(typeId);
            dgvListPart.Columns["id"].Visible = false;
            dgvListPart.Columns["machine_type_name"].HeaderText = "Kiểu máy";
            dgvListPart.Columns["display_order"].HeaderText = "Thứ tự hiển thị";
            dgvListPart.Columns["part_name"].HeaderText = "Bộ phận";

        }
        private void LoadMachineTypeCombo()
        {
            var list = _service.GetMachineTypes();

            cbb_tab2_MachineType.DataSource = list;
            cbb_tab2_MachineType.DisplayMember = "MachineTypeName";
            cbb_tab2_MachineType.ValueMember = "Id";

            cbb_tab3_MachineType.DataSource = list;
            cbb_tab3_MachineType.DisplayMember = "MachineTypeName";
            cbb_tab3_MachineType.ValueMember = "Id";

            cbb_tab4_MachineType.DataSource = list;
            cbb_tab4_MachineType.DisplayMember = "MachineTypeName";
            cbb_tab4_MachineType.ValueMember = "Id";
        }

        private void FrmSetup_Shown(object sender, EventArgs e)
        {
            LoadMachineTypes();
            LoadMachineTypeCombo();
            LoadMachinePartsForType();
            LoadTab4();
        }

        private void LoadTab4()
        {
            cbb_tab4_MachineCode.DataSource = _service.GetAllMachine();
            
            cbb_tab4_MachineCode.DisplayMember = "machine_code";
            cbb_tab4_MachineCode.ValueMember = "id";

            cbb_tab4_MachineType_SelectedIndexChanged(null, null);
            cbb_tab4_MachineCode.SelectedItem = null;
            cbb_tab4_MachineCode.Text = "";
        }

        private void btnLoad_click(object sender, EventArgs e)
        {

            int typeId = (int)cbb_tab3_MachineType.SelectedValue;
            cbb_tab3_Part.DisplayMember = "PartName";
            cbb_tab3_Part.ValueMember = "Id";
            cbb_tab3_Part.DataSource = _service.GetParts(typeId);
            dgv_tab3.DataSource = _service.GetItems((int)cbb_tab3_MachineType.SelectedValue, null);
            dgv_tab3.Columns["id"].Visible = false;
            dgv_tab3.Columns["machine_type_id"].Visible = false;
            dgv_tab3.Columns["part_display_order"].Visible = false;
            dgv_tab3.Columns["machine_type_name"].HeaderText = "Kiểu máy";
            dgv_tab3.Columns["part_name"].HeaderText = "Bộ phận";
            dgv_tab3.Columns["display_order"].HeaderText = "Thứ tự hiển thị";
            dgv_tab3.Columns["item_name"].HeaderText = "Mục kiểm tra";
            dgv_tab3.Columns["standard"].HeaderText = "Tiêu chuẩn kiểm tra";
            dgv_tab3.Columns["method"].HeaderText = "Phương pháp kiểm tra";
            dgv_tab3.Columns["ng_solution"].HeaderText = "Phương pháp xử lý NG";
            if (dgv_tab3.SelectedRows.Count > 0)
                dgv_tab3.SelectedRows[0].Selected = false;
            txt_tab3_IteamName.Text = txt_tab3_standard.Text = txt_tab3_method.Text = txt_tab3_Ng_solution.Text = "";
        }
        private void cbb_tab3_MachineType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int typeId = (int)cbb_tab3_MachineType.SelectedValue;
            cbb_tab3_Part.DisplayMember = "PartName";
            cbb_tab3_Part.ValueMember = "Id";
            cbb_tab3_Part.DataSource = _service.GetParts(typeId);
            dgv_tab3.DataSource = _service.GetItems((int)cbb_tab3_MachineType.SelectedValue, null);
            dgv_tab3.Columns["id"].Visible = false;
            dgv_tab3.Columns["part_display_order"].Visible = false;
            dgv_tab3.Columns["machine_type_name"].HeaderText = "Kiểu máy";
            dgv_tab3.Columns["part_name"].HeaderText = "Bộ phận";
            dgv_tab3.Columns["display_order"].HeaderText = "Thứ tự hiển thị";
            dgv_tab3.Columns["item_name"].HeaderText = "Mục kiểm tra";
            dgv_tab3.Columns["standard"].HeaderText = "Tiêu chuẩn kiểm tra";
            dgv_tab3.Columns["method"].HeaderText = "Phương pháp kiểm tra";
            dgv_tab3.Columns["ng_solution"].HeaderText = "Phương pháp xử lý NG";
            if (dgv_tab3.SelectedRows.Count > 0)
                dgv_tab3.SelectedRows[0].Selected = false;
            txt_tab3_IteamName.Text=txt_tab3_standard.Text=txt_tab3_method.Text=txt_tab3_Ng_solution.Text="";
        }
        void LoadPartsForItem()
        {

        }

        private void btn_tab3_AddIteamMaintenance_Click(object sender, EventArgs e)
        {
            _service.AddMaintenanceItem((int)cbb_tab3_MachineType.SelectedValue, (int)cbb_tab3_Part.SelectedValue, txt_tab3_IteamName.Text, txt_tab3_standard.Text, txt_tab3_method.Text, txt_tab3_Ng_solution.Text, (int)txt_tab3_DisplayOrder.Value);
            MessageBox.Show("Thêm thành công");
            cbb_tab3_MachineType_SelectedIndexChanged(null,null);


        }

        private void btn_tab4_AddMachine_Click(object sender, EventArgs e)
        {
            _service.AddMachine(txt_tab4_MachineID.Text, (int)cbb_tab4_MachineType.SelectedValue);
            MessageBox.Show("Added successfully");
            LoadTab4();
            


        }
        void LoadAllMachinesDependOnCode()
        {
            

            DataTable dt = _service.GetAllMachine();

            dt.DefaultView.RowFilter =
                $"machine_code LIKE '%{cbb_tab4_MachineCode.Text}%'";

            dgv_tab4.DataSource = dt;

            dgv_tab4.Columns["machine_type_id"].Visible = false;
            dgv_tab4.Columns["id"].Visible = false;
            dgv_tab4.Columns["machine_type_name"].HeaderText = "Kiểu máy";
            dgv_tab4.Columns["machine_code"].HeaderText = "Kiểu máy";
            if (dgv_tab4.SelectedRows.Count > 0)
                dgv_tab4.SelectedRows[0].Selected = false;

        }
        private void btn_tab3_Detail_Click(object sender, EventArgs e)
        {
            pnTab3.Width = pnTab3Width;
            //dgv_tab3.DataSource = _service.GetItems((int)cbb_tab3_MachineType.SelectedValue, Convert.ToInt32(cbb_tab3_Part.SelectedValue));


        }

        private void dgvMachineType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ép kiểu dòng hiện tại
                DataGridViewRow row = dgvMachineType.Rows[e.RowIndex];

                // Ví dụ: Lấy giá trị cột đầu tiên
                selectedTypeId = Convert.ToInt32(row.Cells[0].Value);
                txt_tab1_MachineType.Text = row.Cells[1].Value.ToString();

            }
        }

        private void btn_tab1_Fix_Click(object sender, EventArgs e)
        {
            _service.UpdateMachineType(selectedTypeId, txt_tab1_MachineType.Text);
            MessageBox.Show("Cập nhật thành công");
            FrmSetup_Shown(null, null);
        }

        private void btn_tab1_Delete_Click(object sender, EventArgs e)
        {
            _service.DeleteMachineType(selectedTypeId);
            FrmSetup_Shown(null, null);

        }

        private void btn_tab2_Fix_Click(object sender, EventArgs e)
        {
            if (dgvListPart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bộ phận cần sửa");
                return;
            }
            _service.UpdateMachinePart((int)dgvListPart.SelectedRows[0].Cells["id"].Value, txt_tab2_MachinePart.Text, (int)txt_tab2_DisplayOrder.Value);
            MessageBox.Show("Cập nhật thành công");
            LoadMachinePartsForType();
            cbb_tab3_MachineType_SelectedIndexChanged(null, null);
            dgvListPart.SelectedRows[0].Selected = false;

        }

        private void btn_tab2_Del_Click(object sender, EventArgs e)
        {
            _service.DeleteMachinePart((int)dgvListPart.SelectedRows[0].Cells["id"].Value);
            MessageBox.Show("Xoá thành công");
            LoadMachinePartsForType();
            cbb_tab3_MachineType_SelectedIndexChanged(null, null);
        }

        private void dgvListPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvListPart.Rows[e.RowIndex];
                txt_tab2_MachinePart.Text = row.Cells["part_name"].Value.ToString();
                txt_tab2_DisplayOrder.Value = Convert.ToInt32(row.Cells["display_order"].Value);
            }
        }

        private void cbb_tab2_MachineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_tab2_MachineType.SelectedValue != null)
                LoadMachinePartsForType();
        }

        private void dgv_tab3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Compare KeyChar to the Escape character and handle the event.
            if (e.KeyChar == (char)Keys.Escape)
            {
                pnTab3.Visible = true;
                e.Handled = true;
            }
        }

        int pnTab3Width = 0;
        private void btn_tab3_MiniDisplay_Click(object sender, EventArgs e)
        {
            pnTab3Width = pnTab3.Width;
            pnTab3.Width = btn_tab3_FullDisplay.Width + 5;
            dgv_tab3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmSetup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (tabControl1.SelectedIndex == 2) // Tab thứ 3
                {



                    pnTab3.Visible = true;

                }
            }
        }

        private void btn_tab3_Fix_Click(object sender, EventArgs e)
        {
            if (dgv_tab3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần sửa");
                return;
            }
            _service.UpdateMaintenanceItem((int)dgv_tab3.SelectedRows[0].Cells["id"].Value, txt_tab3_IteamName.Text, txt_tab3_standard.Text, txt_tab3_method.Text, txt_tab3_Ng_solution.Text, (int)txt_tab3_DisplayOrder.Value,(int)cbb_tab3_Part.SelectedValue,(int)cbb_tab3_MachineType.SelectedValue);
            MessageBox.Show("Cập nhật thành công");
            dgv_tab3.SelectedRows[0].Selected = false;
            dgv_tab3.DataSource = _service.GetItems((int)cbb_tab3_MachineType.SelectedValue, Convert.ToInt32(cbb_tab3_Part.SelectedValue));
        }

        private void dgv_tab3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgv_tab3.Rows[e.RowIndex];
                cbb_tab3_Part.SelectedIndex =Convert.ToInt32( row.Cells["part_display_order"].Value)-1;
                cbb_tab3_MachineType.SelectedValue = Convert.ToInt32(row.Cells["machine_type_id"].Value);
                txt_tab3_IteamName.Text = row.Cells["item_name"].Value.ToString();
                txt_tab3_standard.Text = row.Cells["standard"].Value.ToString();
                txt_tab3_method.Text = row.Cells["method"].Value.ToString();
                txt_tab3_Ng_solution.Text = row.Cells["ng_solution"].Value.ToString();
                txt_tab3_DisplayOrder.Value = Convert.ToInt32(row.Cells["display_order"].Value);

            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần sửa");

            }
        }

        private void btn_tab3_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_tab3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xoá");
                return;
            }
            // Xác nhận xoá
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xoá bản ghi này?", "Xác nhận xoá", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                _service.DeleteMaintenanceItem((int)dgv_tab3.SelectedRows[0].Cells["id"].Value);
                MessageBox.Show("Xoá thành công");
                dgv_tab3.SelectedRows[0].Selected = false;
                dgv_tab3.DataSource = _service.GetItems((int)cbb_tab3_MachineType.SelectedValue, Convert.ToInt32(cbb_tab3_Part.SelectedValue));
            }

        }

        private void cbb_tab3_Part_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgv_tab3.DataSource = _service.GetItems((int)cbb_tab3_MachineType.SelectedValue, Convert.ToInt32(cbb_tab3_Part.SelectedValue));
            //dgv_tab3.Columns["id"].Visible = false;
            //if (dgv_tab3.SelectedRows.Count > 0)
            //    dgv_tab3.SelectedRows[0].Selected = false;
            //txt_tab3_IteamName.Text = txt_tab3_standard.Text = txt_tab3_method.Text = txt_tab3_Ng_solution.Text = "";
        }

        private void dgv_tab4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgv_tab4.Rows[e.RowIndex];
                txt_tab4_MachineID.Text = row.Cells["machine_code"].Value.ToString();
                cbb_tab4_MachineType.SelectedValue = Convert.ToInt32(row.Cells["machine_type_id"].Value);
            }
        }

        private void btn_tab4_fix_Click(object sender, EventArgs e)
        {
            if (dgv_tab4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn máy cần sửa");
                return;
            }
            _service.UpdateMachine(Convert.ToInt32(dgv_tab4.SelectedRows[0].Cells["id"].Value), txt_tab4_MachineID.Text, (int)cbb_tab4_MachineType.SelectedValue);
            MessageBox.Show("Cập nhật thành công");
            LoadTab4();

        }

        private void btn_tab4_del_Click(object sender, EventArgs e)
        {
            if (dgv_tab4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn máy cần xoá");
                return;
            }
            // Xác nhận xoá
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xoá máy này?", "Xác nhận xoá", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                _service.DeleteMachine((int)dgv_tab4.SelectedRows[0].Cells["id"].Value);
                MessageBox.Show("Xoá thành công");
                LoadTab4();
            }
        }

        private void dgvMachineType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }

        private void dgvListPart_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }

        private void dgv_tab3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }

        private void dgv_tab4_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }

        private void cbb_tab4_MachineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = _service.GetAllMachine();
            if (dt == null)
            {
                dgv_tab4.DataSource = null;
                return;
            }

            object sel = cbb_tab4_MachineType.SelectedValue;
            if (sel == null || sel == DBNull.Value)
            {
                // No selection -> show all machines
                dgv_tab4.DataSource = dt;
                return;
            }

            int selectedTypeId;
            try
            {
                selectedTypeId = Convert.ToInt32(sel);
            }
            catch
            {
                // If SelectedValue cannot be converted to int, fallback to full table
                dgv_tab4.DataSource = dt;
                return;
            }

            // Use AsEnumerable to perform LINQ over DataTable rows (resolves CS0411).
            var matchedRows = dt.AsEnumerable()
                                .Where(r => !r.IsNull("machine_type_id") && r.Field<int>("machine_type_id") == selectedTypeId);

            DataTable filtered = dt.Clone(); // same schema, no rows
            foreach (var row in matchedRows)
                filtered.ImportRow(row);

            dgv_tab4.DataSource = filtered;
            dgv_tab4.Columns["machine_type_id"].Visible = false;
            dgv_tab4.Columns["id"].Visible = false;
            dgv_tab4.Columns["machine_type_name"].HeaderText = "Kiểu máy";
            dgv_tab4.Columns["machine_code"].HeaderText = "Kiểu máy";

        }

        private void btn_tab4_Find_Click(object sender, EventArgs e)
        {
            LoadAllMachinesDependOnCode();
        }
    }
}
