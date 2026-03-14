//using DocumentFormat.OpenXml.Drawing.Charts;
using MaintenanceApp.Domain;
using MaintenanceApp.Interfaces;
using Npgsql;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MaintenanceApp.Infrastructure
{
    public class MaintenanceRepository: IMaintenanceRepository
    {
        private readonly string _connectionString;

        public MaintenanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<MaintenanceItem> GetItemsByMachine(string machineCode)
        {
            var list = new List<MaintenanceItem>();

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"
        SELECT
            mp.part_name,
            mi.id,
            mi.item_name,
            mi.standard,
            mi.method
        FROM machine m
        JOIN machine_part mp
            ON mp.machine_type_id = m.machine_type_id
        JOIN maintenance_item mi
            ON mi.part_id = mp.id
        WHERE m.machine_code = @code
            AND mp.deleted = false
            AND mi.deleted = false
        ORDER BY mp.display_order, mi.display_order";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("code", machineCode);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new MaintenanceItem
                {
                    Id = reader.GetInt32(1),
                    ItemName = reader.GetString(2),
                    Standard = reader.GetString(3),
                    Method = reader.GetString(4),
                    PartName = reader.GetString(0)
                });
            }

            return list;
        }
        public void SaveHistory(List<MaintenanceHistory> histories)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            foreach (var h in histories)
            {
                var sql = @"INSERT INTO maintenance_history
                    (machine_code,user_id,item_id,result,check_date)
                    VALUES (@machine,@user,@item,@result,@date)";

                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("machine", h.MachineCode);
                cmd.Parameters.AddWithValue("user", h.UserId);
                cmd.Parameters.AddWithValue("item", h.ItemId);
                cmd.Parameters.AddWithValue("result", h.Result);
                cmd.Parameters.AddWithValue("date", h.MaintenanceDate);

                cmd.ExecuteNonQuery();
            }
        }
        public void AddMachineType(string name)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"INSERT INTO machine_type(machine_type_name)
                VALUES (@name)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("name", name);

            cmd.ExecuteNonQuery();
        }
        public void AddMachinePart(int typeId, string partName, int order)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"INSERT INTO machine_part
                (machine_type_id,part_name,display_order)
                VALUES (@type,@name,@order)";

            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("type", typeId);
            cmd.Parameters.AddWithValue("name", partName);
            cmd.Parameters.AddWithValue("order", order);

            cmd.ExecuteNonQuery();
        }
        public void AddMaintenanceItem(int machine_type_id,int part_id,string item_name,string standard,string method,string ng_solution,int display_order)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"INSERT INTO maintenance_item
                        (machine_type_id,part_id,item_name,standard,method,ng_solution,display_order)
                        VALUES
                        (@type,@part,@item,@standard,@method,@solution,@order)";

            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("type", machine_type_id);
            cmd.Parameters.AddWithValue("part", part_id);
            cmd.Parameters.AddWithValue("item", item_name);
            cmd.Parameters.AddWithValue("standard", standard);
            cmd.Parameters.AddWithValue("method", method);
            cmd.Parameters.AddWithValue("solution", ng_solution);
            cmd.Parameters.AddWithValue("order", display_order);
            

            cmd.ExecuteNonQuery();
        }
        public void AddMachine(int machineCode,int machine_type_id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"INSERT INTO machine(machine_code,machine_type_id)
                        VALUES (@code,@type)";

            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("code", machineCode);
            cmd.Parameters.AddWithValue("type", machine_type_id);
            


            cmd.ExecuteNonQuery();
        }
        public List<MachineType> GetMachineTypes()
        {
            var list = new List<MachineType>();

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT id, machine_type_name FROM machine_type where deleted = false order by id", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new MachineType
                {
                    Id = reader.GetInt32(0),
                    MachineTypeName = reader.GetString(1)
                });
            }

            return list;
        }
        public List<MachinePart> GetParts(int machineTypeId)
        {
            var list = new List<MachinePart>();

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"SELECT id, part_name, display_order
                FROM machine_part
                WHERE machine_type_id = @typeId
                    AND deleted = false 
                ORDER BY display_order";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("typeId", machineTypeId);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new MachinePart
                {
                    Id = reader.GetInt32(0),
                    PartName = reader.GetString(1),
                    DisplayOrder = reader.GetInt32(2)
                });
            }

            return list;
        }
        public DataTable GetItems(int machineTypeId, int? partId)
        {
            using var conn = new NpgsqlConnection(_connectionString);

            var sql = @"SELECT 
                mi.id,
                mp.part_name,
                mi.display_order,
                mi.item_name,
                mi.standard,
                mi.method,
                mi.ng_solution
                FROM maintenance_item mi
                JOIN machine_part mp ON mi.part_id = mp.id
                WHERE mp.machine_type_id = @typeId
                AND mp.deleted = false
                AND mi.deleted = false
                AND (@partId IS NULL OR mi.part_id = @partId)
                ORDER BY mp.display_order, mi.display_order";

            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("typeId", machineTypeId);

            if (partId == null)
                cmd.Parameters.AddWithValue("partId", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("partId", partId);

            var dt = new DataTable();

            using var adapter = new NpgsqlDataAdapter(cmd);

            adapter.Fill(dt);

            return dt;
        }
        public void UpdateMachineType(int id, string name)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"UPDATE machine_type
                SET machine_type_name = @name
                WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);

            cmd.ExecuteNonQuery();
        }
        public void DeleteMachineType(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"UPDATE machine_type
                SET deleted = true
                WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        public DataTable GetPartsForType(int machineTypeId)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            var sql = @"SELECT 
	                    mt.machine_type_name,
                        mp.id,
	                    mp.display_order,
	                    mp.part_name
                    FROM machine_type mt
                    JOIN machine_part mp 
                        ON mt.id = @typeId 
                        AND mp.machine_type_id = mt.id
                        AND mp.deleted = false
                        AND mt.deleted = false
                    ORDER BY mp.display_order";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("typeId", machineTypeId);
            var dt = new DataTable();
            using var adapter = new NpgsqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public void UpdateMachinePart(int id, string name,int display_order)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = @"UPDATE machine_part
                SET  part_name= @name,
                    display_order = @display_order
                WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("display_order", display_order);

            cmd.ExecuteNonQuery();
        }
        public void DeleteMachinePart(int machinePartId)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = @"UPDATE machine_part
                SET deleted = true
                WHERE id = @machinePartId";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("machinePartId", machinePartId);
            cmd.ExecuteNonQuery();

        }


    }
}
