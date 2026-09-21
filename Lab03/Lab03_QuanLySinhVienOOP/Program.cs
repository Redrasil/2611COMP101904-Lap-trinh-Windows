using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab03_QuanLySinhVienOOP
{
    internal class Program
    {
        private static readonly QuanLySinhVien qlsv = new QuanLySinhVien();

        static void Main(string[] args)
        {
            // Thiết lập console hỗ trợ tiếng Việt có dấu Unicode UTF-8
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Nạp dữ liệu mẫu ban đầu để thuận tiện chạy thử và chấm điểm
            qlsv.KhoiTaoDuLieuMau();

            int luaChon;
            do
            {
                HienThiMenu();
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out luaChon))
                {
                    luaChon = -1;
                }

                Console.WriteLine();

                switch (luaChon)
                {
                    case 1:
                        XuLyThemSinhVien();
                        break;
                    case 2:
                        XuLyXuatDanhSach();
                        break;
                    case 3:
                        XuLyTimTheoMa();
                        break;
                    case 4:
                        XuLyTimTheoTen();
                        break;
                    case 5:
                        XuLySuaDiem();
                        break;
                    case 6:
                        XuLyXoaSinhVien();
                        break;
                    case 7:
                        XuLySapXepTheoDiem();
                        break;
                    case 8:
                        XuLyLocSinhVienDat();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình! Tạm biệt.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn từ 0 đến 8.");
                        Console.ResetColor();
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine();
                    if (!Console.IsInputRedirected)
                    {
                        Console.Write("Nhấn phím bất kỳ để quay lại menu...");
                        try { Console.ReadKey(); } catch { }
                        try { Console.Clear(); } catch { }
                    }
                }

            } while (luaChon != 0);
        }

        /// <summary>
        /// Hiển thị Menu chính theo đúng chuẩn yêu cầu đề bài
        /// </summary>
        static void HienThiMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
            Console.ResetColor();
        }

        /// <summary>
        /// Chức năng 1: Thêm mới một sinh viên với đầy đủ validation
        /// </summary>
        static void XuLyThemSinhVien()
        {
            Console.WriteLine("--- 1. THÊM SINH VIÊN MỚI ---");

            // 1. Nhập và kiểm tra mã sinh viên (không được rỗng, không được trùng)
            string maSV;
            while (true)
            {
                Console.Write("Nhập mã sinh viên: ");
                maSV = (Console.ReadLine() ?? string.Empty).Trim();

                if (string.IsNullOrWhiteSpace(maSV))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mã sinh viên không được để trống! Vui lòng nhập lại.");
                    Console.ResetColor();
                    continue;
                }

                if (qlsv.KiemTraTonTai(maSV))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Mã sinh viên '{maSV}' đã tồn tại trong danh sách! Không thể thêm.");
                    Console.ResetColor();
                    return;
                }

                break;
            }

            // 2. Nhập họ tên (không được rỗng)
            string hoTen;
            while (true)
            {
                Console.Write("Nhập họ và tên: ");
                hoTen = (Console.ReadLine() ?? string.Empty).Trim();

                if (!string.IsNullOrWhiteSpace(hoTen))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Họ tên không được để trống! Vui lòng nhập lại.");
                Console.ResetColor();
            }

            // 3. Nhập ngày sinh (kiểm tra định dạng dd/MM/yyyy)
            DateTime ngaySinh;
            while (true)
            {
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                string inputNgaySinh = (Console.ReadLine() ?? string.Empty).Trim();

                if (DateTime.TryParseExact(inputNgaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                {
                    if (ngaySinh.Year >= 1900 && ngaySinh <= DateTime.Now)
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ngày sinh không hợp lệ hoặc sai định dạng dd/MM/yyyy! Vui lòng nhập lại.");
                Console.ResetColor();
            }

            // 4. Nhập mã lớp (không được rỗng)
            string maLop;
            while (true)
            {
                Console.Write("Nhập mã lớp: ");
                maLop = (Console.ReadLine() ?? string.Empty).Trim();

                if (!string.IsNullOrWhiteSpace(maLop))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mã lớp không được để trống! Vui lòng nhập lại.");
                Console.ResetColor();
            }

            // 5. Nhập điểm trung bình (kiểm tra kiểu số thực và trong đoạn 0 - 10)
            double diemTB = NhapDiemTrungBinh();

            // Khởi tạo đối tượng SinhVien và thêm vào danh sách
            var svMoi = new SinhVien(maSV, hoTen, ngaySinh, maLop, diemTB);
            bool kq = qlsv.Them(svMoi);

            if (kq)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nThêm sinh viên thành công! Xếp loại: {svMoi.XepLoai()}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThêm sinh viên thất bại!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Chức năng 2: Xuất toàn bộ danh sách sinh viên
        /// </summary>
        static void XuLyXuatDanhSach()
        {
            Console.WriteLine("--- 2. DANH SÁCH SINH VIÊN ---");
            var ds = qlsv.LayDanhSach();
            InBangSinhVien(ds);
        }

        /// <summary>
        /// Chức năng 3: Tìm kiếm sinh viên theo mã
        /// </summary>
        static void XuLyTimTheoMa()
        {
            Console.WriteLine("--- 3. TÌM SINH VIÊN THEO MÃ ---");
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string maSV = (Console.ReadLine() ?? string.Empty).Trim();

            var sv = qlsv.TimTheoMa(maSV);
            if (sv != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nĐã tìm thấy sinh viên:");
                Console.ResetColor();
                InBangSinhVien(new List<SinhVien> { sv });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nKhông tìm thấy sinh viên có mã '{maSV}'.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Chức năng 4: Tìm kiếm sinh viên theo từ khóa họ tên
        /// </summary>
        static void XuLyTimTheoTen()
        {
            Console.WriteLine("--- 4. TÌM SINH VIÊN THEO TÊN ---");
            Console.Write("Nhập từ khóa họ tên cần tìm: ");
            string tuKhoa = (Console.ReadLine() ?? string.Empty).Trim();

            var ketQua = qlsv.TimTheoTen(tuKhoa);
            if (ketQua.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nTìm thấy {ketQua.Count} sinh viên phù hợp với từ khóa '{tuKhoa}':");
                Console.ResetColor();
                InBangSinhVien(ketQua);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nKhông tìm thấy sinh viên nào có tên chứa từ khóa '{tuKhoa}'.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Chức năng 5: Cập nhật điểm trung bình của sinh viên
        /// </summary>
        static void XuLySuaDiem()
        {
            Console.WriteLine("--- 5. SỬA ĐIỂM TRUNG BÌNH ---");
            Console.Write("Nhập mã sinh viên cần sửa điểm: ");
            string maSV = (Console.ReadLine() ?? string.Empty).Trim();

            var sv = qlsv.TimTheoMa(maSV);
            if (sv == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nKhông tìm thấy sinh viên có mã '{maSV}'.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"Sinh viên tìm thấy: {sv.HoTen} | Điểm hiện tại: {sv.DiemTrungBinh:F1}");
            Console.WriteLine("Nhập điểm trung bình mới:");
            double diemMoi = NhapDiemTrungBinh();

            bool kq = qlsv.SuaDiem(maSV, diemMoi);
            if (kq)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nCập nhật điểm thành công cho sinh viên '{sv.HoTen}'! Điểm mới: {sv.DiemTrungBinh:F1} | Xếp loại mới: {sv.XepLoai()}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCập nhật điểm thất bại!");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Chức năng 6: Xóa sinh viên khỏi danh sách theo mã
        /// </summary>
        static void XuLyXoaSinhVien()
        {
            Console.WriteLine("--- 6. XÓA SINH VIÊN ---");
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string maSV = (Console.ReadLine() ?? string.Empty).Trim();

            var sv = qlsv.TimTheoMa(maSV);
            if (sv == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nKhông tìm thấy sinh viên có mã '{maSV}'.");
                Console.ResetColor();
                return;
            }

            Console.Write($"Bạn có chắc chắn muốn xóa sinh viên '{sv.HoTen}' (Mã: {sv.MaSinhVien})? (y/n): ");
            string xacNhan = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

            if (xacNhan == "y" || xacNhan == "yes" || xacNhan == "co")
            {
                bool kq = qlsv.Xoa(maSV);
                if (kq)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nĐã xóa thành công sinh viên có mã '{maSV}' khỏi danh sách.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nXóa thất bại!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nĐã hủy thao tác xóa.");
            }
        }

        /// <summary>
        /// Chức năng 7: Sắp xếp danh sách theo điểm giảm dần và in ra màn hình
        /// </summary>
        static void XuLySapXepTheoDiem()
        {
            Console.WriteLine("--- 7. SẮP XẾP DANH SÁCH THEO ĐIỂM GIẢM DẦN ---");
            var dsSapXep = qlsv.SapXepTheoDiemGiamDan();
            InBangSinhVien(dsSapXep);
        }

        /// <summary>
        /// Chức năng 8: Lọc và in danh sách sinh viên đạt (điểm TB >= 5.0)
        /// </summary>
        static void XuLyLocSinhVienDat()
        {
            Console.WriteLine("--- 8. DANH SÁCH SINH VIÊN ĐẠT (ĐIỂM TB >= 5.0) ---");
            var dsDat = qlsv.LocSinhVienDat();
            InBangSinhVien(dsDat);
        }

        /// <summary>
        /// Hàm bổ trợ nhập điểm trung bình an toàn (0 - 10), bắt lỗi ép kiểu và ngoài khoảng
        /// </summary>
        static double NhapDiemTrungBinh()
        {
            double diem;
            while (true)
            {
                Console.Write("Nhập điểm trung bình (0.0 - 10.0): ");
                string input = Console.ReadLine() ?? string.Empty;

                // Chuẩn hóa dấu chấm và dấu phẩy thập phân
                input = input.Replace(',', '.');

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out diem))
                {
                    if (diem >= 0.0 && diem <= 10.0)
                    {
                        return diem;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Điểm không hợp lệ! Điểm phải là số từ 0 đến 10. Vui lòng nhập lại.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// In danh sách sinh viên dưới dạng bảng trực quan, căn chỉnh chuẩn
        /// </summary>
        static void InBangSinhVien(List<SinhVien> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Danh sách sinh viên hiện đang trống.");
                Console.ResetColor();
                return;
            }

            string duongKe = new string('-', 88);
            Console.WriteLine(duongKe);
            Console.WriteLine($"| {"STT",-4} | {"MÃ SV",-8} | {"HỌ VÀ TÊN",-22} | {"NGÀY SINH",-10} | {"LỚP",-10} | {"ĐTB",-5} | {"XẾP LOẠI",-10} |");
            Console.WriteLine(duongKe);

            int stt = 1;
            foreach (var sv in danhSach)
            {
                Console.WriteLine($"| {stt++,-4} | {sv.MaSinhVien,-8} | {sv.HoTen,-22} | {sv.NgaySinh:dd/MM/yyyy} | {sv.MaLop,-10} | {sv.DiemTrungBinh,5:F1} | {sv.XepLoai(),-10} |");
            }

            Console.WriteLine(duongKe);
            Console.WriteLine($"Tổng số sinh viên: {danhSach.Count}");
        }
    }
}
