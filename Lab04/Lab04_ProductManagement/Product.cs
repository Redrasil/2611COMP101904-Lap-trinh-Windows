using System;
using System.Globalization;

namespace Lab04_ProductManagement
{
    /// <summary>
    /// Lớp đại diện cho thực thể Sản phẩm (Product), thực thi interface IEntity.
    /// </summary>
    public class Product : IEntity
    {
        private string _maSP = string.Empty;
        private string _tenSP = string.Empty;
        private decimal _price;
        private int _quantity;

        /// <summary>
        /// Ràng buộc IEntity.Id trỏ về mã sản phẩm MaSP.
        /// </summary>
        public string Id => MaSP;

        /// <summary>
        /// Mã sản phẩm (duy nhất, không được để trống).
        /// </summary>
        public string MaSP
        {
            get => _maSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sản phẩm không được để trống!", nameof(value));
                _maSP = value.Trim();
            }
        }

        /// <summary>
        /// Tên sản phẩm.
        /// </summary>
        public string TenSP
        {
            get => _tenSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sản phẩm không được để trống!", nameof(value));
                _tenSP = value.Trim();
            }
        }

        /// <summary>
        /// Đơn giá sản phẩm (không được âm).
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Đơn giá không được âm!");
                _price = value;
            }
        }

        /// <summary>
        /// Số lượng tồn kho (không được âm).
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Số lượng không được âm!");
                _quantity = value;
            }
        }

        /// <summary>
        /// Constructor mặc định.
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Constructor đầy đủ tham số kèm kiểm tra ràng buộc nghiệp vụ.
        /// </summary>
        public Product(string maSP, string tenSP, decimal price, int quantity)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Price = price;
            Quantity = quantity;
        }

        /// <summary>
        /// Tính thành tiền của sản phẩm trong kho (Đơn giá * Số lượng).
        /// </summary>
        public decimal TotalValue => Price * Quantity;

        /// <summary>
        /// Định dạng hiển thị thông tin sản phẩm dạng chuỗi.
        /// </summary>
        public override string ToString()
        {
            return $"[Mã: {MaSP}] - {TenSP} | Giá: {Price.ToString("#,##0", CultureInfo.InvariantCulture)} đ | SL: {Quantity} | Thành tiền: {TotalValue.ToString("#,##0", CultureInfo.InvariantCulture)} đ";
        }
    }
}
