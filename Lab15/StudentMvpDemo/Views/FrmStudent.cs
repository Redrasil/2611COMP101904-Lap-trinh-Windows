using StudentMvpDemo.Models;
namespace StudentMvpDemo.Views;
public sealed partial class FrmStudent : Form, IStudentView
{
    public event Action? LoadRequested, AddRequested, DeleteRequested, SearchRequested;
    public string StudentId => txtMaSV.Text; public string FullName => txtHoTen.Text; public string ClassCode => txtMaLop.Text; public string Email => txtEmail.Text; public string SearchText => txtTimKiem.Text; public string? SelectedStudentId => dgvStudents.CurrentRow?.Cells[nameof(Student.MaSV)].Value?.ToString();
    public FrmStudent()
    {
        InitializeComponent();
    }
    public void ShowStudents(IReadOnlyList<Student> students) => dgvStudents.DataSource = students.ToList();
    public void ShowMessage(string message, bool error = false) => MessageBox.Show(message, error ? "Lỗi" : "Thông báo", MessageBoxButtons.OK, error ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
}
