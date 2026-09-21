using System;

namespace Lab03_QuanLySinhVienOOP
{
    /// <summary>
    /// Lớp SinhVien kế thừa từ lớp Nguoi
    /// </summary>
    public class SinhVien : Nguoi
    {
        // Các trường dữ liệu riêng (Fields)
        private string maSinhVien = string.Empty;
        private string maLop = string.Empty;
        private double diemTrungBinh;

        // Thuộc tính Mã sinh viên
        public string MaSinhVien
        {
            get => maSinhVien;
            set => maSinhVien = value?.Trim() ?? string.Empty;
        }

        // Thuộc tính Mã lớp
        public string MaLop
        {
            get => maLop;
            set => maLop = value?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Thuộc tính Điểm trung bình có kiểm tra ràng buộc giá trị từ 0 đến 10
        /// </summary>
        public double DiemTrungBinh
        {
            get => diemTrungBinh;
            set
            {
                if (value < 0.0 || value > 10.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Điểm trung bình chỉ nhận giá trị từ 0 đến 10.");
                }
                diemTrungBinh = Math.Round(value, 2);
            }
        }

        // Constructor không tham số
        public SinhVien() : base()
        {
            MaSinhVien = string.Empty;
            MaLop = string.Empty;
            DiemTrungBinh = 0;
        }

        // Constructor có tham số đầy đủ
        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        /// <summary>
        /// Xếp loại học lực dựa trên điểm trung bình
        /// </summary>
        /// <returns>Chuỗi xếp loại: Xuất sắc, Giỏi, Khá, Trung bình, Yếu</returns>
        public string XepLoai()
        {
            if (DiemTrungBinh >= 9.0)
                return "Xuất sắc";
            if (DiemTrungBinh >= 8.0)
                return "Giỏi";
            if (DiemTrungBinh >= 6.5)
                return "Khá";
            if (DiemTrungBinh >= 5.0)
                return "Trung bình";
            return "Yếu";
        }

        /// <summary>
        /// Kiểm tra sinh viên có đạt yêu cầu (điểm trung bình >= 5.0) hay không
        /// </summary>
        public bool LaSinhVienDat()
        {
            return DiemTrungBinh >= 5.0;
        }

        /// <summary>
        /// Ghi đè (override) phương thức LayThongTin của lớp Nguoi
        /// </summary>
        /// <returns>Chuỗi thông tin chi tiết sinh viên</returns>
        public override string LayThongTin()
        {
            return $"Mã SV: {MaSinhVien,-8} | Họ tên: {HoTen,-20} | Ngày sinh: {NgaySinh:dd/MM/yyyy} | Lớp: {MaLop,-10} | ĐTB: {DiemTrungBinh,4:F1} | Xếp loại: {XepLoai()}";
        }

        public override string ToString()
        {
            return LayThongTin();
        }
    }
}
