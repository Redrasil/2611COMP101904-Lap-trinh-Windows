using System;

namespace QuanLyNhanVien
{
    /// <summary>
    /// Lớp Bonus: Nhân viên thời vụ kế thừa từ NhanVien
    /// Minh chứng cho nguyên lý Đa hình (Polymorphism) & Open/Closed Principle (OCP):
    /// Thêm loại nhân viên mới mà không cần sửa đổi thuật toán tính tổng lương hoặc tìm max lương!
    /// </summary>
    public class NhanVienThoiVu : NhanVien
    {
        private double soGioLam;
        private double luongTheoGio;

        public double SoGioLam
        {
            get => soGioLam;
            set => soGioLam = (value >= 0) ? value : 0;
        }

        public double LuongTheoGio
        {
            get => luongTheoGio;
            set => luongTheoGio = (value >= 0) ? value : 0;
        }

        // Constructor gọi base(maNV, hoTen, 0) vì nhân viên thời vụ không hưởng lương cơ bản cố định
        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 0)
        {
            this.SoGioLam = soGioLam;
            this.LuongTheoGio = luongTheoGio;
        }

        // Ghi đè phương thức tính lương: Số giờ làm * Lương theo giờ
        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        // Ghi đè phương thức hiển thị thông tin
        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Thời Vụ   ] Mã: {MaNV,-8} | Họ tên: {HoTen,-20} | Giờ làm: {SoGioLam,4:F1}h | Lương/giờ: {LuongTheoGio,9:N0} VNĐ | Thực lĩnh: {TinhLuong(),12:N0} VNĐ");
        }
    }
}
