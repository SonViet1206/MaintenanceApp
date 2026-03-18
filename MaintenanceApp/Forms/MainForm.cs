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

    public partial class MainForm : Form
    {
        MaintenanceService _service;
        public MainForm(MaintenanceService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            FrmExecute frmExecute = new FrmExecute(_service);
            frmExecute.Show();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            FrmSetup frmSetup = new FrmSetup(_service);
            frmSetup.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            FrmHistory frmHistory = new FrmHistory(_service);
            frmHistory.Show();
        }
    }
}
