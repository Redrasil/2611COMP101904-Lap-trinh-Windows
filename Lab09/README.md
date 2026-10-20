# Lab 09: Thiết kế và in thẻ sinh viên

## Thông tin sinh viên
- Họ tên: Hoàng Dương Phúc Quang
- MSSV: 49.01.101.075
- Lớp: 49.01.TOAN.SN
- Nhóm: 11

## Mô tả
Chương trình Windows Forms cho phép nhập thông tin sinh viên, chọn ảnh đại diện, xem trước thẻ bằng GDI+ và in thẻ bằng `PrintDocument`.

## Chức năng
- Nhập mã sinh viên, họ tên, lớp, khoa, khóa học, ngày sinh và giới tính.
- Chọn ảnh JPG, JPEG, PNG hoặc BMP bằng `OpenFileDialog`.
- Hiển thị ảnh trong `PictureBox` theo tỉ lệ phù hợp.
- Vẽ thẻ sinh viên trên Panel bằng sự kiện `Paint`.
- Kiểm tra mã sinh viên, họ tên và ảnh trước khi preview hoặc in.
- Xem trước bằng `PrintPreviewDialog`.
- In bằng `PrintDialog` và `PrintDocument`.
- Làm mới form bằng nút hoặc phím `F6`.
- Phím tắt: `F1` chọn ảnh, `F2` preview, `F3` kiểm tra, `F4` xem trước in, `F5` in.

## Cấu trúc chương trình
```text
COMP1019_Lab09_StudentCard/
├── FrmStudentCard.cs
├── FrmStudentCard.Designer.cs
├── Program.cs
└── Models/
    └── Student.cs
```

## Cách chạy
1. Mở `COMP1019_Lab09_StudentCard.csproj` bằng Visual Studio.
2. Build project.
3. Nhấn `F5` hoặc `Ctrl + F5` để chạy.

Có thể chạy bằng .NET CLI:
```powershell
dotnet run --project COMP1019_Lab09_StudentCard/COMP1019_Lab09_StudentCard.csproj
```

## Kiểm thử
- Bấm xem trước khi thiếu mã, họ tên hoặc ảnh.
- Chọn ảnh hợp lệ và kiểm tra ảnh không bị méo.
- Nhập đầy đủ thông tin và kiểm tra Panel preview.
- Mở Print Preview và kiểm tra nội dung thẻ.
- Thử in hoặc hủy hộp thoại PrintDialog.
- Dùng F6 để xóa dữ liệu và chọn ảnh khác.
