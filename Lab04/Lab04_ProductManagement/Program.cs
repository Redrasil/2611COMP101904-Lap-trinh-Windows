using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Lab04_ProductManagement.Exceptions;
using Lab04_ProductManagement.Services;

namespace Lab04_ProductManagement
{
    internal class Program
    {
        private static readonly ProductService _productService = new ProductService();

        static void Main(string[] args)
        {
            // Thiết lập hiển thị bảng mã ký tự tiếng Việt Unicode UTF-8
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Đăng ký nhận sự kiện (Event Subscriptions) từ ProductService
            _productService.OnProductAdded += HandleProductAddedEvent;
            _productService.OnProductRemoved += HandleProductRemovedEvent;

            // Khởi tạo dữ liệu mẫu sẵn có để tiện cho việc chấm điểm và kiểm thử chức năng
            _productService.SeedSampleData();

            int choice;
            do
            {
                DisplayMenu();
                Console.Write("Chon: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ExecuteAddProduct();
                        break;
                    case 2:
                        ExecuteListProducts();
                        break;
                    case 3:
                        ExecuteFindById();
                        break;
                    case 4:
                        ExecuteSearchByName();
                        break;
                    case 5:
                        ExecuteFilterByPrice();
                        break;
                    case 6:
                        ExecuteRemoveProduct();
                        break;
                    case 7:
                        ExecuteCalculateTotalValue();
                        break;
                    case 0:
                        PrintColored("Đang thoát chương trình. Cảm ơn bạn đã sử dụng!", ConsoleColor.Green);
                        break;
                    default:
                        PrintColored("Lựa chọn không hợp lệ! Vui lòng chọn các số từ 0 đến 7.", ConsoleColor.Red);
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine();
                    if (!Console.IsInputRedirected)
                    {
                        Console.Write("Nhấn phím bất kỳ để tiếp tục...");
                        try { Console.ReadKey(); } catch { }
                        try { Console.Clear(); } catch { }
                    }
                }

            } while (choice != 0);
        }

        #region Event Handlers
        /// <summary>
        /// Xử lý sự kiện khi có sản phẩm được thêm mới thành công.
        /// </summary>
        private static void HandleProductAddedEvent(Product product)
        {
            PrintColored($"🔔 [SỰ KIỆN - THÊM THÀNH CÔNG] Đã thêm sản phẩm: [{product.MaSP}] {product.TenSP} - Đơn giá: {FormatCurrency(product.Price)} - SL: {product.Quantity}", ConsoleColor.Cyan);
        }

        /// <summary>
        /// Xử lý sự kiện khi có sản phẩm bị xóa thành công.
        /// </summary>
        private static void HandleProductRemovedEvent(Product product)
        {
            PrintColored($"🔔 [SỰ KIỆN - XÓA THÀNH CÔNG] Đã xóa sản phẩm: [{product.MaSP}] {product.TenSP} khỏi danh sách!", ConsoleColor.Yellow);
        }
        #endregion

