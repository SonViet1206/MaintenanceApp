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
            dgvChecklist.Rows.Clear();

            var items = _service.LoadChecklist(txtMachineID.Text);

            foreach (var item in items)
            {
                dgvChecklist.Rows.Add(
                    item.PartName,
                    item.ItemName,
                    item.Standard,
                    item.Method,
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
            var histories = new List<MaintenanceHistory>();

            foreach (DataGridViewRow row in dgvChecklist.Rows)
            {
                string result = "";

                if (Convert.ToBoolean(row.Cells["OK"].Value))
                    result = "OK";

                if (Convert.ToBoolean(row.Cells["Clean"].Value))
                    result = "Clean";

                if (Convert.ToBoolean(row.Cells["Replace"].Value))
                    result = "Replace";

                var itemId = Convert.ToInt32(row.Cells["ItemId"].Value);

                histories.Add(new MaintenanceHistory
                {
                    MachineCode = txtMachineID.Text,
                    UserId = txtUserID.Text,
                    ItemId = itemId,
                    Result = result,
                    MaintenanceDate = DateTime.Now
                });
            }

            _service.SaveChecklist(histories);

            MessageBox.Show("Saved successfully");
        }
    }
}
