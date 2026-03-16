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
        }
        void LoadMachinePartsForType()
        {
            int typeId = (int)cbb_tab2_MachineType.SelectedValue;
            dgvListPart.DataSource = _service.GetPartsForType(typeId);

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
        }

        private void cbb_tab3_MachineType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int typeId = (int)cbb_tab3_MachineType.SelectedValue;
            cbb_tab3_Part.DisplayMember = "PartName";
            cbb_tab3_Part.ValueMember = "Id";
            cbb_tab3_Part.DataSource = _service.GetParts(typeId);

        }
        void LoadPartsForItem()
        {

        }

        private void btn_tab3_AddIteamMaintenance_Click(object sender, EventArgs e)
        {
            _service.AddMaintenanceItem((int)cbb_tab3_MachineType.SelectedValue, (int)cbb_tab3_Part.SelectedValue, txt_tab3_IteamName.Text, txt_tab3_standard.Text, txt_tab3_method.Text, txt_tab3_Ng_solution.Text, (int)txt_tab3_DisplayOrder.Value);
        }

        private void btn_tab4_AddMachine_Click(object sender, EventArgs e)
        {

        }

        private void btn_tab3_Detail_Click(object sender, EventArgs e)
        {
            pnTab3.Visible = false;
            dgv_tab3.DataSource = _service.GetItems((int)cbb_tab3_MachineType.SelectedValue, Convert.ToInt32(cbb_tab3_Part.SelectedValue));


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

        private void btn_tab3_FullDisplay_Click(object sender, EventArgs e)
        {

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
            _service.UpdateMaintenanceItem((int)dgv_tab3.SelectedRows[0].Cells["id"].Value, txt_tab3_IteamName.Text, txt_tab3_standard.Text, txt_tab3_method.Text, txt_tab3_Ng_solution.Text, (int)txt_tab3_DisplayOrder.Value);
            MessageBox.Show("Cập nhật thành công");
            dgv_tab3.SelectedRows[0].Selected = false;
        }

        private void dgv_tab3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                DataGridViewRow row = dgv_tab3.Rows[e.RowIndex];
                txt_tab3_IteamName.Text = row.Cells["item_name"].Value.ToString();
                txt_tab3_standard.Text = row.Cells["standard"].Value.ToString();
                txt_tab3_method.Text = row.Cells["method"].Value.ToString();
                txt_tab3_Ng_solution.Text = row.Cells["ng_solution"].Value.ToString();
                txt_tab3_DisplayOrder.Value = Convert.ToInt32(row.Cells["display_order"].Value);
            }    
        }
    }
}
