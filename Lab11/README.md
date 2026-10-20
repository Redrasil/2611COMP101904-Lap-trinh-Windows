# Lab 11: Quản lý lớp học bằng ADO.NET

## Thông tin sinh viên
- Họ tên: Hoàng Dương Phúc Quang
- MSSV: 49.01.101.075
- Lớp: 49.01.TOAN.SN
- Nhóm: 11

## Mô tả
Chương trình Windows Forms kết nối SQL Server bằng ADO.NET để quản lý dữ liệu trong bảng `LOP` của database `EduManagerDB`.

## Chức năng
- Tự động tải danh sách lớp lên `DataGridView` khi mở Form.
- Chọn một dòng để đưa mã lớp và tên lớp lên các ô nhập.
- Thêm lớp mới, kiểm tra rỗng và kiểm tra trùng mã.
- Sửa tên lớp theo mã lớp được chọn.
- Xóa lớp sau khi xác nhận, không cho xóa lớp đang có sinh viên.
- Tìm kiếm theo mã hoặc tên lớp bằng `LIKE`.
- Làm mới dữ liệu và tải lại danh sách.
- Sử dụng `SqlParameter` cho dữ liệu nhập từ người dùng.

## Cấu trúc chương trình
```text
COMP1019_Lab11_ClassManager/
├── FrmClassManager.cs
├── FrmClassManager.Designer.cs
└── Program.cs
```

## Kết nối cơ sở dữ liệu
Máy hiện tại dùng SQL Server Express:
```csharp
private readonly string connectionString =
    "Server=.\\SQLEXPRESS;Database=EduManagerDB;" +
    "Integrated Security=True;TrustServerCertificate=True;";
```

Nếu máy dùng instance khác, thay đổi chuỗi kết nối trong `FrmClassManager.cs`.

## Cách chạy
1. Chạy các file SQL trong Lab 10 theo đúng thứ tự.
2. Mở `COMP1019_Lab11_ClassManager.csproj` bằng Visual Studio.
3. Build project.
4. Nhấn `F5` hoặc `Ctrl + F5`.

Có thể chạy bằng .NET CLI:
```powershell
dotnet run --project COMP1019_Lab11_ClassManager/COMP1019_Lab11_ClassManager.csproj
```

## Phím tắt
- `F1`: Tải lại danh sách.
- `F3`: Thêm lớp.
- `F4`: Sửa lớp.
- `F5`: Xóa lớp.
- `F6`: Tìm kiếm.
- `F7`: Làm mới.
