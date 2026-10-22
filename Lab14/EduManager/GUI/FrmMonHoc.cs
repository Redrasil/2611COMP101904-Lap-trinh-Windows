using EduManager.BLL;
using EduManager.Models;

namespace EduManager.GUI;
public sealed partial class FrmMonHoc : Form
{
    private readonly MonHocBLL bll;
    public FrmMonHoc(MonHocBLL bll)
    {
        this.bll = bll;
        InitializeComponent();
    }
    private MonHoc ReadForm() => new() { MaMonHoc = txtMaMonHoc.Text.Trim(), TenMonHoc = txtTenMonHoc.Text.Trim(), SoTinChi = (int)nudSoTinChi.Value, TrangThai = chkTrangThai.Checked };
    private void WriteForm(MonHoc item) { txtMaMonHoc.Text = item.MaMonHoc; txtTenMonHoc.Text = item.TenMonHoc; nudSoTinChi.Value = item.SoTinChi; chkTrangThai.Checked = item.TrangThai; }
    private void ClearForm() { txtMaMonHoc.Clear(); txtTenMonHoc.Clear(); nudSoTinChi.Value = 3; chkTrangThai.Checked = true; }
    private void LoadData() { try { dgvMonHoc.DataSource = bll.GetAll(); } catch (Exception ex) { MessageBox.Show($"Không thể tải dữ liệu: {ex.Message}", "Lỗi"); } }
    private void Execute(Action action) { try { action(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); } }
}
