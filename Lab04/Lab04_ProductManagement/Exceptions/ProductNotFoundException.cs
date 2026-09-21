using System;

namespace Lab04_ProductManagement.Exceptions
{
    /// <summary>
    /// Ngoại lệ phát sinh khi xóa, sửa hoặc tìm kiếm sản phẩm nhưng mã sản phẩm không tồn tại.
    /// </summary>
    public class ProductNotFoundException : Exception
    {
        /// <summary>
        /// Mã sản phẩm không tìm thấy.
        /// </summary>
        public string? ProductId { get; }

        public ProductNotFoundException()
            : base("Không tìm thấy sản phẩm với mã được chỉ định!")
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ProductNotFoundException(string productId, string message)
            : base(message)
        {
            ProductId = productId;
        }
    }
}
