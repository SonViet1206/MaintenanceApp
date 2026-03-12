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
    }
}
