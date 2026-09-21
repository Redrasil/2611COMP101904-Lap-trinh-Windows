namespace Lab04_ProductManagement
{
    /// <summary>
    /// Interface thực thể cơ sở định nghĩa khóa định danh Id.
    /// Dùng làm ràng buộc generic (generic constraint) cho Repository&lt;T&gt;.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Mã định danh duy nhất của thực thể.
        /// </summary>
        string Id { get; }
    }
}
