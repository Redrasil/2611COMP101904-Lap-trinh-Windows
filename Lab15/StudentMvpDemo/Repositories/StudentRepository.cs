using StudentMvpDemo.Models;
namespace StudentMvpDemo.Repositories;
public sealed class StudentRepository : IStudentRepository
{
    private readonly List<Student> students = new()
    {
        new() { MaSV="SV001", HoTen="Nguyễn An", MaLop="CNTT1", Email="an@example.com" },
        new() { MaSV="SV002", HoTen="Trần Bình", MaLop="CNTT1", Email="binh@example.com" },
        new() { MaSV="SV003", HoTen="Lê Chi", MaLop="CNTT2", Email="chi@example.com" }
    };
    public IReadOnlyList<Student> GetAll() => students.ToList();
    public void Add(Student student) => students.Add(student);
    public bool Delete(string maSV) { var item = students.FirstOrDefault(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase)); return item is not null && students.Remove(item); }
}
