# Lab 08: Ứng dụng Paint đơn giản

## Thông tin sinh viên
- Họ tên: Hoàng Dương Phúc Quang
- MSSV: 49.01.101.075
- Lớp: 49.01.TOAN.SN
- Nhóm: 11

## Mô tả
Chương trình Windows Forms sử dụng GDI+ để vẽ các hình cơ bản trên Panel. Các nét vẽ được lưu trong `List<DrawItem>` và vẽ lại trong sự kiện `Paint`, vì vậy không bị mất khi cửa sổ bị che hoặc thay đổi kích thước.

## Chức năng
- Vẽ tự do bằng Pen.
- Vẽ đường thẳng, hình chữ nhật và hình ellipse.
- Chọn màu và độ dày nét vẽ từ 1 đến 20.
- Undo nét vẽ cuối cùng bằng nút Undo hoặc `Ctrl + Z`.
- Xóa toàn bộ hình bằng nút Clear.
- Hiển thị tọa độ chuột trên Status Label.
- Mở ảnh nền và lưu vùng vẽ thành file PNG.

## Cấu trúc chương trình
```text
COMP1019_Lab08_SimplePaint/
├── Form1.cs
├── Form1.Designer.cs
├── Program.cs
└── Models/
    └── DrawItem.cs
```

## Cách chạy
1. Mở `COMP1019_Lab08_SimplePaint.csproj` bằng Visual Studio.
2. Build project.
3. Nhấn `F5` hoặc `Ctrl + F5` để chạy.

Có thể chạy bằng .NET CLI:
```powershell
dotnet run --project COMP1019_Lab08_SimplePaint/COMP1019_Lab08_SimplePaint.csproj
```

## Kiểm thử
- Chọn lần lượt bốn chế độ vẽ và kéo chuột trên canvas.
- Đổi màu, đổi độ dày rồi vẽ thêm.
- Thử kéo hình theo cả hai hướng.
- Dùng Undo, Clear, Ctrl + Z.
- Mở một ảnh nền, lưu kết quả thành PNG.
- Resize cửa sổ hoặc che canvas rồi kiểm tra các nét vẽ vẫn còn.
