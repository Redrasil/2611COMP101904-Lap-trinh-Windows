using System.Data;
using COMP1019_Lab12_GradeManager.DAL;

namespace COMP1019_Lab12_GradeManager.Forms;

public sealed partial class FrmNhapDiemTheoLop : Form
{
    private readonly KetQuaDAL dal = new();
    private BindingSource source = new();

    public FrmNhapDiemTheoLop()
    {
        InitializeComponent();
    }

    private void LoadLookups()
    {
        try
        {
            cboLop.DataSource = dal.GetClasses(); cboLop.DisplayMember = "TenLop"; cboLop.ValueMember = "MaLop";
            cboMonHoc.DataSource = dal.GetSubjects(); cboMonHoc.DisplayMember = "TenMon"; cboMonHoc.ValueMember = "MaMon";
            lblStatus.Text = "Đã tải danh mục";
        }
        catch (Exception ex) { ShowError(ex); }
    }

    private void LoadGrades()
    {
        if (cboLop.SelectedValue is null || cboMonHoc.SelectedValue is null) return;
        try { source.DataSource = dal.GetGrades(cboLop.SelectedValue.ToString()!, cboMonHoc.SelectedValue.ToString()!); dgvKetQua.DataSource = source; ConfigureGrid(); lblStatus.Text = "Đã tải danh sách sinh viên"; }
        catch (Exception ex) { ShowError(ex); }
    }

    private void ConfigureGrid()
    {
        if (dgvKetQua.Columns["MaSV"] is not null) dgvKetQua.Columns["MaSV"].ReadOnly = true;
        if (dgvKetQua.Columns["HoTen"] is not null) dgvKetQua.Columns["HoTen"].ReadOnly = true;
        if (dgvKetQua.Columns["Diem"] is not null) dgvKetQua.Columns["Diem"].HeaderText = "Điểm";
        if (dgvKetQua.Columns["GhiChu"] is not null) dgvKetQua.Columns["GhiChu"].HeaderText = "Ghi chú";
    }

    private void SaveGrades()
    {
        if (source.DataSource is not DataTable table || table.Rows.Count == 0 || cboMonHoc.SelectedValue is null) return;
        foreach (DataRow row in table.Rows)
        {
            if (row["Diem"] == DBNull.Value || !decimal.TryParse(row["Diem"].ToString(), out decimal grade) || grade is < 0 or > 10)
            {
                MessageBox.Show($"Điểm của {row["MaSV"]} phải là số từ 0 đến 10.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            row["Diem"] = grade;
        }
        try { int count = dal.SaveGrades(cboMonHoc.SelectedValue.ToString()!, table); lblStatus.Text = $"Đã lưu {count} dòng (transaction commit)"; MessageBox.Show(lblStatus.Text, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void ShowError(Exception ex) => MessageBox.Show($"Thao tác thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
