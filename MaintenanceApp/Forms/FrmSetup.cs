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
        }
        private void LoadMachineTypes()
        {
            dgvMachineType.DataSource = _service.GetMachineTypes();
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
        }

        private void cbb_tab3_MachineType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int typeId = (int)cbb_tab3_MachineType.SelectedValue;
            cbb_tab3_Part.DisplayMember = "PartName";
            cbb_tab3_Part.ValueMember = "Id";
            cbb_tab3_Part.DataSource = _service.GetParts(typeId);

        }

        private void btn_tab3_AddIteamMaintenance_Click(object sender, EventArgs e)
        {

        }

        private void btn_tab4_AddMachine_Click(object sender, EventArgs e)
        {

        }

        private void btn_tab3_Detail_Click(object sender, EventArgs e)
        {
            FrmTable table = new FrmTable(_service.GetItems((int)cbb_tab3_MachineType.SelectedValue, Convert.ToInt32(cbb_tab3_Part.SelectedValue)));
            table.ShowDialog();

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
            FrmSetup_Shown(null, null);
        }
    }
}
