using System.Data;
using Microsoft.Data.SqlClient;

namespace COMP1019_Lab12_GradeManager.DAL;

public sealed class KetQuaDAL
{
    public DataTable GetClasses()
    {
        using SqlConnection connection = new(Database.ConnectionString);
        using SqlCommand command = new("sp_Lop_GetAll", connection) { CommandType = CommandType.StoredProcedure };
        using SqlDataAdapter adapter = new(command);
        DataTable table = new();
        adapter.Fill(table);
        return table;
    }

    public DataTable GetSubjects()
    {
        using SqlConnection connection = new(Database.ConnectionString);
        using SqlCommand command = new("sp_MonHoc_GetAll", connection) { CommandType = CommandType.StoredProcedure };
        using SqlDataAdapter adapter = new(command);
        DataTable table = new();
        adapter.Fill(table);
        return table;
    }

    public DataTable GetGrades(string maLop, string maMon)
    {
        using SqlConnection connection = new(Database.ConnectionString);
        using SqlCommand command = new("sp_KetQua_GetByLopMon", connection) { CommandType = CommandType.StoredProcedure };
        command.Parameters.Add("@MaLop", SqlDbType.NVarChar, 20).Value = maLop;
        command.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
        using SqlDataAdapter adapter = new(command);
        DataTable table = new();
        adapter.Fill(table);
        return table;
    }

    public int SaveGrades(string maMon, DataTable grades)
    {
        using SqlConnection connection = new(Database.ConnectionString);
        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            int saved = 0;
            foreach (DataRow row in grades.Rows)
            {
                using SqlCommand command = new("sp_KetQua_Save", connection, transaction)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20).Value = row["MaSV"];
                command.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
                command.Parameters.Add("@Diem", SqlDbType.Decimal).Value = row["Diem"];
                command.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 200).Value =
                    row["GhiChu"] == DBNull.Value ? DBNull.Value : row["GhiChu"];
                saved += command.ExecuteNonQuery();
            }
            transaction.Commit();
            return saved;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
