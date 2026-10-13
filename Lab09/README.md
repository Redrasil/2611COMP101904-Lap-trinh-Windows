# Lab 09 - Thiết kế và in thẻ sinh viên bằng WinForms

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Nhóm**: 11
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại
- **Buổi thực hành**: Buổi 9 (Lab 09) - Thiết kế và in thẻ sinh viên bằng WinForms

---

## 1. Mục tiêu bài thực hành
- Sử dụng PictureBox và OpenFileDialog để chọn, hiển thị ảnh đại diện.
- Vẽ preview thẻ sinh viên bằng Panel và GDI+.
- Sử dụng PrintDocument và PrintPreviewDialog để xem trước và in thẻ.
- Biết kiểm tra dữ liệu đầu vào và kiểm thử bản in.
- Rèn luyện cách tổ chức code WinForms rõ ràng, dễ đọc.

---

## 2. Bài toán
Xây dựng ứng dụng Windows Forms cho phép nhập thông tin sinh viên, chọn ảnh đại diện, hiển thị bản xem trước của thẻ sinh viên và in thẻ sinh viên.
Ứng dụng không yêu cầu kết nối cơ sở dữ liệu trong buổi này. Dữ liệu được nhập trực tiếp trên Form.

---

## 3. Cấu trúc thư mục mã nguồn
```text
Lab09/
├── README.md                                    # Báo cáo chi tiết Lab 09
├── COMP1019_Lab09_StudentCard/
│   ├── COMP1019_Lab09_StudentCard.csproj         # File cấu hình dự án C# WinForms (.NET 8.0)
│   ├── Program.cs                               # Điểm khởi chạy ứng dụng
│   ├── FrmStudentCard.cs                        # Form chính chứa giao diện và xử lý logic
│   ├── FrmStudentCard.Designer.cs               # Thiết kế giao diện
│   └── Models/
│       └── Student.cs                            # Class lưu thông tin sinh viên
```

---

## 4. Yêu cầu giao diện

Thiết kế Form chính tên `FrmStudentCard`. Giao diện nên chia thành hai vùng: vùng nhập liệu bên trái và vùng xem trước thẻ bên phải.

### 4.1. Bảng điều khiển

| Nhóm control | Control giỏ | Mô tả |
| :--- | :--- | :--- |
| Thông tin sinh viên | TextBox, ComboBox, DateTimePicker | Nhập mã, họ tên, lớp, khoa, khóa học, ngày sinh, giới tính |
| Ảnh đại diện | PictureBox, Button, OpenFileDialog | Chọn ảnh JPG, PNG, BMP; ảnh hiển thị không méo |
| Preview thẻ | Panel | Vẽ thẻ sinh viên bằng GDI+ trong Paint event |
| In n in điều khiển | PrintDocument, PrintPreviewDialog, PrintDialog | Có nút xem trước khi in và nút in |

### 4.2. Các nút chức năng
- **Chọn ảnh (F1)**: Mở OpenFileDialog, chỉ cho chọn file ảnh. Ảnh sau khi chọn hiển thị trong PictureBox theo chế độ Zoom.
- **Preview thẻ (F2)**: Khi nhập hoặc thay đổi dữ liệu, Panel preview được vẽ lại bằng GDI+.
- **Validation (F3)**: Không cho preview/in nếu thiếu mã sinh viên, họ tên hoặc ảnh.
- **Print Preview (F4)**: Bấm nút Xem trước in để mở PrintPreviewDialog.
- **Print (F5)**: Bấm nút In để mở PrintDialog và in qua PrintDocument.
- **Làm mới (F6)**: Xóa dữ liệu nhập, xóa ảnh, trả Form về trạng thái ban đầu.

---

## 5. Thông tin cần nhập

- **Mã sinh viên**: Bắt buộc, không được rỗng.
- **Họ tên**: Bắt buộc, không được rỗng.
- **Lớp**: Chọn từ ComboBox hoặc nhập sẵn danh sách mẫu.
- **Khoa**: Chọn từ ComboBox hoặc nhập sẵn danh sách mẫu.
- **Khóa học**: Ví dụ K49, K50, K51.
- **Ngày sinh**: Dùng DateTimePicker.
- **Giới tính**: Nam/Nữ/Khác.
- **Ảnh đại diện**: Chọn từ máy tính.

---

## 6. Yêu cầu chức năng

