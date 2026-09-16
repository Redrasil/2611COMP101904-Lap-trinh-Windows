using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font chữ hiển thị tiếng Việt UTF-8 trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Danh sách đa hình chứa các đối tượng kế thừa từ NhanVien
            List<NhanVien> danhSach = new List<NhanVien>();

            // Khởi tạo sẵn dữ liệu mẫu (ít nhất 5 nhân viên theo yêu cầu)
            KhoiTaoDuLieuMau(danhSach);

            int luaChon;
            do
            {
                HienThiMenu();
                Console.Write("Nhập lựa chọn của bạn (0 - 5): ");

                if (!int.TryParse(Console.ReadLine(), out luaChon))
                {
                    luaChon = -1;
                }

                Console.WriteLine(new string('-', 95));

                switch (luaChon)
                {
                    case 1:
                        XuatDanhSachNhanVien(danhSach);
                        break;
                    case 2:
                        TimNhanVienTheoMa(danhSach);
                        break;
                    case 3:
                        TimNhanVienLuongCaoNhat(danhSach);
                        break;
                    case 4:
                        TinhTongLuongCongTy(danhSach);
                        break;
                    case 5:
                        NhapThemNhanVien(danhSach);
                        break;
                    case 0:
                        Console.WriteLine("Đã thoát chương trình. Cảm ơn bạn đã sử dụng hệ thống!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn từ 0 đến 5.");
                        break;
                }

                Console.WriteLine(new string('-', 95));
                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (luaChon != 0);
        }

        /// <summary>
        /// Hiển thị Menu chức năng của chương trình
        /// </summary>
        static void HienThiMenu()
        {
            Console.WriteLine("======================= MENU QUẢN LÝ NHÂN VIÊN =======================");
            Console.WriteLine("1. Xuất danh sách nhân viên");
            Console.WriteLine("2. Tìm nhân viên theo mã");
            Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("4. Tính tổng lương công ty phải trả");
            Console.WriteLine("5. Nhập thêm nhân viên mới");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("======================================================================");
        }

        /// <summary>
        /// Khởi tạo sẵn ít nhất 5 nhân viên mẫu
        /// </summary>
        static void KhoiTaoDuLieuMau(List<NhanVien> danhSach)
        {
            danhSach.Add(new NhanVienVanPhong("VP001", "Nguyễn Văn An", 5000000, 24));
            danhSach.Add(new NhanVienVanPhong("VP002", "Trần Thị Bình", 6000000, 26));
            danhSach.Add(new NhanVienKinhDoanh("KD001", "Lê Hoàng Cường", 4500000, 80000000));
            danhSach.Add(new NhanVienKinhDoanh("KD002", "Phạm Ngọc Dung", 4000000, 150000000));
            danhSach.Add(new NhanVienVanPhong("VP003", "Đỗ Minh Em", 5500000, 20));
            // Nhân viên thời vụ (Bonus)
            danhSach.Add(new NhanVienThoiVu("TV001", "Vũ Quốc Phong", 80, 50000));
        }

        /// <summary>
        /// Chức năng 1: Xuất danh sách nhân viên
        /// Yêu cầu: Sử dụng đa hình thông qua HienThiThongTin(). Tuyệt đối không dùng if/switch check loại.
        /// </summary>
        static void XuatDanhSachNhanVien(List<NhanVien> danhSach)
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên đang trống!");
                return;
            }

            Console.WriteLine($"--- DANH SÁCH NHÂN VIÊN (Tổng số: {danhSach.Count}) ---");
            // Áp dụng tính ĐA HÌNH: Mỗi đối tượng tự gọi đúng phương thức HienThiThongTin() của nó
            foreach (NhanVien nv in danhSach)
            {
                nv.HienThiThongTin();
            }
        }

        /// <summary>
        /// Chức năng 2: Tìm nhân viên theo mã
        /// </summary>
        static void TimNhanVienTheoMa(List<NhanVien> danhSach)
        {
            Console.Write("Nhập mã nhân viên cần tìm: ");
            string maTim = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(maTim))
            {
                Console.WriteLine("Mã nhân viên không được để trống!");
                return;
            }

            bool timThay = false;
            foreach (NhanVien nv in danhSach)
            {
                if (string.Equals(nv.MaNV, maTim, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n--> Tìm thấy nhân viên:");
                    nv.HienThiThongTin();
                    timThay = true;
                    break;
                }
            }

            if (!timThay)
            {
                Console.WriteLine($"\n--> Không tìm thấy nhân viên nào có mã: {maTim}");
            }
        }

        /// <summary>
        /// Chức năng 3: Tìm nhân viên có lương cao nhất
        /// Yêu cầu: Sử dụng đa hình TinhLuong(). Thuật toán không đổi khi có thêm loại nhân viên mới.
        /// </summary>
        static void TimNhanVienLuongCaoNhat(List<NhanVien> danhSach)
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên đang trống!");
                return;
            }

            // Tìm nhân viên có lương cao nhất dựa vào phương thức ảo TinhLuong()
            NhanVien nvMax = danhSach[0];
            for (int i = 1; i < danhSach.Count; i++)
            {
                if (danhSach[i].TinhLuong() > nvMax.TinhLuong())
                {
                    nvMax = danhSach[i];
                }
            }

            Console.WriteLine("--- NHÂN VIÊN CÓ LƯƠNG CAO NHẤT ---");
            nvMax.HienThiThongTin();
        }

        /// <summary>
        /// Chức năng 4: Tính tổng lương công ty phải trả
        /// Yêu cầu: Sử dụng đa hình TinhLuong(). Tuyệt đối không dùng if/switch kiểm tra loại.
        /// </summary>
        static void TinhTongLuongCongTy(List<NhanVien> danhSach)
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên đang trống!");
                return;
            }

            double tongLuong = 0;
            // ĐA HÌNH: Tính lương tự động kích hoạt TinhLuong() của đúng lớp con tương ứng
            foreach (NhanVien nv in danhSach)
            {
                tongLuong += nv.TinhLuong();
            }

            Console.WriteLine($"--- TỔNG LƯƠNG CÔNG TY PHẢI TRẢ ---");
            Console.WriteLine($"Số lượng nhân viên: {danhSach.Count}");
            Console.WriteLine($"Tổng chi phí lương: {tongLuong:N0} VNĐ");
        }

        /// <summary>
        /// Chức năng 5: Nhập thêm nhân viên mới từ bàn phím
        /// </summary>
        static void NhapThemNhanVien(List<NhanVien> danhSach)
        {
            Console.WriteLine("Chọn loại nhân viên cần thêm:");
            Console.WriteLine("1. Nhân viên Văn Phòng");
            Console.WriteLine("2. Nhân viên Kinh Doanh");
            Console.WriteLine("3. Nhân viên Thời Vụ (Bonus)");
            Console.Write("Lựa chọn (1-3): ");

            if (!int.TryParse(Console.ReadLine(), out int loaiNV) || loaiNV < 1 || loaiNV > 3)
            {
                Console.WriteLine("Lựa chọn loại nhân viên không hợp lệ!");
                return;
            }

            Console.Write("Nhập mã nhân viên: ");
            string maNV = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Nhập họ tên: ");
            string hoTen = Console.ReadLine()?.Trim() ?? "";

            switch (loaiNV)
            {
                case 1:
                    Console.Write("Nhập lương cơ bản (> 0): ");
                    double.TryParse(Console.ReadLine(), out double lcbVP);
                    Console.Write("Nhập số ngày làm việc (0 - 31): ");
                    int.TryParse(Console.ReadLine(), out int soNgay);
                    danhSach.Add(new NhanVienVanPhong(maNV, hoTen, lcbVP, soNgay));
                    Console.WriteLine("--> Thêm nhân viên Văn Phòng thành công!");
                    break;

                case 2:
                    Console.Write("Nhập lương cơ bản (> 0): ");
                    double.TryParse(Console.ReadLine(), out double lcbKD);
                    Console.Write("Nhập doanh số bán hàng (>= 0): ");
                    double.TryParse(Console.ReadLine(), out double doanhSo);
                    danhSach.Add(new NhanVienKinhDoanh(maNV, hoTen, lcbKD, doanhSo));
                    Console.WriteLine("--> Thêm nhân viên Kinh Doanh thành công!");
                    break;

                case 3:
                    Console.Write("Nhập số giờ làm việc (>= 0): ");
                    double.TryParse(Console.ReadLine(), out double soGio);
                    Console.Write("Nhập lương theo giờ (>= 0): ");
                    double.TryParse(Console.ReadLine(), out double luongGio);
                    danhSach.Add(new NhanVienThoiVu(maNV, hoTen, soGio, luongGio));
                    Console.WriteLine("--> Thêm nhân viên Thời Vụ thành công!");
                    break;
            }
        }
    }
}
