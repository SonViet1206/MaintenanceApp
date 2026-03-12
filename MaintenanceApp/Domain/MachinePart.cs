using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceApp.Domain
{
    public class MachinePart
    {
        public int Id { get; set; }

        public int MachineTypeId { get; set; }

        public string PartName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
