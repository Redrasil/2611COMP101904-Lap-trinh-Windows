using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    /// <summary>
    /// Lớp dịch vụ quản lý danh sách sinh viên bằng List&lt;SinhVien&gt;
    /// Đóng gói toàn bộ thao tác CRUD, tìm kiếm, lọc và sắp xếp.
    /// </summary>
    public class QuanLySinhVien
    {
        // Danh sách sinh viên lưu trong bộ nhớ
        private readonly List<SinhVien> danhSachSinhVien;

        public QuanLySinhVien()
        {
            danhSachSinhVien = new List<SinhVien>();
        }

        /// <summary>
        /// Khởi tạo dữ liệu mẫu ban đầu để thuận tiện kiểm thử
        /// (Giữ lại mã SV001 để người dùng kiểm thử thêm mới theo đề bài)
        /// </summary>
        public void KhoiTaoDuLieuMau()
        {
            danhSachSinhVien.Clear();
            Them(new SinhVien("SV002", "Trần Thị Mai", new DateTime(2004, 5, 15), "49.01.TOAN", 8.8));
            Them(new SinhVien("SV003", "Lê Văn Hùng", new DateTime(2004, 11, 20), "49.01.CNTT", 4.5));
            Them(new SinhVien("SV004", "Phạm Quỳnh Chi", new DateTime(2005, 2, 10), "49.01.TOAN", 9.2));
            Them(new SinhVien("SV005", "Nguyễn Tuấn Anh", new DateTime(2003, 8, 30), "49.01.SPTOAN", 6.8));
            Them(new SinhVien("SV006", "Đặng Minh Tâm", new DateTime(2004, 12, 5), "49.01.CNTT", 3.8));
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên hiện có
        /// </summary>
        /// <returns>Bản sao danh sách sinh viên</returns>
        public List<SinhVien> LayDanhSach()
        {
            return danhSachSinhVien.ToList();
        }

        /// <summary>
        /// Kiểm tra xem mã sinh viên đã tồn tại trong danh sách hay chưa (không phân biệt hoa thường)
        /// </summary>
        public bool KiemTraTonTai(string maSinhVien)
        {
            if (string.IsNullOrWhiteSpace(maSinhVien))
                return false;

            return danhSachSinhVien.Any(sv => sv.MaSinhVien.Equals(maSinhVien.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Chức năng 1: Thêm một sinh viên mới vào danh sách.
        /// Mã sinh viên không được trùng.
        /// </summary>
        public bool Them(SinhVien sv)
        {
            if (sv == null)
                return false;

            if (KiemTraTonTai(sv.MaSinhVien))
                return false;

            danhSachSinhVien.Add(sv);
            return true;
        }

        /// <summary>
        /// Chức năng 3: Tìm sinh viên theo mã sinh viên chính xác bằng LINQ FirstOrDefault
        /// </summary>
        public SinhVien? TimTheoMa(string maSinhVien)
        {
            if (string.IsNullOrWhiteSpace(maSinhVien))
                return null;

            return danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien.Equals(maSinhVien.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Chức năng 4: Tìm kiếm danh sách sinh viên có họ tên chứa từ khóa bằng LINQ Where
        /// </summary>
        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return new List<SinhVien>();

            return danhSachSinhVien
                .Where(sv => sv.HoTen.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Chức năng 5: Cập nhật điểm trung bình của sinh viên theo mã
        /// </summary>
        public bool SuaDiem(string maSinhVien, double diemMoi)
        {
            var sv = TimTheoMa(maSinhVien);
            if (sv == null)
                return false;

            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        /// <summary>
        /// Chức năng 6: Xóa sinh viên khỏi danh sách theo mã sinh viên
        /// </summary>
        public bool Xoa(string maSinhVien)
        {
            var sv = TimTheoMa(maSinhVien);
            if (sv == null)
                return false;

            return danhSachSinhVien.Remove(sv);
        }

        /// <summary>
        /// Chức năng 7: Sắp xếp danh sách sinh viên theo điểm trung bình giảm dần bằng LINQ OrderByDescending
        /// </summary>
        public List<SinhVien> SapXepTheoDiemGiamDan()
        {
            return danhSachSinhVien
                .OrderByDescending(sv => sv.DiemTrungBinh)
                .ThenBy(sv => sv.HoTen)
                .ToList();
        }

        /// <summary>
        /// Chức năng 8: Lọc sinh viên đạt (điểm trung bình >= 5.0) bằng LINQ Where
        /// </summary>
        public List<SinhVien> LocSinhVienDat()
        {
            return danhSachSinhVien
                .Where(sv => sv.LaSinhVienDat())
                .OrderByDescending(sv => sv.DiemTrungBinh)
                .ToList();
        }

        /// <summary>
        /// Đếm số lượng sinh viên hiện có
        /// </summary>
        public int SoLuong => danhSachSinhVien.Count;
    }
}
