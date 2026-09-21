# Lab 03 - Quản lý sinh viên bằng Console (OOP C#)

## Thông tin sinh viên
- **Họ tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Môn học**: COMP1019 - Lập trình trên Windows

## Mô tả
Chương trình Console C# quản lý sinh viên theo mô hình lập trình hướng đối tượng (OOP):
- Ứng dụng tính **kế thừa**: Lớp `SinhVien` kế thừa từ lớp cơ sở `Nguoi`.
- Đóng gói dữ liệu (**Encapsulation**): Kiểm tra ràng buộc dữ liệu tại Property (điểm trung bình chỉ nhận giá trị từ $0.0$ đến $10.0$).
- Đa hình (**Polymorphism**): Ghi đè phương thức ảo `LayThongTin()` từ lớp `Nguoi`.
- Quản lý danh sách đối tượng bằng `List<SinhVien>` trong lớp riêng `QuanLySinhVien`.
- Ứng dụng **LINQ** trong tìm kiếm, sắp xếp và lọc dữ liệu.
- Xử lý nhập liệu an toàn (Validation), không để chương trình bị dừng đột ngột khi người dùng nhập sai kiểu dữ liệu.

## Cấu trúc chương trình
```text
Lab03_QuanLySinhVienOOP/
├── Nguoi.cs             # Lớp cơ sở (HoTen, NgaySinh, LayThongTin virtual)
├── SinhVien.cs          # Lớp con kế thừa Nguoi (MaSV, DiemTB, MaLop, XepLoai, LayThongTin override)
├── QuanLySinhVien.cs    # Lớp dịch vụ quản lý List<SinhVien>, CRUD và xử lý LINQ
└── Program.cs           # Điều khiển luồng chương trình, menu và nhập liệu an toàn
```

## Danh sách chức năng
1. **Thêm sinh viên**: Nhập mã sinh viên (kiểm tra không trùng), họ tên, ngày sinh (`dd/MM/yyyy`), mã lớp và điểm trung bình ($0.0 - 10.0$).
2. **Xuất danh sách**: Hiển thị bảng toàn bộ sinh viên gồm mã, họ tên, ngày sinh, lớp, điểm và xếp loại học lực.
3. **Tìm sinh viên theo mã**: Tìm chính xác sinh viên theo mã bằng LINQ `FirstOrDefault`.
4. **Tìm sinh viên theo tên**: Tìm các sinh viên có họ tên chứa từ khóa bằng LINQ `Where`.
5. **Sửa điểm trung bình**: Cập nhật điểm trung bình mới theo mã sinh viên (có kiểm tra khoảng điểm $0 - 10$).
6. **Xóa sinh viên**: Xóa sinh viên khỏi danh sách theo mã sinh viên với xác nhận an toàn.
7. **Sắp xếp theo điểm giảm dần**: Sắp xếp danh sách theo điểm giảm dần bằng LINQ `OrderByDescending`.
8. **Lọc sinh viên đạt**: Lọc và hiển thị danh sách các sinh viên có điểm trung bình $\ge 5.0$ bằng LINQ `Where`.
0. **Thoát**: Kết thúc phiên làm việc.

## Cách chạy chương trình
### Cách 1: Sử dụng Visual Studio
1. Mở file solution `Lab03_QuanLySinhVienOOP.sln` bằng Visual Studio.
2. Chọn cấu hình **Debug** hoặc **Release**.
3. Nhấn **Ctrl + F5** để chạy chương trình.

### Cách 2: Sử dụng dòng lệnh .NET CLI
Mở Terminal tại thư mục `Lab03` và thực hiện lệnh:
```bash
dotnet run --project Lab03_QuanLySinhVienOOP/Lab03_QuanLySinhVienOOP.csproj
```
