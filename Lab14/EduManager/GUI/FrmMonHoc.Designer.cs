#nullable enable
using EduManager.Models;

namespace EduManager.GUI;

partial class FrmMonHoc
{
    private System.ComponentModel.IContainer? components;
    private TextBox txtMaMonHoc = null!, txtTenMonHoc = null!, txtTimKiem = null!;
    private NumericUpDown nudSoTinChi = null!;
    private CheckBox chkTrangThai = null!;
    private DataGridView dgvMonHoc = null!;
    private Button btnThem = null!, btnSua = null!, btnXoa = null!, btnLamMoi = null!, btnTimKiem = null!;

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtMaMonHoc = new TextBox { Name = "txtMaMonHoc", Dock = DockStyle.Fill };
        txtTenMonHoc = new TextBox { Name = "txtTenMonHoc", Dock = DockStyle.Fill };
        txtTimKiem = new TextBox { Name = "txtTimKiem", Dock = DockStyle.Fill };
        nudSoTinChi = new NumericUpDown { Name = "nudSoTinChi", Minimum = 1, Maximum = 6, Value = 3 };
        chkTrangThai = new CheckBox { Name = "chkTrangThai", Text = "Còn sử dụng", Checked = true, AutoSize = true };
        dgvMonHoc = new DataGridView { Name = "dgvMonHoc", Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AllowUserToAddRows = false };
        btnThem = new Button { Name = "btnThem", Text = "Thêm", Width = 75 };
        btnSua = new Button { Name = "btnSua", Text = "Sửa", Width = 75 };
        btnXoa = new Button { Name = "btnXoa", Text = "Xóa", Width = 75 };
        btnTimKiem = new Button { Name = "btnTimKiem", Text = "Tìm kiếm", Width = 85 };
        btnLamMoi = new Button { Name = "btnLamMoi", Text = "Làm mới", Width = 85 };
        var input = new TableLayoutPanel { Dock = DockStyle.Top, Height = 170, Padding = new Padding(10), ColumnCount = 4, RowCount = 4 };
        input.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110)); input.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35)); input.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110)); input.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
        input.Controls.Add(new Label { Text = "Mã môn học", AutoSize = true }, 0, 0); input.Controls.Add(txtMaMonHoc, 1, 0); input.Controls.Add(new Label { Text = "Tên môn học", AutoSize = true }, 2, 0); input.Controls.Add(txtTenMonHoc, 3, 0);
        input.Controls.Add(new Label { Text = "Số tín chỉ", AutoSize = true }, 0, 1); input.Controls.Add(nudSoTinChi, 1, 1); input.Controls.Add(chkTrangThai, 2, 1);
        input.Controls.Add(new Label { Text = "Tìm kiếm", AutoSize = true }, 0, 2); input.Controls.Add(txtTimKiem, 1, 2);
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true }; buttons.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnTimKiem, btnLamMoi }); input.Controls.Add(buttons, 0, 3); input.SetColumnSpan(buttons, 4);
        Controls.Add(dgvMonHoc); Controls.Add(input);
        btnThem.Click += (_, _) => Execute(() => { bll.Add(ReadForm()); LoadData(); ClearForm(); });
        btnSua.Click += (_, _) => Execute(() => { bll.Update(ReadForm()); LoadData(); ClearForm(); });
        btnXoa.Click += (_, _) => Execute(() => { if (MessageBox.Show("Xác nhận xóa?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.Yes) { bll.Delete(txtMaMonHoc.Text.Trim()); LoadData(); ClearForm(); } });
        btnTimKiem.Click += (_, _) => Execute(() => dgvMonHoc.DataSource = bll.GetAll(txtTimKiem.Text.Trim()));
        btnLamMoi.Click += (_, _) => { ClearForm(); LoadData(); };
        Load += (_, _) => LoadData();
        dgvMonHoc.CellClick += (_, e) => { if (e.RowIndex >= 0 && dgvMonHoc.Rows[e.RowIndex].DataBoundItem is MonHoc item) WriteForm(item); };
        ClientSize = new Size(900, 600); Name = "FrmMonHoc"; StartPosition = FormStartPosition.CenterScreen; Text = "Quản lý môn học - Lab 14";
    }
}
