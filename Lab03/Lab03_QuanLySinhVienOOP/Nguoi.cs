using System;

namespace Lab03_QuanLySinhVienOOP
{
    /// <summary>
    /// Lớp cha cơ sở quản lý thông tin chung của Người
    /// </summary>
    public class Nguoi
    {
        // Các trường dữ liệu (Fields)
        private string hoTen = string.Empty;
        private DateTime ngaySinh;

        // Các thuộc tính (Properties)
        public string HoTen
        {
            get => hoTen;
            set => hoTen = string.IsNullOrWhiteSpace(value) ? "Chưa có tên" : value.Trim();
        }

        public DateTime NgaySinh
        {
            get => ngaySinh;
            set => ngaySinh = value;
        }

        // Constructor không tham số
        public Nguoi()
        {
            HoTen = string.Empty;
            NgaySinh = DateTime.MinValue;
        }

        // Constructor có tham số
        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        /// <summary>
        /// Phương thức ảo lấy thông tin - cho phép lớp con override
        /// </summary>
        /// <returns>Chuỗi thông tin đối tượng</returns>
        public virtual string LayThongTin()
        {
            return $"Họ tên: {HoTen,-20} | Ngày sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}
