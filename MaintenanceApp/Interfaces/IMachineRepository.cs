using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceApp.Domain;

namespace MaintenanceApp.Interfaces
{
    public interface IMachineRepository
    {
        Machine GetMachine(string machineCode);

        List<MaintenanceItem> GetMaintenanceItems(string machineCode);
    }
}
