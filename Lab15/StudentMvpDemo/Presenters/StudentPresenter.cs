using StudentMvpDemo.Models;
using StudentMvpDemo.Repositories;
using StudentMvpDemo.Views;
namespace StudentMvpDemo.Presenters;
public sealed class StudentPresenter
{
    private readonly IStudentView view;
    private readonly IStudentRepository repository;
    public StudentPresenter(IStudentView view, IStudentRepository repository) { this.view = view; this.repository = repository; view.LoadRequested += Load; view.AddRequested += AddStudent; view.DeleteRequested += DeleteStudent; view.SearchRequested += Search; Load(); }
    private void Load() => view.ShowStudents(repository.GetAll());
    private void AddStudent()
    {
        if (string.IsNullOrWhiteSpace(view.StudentId) || string.IsNullOrWhiteSpace(view.FullName) || string.IsNullOrWhiteSpace(view.ClassCode) || string.IsNullOrWhiteSpace(view.Email)) { view.ShowMessage("Mã, họ tên, lớp và email không được rỗng.", true); return; }
        if (repository.GetAll().Any(s => s.MaSV.Equals(view.StudentId.Trim(), StringComparison.OrdinalIgnoreCase))) { view.ShowMessage("Mã sinh viên đã tồn tại.", true); return; }
        repository.Add(new Student { MaSV = view.StudentId.Trim(), HoTen = view.FullName.Trim(), MaLop = view.ClassCode.Trim(), Email = view.Email.Trim() }); Load(); view.ShowMessage("Thêm sinh viên thành công.");
    }
    private void DeleteStudent() { if (string.IsNullOrWhiteSpace(view.SelectedStudentId)) { view.ShowMessage("Hãy chọn sinh viên cần xóa.", true); return; } if (repository.Delete(view.SelectedStudentId)) { Load(); view.ShowMessage("Xóa sinh viên thành công."); } else view.ShowMessage("Không tìm thấy sinh viên.", true); }
    private void Search() => view.ShowStudents(repository.GetAll().Where(s => string.IsNullOrWhiteSpace(view.SearchText) || s.MaSV.Contains(view.SearchText, StringComparison.OrdinalIgnoreCase) || s.HoTen.Contains(view.SearchText, StringComparison.OrdinalIgnoreCase)).ToList());
}
