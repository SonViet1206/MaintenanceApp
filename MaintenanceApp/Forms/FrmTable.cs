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
    public partial class FrmTable : Form
    {
        public FrmTable(DataTable dt)
        {
            InitializeComponent();
            dgvList.DataSource = dt;
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {

        }
    }
}
