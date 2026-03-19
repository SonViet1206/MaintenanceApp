using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceApp.Interfaces;
using MaintenanceApp.Domain;
using System.Data;
namespace MaintenanceApp.Services
{
    public class MaintenanceService
    {
        private readonly IMaintenanceRepository _repo;

        public MaintenanceService(IMaintenanceRepository repo)
        {
            _repo = repo;
        }

        public List<MaintenanceItem> LoadChecklist(string machineCode)
        {
            return _repo.GetItemsByMachine(machineCode);
        }
        public void SaveChecklist(List<MaintenanceHistory> histories)
        {
            _repo.SaveHistory(histories);
        }
        public void AddMachineType(string name)
        {
            _repo.AddMachineType(name);
        }
        public void AddMachinePart(int typeId, string partName, int order)
        {
            _repo.AddMachinePart(typeId, partName, order);
        }
        public void AddMaintenanceItem(int MachineTypeID, int partId, string itemName, string standard, string method, string ng_solution, int order)
        {
            _repo.AddMaintenanceItem(MachineTypeID, partId, itemName, standard, method, ng_solution, order);
        }
        public List<MachineType> GetMachineTypes()
        {
            return _repo.GetMachineTypes();
        }
        public List<MachinePart> GetParts(int machineTypeId)
        {
            return _repo.GetParts(machineTypeId);
        }
        public DataTable GetItems(int machineTypeId, int? partId)
        {
            return _repo.GetItems(machineTypeId, partId);
        }
        public void UpdateMachineType(int id, string name)
        {
            _repo.UpdateMachineType(id, name);
        }

        public void DeleteMachineType(int id)
        {
            _repo.DeleteMachineType(id);
        }
        public DataTable GetPartsForType(int machineTypeId)
        {
            return _repo.GetPartsForType(machineTypeId);

        }
        public void UpdateMachinePart(int machinePartId, string name, int display_order)
        {
            _repo.UpdateMachinePart(machinePartId, name, display_order);
        }
        public void DeleteMachinePart(int machinePartId)
        {
            _repo.DeleteMachinePart(machinePartId);
        }

        public void UpdateMaintenanceItem(int id,string itemName,string standard,string method,string ng_solution,int display_order,int partId, int machineTypeId)
        {
            _repo.UpdateMaintenanceItem(id,itemName,standard,method,ng_solution,display_order, partId, machineTypeId);
        }

        internal void DeleteMaintenanceItem(int id)
        {
            _repo.DeleteMaintenanceItem(id);

        }

        internal void AddMachine(string machineName, int machineType_ID)
        {
            _repo.AddMachine(machineName, machineType_ID);
        }

        internal DataTable GetAllMachine()
        {
            return _repo.GetAllMachine();
        }

        internal void UpdateMachine(int idMachine, string machineName, int machine_type_id)
        {
             _repo.UpdateMachine(idMachine, machineName, machine_type_id);
        }

        internal void DeleteMachine(int idMachine)
        {
           _repo.DeleteMachine(idMachine);
        }

        internal DataTable SearchHistory(string? machineId, string? UserID, string? result, DateTime? fromTime, DateTime? toTime)
        {
            return _repo.SearchHistory(machineId, UserID, result, fromTime, toTime);
        }
        
    }
}
