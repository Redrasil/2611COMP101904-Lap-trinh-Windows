# Lab 08 - Ứng dụng Paint đơn giản bằng WinForms và GDI+

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Nhóm**: 11
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại
- **Buổi thực hành**: Buổi 8 (Lab 08) - Ứng dụng Paint đơn giản bằng WinForms và GDI+

---

## 1. Mục tiêu bài thực hành
- Sử dụng Graphics, Pen, Brush và sự kiện Paint trong WinForms.
- Xử lý MouseDown, MouseMove, MouseUp và tương tác bằng chuột.
- Lưu danh sách đối tượng cần vẽ và vẽ lại khi Form hoặc Panel refresh.
- Tạo một ứng dụng Paint đơn giản có chọn màu, độ dày, undo và clear.

---

## 2. Cấu trúc thư mục mã nguồn
```text
Lab08/
├── README.md                                    # Báo cáo chi tiết Lab 08
├── COMP1019_Lab08_SimplePaint/
│   ├── COMP1019_Lab08_SimplePaint.csproj         # File cấu hình dự án C# WinForms (.NET 8.0)
│   ├── Program.cs                               # Điểm khởi chạy ứng dụng
│   ├── Form1.cs                                 # Form chính chứa giao diện và xử lý vẽ
│   ├── Form1.Designer.cs                        # Thiết kế giao diện
│   └── Models/
│       └── DrawItem.cs                          # Class lưu thông tin các nét vẽ
```

---

## 3. Mô tả bài toán
Sinh viên xây dựng ứng dụng Paint đơn giản. Người dùng có thể chọn chế độ vẽ, chọn màu, chọn độ dày nét và vẽ trực tiếp trên vùng canvas bằng chuột. Các hình đã vẽ không bị mất khi Form được resize hoặc bị che rồi hiện lại.

---

## 4. Giao diện yêu cầu

### 4.1. Các điều khiển (Controls)

| Thành phần | Tên giỏ | Mô tả |
| :--- | :--- | :--- |
| ComboBox | cboMode | Chọn chế độ: Pen, Line, Rectangle, Ellipse |
| NumericUpDown | nudWidth | Chọn độ dày nét vẽ, từ 1 đến 20 |
| Button | btnColor | Mở ColorDialog để chọn màu vẽ |
| Button | btnUndo | Xóa nét vẽ gần nhất |
| Button | btnClear | Xóa toàn bộ vùng vẽ |
| Panel | canvas | Vùng vẽ chính, nền trắng |
| Label | lblStatus | Hiển thị tọa độ chuột hiện tại |

### 4.2. Menu
- **File**:
  - Save Image as PNG: Lưu vùng vẽ ra file PNG
  - Open Background Image: Mở ảnh làm nền cho canvas
  - Exit: Thoát ứng dụng

---

## 5. Chức năng bắt buộc

1. **Vẽ tự do bằng chuột khi chọn chế độ Pen**: Người dùng kéo chuột để vẽ đường nét tự do.
2. **Vẽ đường thẳng khi chọn chế độ Line**: Người dùng kéo chuột từ điểm đầu đến điểm cuối để vẽ đường thẳng.
3. **Vẽ hình chữ nhật khi chọn chế độ Rectangle**: Người dùng kéo chuột để vẽ hình chữ nhật.
4. **Vẽ hình ellipse khi chọn chế độ Ellipse**: Người dùng kéo chuột để vẽ hình ellipse.
5. **Cho phép chọn màu bằng ColorDialog**: Người dùng nhấn nút Color để chọn màu vẽ.
6. **Cho phép chọn độ dày nét bằng NumericUpDown**: Người dùng chọn độ dày từ 1 đến 20.
7. **Có nút Clear để xóa toàn bộ nét vẽ**: Xóa tất cả các nét đã vẽ và ảnh nền.
8. **Có nút Undo để xóa nét vẽ cuối cùng**: Xóa nét vẽ vừa thêm vào danh sách.
9. **Hiển thị tọa độ chuột trên Status Label**: Cập nhật tọa độ X, Y khi chuột di chuyển trên canvas.
10. **Các nét vẽ không bị mất khi resize Form**: Sử dụng Paint event để vẽ lại danh sách DrawItem.

---

## 6. Yêu cầu kỹ thuật

- **Phải vẽ trong sự kiện Paint của vùng canvas**: Không vẽ trực tiếp trong MouseMove mà chỉ cập nhật dữ liệu gốc.
- **Không có vẽ trực tiếp trong MouseMove rồi bỏ qua dữ liệu gốc**: Chỉ lưu thông tin, Paint event sẽ vẽ lại.
- **Phải có danh sách lưu các đối tượng đã vẽ**: Sử dụng `List<DrawItem>` để lưu trữ.
- **Khi dữ liệu nét vẽ thay đổi, gọi canvas.Invalidate()**: Yêu cầu vẽ lại canvas.
- **Các đối tượng Pen/Brush/Font tự tạo phải được giải phóng bằng using hoặc Dispose**: Sử dụng `using` statement.
- **Hàm vẽ hình chữ nhật và ellipse phải xử lý trường hợp kéo chuột theo mọi hướng**: Sử dụng Math.Min và Math.Abs để tính toán tọa độ.

---

## 7. Chức năng nâng cao (đã hiện thực)

1. **Lưu vùng vẽ ra file PNG**: Cho phép người dùng lưu canvas thành ảnh PNG thông qua menu File → Save Image as PNG.
2. **Mở ảnh nền để vẽ đè lên**: Cho phép người dùng mở ảnh làm nền cho canvas thông qua menu File → Open Background Image.
3. **Thêm phím tắt Ctrl+Z để Undo**: Người dùng có thể nhấn Ctrl+Z để undo nhanh.

