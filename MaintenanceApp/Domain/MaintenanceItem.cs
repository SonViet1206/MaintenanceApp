using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceApp.Domain
{
    public class MaintenanceItem
    {
        public int Id { get; set; }

        public int MachineTypeId { get; set; }

        public int PartId { get; set; }
        public string PartName { get; set; }

        public string ItemName { get; set; }

        public string Standard { get; set; }

        public string Method { get; set; }

        public string NgSolution { get; set; }

        public int DisplayOrder { get; set; }
    }
}

