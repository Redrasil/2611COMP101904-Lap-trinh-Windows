namespace COMP1019_Lab12_GradeManager.DAL;

public static class Database
{
    public static string ConnectionString { get; } =
        "Server=.\\SQLEXPRESS;Database=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True;";
}
