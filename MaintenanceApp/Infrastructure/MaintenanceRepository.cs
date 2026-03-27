//using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Wordprocessing;
using MaintenanceApp.Domain;
using MaintenanceApp.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MaintenanceApp.Infrastructure
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly string _connectionString;

        public MaintenanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<MaintenanceItem> GetItemsByMachine(string machineCode)
        {
            var list = new List<MaintenanceItem>();
            try
            {
                

                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();

                var sql = @"
        SELECT
            mp.part_name,
            mi.id,
            mi.item_name,
            mi.standard,
            mi.method,
            mi.ng_solution
            
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
                        NgSolution = reader.GetString(5),
                        PartName = reader.GetString(0)
                    });
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            return list;

        }
        //public void SaveHistory(List<MaintenanceHistory> histories)
        //{
        //    using var conn = new NpgsqlConnection(_connectionString);
        //    conn.Open();

        //    foreach (var h in histories)
        //    {
        //        var sql = @"INSERT INTO maintenance_history
        //            (machine_code,user_id,item_id,result)
        //            VALUES (@machine,@user,@item,@result)";

        //        using var cmd = new NpgsqlCommand(sql, conn);

        //        cmd.Parameters.AddWithValue("machine", h.MachineCode);
        //        cmd.Parameters.AddWithValue("user", h.UserId);
        //        cmd.Parameters.AddWithValue("item", h.ItemId);
        //        cmd.Parameters.AddWithValue("result", h.Result);
        //        //cmd.Parameters.AddWithValue("date", h.MaintenanceDate);

        //        cmd.ExecuteNonQuery();
        //    }
        //}
        public int SaveHistory(List<MaintenanceHistory> histories)
        {

            using var conn = new NpgsqlConnection(_connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);

            }
            

            using var tran = conn.BeginTransaction();

            try
            {
                
                // 1️⃣ Tạo sheet trước
                var createSheetSql = @"INSERT INTO maintenance_sheet(machine_code,user_id)
                               VALUES (@machine,@user)
                               RETURNING id";

                using var cmdSheet = new NpgsqlCommand(createSheetSql, conn, tran);

                cmdSheet.Parameters.AddWithValue("machine", histories[0].MachineCode);
                cmdSheet.Parameters.AddWithValue("user", histories[0].UserId);

                int sheetId = Convert.ToInt32(cmdSheet.ExecuteScalar());

                // 2️⃣ Insert history
                foreach (var h in histories)
                {
                    var sql = @"INSERT INTO maintenance_history
                        (sheet_id, machine_code, user_id, item_id, result)
                        VALUES (@sheet_id, @machine, @user, @item, @result)";

                    using var cmd = new NpgsqlCommand(sql, conn, tran);

                    cmd.Parameters.AddWithValue("sheet_id", sheetId);
                    cmd.Parameters.AddWithValue("machine", h.MachineCode);
                    cmd.Parameters.AddWithValue("user", h.UserId);
                    cmd.Parameters.AddWithValue("item", h.ItemId);
                    cmd.Parameters.AddWithValue("result", h.Result);

                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                return sheetId;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
                tran.Rollback();
                throw;
            }
        }
        public void AddMachineType(string name)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();

                var sql = @"INSERT INTO machine_type(machine_type_name)
                VALUES (@name)";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("name", name);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            
        }
        public void AddMachinePart(int typeId, string partName, int order)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            
        }
        public void AddMaintenanceItem(int machine_type_id, int part_id, string item_name, string standard, string method, string ng_solution, int display_order)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            
        }
        public void AddMachine(string machineCode, int machine_type_id)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            
        }
        public List<MachineType> GetMachineTypes()
        {
            var list = new List<MachineType>();

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            

            return list;
        }
        public List<MachinePart> GetParts(int machineTypeId)
        {
            var list = new List<MachinePart>();
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            

            return list;
        }
        public DataTable GetItems(int machineTypeId, int? partId)
        {
            var dt = new DataTable();
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);

                var sql = @"SELECT 
                mt.machine_type_name,
                mi.id,
                mp.display_order as part_display_order,
                mp.part_name,
                mi.display_order,
                mi.item_name,
                mi.standard,
                mi.method,
                mi.ng_solution,
                mp.machine_type_id
                FROM maintenance_item mi
                JOIN machine_part mp 
                    ON mi.part_id = mp.id
                JOIN machine_type mt 
                    ON mp.machine_type_id = mt.id
                WHERE mp.machine_type_id = @typeId
                AND mp.deleted = false
                AND mi.deleted = false
                AND (@partId IS NULL OR mi.part_id = @partId)
                ORDER BY mp.display_order , mi.display_order";

                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("typeId", machineTypeId);

                if (partId == null)
                    cmd.Parameters.Add("partId", NpgsqlTypes.NpgsqlDbType.Integer).Value = DBNull.Value;
                else
                    cmd.Parameters.AddWithValue("partId", partId);

                

                using var adapter = new NpgsqlDataAdapter(cmd);

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            

            return dt;
        }
        public void UpdateMachineType(int id, string name)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            
        }
        public void DeleteMachineType(int id)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            
        }
        public DataTable GetPartsForType(int machineTypeId)
        {
            var dt = new DataTable();
            try
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
                
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            
            return dt;
        }
        public void UpdateMachinePart(int id, string name, int display_order)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);   
            }
            
        }
        public void DeleteMachinePart(int machinePartId)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            

        }
        public void UpdateMaintenanceItem(int id, string itemName, string standard, string method, string ng_solution, int display_order, int partId, int machine_type_id)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var sql = @"UPDATE maintenance_item
                SET  item_name= @item_name,
                     standard= @standard,
                        method= @method,
                        ng_solution= @ng_solution,
                        part_id = @partId,
                        machine_type_id = @machine_type_id,
                    display_order = @display_order
                WHERE id = @id";

                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("item_name", itemName);
                cmd.Parameters.AddWithValue("standard", standard);
                cmd.Parameters.AddWithValue("method", method);
                cmd.Parameters.AddWithValue("ng_solution", ng_solution);
                cmd.Parameters.AddWithValue("display_order", display_order);
                cmd.Parameters.AddWithValue("partId", partId);
                cmd.Parameters.AddWithValue("machine_type_id", machine_type_id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            

        }
        public void DeleteMaintenanceItem(int id)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var sql = @"UPDATE maintenance_item
                SET deleted = true
                WHERE id = @id";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            


        }
        public DataTable GetAllMachine()
        {
            DataTable table = new DataTable();
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                
                var sql = @"Select 
                        mt.id as machine_type_id,
                        mt.machine_type_name,
                        m.id,
                        m.machine_code
                        From machine m
                        JOIN machine_type mt
                        ON m.machine_type_id = mt.id
                        WHERE m.deleted = false
                        ORDER BY mt.id, m.machine_code";

                using var cmd = new NpgsqlCommand(sql, conn);
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(table);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);   

            }
            return table;

        }
        public void UpdateMachine(int idMachine, string machineName, int machine_type_id)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var sql = @"UPDATE machine
                SET  machine_code= @machineName,
                     machine_type_id = @machine_type_id
                WHERE id = @idMachine";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("idMachine", idMachine);
                cmd.Parameters.AddWithValue("machineName", machineName);
                cmd.Parameters.AddWithValue("machine_type_id", machine_type_id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            
        }
        public void DeleteMachine(int idMachine)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var sql = @"UPDATE machine
                SET deleted = true
                WHERE id = @idMachine";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("idMachine", idMachine);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);

            }
            
        }
        public DataTable SearchHistory(
            string machineCode,
            string userId,
            string result,
            DateTime? fromDate,
            DateTime? toDate)
        {
            var dt = new DataTable();
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);

                var sql = @"SELECT
                    
                    mh.machine_code,
                    mh.user_id,
                    mt.machine_type_name,
                    mp.part_name,
                    mi.item_name,
                    mi.standard,
                    mi.method,
                    mi.ng_solution,
                    mh.item_id,
                    mh.result,
                    mh.check_date
                

                FROM maintenance_history mh

                JOIN maintenance_item mi 
                    ON mh.item_id = mi.id

                JOIN machine_part mp 
                    ON mi.part_id = mp.id

                JOIN machine_type mt 
                    ON mp.machine_type_id = mt.id

                WHERE mh.sheet_id = (
                    SELECT mh2.sheet_id
                    FROM maintenance_history mh2
                    WHERE 
                        (@machineCode IS NULL OR mh2.machine_code ILIKE '%' || @machineCode || '%')
                    AND (@userId IS NULL OR mh2.user_id ILIKE '%' || @userId || '%')
                    AND (@result IS NULL OR mh2.result = @result)
                    AND (@fromDate IS NULL OR mh2.check_date >= @fromDate)
                    AND (@toDate IS NULL OR mh2.check_date < @toDate + INTERVAL '1 day')
    
                    ORDER BY mh2.check_date DESC, mh2.sheet_id DESC
                    LIMIT 1
                    )

                        ORDER BY mp.display_order, mi.display_order;";

                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.Add("machineCode", NpgsqlTypes.NpgsqlDbType.Text)
                    .Value = (object?)machineCode ?? DBNull.Value;

                cmd.Parameters.Add("userId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Value = (object?)userId ?? DBNull.Value;

                cmd.Parameters.Add("result", NpgsqlTypes.NpgsqlDbType.Text)
                    .Value = (object?)result ?? DBNull.Value;

                cmd.Parameters.Add("fromDate", NpgsqlTypes.NpgsqlDbType.Timestamp)
                    .Value = (object?)fromDate ?? DBNull.Value;

                cmd.Parameters.Add("toDate", NpgsqlTypes.NpgsqlDbType.Timestamp)
                    .Value = (object?)toDate ?? DBNull.Value;

                

                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            

            return dt;
        }

        public int CreateSheet(string machineCode, string userId)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();

                var sql = @"INSERT INTO maintenance_sheet(machine_code,user_id)
                VALUES (@machine,@user)
                RETURNING id";

                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("machine", machineCode);
                cmd.Parameters.AddWithValue("user", userId);

                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
                return -1;
            }
            
        }
        public DataTable GetHistory(string machineCode, DateTime? from, DateTime? to)
        {
            var dt = new DataTable();
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();

                var sql = @"SELECT 
                mh.sheet_id,
                mh.machine_code,
                mh.user_id,
                mt.machine_type_name,   -- ✔ dùng được

                mp.part_name,
                mi.item_name,
                mi.standard,
                mi.method,
                mi.ng_solution,

                mh.item_id,
                mh.result,
                mh.check_date,

                mp.display_order,
                mi.display_order,
                aqm.measure_value1,
                aqm.measure_value2,
                aqm.measure_value3

            FROM maintenance_history mh

            JOIN maintenance_item mi ON mh.item_id = mi.id
            JOIN machine_part mp ON mi.part_id = mp.id
            JOIN machine_type mt ON mp.machine_type_id = mt.id   -- 🔥 FIX
            JOIN maintenance_sheet ms ON mh.sheet_id = ms.id   -- 🔥 JOIN đúng
            LEFT JOIN air_quality_measurement aqm ON aqm.maintenance_sheet_id = ms.id
                
            WHERE 
                (@machineCode IS NULL OR mh.machine_code = @machineCode)
            AND (@fromDate IS NULL OR mh.check_date >= @fromDate)
            AND (@toDate IS NULL OR mh.check_date < @toDate + INTERVAL '1 day')

            ORDER BY 
                mh.check_date DESC,
                mh.sheet_id,
                mp.display_order,
                mi.display_order";

                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("machineCode", (object?)machineCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("fromDate", (object?)from ?? DBNull.Value);
                cmd.Parameters.AddWithValue("toDate", (object?)to ?? DBNull.Value);

               
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
                 
            }
            

            return dt;
        }
        public string GetMachineTypeName(string idMachine)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                string sql = @"SELECT mt.machine_type_name
                FROM machine m
                JOIN machine_type mt ON m.machine_type_id = mt.id
                WHERE m.machine_code = @idMachine";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("idMachine", idMachine);
                return (string)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
                return string.Empty;
            }
            

        }
        public int Add_air_quality_checklist(int sheet_id, double value1, double value2, double value3)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var sql = @"INSERT INTO air_quality_measurement(maintenance_sheet_id, measure_value1, measure_value2, measure_value3)
                        VALUES (@sheet_id, @value1, @value2, @value3) RETURNING id";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("sheet_id", sheet_id);
                cmd.Parameters.AddWithValue("value1", value1);
                cmd.Parameters.AddWithValue("value2", value2);
                cmd.Parameters.AddWithValue("value3", value3);
                var result = cmd.ExecuteScalar();

                // Kiểm tra null trước khi ép kiểu
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);


            }
            
            throw new Exception("Không thể lấy được ID mới sau khi INSERT.");
        }
        public void Update_maintenance_history(int id, int id_air)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var sql = @"UPDATE maintenance_sheet
                SET air_quality_measurement_id = @id_air
                WHERE id = @id";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("id_air", id_air);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            
        }
        public DataTable Get_air_quality_data(string machine_code, DateTime? from, DateTime? to)
        {
            var dt = new DataTable();
            try
            {
                using var conn = new NpgsqlConnection(_connectionString);
                conn.Open();
                var sql = @"Select 
                                ms.machine_code,        
                                air.measure_value1,
                                air.measure_value2,
                                air.measure_value3,
                                ms.created_at
                            from air_quality_measurement air
                            JOIN maintenance_sheet ms
                            ON air.id= ms.air_quality_measurement_id
                            WHERE ms.machine_code=@machine_code 
                                    AND(@fromDate IS NULL OR ms.created_at >= @fromDate)
                                    AND(@toDate IS NULL OR ms.created_at < @toDate + INTERVAL '1 day')";
                using var cmd = new NpgsqlCommand( sql, conn);
                cmd.Parameters.AddWithValue("machine_code", machine_code);
                cmd.Parameters.AddWithValue("fromDate", (object?)from ?? DBNull.Value);
                cmd.Parameters.AddWithValue("toDate", (object?)to ?? DBNull.Value);

                
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dt);

               


            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:" + ex.Message);
            }
            return dt;
        }
    }
}
