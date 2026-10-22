using StudentMvpDemo.Models;
namespace StudentMvpDemo.Views;
public interface IStudentView
{
    event Action? LoadRequested;
    event Action? AddRequested;
    event Action? DeleteRequested;
    event Action? SearchRequested;
    string StudentId { get; }
    string FullName { get; }
    string ClassCode { get; }
    string Email { get; }
    string SearchText { get; }
    string? SelectedStudentId { get; }
    void ShowStudents(IReadOnlyList<Student> students);
    void ShowMessage(string message, bool error = false);
}