        #region Menu & UI
        /// <summary>
        /// Hiển thị Menu chính theo đúng chuẩn yêu cầu đề bài Lab04.
        /// </summary>
        private static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===== PRODUCT MANAGER =====");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim theo ma");
            Console.WriteLine("4. Tim theo ten");
            Console.WriteLine("5. Loc theo khoang gia");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Tinh tong gia tri kho");
            Console.WriteLine("0. Thoat");
            Console.ResetColor();
        }

        /// <summary>
        /// Chức năng 1: Thêm sản phẩm mới với xử lý DuplicateProductException.
        /// </summary>
        private static void ExecuteAddProduct()
        {
            PrintSectionHeader("1. THÊM SẢN PHẨM MỚI");

            string maSP = ReadNonEmptyString("Nhập mã sản phẩm: ");
            string tenSP = ReadNonEmptyString("Nhập tên sản phẩm: ");
            decimal price = ReadNonNegativeDecimal("Nhập đơn giá (VND): ");
            int quantity = ReadNonNegativeInt("Nhập số lượng: ");

            try
            {
                var product = new Product(maSP, tenSP, price, quantity);
                _productService.AddProduct(product);
                PrintColored("=> Thêm sản phẩm hoàn tất!", ConsoleColor.Green);
            }
            catch (DuplicateProductException ex)
            {
                PrintColored($"❌ LỖI TRÙNG MÃ: {ex.Message}", ConsoleColor.Red);
                if (!string.IsNullOrEmpty(ex.ProductId))
                {
                    PrintColored($"   (Mã sản phẩm đã tồn tại: {ex.ProductId})", ConsoleColor.DarkYellow);
                }
            }
            catch (ArgumentException ex)
            {
                PrintColored($"❌ LỖI DỮ LIỆU: {ex.Message}", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                PrintColored($"❌ LỖI HỆ THỐNG: {ex.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Chức năng 2: Xuất danh sách sản phẩm dạng bảng biểu.
        /// </summary>
        private static void ExecuteListProducts()
        {
            PrintSectionHeader("2. DANH SÁCH TOÀN BỘ SẢN PHẨM TRONG KHO");

            var products = _productService.GetAll();
            RenderProductTable(products);
        }

        /// <summary>
        /// Chức năng 3: Tìm sản phẩm theo mã với xử lý ProductNotFoundException.
        /// </summary>
        private static void ExecuteFindById()
        {
            PrintSectionHeader("3. TÌM KIẾM SẢN PHẨM THEO MÃ");

            string maSP = ReadNonEmptyString("Nhập mã sản phẩm cần tìm: ");

            try
            {
                var product = _productService.GetById(maSP);
                PrintColored("=> Đã tìm thấy sản phẩm:", ConsoleColor.Green);
                RenderProductTable(new List<Product> { product });
            }
            catch (ProductNotFoundException ex)
            {
                PrintColored($"❌ KHÔNG TÌM THẤY: {ex.Message}", ConsoleColor.Red);
                if (!string.IsNullOrEmpty(ex.ProductId))
                {
                    PrintColored($"   (Mã sản phẩm không tồn tại: {ex.ProductId})", ConsoleColor.DarkYellow);
                }
            }
            catch (Exception ex)
            {
                PrintColored($"❌ LỖI: {ex.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Chức năng 4: Tìm sản phẩm theo tên sử dụng Func predicate.
        /// </summary>
        private static void ExecuteSearchByName()
        {
            PrintSectionHeader("4. TÌM KIẾM SẢN PHẨM THEO TÊN (SỬ DỤNG FUNC)");

            string keyword = ReadNonEmptyString("Nhập từ khóa tên sản phẩm: ");

            var matches = _productService.Search(keyword).ToList();
            if (!matches.Any())
            {
                PrintColored($"Không tìm thấy sản phẩm nào có tên chứa từ khóa: '{keyword}'", ConsoleColor.Yellow);
            }
            else
            {
                PrintColored($"Tìm thấy {matches.Count} sản phẩm phù hợp với từ khóa '{keyword}':", ConsoleColor.Green);
                RenderProductTable(matches);
            }
        }

        /// <summary>
        /// Chức năng 5: Lọc sản phẩm theo khoảng giá qua Func&lt;Product, bool&gt;.
        /// </summary>
        private static void ExecuteFilterByPrice()
        {
            PrintSectionHeader("5. LỌC SẢN PHẨM THEO KHOẢNG GIÁ (FUNC<PRODUCT, BOOL>)");

            decimal minPrice;
            decimal maxPrice;

            while (true)
            {
                minPrice = ReadNonNegativeDecimal("Nhập giá tối thiểu (Min VND): ");
                maxPrice = ReadNonNegativeDecimal("Nhập giá tối đa (Max VND): ");

                if (minPrice <= maxPrice)
                    break;

                PrintColored("Giá tối thiểu không được lớn hơn giá tối đa! Vui lòng nhập lại.", ConsoleColor.Red);
            }

            try
            {
                var filtered = _productService.FilterByPrice(minPrice, maxPrice).ToList();
                if (!filtered.Any())
                {
                    PrintColored($"Không có sản phẩm nào trong khoảng giá từ {FormatCurrency(minPrice)} đến {FormatCurrency(maxPrice)}.", ConsoleColor.Yellow);
                }
                else
                {
                    PrintColored($"Tìm thấy {filtered.Count} sản phẩm trong khoảng giá từ {FormatCurrency(minPrice)} đến {FormatCurrency(maxPrice)}:", ConsoleColor.Green);
                    RenderProductTable(filtered);
                }
            }
            catch (Exception ex)
            {
                PrintColored($"❌ LỖI LỌC DỮ LIỆU: {ex.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Chức năng 6: Xóa sản phẩm theo mã với xử lý ProductNotFoundException và kích hoạt Event.
        /// </summary>
        private static void ExecuteRemoveProduct()
        {
            PrintSectionHeader("6. XÓA SẢN PHẨM THEO MÃ");

            string maSP = ReadNonEmptyString("Nhập mã sản phẩm cần xóa: ");

            try
            {
                // Kiểm tra trước thông tin sản phẩm cần xóa để xác nhận
                var existing = _productService.GetById(maSP);
                Console.Write($"Bạn có chắc chắn muốn xóa sản phẩm [{existing.MaSP} - {existing.TenSP}]? (y/n): ");
                string confirm = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

                if (confirm == "y" || confirm == "yes")
                {
                    _productService.RemoveProduct(maSP);
                    PrintColored("=> Đã thực hiện xóa sản phẩm thành công!", ConsoleColor.Green);
                }
                else
                {
                    PrintColored("=> Hủy bỏ thao tác xóa sản phẩm.", ConsoleColor.DarkGray);
                }
            }
            catch (ProductNotFoundException ex)
            {
                PrintColored($"❌ KHÔNG TÌM THẤY: {ex.Message}", ConsoleColor.Red);
                if (!string.IsNullOrEmpty(ex.ProductId))
                {
                    PrintColored($"   (Mã sản phẩm không tồn tại: {ex.ProductId})", ConsoleColor.DarkYellow);
                }
            }
            catch (Exception ex)
            {
                PrintColored($"❌ LỖI XÓA SẢN PHẨM: {ex.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Chức năng 7: Tính và hiển thị tổng giá trị kho hàng.
        /// </summary>
        private static void ExecuteCalculateTotalValue()
        {
            PrintSectionHeader("7. TÍNH TỔNG GIÁ TRỊ TOÀN BỘ KHO HÀNG");

            var products = _productService.GetAll();
            decimal totalValue = _productService.CalculateTotalInventoryValue();
            int totalQuantity = products.Sum(p => p.Quantity);

            Console.WriteLine($"• Tổng số lượng mặt hàng (SKU): {products.Count}");
            Console.WriteLine($"• Tổng số lượng hiện vật tồn kho: {totalQuantity:#,##0}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"• TỔNG GIÁ TRỊ KHO HÀNG        : {FormatCurrency(totalValue)}");
            Console.ResetColor();
        }
        #endregion

        #region Helper Render & Input
        /// <summary>
        /// Hiển thị bảng sản phẩm có kẻ khung đẹp mắt và căn cột ngay ngắn.
        /// </summary>
        private static void RenderProductTable(IEnumerable<Product> list)
        {
            var productList = list.ToList();
            if (!productList.Any())
            {
                PrintColored("Danh sách sản phẩm hiện đang rỗng!", ConsoleColor.Yellow);
                return;
            }

            string separator = "+" + new string('-', 6) + "+" + new string('-', 12) + "+" + new string('-', 38) + "+" + new string('-', 16) + "+" + new string('-', 12) + "+" + new string('-', 18) + "+";
            Console.WriteLine(separator);
            Console.WriteLine("| {0,-4} | {1,-10} | {2,-36} | {3,14} | {4,10} | {5,16} |", "STT", "Mã SP", "Tên sản phẩm", "Đơn giá (đ)", "Số lượng", "Thành tiền (đ)");
            Console.WriteLine(separator);

            int index = 1;
            decimal grandTotal = 0;
            int totalQty = 0;

            foreach (var p in productList)
            {
                Console.WriteLine("| {0,-4} | {1,-10} | {2,-36} | {3,14} | {4,10} | {5,16} |",
                    index++,
                    p.MaSP,
                    TruncateString(p.TenSP, 36),
                    FormatNumber(p.Price),
                    FormatNumber(p.Quantity),
                    FormatNumber(p.TotalValue));

                grandTotal += p.TotalValue;
                totalQty += p.Quantity;
            }

            Console.WriteLine(separator);
            Console.WriteLine("| {0,-54} | {1,14} | {2,10} | {3,16} |",
                $"TỔNG CỘNG: {productList.Count} mặt hàng",
                "-",
                FormatNumber(totalQty),
                FormatNumber(grandTotal));
            Console.WriteLine(separator);
        }

        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? string.Empty).Trim();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                PrintColored("Dữ liệu không được để trống! Vui lòng nhập lại.", ConsoleColor.Red);
            }
        }

        private static decimal ReadNonNegativeDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? string.Empty).Trim();
                if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value) ||
                    decimal.TryParse(input, NumberStyles.Any, new CultureInfo("vi-VN"), out value))
                {
                    if (value >= 0)
                        return value;

                    PrintColored("Giá trị không được âm (< 0)! Vui lòng nhập lại.", ConsoleColor.Red);
                }
                else
                {
                    PrintColored("Dữ liệu phải là số hợp lệ! Vui lòng nhập lại.", ConsoleColor.Red);
                }
            }
        }

        private static int ReadNonNegativeInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? string.Empty).Trim();
                if (int.TryParse(input, out int value))
                {
                    if (value >= 0)
                        return value;

                    PrintColored("Số lượng không được âm (< 0)! Vui lòng nhập lại.", ConsoleColor.Red);
                }
                else
                {
                    PrintColored("Số lượng phải là số nguyên hợp lệ! Vui lòng nhập lại.", ConsoleColor.Red);
                }
            }
        }

        private static string FormatCurrency(decimal amount)
        {
            return $"{amount.ToString("#,##0", CultureInfo.InvariantCulture)} đ";
        }

        private static string FormatNumber(decimal number)
        {
            return number.ToString("#,##0", CultureInfo.InvariantCulture);
        }

        private static string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }

        private static void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void PrintSectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"--- {title} ---");
            Console.ResetColor();
        }
        #endregion
    }
}
