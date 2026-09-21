using System;
using System.Collections.Generic;
using System.Linq;
using Lab04_ProductManagement.Exceptions;

namespace Lab04_ProductManagement.Repositories
{
    /// <summary>
    /// Lớp Generic Repository quản lý tập hợp các thực thể kế thừa từ IEntity trong bộ nhớ.
    /// </summary>
    /// <typeparam name="T">Kiểu thực thể có ràng buộc where T : IEntity</typeparam>
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        /// <summary>
        /// Lấy toàn bộ danh sách các phần tử trong kho lưu trữ.
        /// </summary>
        public IReadOnlyList<T> GetAll()
        {
            return _items.AsReadOnly();
        }

        /// <summary>
        /// Thêm một thực thể mới vào kho lưu trữ.
        /// Ném DuplicateProductException nếu Id đã tồn tại.
        /// </summary>
        /// <param name="item">Thực thể cần thêm</param>
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Dữ liệu thực thể không được null!");

            if (string.IsNullOrWhiteSpace(item.Id))
                throw new ArgumentException("Mã Id của thực thể không được để trống!", nameof(item));

            // Kiểm tra trùng mã Id (không phân biệt chữ hoa, chữ thường)
            var existing = FindById(item.Id);
            if (existing != null)
            {
                throw new DuplicateProductException(item.Id, $"Thực thể với mã '{item.Id}' đã tồn tại trong hệ thống!");
            }

            _items.Add(item);
        }

        /// <summary>
        /// Xóa một thực thể khỏi kho lưu trữ theo mã Id.
        /// Ném ProductNotFoundException nếu không tìm thấy.
        /// </summary>
        /// <param name="id">Mã Id cần xóa</param>
        /// <returns>True nếu xóa thành công</returns>
        public bool Remove(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Mã Id cần xóa không được để trống!", nameof(id));

            var item = FindById(id);
            if (item == null)
            {
                throw new ProductNotFoundException(id, $"Không tìm thấy thực thể với mã '{id}' để xóa!");
            }

            return _items.Remove(item);
        }

        /// <summary>
        /// Tìm kiếm thực thể theo mã Id duy nhất.
        /// </summary>
        /// <param name="id">Mã Id cần tìm</param>
        /// <returns>Thực thể nếu tìm thấy, ngược lại trả về null</returns>
        public T? FindById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return default;

            return _items.FirstOrDefault(x => string.Equals(x.Id, id.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tìm kiếm hoặc lọc các thực thể thỏa mãn điều kiện thông qua Func&lt;T, bool&gt;.
        /// </summary>
        /// <param name="predicate">Hàm điều kiện Func</param>
        /// <returns>Danh sách các thực thể thỏa mãn điều kiện</returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate), "Điều kiện lọc predicate không được null!");

            return _items.Where(predicate).ToList();
        }

        /// <summary>
        /// Kiểm tra xem mã Id đã tồn tại hay chưa.
        /// </summary>
        public bool Exists(string id)
        {
            return FindById(id) != null;
        }

        /// <summary>
        /// Số lượng thực thể hiện tại.
        /// </summary>
        public int Count => _items.Count;
    }
}
