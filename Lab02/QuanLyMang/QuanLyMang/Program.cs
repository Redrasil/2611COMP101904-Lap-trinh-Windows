using System;

namespace QuanLyMang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font chữ hiển thị tiếng Việt UTF-8 trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int[] arr = null; // Khởi tạo mảng ban đầu chưa có dữ liệu
            int luaChon;

            do
            {
                // 1. Hiển thị Menu
                Console.WriteLine("\n===== MENU QUẢN LÝ MẢNG SỐ NGUYÊN =====");
                Console.WriteLine("1. Nhap mang");
                Console.WriteLine("2. Xuat mang");
                Console.WriteLine("3. Tinh tong");
                Console.WriteLine("4. Tim max/min");
                Console.WriteLine("5. Dem chan/le");
                Console.WriteLine("6. Sap xep tang dan");
                Console.WriteLine("7. Tim kiem");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("========================================");
                luaChon = NhapSoNguyen("Chon chuc nang: ");

                // 2. Kiểm tra điều kiện: Nếu chưa nhập mảng mà chọn chức năng 2 -> 7 thì yêu cầu nhập trước
                if (luaChon >= 2 && luaChon <= 7 && (arr == null || arr.Length == 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lỗi: Bạn chưa nhập mảng! Vui lòng chọn chức năng 1 để nhập mảng trước.");
                    Console.ResetColor();
                    continue;
                }

                // 3. Xử lý chức năng người dùng chọn
                switch (luaChon)
                {
                    case 1:
                        Console.WriteLine("\n--- 1. NHẬP MẢNG ---");
                        arr = NhapMang();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Đã nhập mảng thành công!");
                        Console.ResetColor();
                        break;

                    case 2:
                        Console.WriteLine("\n--- 2. XUẤT MẢNG ---");
                        Console.Write("Mảng hiện tại: ");
                        XuatMang(arr);
                        break;

                    case 3:
                        Console.WriteLine("\n--- 3. TÍNH TỔNG CÁC PHẦN TỬ ---");
                        int tong = TinhTong(arr);
                        Console.WriteLine($"Tổng các phần tử trong mảng = {tong}");
                        break;

                    case 4:
                        Console.WriteLine("\n--- 4. TÌM GIÁ TRỊ LỚN NHẤT VÀ NHỎ NHẤT ---");
                        int max = TimMax(arr);
                        int min = TimMin(arr);
                        Console.WriteLine($"Giá trị lớn nhất (Max) = {max}");
                        Console.WriteLine($"Giá trị nhỏ nhất (Min) = {min}");
                        break;

                    case 5:
                        Console.WriteLine("\n--- 5. ĐẾM SỐ LƯỢNG CHẴN / LẺ ---");
                        int soChan = DemChan(arr);
                        int soLe = DemLe(arr);
                        Console.WriteLine($"Số lượng phần tử chẵn = {soChan}");
                        Console.WriteLine($"Số lượng phần tử lẻ   = {soLe}");
                        break;

                    case 6:
                        Console.WriteLine("\n--- 6. SẮP XẾP TĂNG DẦN ---");
                        SapXepTangDan(arr);
                        Console.Write("Mảng sau khi sắp xếp tăng dần: ");
                        XuatMang(arr);
                        break;

                    case 7:
                        Console.WriteLine("\n--- 7. TÌM KIẾM PHẦN TỬ ---");
                        int x = NhapSoNguyen("Nhập giá trị x cần tìm: ");
                        int viTri = TimKiem(arr, x);
                        if (viTri != -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Tìm thấy giá trị {x} tại vị trí đầu tiên (index từ 0) là: {viTri}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Không tìm thấy giá trị {x} trong mảng.");
                            Console.ResetColor();
                        }
                        break;

                    case 0:
                        Console.WriteLine("\nĐang thoát chương trình... Tạm biệt!");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn từ 0 đến 7.");
                        Console.ResetColor();
                        break;
                }

            } while (luaChon != 0);
        }

        #region Các Phương Thức Nhập Xuất & Kiểm Tra Dữ Liệu

        // Hàm nhập số nguyên an toàn, không bị crash khi nhập chữ
        static int NhapSoNguyen(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dữ liệu không hợp lệ! Vui lòng nhập một số nguyên.");
                Console.ResetColor();
            }
        }

        // Hàm nhập số lượng phần tử n > 0 (nguyên dương)
        static int NhapSoNguyenDuong(string message)
        {
            int value;
            while (true)
            {
                value = NhapSoNguyen(message);
                if (value > 0)
                {
                    return value;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Số lượng phần tử phải là số nguyên dương (> 0). Vui lòng nhập lại!");
                Console.ResetColor();
            }
        }

        // Hàm nhập mảng số nguyên
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhập số lượng phần tử n (n > 0): ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhập phần tử a[{i}]: ");
            }
            return a;
        }

        // Hàm in toàn bộ phần tử mảng ra màn hình
        static void XuatMang(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                Console.WriteLine("(Mảng rỗng)");
                return;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + (i < a.Length - 1 ? " " : "\n"));
            }
        }

        #endregion

        #region Các Phương Thức Xử Lý Nghiệp Vụ Mảng

        // Hàm tính tổng các phần tử
        static int TinhTong(int[] a)
        {
            int tong = 0;
            foreach (int item in a)
            {
                tong += item;
            }
            return tong;
        }

        // Hàm tìm giá trị lớn nhất
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }

        // Hàm tìm giá trị nhỏ nhất
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        // Hàm đếm số phần tử chẵn
        static int DemChan(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        // Hàm đếm số phần tử lẻ
        static int DemLe(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 != 0)
                {
                    count++;
                }
            }
            return count;
        }

        // Hàm sắp xếp mảng tăng dần
        static void SapXepTangDan(int[] a)
        {
            // Sử dụng thuật toán Bubble Sort hoặc Array.Sort(a)
            Array.Sort(a);
        }

        // Hàm tìm kiếm giá trị x, trả về chỉ số đầu tiên hoặc -1
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                {
                    return i; // Tìm thấy tại index i
                }
            }
            return -1; // Không tìm thấy
        }

        #endregion
    }
}
