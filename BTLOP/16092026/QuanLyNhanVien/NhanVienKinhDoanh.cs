using System;

namespace QuanLyNhanVien
{
    /// <summary>
    /// Lớp Nhân viên kinh doanh kế thừa từ NhanVien
    /// </summary>
    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;

        // Ràng buộc doanh số >= 0
        public double DoanhSo
        {
            get => doanhSo;
            set => doanhSo = (value >= 0) ? value : 0;
        }

        // Constructor sử dụng base(...) để gọi constructor của lớp cha NhanVien
        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            this.DoanhSo = doanhSo;
        }

        // Ghi đè phương thức tính lương: Lương cơ bản + 5% * Doanh số
        public override double TinhLuong()
        {
            return LuongCoBan + (0.05 * DoanhSo);
        }

        // Ghi đè phương thức hiển thị thông tin
        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Kinh Doanh] Mã: {MaNV,-8} | Họ tên: {HoTen,-20} | Lương CB: {LuongCoBan,12:N0} VNĐ | Doanh số: {DoanhSo,13:N0} VNĐ | Thực lĩnh: {TinhLuong(),12:N0} VNĐ");
        }
    }
}
