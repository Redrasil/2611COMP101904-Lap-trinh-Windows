using System;

namespace QuanLyNhanVien
{
    /// <summary>
    /// Lớp cha cơ sở quản lý thông tin chung của Nhân viên
    /// </summary>
    public class NhanVien
    {
        // Các trường dữ liệu (Encapsulation)
        private string maNV;
        private string hoTen;
        private double luongCoBan;

        // Các thuộc tính (Properties)
        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string HoTen
        {
            get => hoTen;
            set => hoTen = value;
        }

        public double LuongCoBan
        {
            get => luongCoBan;
            set
            {
                if (value > 0)
                    luongCoBan = value;
                else
                    luongCoBan = 0;
            }
        }

        // Constructor khởi tạo thông tin
        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.LuongCoBan = luongCoBan;
        }

        // Phương thức ảo tính lương (Virtual method) - Cho phép lớp con ghi đè đa hình
        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        // Phương thức ảo hiển thị thông tin
        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"[Nhân viên] Mã: {MaNV,-8} | Họ tên: {HoTen,-20} | Lương CB: {LuongCoBan,12:N0} VNĐ | Thực lĩnh: {TinhLuong(),12:N0} VNĐ");
        }
    }
}