| Mã phím | Chức năng | Mô tả |
| :--- | :--- | :--- |
| F1 | Chọn ảnh | Mở OpenFileDialog, chỉ cho chọn file ảnh. Ảnh sau khi chọn hiển thị trong PictureBox theo chế độ Zoom. |
| F2 | Preview thẻ | Khi nhập hoặc thay đổi dữ liệu, Panel preview được vẽ lại bằng GDI+. |
| F3 | Validation | Không cho preview/in nếu thiếu mã sinh viên, họ tên hoặc ảnh. |
| F4 | Print Preview | Bấm nút Xem trước in để mở PrintPreviewDialog. |
| F5 | Print | Bấm nút In để mở PrintDialog và in qua PrintDocument. |
| F6 | Làm mới | Xóa dữ liệu nhập, xóa ảnh, trả Form về trạng thái ban đầu. |

---

## 7. Yêu cầu xử lý ảnh

- Sử dụng OpenFileDialog với Filter: JPG, JPEG, PNG, BMP.
- Ảnh hiển thị trong PictureBox phải giữ đúng tỉ lệ (SizeMode.Zoom).
- Khi đổi ảnh, chương trình không bị lỗi và không khóa file ảnh.
- Khi in, ảnh trên thẻ không bị méo.

---

## 8. Yêu cầu xử lý in ấn

- Sử dụng PrintDocument để định nghĩa nội dung cần in.
- Sử dụng PrintPreviewDialog để xem trước khi in.
- Có thể dùng PrintDialog để chọn máy in.
- Nội dung thẻ in phải có khung, tiêu đề, ảnh và thông tin sinh viên.
- Không được in khi thiếu dữ liệu bắt buộc.

---

## 9. Giá bức thẻ

Thẻ sinh viên nên có kích thước tương đương một thẻ ngang. Bức thẻ gồm:

- Dùng tiêu đề: **THẺ SINH VIÊN**.
- Ảnh sinh viên ở bên trái.
- Thông tin sinh viên ở bên phải.
- Màu nền trắng, có khung ngoài.
- Có tên trường hoặc khoa ở cuối thẻ.

---

## 10. Hiện thực kỹ thuật cốt lõi

### 10.1. Class Student
```csharp
public class Student
{
    public string StudentId { get; set; }
    public string FullName { get; set; }
    public string Class { get; set; }
    public string Faculty { get; set; }
    public string Course { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public Image? Photo { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(StudentId) &&
               !string.IsNullOrWhiteSpace(FullName) &&
               Photo != null;
    }
}
```

### 10.2. Xử lý Paint Event để vẽ thẻ
```csharp
private void pnlPreview_Paint(object? sender, PaintEventArgs e)
{
    if (e?.Graphics == null) return;

    Graphics g = e.Graphics;
    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

    DrawStudentCard(g, pnlPreview.Width, pnlPreview.Height);
}

private void DrawStudentCard(Graphics g, int width, int height)
{
    // Background
    using (SolidBrush bgBrush = new SolidBrush(Color.White))
    {
        g.FillRectangle(bgBrush, 0, 0, width, height);
    }

    // Border
    using (Pen borderPen = new Pen(Color.Black, 2))
    {
        g.DrawRectangle(borderPen, 5, 5, width - 10, height - 10);
    }

    // Title
    using (Font titleFont = new Font("Arial", 16, FontStyle.Bold))
    using (SolidBrush titleBrush = new SolidBrush(Color.Black))
    {
        string title = "THẺ SINH VIÊN";
        SizeF titleSize = g.MeasureString(title, titleFont);
        g.DrawString(title, titleFont, titleBrush, (width - titleSize.Width) / 2, 20);
    }

    // Photo (left side)
    if (studentPhoto != null)
    {
        int photoWidth = 120;
        int photoHeight = 150;
        int photoX = 30;
        int photoY = 60;

        using (Pen photoBorder = new Pen(Color.Black, 1))
        {
            g.DrawRectangle(photoBorder, photoX, photoY, photoWidth, photoHeight);
        }

        g.DrawImage(studentPhoto, photoX + 1, photoY + 1, photoWidth - 2, photoHeight - 2);
    }

    // Student info (right side)
    // ... (vẽ thông tin sinh viên)
}
```

### 10.3. Xử lý PrintDocument
```csharp
private void printDocument_PrintPage(object? sender, PrintPageEventArgs e)
{
    if (e?.Graphics != null)
    {
        DrawStudentCard(e.Graphics, e.PageBounds.Width, e.PageBounds.Height);
    }
}
```

