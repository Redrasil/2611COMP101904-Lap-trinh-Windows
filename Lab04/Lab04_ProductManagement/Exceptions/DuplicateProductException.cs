using System;

namespace Lab04_ProductManagement.Exceptions
{
    /// <summary>
    /// Ngoại lệ phát sinh khi cố gắng thêm sản phẩm có mã đã tồn tại trong danh sách.
    /// </summary>
    public class DuplicateProductException : Exception
    {
        /// <summary>
        /// Mã sản phẩm bị trùng.
        /// </summary>
        public string? ProductId { get; }

        public DuplicateProductException()
            : base("Mã sản phẩm đã tồn tại trong hệ thống!")
        {
        }

        public DuplicateProductException(string message)
            : base(message)
        {
        }

        public DuplicateProductException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DuplicateProductException(string productId, string message)
            : base(message)
        {
            ProductId = productId;
        }
    }
}
