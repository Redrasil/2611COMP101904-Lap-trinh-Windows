using System;
using System.Collections.Generic;
using System.Linq;
using Lab04_ProductManagement.Exceptions;
using Lab04_ProductManagement.Repositories;

namespace Lab04_ProductManagement.Services
{
    /// <summary>
    /// Lớp dịch vụ quản lý sản phẩm, chịu trách nhiệm kiểm tra nghiệp vụ,
    /// tương tác với Repository và phát sự kiện (Events) khi dữ liệu thay đổi.
    /// </summary>
    public class ProductService
    {
        private readonly Repository<Product> _repository;

        /// <summary>
        /// Sự kiện phát sinh khi một sản phẩm được thêm mới thành công.
        /// Sử dụng Action delegate để gửi thông tin sản phẩm vừa thêm.
        /// </summary>
        public event Action<Product>? OnProductAdded;

        /// <summary>
        /// Sự kiện phát sinh khi một sản phẩm bị xóa thành công.
        /// Sử dụng Action delegate để gửi thông tin sản phẩm vừa xóa.
        /// </summary>
        public event Action<Product>? OnProductRemoved;

        /// <summary>
        /// Khởi tạo ProductService với Repository mặc định hoặc được tiêm vào.
        /// </summary>
        public ProductService(Repository<Product>? repository = null)
        {
            _repository = repository ?? new Repository<Product>();
        }

        /// <summary>
        /// Thêm mới sản phẩm vào hệ thống.
        /// Kiểm tra nghiệp vụ và phát sự kiện OnProductAdded khi thêm thành công.
        /// Ném DuplicateProductException nếu trùng mã sản phẩm.
        /// </summary>
        /// <param name="product">Đối tượng sản phẩm cần thêm</param>
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Sản phẩm không được null!");

            if (string.IsNullOrWhiteSpace(product.MaSP))
                throw new ArgumentException("Mã sản phẩm không được để trống!", nameof(product.MaSP));

            if (string.IsNullOrWhiteSpace(product.TenSP))
                throw new ArgumentException("Tên sản phẩm không được để trống!", nameof(product.TenSP));

            if (product.Price < 0)
                throw new ArgumentOutOfRangeException(nameof(product.Price), "Đơn giá không được âm!");

            if (product.Quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(product.Quantity), "Số lượng không được âm!");

            // Thêm vào repository (sẽ ném DuplicateProductException nếu trùng)
            _repository.Add(product);

            // Kích hoạt Event thông báo thêm thành công
            OnProductAdded?.Invoke(product);
        }

        /// <summary>
        /// Xóa sản phẩm khỏi hệ thống theo mã.
        /// Phát sự kiện OnProductRemoved khi xóa thành công.
        /// Ném ProductNotFoundException nếu không tìm thấy mã sản phẩm.
        /// </summary>
        /// <param name="maSP">Mã sản phẩm cần xóa</param>
        /// <returns>True nếu xóa thành công</returns>
        public bool RemoveProduct(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã sản phẩm cần xóa không được để trống!", nameof(maSP));

            // Tìm sản phẩm trước khi xóa để lấy thông tin phát sự kiện
            var product = _repository.FindById(maSP);
            if (product == null)
            {
                throw new ProductNotFoundException(maSP, $"Không tìm thấy sản phẩm có mã '{maSP}' để xóa!");
            }

            bool removed = _repository.Remove(maSP);
            if (removed)
            {
                // Kích hoạt Event thông báo xóa thành công
                OnProductRemoved?.Invoke(product);
            }

            return removed;
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm hiện có trong kho.
        /// </summary>
        public IReadOnlyList<Product> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Tìm sản phẩm theo mã sản phẩm chính xác.
        /// Ném ProductNotFoundException nếu không tìm thấy.
        /// </summary>
        public Product GetById(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã sản phẩm không được để trống!", nameof(maSP));

            var product = _repository.FindById(maSP);
            if (product == null)
            {
                throw new ProductNotFoundException(maSP, $"Không tìm thấy sản phẩm có mã '{maSP}'!");
            }

            return product;
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo từ khóa tên (sử dụng Func&lt;Product, bool&gt;).
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm trong tên sản phẩm</param>
        /// <returns>Danh sách sản phẩm phù hợp</returns>
        public IEnumerable<Product> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _repository.GetAll();

            Func<Product, bool> predicate = p =>
                p.TenSP.IndexOf(keyword.Trim(), StringComparison.OrdinalIgnoreCase) >= 0;

            return _repository.Find(predicate);
        }

        /// <summary>
        /// Lọc sản phẩm theo điều kiện tùy ý truyền qua Func&lt;Product, bool&gt;.
        /// </summary>
        /// <param name="predicate">Biểu thức lọc điều kiện Func</param>
        public IEnumerable<Product> Filter(Func<Product, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate), "Điều kiện lọc không được null!");

            return _repository.Find(predicate);
        }

        /// <summary>
        /// Lọc sản phẩm theo khoảng giá [minPrice, maxPrice] sử dụng delegate Func&lt;Product, bool&gt;.
        /// </summary>
        /// <param name="minPrice">Giá tối thiểu</param>
        /// <param name="maxPrice">Giá tối đa</param>
        public IEnumerable<Product> FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0)
                throw new ArgumentOutOfRangeException("Giá tối thiểu và giá tối đa không được âm!");

            if (minPrice > maxPrice)
                throw new ArgumentException("Giá tối thiểu không được lớn hơn giá tối đa!");

            // Sử dụng Func<Product, bool> theo yêu cầu tiêu chí chấm điểm
            Func<Product, bool> priceFilter = p => p.Price >= minPrice && p.Price <= maxPrice;

            return Filter(priceFilter);
        }

        /// <summary>
        /// Tính tổng giá trị toàn bộ kho hàng (Tổng = đơn giá * số lượng của tất cả sản phẩm).
        /// </summary>
        public decimal CalculateTotalInventoryValue()
        {
            return _repository.GetAll().Sum(p => p.TotalValue);
        }

        /// <summary>
        /// Khởi tạo dữ liệu mẫu phong phú để thuận tiện chạy thử nghiệm và kiểm tra chức năng.
        /// </summary>
        public void SeedSampleData()
        {
            var samples = new List<Product>
            {
                new Product("SP001", "Laptop Dell XPS 13", 28500000m, 10),
                new Product("SP002", "Bàn phím cơ Logitech MX Mechanical", 3200000m, 25),
                new Product("SP003", "Chuột không dây Logitech MX Master 3S", 2150000m, 40),
                new Product("SP004", "Màn hình Dell UltraSharp 27 inch 4K", 14800000m, 15),
                new Product("SP005", "Tai nghe Sony WH-1000XM5", 7990000m, 18),
                new Product("SP006", "Ổ cứng SSD Samsung 990 Pro 1TB", 3100000m, 30)
            };

            foreach (var item in samples)
            {
                try
                {
                    _repository.Add(item);
                }
                catch (DuplicateProductException)
                {
                    // Bỏ qua nếu đã tồn tại khi nạp lại
                }
            }
        }
    }
}
