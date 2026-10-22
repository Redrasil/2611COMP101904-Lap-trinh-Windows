using System.Text;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms;
public sealed partial class FrmBaoCaoSinhVien : Form
{
    private readonly List<SinhVien> students = TaoDuLieuMau();
    private List<SinhVien> current = new();

    public FrmBaoCaoSinhVien()
    {
        InitializeComponent();
    }

    private void LoadComboBox()
    {
        cboLop.Items.Add("Tất cả"); cboLop.Items.AddRange(students.Select(s => s.TenLop).Distinct().OrderBy(x => x).ToArray()); cboLop.SelectedIndex = 0;
        cboKetQua.Items.AddRange(new object[] { "Tất cả", "Đạt", "Không đạt" }); cboKetQua.SelectedIndex = 0; XemBaoCao();
    }

    private void XemBaoCao()
    {
        string lop = cboLop.SelectedItem?.ToString() ?? "Tất cả", result = cboKetQua.SelectedItem?.ToString() ?? "Tất cả", keyword = txtTuKhoa.Text.Trim();
        current = students.Where(s => (lop == "Tất cả" || s.TenLop == lop) && (result == "Tất cả" || s.KetQua == result) && (keyword.Length == 0 || s.MaSV.Contains(keyword, StringComparison.OrdinalIgnoreCase) || s.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase))).OrderByDescending(s => s.Diem).ToList();
        dgvBaoCao.DataSource = current.Select(s => new { s.MaSV, s.HoTen, s.MaLop, s.TenLop, s.Diem, s.KetQua }).ToList(); CapNhatThongKe();
    }

    private void CapNhatThongKe()
    {
        int passed = current.Count(s => s.KetQua == "Đạt");
        string byClass = string.Join(" ; ", current.GroupBy(s => s.TenLop).OrderBy(g => g.Key).Select(g => $"{g.Key}: {g.Count()} SV, TB {g.Average(s => s.Diem):0.00}"));
        lblStatus.Text = $"Tổng: {current.Count} | Đạt: {passed} | Không đạt: {current.Count - passed} | Điểm TB: {(current.Count == 0 ? 0 : current.Average(s => s.Diem)):0.00}" + (byClass.Length == 0 ? "" : $" | Theo lớp: {byClass}");
    }

    private void XuatFile()
    {
        if (current.Count == 0) { MessageBox.Show("Không có dữ liệu phù hợp để xuất.", "Thông báo"); return; }
        using SaveFileDialog dialog = new() { Filter = "CSV (*.csv)|*.csv|Text (*.txt)|*.txt", FileName = "BaoCaoSinhVien.csv" };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        try { var lines = new List<string> { "MaSV,HoTen,MaLop,TenLop,Diem,KetQua" }; lines.AddRange(current.Select(s => $"{s.MaSV},\"{s.HoTen}\",{s.MaLop},\"{s.TenLop}\",{s.Diem:0.00},{s.KetQua}")); File.WriteAllLines(dialog.FileName, lines, Encoding.UTF8); MessageBox.Show("Xuất báo cáo thành công.", "Thông báo"); }
        catch (IOException ex) { MessageBox.Show($"Không thể xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private static List<SinhVien> TaoDuLieuMau() => new()
    {
        new() { MaSV="SV001", HoTen="Nguyễn An", MaLop="CNTT1", TenLop="Công nghệ thông tin 1", Diem=8.5 },
        new() { MaSV="SV002", HoTen="Trần Bình", MaLop="CNTT1", TenLop="Công nghệ thông tin 1", Diem=4.5 },
        new() { MaSV="SV003", HoTen="Lê Chi", MaLop="CNTT1", TenLop="Công nghệ thông tin 1", Diem=7.0 },
        new() { MaSV="SV004", HoTen="Phạm Dũng", MaLop="CNTT1", TenLop="Công nghệ thông tin 1", Diem=5.5 },
        new() { MaSV="SV005", HoTen="Võ Hà", MaLop="CNTT2", TenLop="Công nghệ thông tin 2", Diem=9.0 },
        new() { MaSV="SV006", HoTen="Đỗ Huy", MaLop="CNTT2", TenLop="Công nghệ thông tin 2", Diem=3.0 },
        new() { MaSV="SV007", HoTen="Bùi Lan", MaLop="CNTT2", TenLop="Công nghệ thông tin 2", Diem=6.5 },
        new() { MaSV="SV008", HoTen="Ngô Minh", MaLop="CNTT2", TenLop="Công nghệ thông tin 2", Diem=4.0 },
        new() { MaSV="SV009", HoTen="Hoàng Nam", MaLop="CNTT3", TenLop="Hệ thống thông tin", Diem=7.5 },
        new() { MaSV="SV010", HoTen="Đặng Oanh", MaLop="CNTT3", TenLop="Hệ thống thông tin", Diem=8.0 },
        new() { MaSV="SV011", HoTen="Phan Quân", MaLop="CNTT3", TenLop="Hệ thống thông tin", Diem=2.5 },
        new() { MaSV="SV012", HoTen="Mai Trang", MaLop="CNTT3", TenLop="Hệ thống thông tin", Diem=5.0 }
    };
}