---

## 8. Hiện thực kỹ thuật cốt lõi

### 8.1. Class DrawItem
```csharp
public enum PaintMode
{
    Pen,
    Line,
    Rectangle,
    Ellipse
}

public class DrawItem
{
    public PaintMode Mode { get; set; }
    public Color Color { get; set; }
    public float Width { get; set; }
    public List<Point> Points { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
}
```

### 8.2. Xử lý Paint Event
```csharp
private void canvas_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;
    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

    // Draw background image if exists
    if (backgroundImage != null)
    {
        g.DrawImage(backgroundImage, 0, 0, canvas.Width, canvas.Height);
    }

    // Draw all saved items
    foreach (var item in drawItems)
    {
        using (Pen pen = new Pen(item.Color, item.Width))
        {
            switch (item.Mode)
            {
                case PaintMode.Pen:
                    if (item.Points.Count > 1)
                    {
                        g.DrawLines(pen, item.Points.ToArray());
                    }
                    break;
                case PaintMode.Line:
                    g.DrawLine(pen, item.StartPoint, item.EndPoint);
                    break;
                case PaintMode.Rectangle:
                    g.DrawRectangle(pen,
                        Math.Min(item.StartPoint.X, item.EndPoint.X),
                        Math.Min(item.StartPoint.Y, item.EndPoint.Y),
                        Math.Abs(item.EndPoint.X - item.StartPoint.X),
                        Math.Abs(item.EndPoint.Y - item.StartPoint.Y));
                    break;
                case PaintMode.Ellipse:
                    g.DrawEllipse(pen,
                        Math.Min(item.StartPoint.X, item.EndPoint.X),
                        Math.Min(item.StartPoint.Y, item.EndPoint.Y),
                        Math.Abs(item.EndPoint.X - item.StartPoint.X),
                        Math.Abs(item.EndPoint.Y - item.StartPoint.Y));
                    break;
            }
        }
    }

    // Draw current drawing (preview)
    if (isDrawing)
    {
        // Similar logic for current drawing
    }
}
```

### 8.3. Xử lý Mouse Events
```csharp
private void canvas_MouseDown(object sender, MouseEventArgs e)
{
    if (e.Button == MouseButtons.Left)
    {
        isDrawing = true;
        startPoint = e.Location;
        endPoint = e.Location;
        currentPoints.Clear();
        currentPoints.Add(e.Location);
    }
}

private void canvas_MouseMove(object sender, MouseEventArgs e)
{
    lblStatus.Text = $"Status: X={e.X}, Y={e.Y}";

    if (isDrawing)
    {
        PaintMode mode = (PaintMode)cboMode.SelectedIndex;
        endPoint = e.Location;

        if (mode == PaintMode.Pen)
        {
            currentPoints.Add(e.Location);
        }

        canvas.Invalidate();
    }
}

private void canvas_MouseUp(object sender, MouseEventArgs e)
{
    if (e.Button == MouseButtons.Left && isDrawing)
    {
        isDrawing = false;
        endPoint = e.Location;

        PaintMode mode = (PaintMode)cboMode.SelectedIndex;
        DrawItem item = new DrawItem(mode, currentColor, (float)nudWidth.Value);

        switch (mode)
        {
            case PaintMode.Pen:
                item.Points = new List<Point>(currentPoints);
                break;
            case PaintMode.Line:
            case PaintMode.Rectangle:
            case PaintMode.Ellipse:
                item.StartPoint = startPoint;
                item.EndPoint = endPoint;
                break;
        }

        drawItems.Add(item);
        canvas.Invalidate();
    }
}
```

---

## 9. Hướng dẫn biên dịch và kiểm thử

### Bằng Visual Studio
1. Mở file solution `COMP1019_Lab08_SimplePaint.csproj`.
2. Biên dịch bằng tổ hợp phím `Ctrl + Shift + B`.
3. Chạy ứng dụng bằng `F5` hoặc `Ctrl + F5`.

### Bằng dotnet CLI
```powershell
cd Lab08/COMP1019_Lab08_SimplePaint
dotnet build
dotnet run
```

File thực thi nằm tại: `Lab08/COMP1019_Lab08_SimplePaint/bin/Debug/net8.0-windows/COMP1019_Lab08_SimplePaint.exe`.

---

## 10. Kết quả demo

Sau khi chạy ứng dụng, người dùng có thể:
1. Chọn chế độ vẽ từ ComboBox (Pen, Line, Rectangle, Ellipse).
2. Chọn độ dày nét từ NumericUpDown (1-20).
3. Chọn màu bằng nút Color.
4. Vẽ trên canvas bằng chuột.
5. Xem tọa độ chuột trên Status Label.
6. Undo bằng nút Undo hoặc phím tắt Ctrl+Z.
7. Clear toàn bộ bằng nút Clear.
8. Lưu ảnh PNG qua menu File → Save Image as PNG.
9. Mở ảnh nền qua menu File → Open Background Image.

---

## 11. Rubric chấm điểm

| Tiêu chí | Điểm |
| :--- | :--- |
| Thiết kế giao diện rõ ràng, đủ control yêu cầu | 1.5 |
| Vẽ được Pen, Line, Rectangle, Ellipse | 3.0 |
| Dùng Paint event, lưu danh sách nét vẽ và vẽ lại | 2.0 |
| Chọn màu, chọn độ dày, Clear, Undo | 1.5 |
| Hiển thị tọa độ chuột | 1.0 |
| Các nét vẽ không bị mất khi resize Form | 1.0 |
| Code rõ ràng, đặt tên biến/hàm hợp lý, có kiểm tra lỗi | 1.0 |
| Chức năng nâng cao | 1.0 |
| **Tổng** | **10.0** |
