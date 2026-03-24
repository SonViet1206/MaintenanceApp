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
    public partial class FrmKhongKhi : Form
    {
        public FrmKhongKhi(DataTable data)
        {
            InitializeComponent();
            this.dgv.DataSource = data;
        }

        private void FrmKhongKhi_Load(object sender, EventArgs e)
        {

        }
    }
}
