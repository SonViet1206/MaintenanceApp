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
        void AddMachine(string machine_code, int machine_type_id);
        List<MachineType> GetMachineTypes();
        List<MachinePart> GetParts(int machineTypeId);
        DataTable GetItems(int machineTypeId, int? partId);
        void UpdateMachineType(int id, string name);
        void DeleteMachineType(int id);
        DataTable GetPartsForType(int machineTypeId);
        void UpdateMachinePart(int machinePartId, string name, int display_order); 
        void DeleteMachinePart(int machinePartId);
        void UpdateMaintenanceItem(int id, string itemName, string standard, string method, string ng_solution, int display_order, int partId, int machine_type_id);
        void DeleteMaintenanceItem(int id);
        DataTable GetAllMachine();
        void UpdateMachine(int idMachine, string machineName, int machine_type_id);
        void DeleteMachine(int idMachine);
        DataTable SearchHistory(
            string machineCode,
            string userId,
            string result,
            DateTime? fromDate,
            DateTime? toDate);
        int CreateSheet(string machineCode, string userId);





    }
}
