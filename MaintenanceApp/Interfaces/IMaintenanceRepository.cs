using MaintenanceApp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceApp.Interfaces
{
    public interface IMaintenanceRepository
    {
        List<MaintenanceItem> GetItemsByMachine(string machineCode);

        void SaveHistory(List<MaintenanceHistory> history);
        void AddMachineType(string name);
        void AddMachinePart(int typeId, string partName, int order);
        void AddMaintenanceItem(int machine_type_id, int part_id, string item_name, string standard, string method, string ng_solution, int display_order);
        void AddMachine(int machine_code, int machine_type_id);
        List<MachineType> GetMachineTypes();
        List<MachinePart> GetParts(int machineTypeId);
        DataTable GetItems(int machineTypeId, int? partId);
        void UpdateMachineType(int id, string name);
        void DeleteMachineType(int id);

    }
}
