#nullable enable
namespace StudentReportDemo.Forms;

partial class FrmBaoCaoSinhVien
{
    private System.ComponentModel.IContainer? components;
    private ComboBox cboLop = null!;
    private ComboBox cboKetQua = null!;
    private TextBox txtTuKhoa = null!;
    private DataGridView dgvBaoCao = null!;
    private Label lblStatus = null!;
    private Button btnXemBaoCao = null!;
    private Button btnThongKe = null!;
    private Button btnXuatFile = null!;

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        cboLop = new ComboBox { Name = "cboLop", DropDownStyle = ComboBoxStyle.DropDownList, Width = 180 };
        cboKetQua = new ComboBox { Name = "cboKetQua", DropDownStyle = ComboBoxStyle.DropDownList, Width = 140 };
        txtTuKhoa = new TextBox { Name = "txtTuKhoa", Width = 180 };
        dgvBaoCao = new DataGridView { Name = "dgvBaoCao", Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, ReadOnly = true };
        lblStatus = new Label { Name = "lblStatus", AutoSize = true, Text = "Chưa lọc dữ liệu", Padding = new Padding(10, 7, 0, 0) };
        btnXemBaoCao = new Button { Name = "btnXemBaoCao", Text = "Xem báo cáo" };
        btnThongKe = new Button { Name = "btnThongKe", Text = "Thống kê" };
        btnXuatFile = new Button { Name = "btnXuatFile", Text = "Xuất file" };
        var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 90, Padding = new Padding(10) };
        panel.Controls.AddRange(new Control[] { new Label { Text = "Lớp", AutoSize = true, Padding = new Padding(0, 7, 0, 0) }, cboLop, new Label { Text = "Kết quả", AutoSize = true, Padding = new Padding(10, 7, 0, 0) }, cboKetQua, new Label { Text = "Từ khóa", AutoSize = true, Padding = new Padding(10, 7, 0, 0) }, txtTuKhoa, btnXemBaoCao, btnThongKe, btnXuatFile, lblStatus });
        Controls.Add(dgvBaoCao);
        Controls.Add(panel);
        btnXemBaoCao.Click += (_, _) => XemBaoCao();
        btnThongKe.Click += (_, _) => CapNhatThongKe();
        btnXuatFile.Click += (_, _) => XuatFile();
        Load += (_, _) => LoadComboBox();
        ClientSize = new Size(950, 600);
        Name = "FrmBaoCaoSinhVien";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Báo cáo sinh viên bằng LINQ - Lab 13";
    }
}
