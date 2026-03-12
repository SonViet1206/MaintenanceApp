using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceApp.Domain
{
    public class Machine
    {
        public int Id { get; set; }

        public string MachineCode { get; set; }

        public int MachineTypeId { get; set; }
    }
}