### 10.4. Validation dữ liệu
```csharp
private bool ValidateData()
{
    currentStudent.StudentId = txtStudentId.Text.Trim();
    currentStudent.FullName = txtFullName.Text.Trim();
    currentStudent.Class = cboClass.SelectedItem?.ToString() ?? string.Empty;
    currentStudent.Faculty = cboFaculty.SelectedItem?.ToString() ?? string.Empty;
    currentStudent.Course = cboCourse.SelectedItem?.ToString() ?? string.Empty;
    currentStudent.DateOfBirth = dtpDateOfBirth.Value;
    currentStudent.Gender = cboGender.SelectedItem?.ToString() ?? string.Empty;
    currentStudent.Photo = studentPhoto;

    if (string.IsNullOrWhiteSpace(currentStudent.StudentId))
    {
        MessageBox.Show("Vui lòng nhập mã sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtStudentId.Focus();
        return false;
    }

    if (string.IsNullOrWhiteSpace(currentStudent.FullName))
    {
        MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtFullName.Focus();
        return false;
    }

    if (studentPhoto == null)
    {
        MessageBox.Show("Vui lòng chọn ảnh đại diện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }

    return true;
}
```

---

## 11. Test Case

### Test Case 1: Chọn ảnh đại diện hợp lệ
- **Mô tả**: Người dùng chọn file ảnh JPG/PNG/BMP hợp lệ từ máy tính.
- **Kết quả mong đợi**: Ảnh hiển thị trong PictureBox với tỉ lệ đúng, không bị lỗi, không khóa file.

### Test Case 2: Chọn ảnh đại diện không hợp lệ
- **Mô tả**: Người dùng chọn file không phải ảnh (ví dụ: .txt, .docx).
- **Kết quả mong đợi**: OpenFileDialog không cho chọn hoặc chương trình hiển thị thông báo lỗi.

### Test Case 3: Nhập đầy đủ thông tin hợp lệ
- **Mô tả**: Người dùng nhập mã SV, họ tên, chọn lớp, khoa, khóa học, ngày sinh, giới tính và chọn ảnh.
- **Kết quả mong đợi**: Panel preview hiển thị thẻ sinh viên đầy đủ thông tin, có thể xem trước in và in.

### Test Case 4: Thiếu mã sinh viên
- **Mô tả**: Người dùng không nhập mã sinh viên.
- **Kết quả mong đợi**: Khi bấm F3 hoặc F4/F5, chương trình hiển thị cảnh báo và yêu cầu nhập mã SV.

### Test Case 5: Thiếu họ tên
- **Mô tả**: Người dùng không nhập họ tên.
- **Kết quả mong đợi**: Khi bấm F3 hoặc F4/F5, chương trình hiển thị cảnh báo và yêu cầu nhập họ tên.

### Test Case 6: Thiếu ảnh đại diện
- **Mô tả**: Người dùng không chọn ảnh đại diện.
- **Kết quả mong đợi**: Khi bấm F3 hoặc F4/F5, chương trình hiển thị cảnh báo và yêu cầu chọn ảnh.

### Test Case 7: Xem trước in (Print Preview)
- **Mô tả**: Người dùng nhập đầy đủ thông tin và bấm F4 hoặc nút "Xem trước in".
- **Kết quả mong đợi**: PrintPreviewDialog mở và hiển thị thẻ sinh viên đúng như trên Panel preview.

### Test Case 8: In thẻ (Print)
- **Mô tả**: Người dùng nhập đầy đủ thông tin, bấm F5 hoặc nút "In", chọn máy in và in.
- **Kết quả mong đợi**: Thẻ sinh viên được in ra máy in với nội dung đúng như preview.

---

## 12. Hướng dẫn biên dịch và kiểm thử

### Bằng Visual Studio
1. Mở file solution `COMP1019_Lab09_StudentCard.csproj`.
2. Biên dịch bằng tổ hợp phím `Ctrl + Shift + B`.
3. Chạy ứng dụng bằng `F5` hoặc `Ctrl + F5`.

### Bằng dotnet CLI
```powershell
cd Lab09/COMP1019_Lab09_StudentCard
dotnet build
dotnet run
```

File thực thi nằm tại: `Lab09/COMP1019_Lab09_StudentCard/bin/Debug/net8.0-windows/COMP1019_Lab09_StudentCard.exe`.

---

## 13. Rubric chấm điểm

| Tiêu chí | Điểm |
| :--- | :--- |
| Giao diện đầy đủ, bố cục rõ ràng, đặt tên control hợp lý | 2.0 |
| Chọn và hiển thị ảnh đúng, ảnh không méo | 1.5 |
| Validation đầy đủ dữ liệu bắt buộc | 1.5 |
| Preview thẻ bằng GDI+ trên Panel | 2.0 |
| Xem trước và in bằng PrintDocument | 2.0 |
| Code rõ ràng, có README và test case | 1.0 |
| **Tổng** | **10.0** |

---

## 14. Giá mở rộng (tùy chọn)

- Cho phép chọn màu nền thẻ.
- Cho phép lưu preview thẻ thành ảnh PNG.
- Thêm mã QR giả lập bằng cách vẽ ô vuông đơn giản.
- In nhiều thẻ trong một trang.
- Thêm chức năng lưu danh sách sinh viên tạm thời bằng List<T>.
