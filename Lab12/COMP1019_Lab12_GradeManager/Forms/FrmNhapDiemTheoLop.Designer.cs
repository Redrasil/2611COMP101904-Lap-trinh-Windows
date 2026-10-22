#nullable enable
namespace COMP1019_Lab12_GradeManager.Forms;

partial class FrmNhapDiemTheoLop
{
    private System.ComponentModel.IContainer? components;
    private ComboBox cboLop = null!;
    private ComboBox cboMonHoc = null!;
    private DataGridView dgvKetQua = null!;
    private Label lblStatus = null!;
    private Button btnTaiDanhSach = null!;
    private Button btnLuuTatCa = null!;

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        cboLop = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
        cboMonHoc = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 220 };
        dgvKetQua = new DataGridView { Dock = DockStyle.Fill, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        lblStatus = new Label { AutoSize = true, Text = "Sẵn sàng", Padding = new Padding(10, 7, 0, 0) };
        btnTaiDanhSach = new Button { Name = "btnTaiDanhSach", Text = "Tải danh sách", Width = 110 };
        btnLuuTatCa = new Button { Name = "btnLuuTatCa", Text = "Lưu tất cả", Width = 90 };
        var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 70, Padding = new Padding(10) };
        panel.Controls.AddRange(new Control[] { new Label { Text = "Lớp:", AutoSize = true, Padding = new Padding(0, 7, 0, 0) }, cboLop, new Label { Text = "Môn:", AutoSize = true, Padding = new Padding(10, 7, 0, 0) }, cboMonHoc, btnTaiDanhSach, btnLuuTatCa, lblStatus });
        Controls.Add(dgvKetQua);
        Controls.Add(panel);
        btnTaiDanhSach.Click += (_, _) => LoadGrades();
        btnLuuTatCa.Click += (_, _) => SaveGrades();
        Load += (_, _) => LoadLookups();
        AutoScaleDimensions = new SizeF(7F, 15F);
        ClientSize = new Size(850, 560);
        Name = "FrmNhapDiemTheoLop";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Nhập điểm theo lớp - Lab 12";
    }
}
