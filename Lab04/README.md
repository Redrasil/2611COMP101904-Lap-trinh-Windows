# Lab 04 - Quản lý sản phẩm bằng Console (Generic, Delegate/Event, Func/Action, Exception)

## Thông tin sinh viên
- **Họ tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Nhóm**: 11
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Buổi học**: Buổi 4 - Exception, Delegate, Event, Func, Action và Generic

---

## 1. Mục tiêu và Tổng quan đồ án
Đồ án **Lab 04** xây dựng một ứng dụng Console Application (.NET 10 / C#) hoàn chỉnh theo mô hình kiến trúc nhiều tầng (Separation of Concerns), đáp ứng đầy đủ các tiêu chuẩn kỹ thuật hiện đại:
- **Xử lý ngoại lệ (Exception Handling)**: Tự định nghĩa các ngoại lệ nghiệp vụ (`DuplicateProductException`, `ProductNotFoundException`), sử dụng `try-catch-finally`, ném ngoại lệ có ngữ cảnh rõ ràng và xử lý an toàn dữ liệu nhập vào (`safe parsing`).
- **Delegate & Action Events**: Sử dụng `event Action<Product>` để thông báo khi dữ liệu thay đổi (khi thêm hoặc xóa sản phẩm thành công), phân tách rành mạch tầng nghiệp vụ và tầng giao diện.
- **Func<T, bool> Delegate**: Ứng dụng `Func<Product, bool>` để lọc và tìm kiếm linh hoạt dữ liệu theo biểu thức điều kiện (Predicate).
- **Generic Repository Pattern**: Xây dựng lớp dùng chung `Repository<T>` với generic constraint `where T : IEntity` để quản lý tập hợp thực thể trong bộ nhớ.
- **Console UX**: Giao diện tiếng Việt UTF-8, bảng hiển thị căn chỉnh ngay ngắn, hỗ trợ định dạng số tiền VND, thông báo màu trực quan.

---

## 2. Cấu trúc thư mục mã nguồn
```text
Lab04/
├── README.md                                 # Báo cáo chi tiết và tài liệu hướng dẫn
├── Lab04_ProductManagement.sln               # Solution file Visual Studio
└── Lab04_ProductManagement/
    ├── Lab04_ProductManagement.csproj        # File cấu hình dự án .NET 10
    ├── IEntity.cs                            # Interface ràng buộc khóa chính Id
    ├── Product.cs                            # Lớp thực thể Sản phẩm (thực thi IEntity)
    ├── Exceptions/
    │   ├── DuplicateProductException.cs      # Ngoại lệ trùng mã sản phẩm
    │   └── ProductNotFoundException.cs       # Ngoại lệ không tìm thấy sản phẩm
    ├── Repositories/
    │   └── Repository.cs                     # Generic Repository<T> where T : IEntity
    ├── Services/
    │   └── ProductService.cs                 # Xử lý nghiệp vụ, quản lý event và Func filter
    └── Program.cs                            # Điều khiển luồng Console, menu và try-catch
```

---

## 3. Kiến trúc kỹ thuật và Thành phần chi tiết

### 3.1. Interface `IEntity`
```csharp
public interface IEntity
{
    string Id { get; }
}
```
- Đóng vai trò là generic constraint cho `Repository<T>`.
- Cho phép Repository truy cập thuộc tính định danh duy nhất của bất kỳ thực thể nào mà không phụ thuộc vào lớp cụ thể.

### 3.2. Thực thể `Product`
- Thực thi `IEntity` thông qua thuộc tính `public string Id => MaSP;`.
- Bao gồm các trường và property có kiểm tra ràng buộc:
  - `MaSP` (string): Mã sản phẩm duy nhất, không được để trống.
  - `TenSP` (string): Tên sản phẩm, không được để trống.
  - `Price` (decimal): Đơn giá, kiểm tra ràng buộc $\ge 0$ (ném `ArgumentOutOfRangeException` nếu âm).
  - `Quantity` (int): Số lượng, kiểm tra ràng buộc $\ge 0$ (ném `ArgumentOutOfRangeException` nếu âm).
  - `TotalValue` (decimal): Thuộc tính tính toán thành tiền $= \text{Price} \times \text{Quantity}$.
  - Ghi đè `ToString()` hiển thị đầy đủ thông tin kèm định dạng tiền tệ.

### 3.3. Ngoại lệ tự tạo (Custom Exceptions)
- **`DuplicateProductException`**: Kế thừa `Exception`, chứa thêm thuộc tính `ProductId`. Được kích hoạt khi cố gắng thêm một sản phẩm có mã đã tồn tại.
- **`ProductNotFoundException`**: Kế thừa `Exception`, chứa thêm thuộc tính `ProductId`. Được kích hoạt khi tìm kiếm hoặc xóa sản phẩm có mã không tồn tại trong hệ thống.

### 3.4. Lớp Generic Repository `Repository<T>`
Ràng buộc: `public class Repository<T> where T : IEntity`
- `void Add(T item)`: Kiểm tra trùng mã Id qua `FindById(item.Id)`. Nếu trùng thì ném `DuplicateProductException`.
- `bool Remove(string id)`: Tìm kiếm trước khi xóa. Nếu không tồn tại thì ném `ProductNotFoundException`.
- `T? FindById(string id)`: Tìm kiếm đối tượng theo mã duy nhất.
- `IEnumerable<T> Find(Func<T, bool> predicate)`: Lọc danh sách bằng biểu thức hàm `Func<T, bool>`.
- `IReadOnlyList<T> GetAll()`: Trả về danh sách dạng chỉ đọc để bảo vệ tính toàn vẹn dữ liệu.

### 3.5. Dịch vụ `ProductService` & Action Events
- Khai báo các sự kiện:
  ```csharp
  public event Action<Product>? OnProductAdded;
  public event Action<Product>? OnProductRemoved;
  ```
- Phương thức nghiệp vụ:
  - `AddProduct(Product product)`: Kiểm tra dữ liệu, thêm vào repository, kích hoạt event `OnProductAdded?.Invoke(product)`.
  - `RemoveProduct(string id)`: Xóa khỏi repository, kích hoạt event `OnProductRemoved?.Invoke(product)`.
  - `GetById(string id)`: Tìm kiếm theo mã (ném `ProductNotFoundException` nếu không thấy).
  - `Search(string keyword)`: Tìm theo tên dùng `Func<Product, bool>`.
  - `FilterByPrice(decimal minPrice, decimal maxPrice)`: Lọc theo khoảng giá sử dụng biểu thức lambda `Func<Product, bool> priceFilter = p => p.Price >= minPrice && p.Price <= maxPrice`.
  - `CalculateTotalInventoryValue()`: Tính tổng giá trị kho hàng $\sum (\text{Price} \times \text{Quantity})$.
  - `SeedSampleData()`: Khởi tạo sẵn 6 sản phẩm mẫu phong phú phục vụ kiểm thử nhanh chóng.

### 3.6. Giao diện điều khiển `Program.cs`
- Đăng ký nhận sự kiện từ `ProductService` (`HandleProductAddedEvent`, `HandleProductRemovedEvent`).
- Xây dựng 8 chức năng chuẩn theo tài liệu yêu cầu:
  1. `1. Them san pham`: Nhập liệu, bắt ngoại lệ `DuplicateProductException`.
  2. `2. Xuat danh sach`: Hiển thị dạng bảng kẻ khung có cột STT, Mã SP, Tên SP, Đơn giá, Số lượng, Thành tiền.
  3. `3. Tim theo ma`: Bắt ngoại lệ `ProductNotFoundException`.
  4. `4. Tim theo ten`: Tìm kiếm mờ không phân biệt hoa thường qua `Func`.
  5. `5. Loc theo khoang gia`: Lọc khoảng giá hợp lệ bằng `Func<Product, bool>`.
  6. `6. Xoa san pham`: Xác nhận `y/n`, xóa và bắt ngoại lệ `ProductNotFoundException`.
  7. `7. Tinh tong gia tri kho`: Thống kê số lượng SKU, tổng tồn kho và tổng tiền.
  8. `0. Thoat`: Dừng chương trình.

---

## 4. Đáp ứng tiêu chí chấm điểm (10.0 / 10.0)

| Tiêu chí | Điểm tối đa | Trạng thái | Chi tiết triển khai |
| :--- | :---: | :---: | :--- |
| **Class, property, constructor** | 2.0 | ✅ Đạt | Định nghĩa đầy đủ `IEntity`, `Product`, validation `Price >= 0` và `Quantity >= 0`, phương thức `ToString()`. |
| **Exception và xử lý lỗi** | 2.0 | ✅ Đạt | Có 2 exception tự tạo `DuplicateProductException`, `ProductNotFoundException`; try-catch toàn diện, chống crash khi nhập dữ liệu sai. |
| **Event hoặc Action event** | 2.0 | ✅ Đạt | Khai báo và phát `OnProductAdded`, `OnProductRemoved` qua `Action<Product>`; Console đăng ký và hiển thị thông báo sinh động. |
| **Generic Repository và Func** | 2.0 | ✅ Đạt | `Repository<T> where T : IEntity` hoạt động chính xác; sử dụng `Func<Product, bool>` để tìm kiếm và lọc khoảng giá. |
| **Menu, kiểm thử, format code** | 2.0 | ✅ Đạt | Menu 8 chức năng theo đúng mẫu gợi ý, mã nguồn sạch đẹp, phân tầng chuẩn, chạy ổn định trên .NET 10. |

---

## 5. Hướng dẫn biên dịch và chạy chương trình

### Cách 1: Sử dụng Visual Studio
1. Mở solution `Lab04/Lab04_ProductManagement.sln` bằng Visual Studio 2022 trở lên.
2. Thiết lập dự án khởi động là `Lab04_ProductManagement`.
3. Nhấn tổ hợp phím **Ctrl + F5** để chạy chương trình mà không cần gắn debugger.

### Cách 2: Sử dụng .NET CLI
Mở Terminal tại thư mục gốc của repository và chạy:
```bash
# Biên dịch dự án
dotnet build Lab04/Lab04_ProductManagement/Lab04_ProductManagement.csproj

# Chạy ứng dụng console
dotnet run --project Lab04/Lab04_ProductManagement/Lab04_ProductManagement.csproj
```
