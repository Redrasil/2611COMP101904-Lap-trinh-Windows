using System;

namespace QuanLyNhanVien
{
    /// <summary>
    /// Lớp Nhân viên văn phòng kế thừa từ NhanVien
    /// </summary>
    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;

        // Ràng buộc số ngày làm việc từ 0 đến 31
        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set
            {
                if (value < 0) soNgayLamViec = 0;
                else if (value > 31) soNgayLamViec = 31;
                else soNgayLamViec = value;
            }
        }

        // Constructor sử dụng base(...) để gọi constructor của lớp cha NhanVien
        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            this.SoNgayLamViec = soNgayLamViec;
        }

        // Ghi đè phương thức tính lương: Lương cơ bản + Số ngày làm việc * 200.000
        public override double TinhLuong()
        {
            return LuongCoBan + (SoNgayLamViec * 200000.0);
        }

        // Ghi đè phương thức hiển thị thông tin
        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Văn Phòng ] Mã: {MaNV,-8} | Họ tên: {HoTen,-20} | Lương CB: {LuongCoBan,12:N0} VNĐ | Ngày công: {SoNgayLamViec,2} | Thực lĩnh: {TinhLuong(),12:N0} VNĐ");
        }
    }
}
