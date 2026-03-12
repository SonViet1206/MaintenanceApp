using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceApp.Domain
{
    public class MaintenanceHistory
    {
        public int Id { get; set; }

        public string MachineCode { get; set; }

        public string UserId { get; set; }
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string Result { get; set; }

        public DateTime MaintenanceDate { get; set; }
    }
}
