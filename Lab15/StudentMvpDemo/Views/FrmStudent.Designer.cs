#nullable enable
using StudentMvpDemo.Models;

namespace StudentMvpDemo.Views;

partial class FrmStudent
{
    private System.ComponentModel.IContainer? components;
    private TextBox txtMaSV = null!, txtHoTen = null!, txtMaLop = null!, txtEmail = null!, txtTimKiem = null!;
    private DataGridView dgvStudents = null!;
    private Button btnLoad = null!, btnThem = null!, btnXoa = null!, btnTim = null!;

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtMaSV = new TextBox { Name = "txtMaSV", Width = 130 };
        txtHoTen = new TextBox { Name = "txtHoTen", Width = 130 };
        txtMaLop = new TextBox { Name = "txtMaLop", Width = 130 };
        txtEmail = new TextBox { Name = "txtEmail", Width = 130 };
        txtTimKiem = new TextBox { Name = "txtTimKiem", Width = 130 };
        dgvStudents = new DataGridView { Name = "dgvStudents", Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AllowUserToAddRows = false };
        btnLoad = new Button { Name = "btnLoad", Text = "Load", Width = 70 };
        btnThem = new Button { Name = "btnThem", Text = "Thêm", Width = 70 };
        btnXoa = new Button { Name = "btnXoa", Text = "Xóa", Width = 70 };
        btnTim = new Button { Name = "btnTim", Text = "Tìm", Width = 70 };
        var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 150, Padding = new Padding(10) };
        panel.Controls.AddRange(new Control[] { LabelFor("Mã SV"), txtMaSV, LabelFor("Họ tên"), txtHoTen, LabelFor("Lớp"), txtMaLop, LabelFor("Email"), txtEmail, LabelFor("Tìm kiếm"), txtTimKiem, btnLoad, btnThem, btnXoa, btnTim });
        Controls.Add(dgvStudents); Controls.Add(panel);
        btnLoad.Click += (_, _) => LoadRequested?.Invoke(); btnThem.Click += (_, _) => AddRequested?.Invoke(); btnXoa.Click += (_, _) => DeleteRequested?.Invoke(); btnTim.Click += (_, _) => SearchRequested?.Invoke();
        dgvStudents.CellClick += (_, _) => { if (dgvStudents.CurrentRow?.DataBoundItem is Student s) { txtMaSV.Text = s.MaSV; txtHoTen.Text = s.HoTen; txtMaLop.Text = s.MaLop; txtEmail.Text = s.Email; } };
        ClientSize = new Size(900, 600); Name = "FrmStudent"; StartPosition = FormStartPosition.CenterScreen; Text = "Quản lý sinh viên MVP - Lab 15";
    }

    private static Label LabelFor(string text) => new() { Text = text, AutoSize = true, Padding = new Padding(5, 7, 0, 0) };
}
