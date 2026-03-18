using MaintenanceApp.Domain;
using MaintenanceApp.Services;
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
    public partial class FrmExecute : Form
    {
        private MaintenanceService _service;
        public FrmExecute(MaintenanceService service)
        {
            InitializeComponent();
            _service = service;
        }
        void btnRun_Click(object sender, EventArgs e)
        {
            if (txtMachineID.Text == "" || txtUserID.Text == "")
            {
                MessageBox.Show("Chưa nhập mã máy hoặc mã người bảo dưỡng");
                return;
            }
            dgvChecklist.Rows.Clear();

            var items = _service.LoadChecklist(txtMachineID.Text);

            foreach (var item in items)
            {
                dgvChecklist.Rows.Add(
                    item.Id,
                    item.PartName,
                    item.ItemName,
                    item.Standard,
                    item.Method,
                    item.NgSolution,
                    false,
                    false,
                    false
                );
            }

        }
        void dgvChecklist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var columnName = dgvChecklist.Columns[e.ColumnIndex].Name;

            if (columnName == "OK" || columnName == "Clean" || columnName == "Replace")
            {
                foreach (DataGridViewCell cell in dgvChecklist.Rows[e.RowIndex].Cells)
                {
                    if (cell.OwningColumn.Name == "OK" ||
                        cell.OwningColumn.Name == "Clean" ||
                        cell.OwningColumn.Name == "Replace")
                    {
                        cell.Value = false;
                    }
                }

                dgvChecklist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvChecklist.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu");
                return;
            }
            var histories = new List<MaintenanceHistory>();

            foreach (DataGridViewRow row in dgvChecklist.Rows)
            {
                string result = "";

                if (Convert.ToBoolean(row.Cells["OK"].Value))
                    result = "OK";

                if (Convert.ToBoolean(row.Cells["Clean"].Value))
                    result = "Clean/Adjust";

                if (Convert.ToBoolean(row.Cells["Replace"].Value))
                    result = "Replace";

                var itemId = Convert.ToInt32(row.Cells["ItemId"].Value);

                histories.Add(new MaintenanceHistory
                {
                    MachineCode = txtMachineID.Text,
                    UserId = txtUserID.Text,
                    ItemId = itemId,
                    Result = result
                    //MaintenanceDate = DateTime.Now
                });
            }

            _service.SaveChecklist(histories);

            MessageBox.Show("Saved successfully");
        }

        private void FrmExecute_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyBuffer += e.KeyChar.ToString().ToUpper();

            if (keyBuffer.Contains("ENG"))
            {
                btnAllOK.Visible = true;
                keyBuffer = ""; // reset
            }

            // tránh dài quá
            if (keyBuffer.Length > 10)
                keyBuffer = keyBuffer.Substring(keyBuffer.Length - 3);
        }
        string keyBuffer = "";
        private void FrmExecute_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnAllOK_Click(object sender, EventArgs e)
        {
            btnAllOK.Visible = false;
            foreach (DataGridViewRow row in dgvChecklist.Rows)
            {
                row.Cells["OK"].Value = true;
                row.Cells["Clean"].Value = false;
                row.Cells["Replace"].Value = false;
            }
        }
    }
}
