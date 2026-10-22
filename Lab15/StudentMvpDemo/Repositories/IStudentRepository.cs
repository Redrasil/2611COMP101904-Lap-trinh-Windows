using StudentMvpDemo.Models;
namespace StudentMvpDemo.Repositories;
public interface IStudentRepository
{
    IReadOnlyList<Student> GetAll();
    void Add(Student student);
    bool Delete(string maSV);
}
