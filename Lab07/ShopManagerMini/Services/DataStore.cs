using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ShopManagerMini.Models;

namespace ShopManagerMini.Services
{
    public static class DataStore
    {
        public static List<User> Users { get; } = new List<User>
        {
            new User("admin", "123", "Quản trị viên", "Admin"),
            new User("user", "123", "Nhân viên bán hàng", "User")
        };

        public static BindingList<Product> Products { get; } = new BindingList<Product>
        {
            new Product("SP01", "Chuột Logitech G102", "Điện tử", 400000m, 20),
            new Product("SP02", "Bàn phím cơ DareU EK87", "Điện tử", 650000m, 15),
            new Product("SP03", "Tai nghe Gaming Sony", "Điện tử", 1200000m, 8),
            new Product("SP04", "Giấy in A4 Double A", "Văn phòng phẩm", 85000m, 50),
            new Product("SP05", "Bút bi Thiên Long (Hộp)", "Văn phòng phẩm", 75000m, 30)
        };

        public static BindingList<Customer> Customers { get; } = new BindingList<Customer>
        {
            new Customer("KH01", "Nguyễn Văn An", "0901234567", "VIP"),
            new Customer("KH02", "Trần Thị Bích", "0912345678", "Thân thiết"),
            new Customer("KH03", "Lê Hoàng Cường", "0987654321", "Thường"),
            new Customer("KH04", "Công ty TNHH Ánh Dương", "02838352020", "Đại lý")
        };

        public static User Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return Users.FirstOrDefault(u =>
                u.Username.Equals(username.Trim(), StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }
    }
}
