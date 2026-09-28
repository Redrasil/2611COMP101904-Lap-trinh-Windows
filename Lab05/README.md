# Lab 05 - Đăng ký khóa học bằng Windows Forms cơ bản (CourseRegistrationApp)

## Thông tin sinh viên
- **Họ tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Nhóm**: 11
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Buổi học**: Buổi 5 - Windows Forms cơ bản (CourseRegistrationApp)

---

## 1. Mục tiêu bài thực hành
- Tạo và cấu hình hoàn chỉnh project **Windows Forms App (.NET Framework / C#)** mang tên `CourseRegistrationApp`.
- Thiết kế giao diện trực quan, khoa học bằng **Form Designer**, **Toolbox** và cửa sổ thuộc tính **Properties**.
- Sử dụng thành thạo và kết hợp các WinForms Controls cơ bản:
  - `Label`, `TextBox`, `Button`, `ComboBox`, `RadioButton`, `CheckBox`, `DateTimePicker`, `NumericUpDown`, `GroupBox`, `Panel`.
- Đặt tên controls chuẩn theo quy ước tiền tố (`txt`, `dtp`, `chk`, `cbo`, `rad`, `num`, `lbl`, `btn`) giúp mã nguồn trong sáng, dễ bảo trì.
- Lập trình bắt và xử lý các sự kiện tương tác người dùng:
  - `Form1_Load`: Nạp dữ liệu ban đầu, cấu hình giới hạn giá trị và trạng thái mặc định.
  - `SelectedIndexChanged` (ComboBox) & `ValueChanged` (NumericUpDown): Tính toán và cập nhật học phí theo thời gian thực.
  - `Click` (Button): Xử lý nghiệp vụ đăng ký, làm mới form và xác nhận thoát ứng dụng an toàn.
- Kiểm tra tính hợp lệ của dữ liệu nhập (Validation) trước khi xử lý nghiệp vụ và thông báo kết quả bằng `MessageBox`.

---

## 2. Cấu trúc thư mục mã nguồn
```text
Lab05/
├── README.md                                    # Báo cáo chi tiết và tài liệu hướng dẫn Lab 05
├── CourseRegistrationApp.sln                    # Solution file Visual Studio chuẩn
├── CourseRegistrationApp.slnx                   # Solution file định dạng mới (VS 2022+)
├── docs/
│   └── screenshots/                             # Thư mục chứa hình ảnh minh họa giao diện
└── CourseRegistrationApp/
    ├── CourseRegistrationApp.csproj             # File cấu hình dự án C# WinForms
    ├── App.config                               # Cấu hình runtime ứng dụng
    ├── Program.cs                               # Điểm khởi chạy ứng dụng (Main Entry Point)
    ├── Form1.cs                                 # Mã nguồn xử lý logic nghiệp vụ và sự kiện
    ├── Form1.Designer.cs                        # Mã nguồn khởi tạo layout, controls và layout properties
    ├── Form1.resx                               # Tài nguyên giao diện Form
    └── Properties/
        ├── AssemblyInfo.cs                      # Thông tin định danh Assembly
        ├── Resources.Designer.cs
        ├── Resources.resx
        ├── Settings.Designer.cs
        └── Settings.settings
```

---

## 3. Quy ước và Ánh xạ Controls trên giao diện

| Nhóm thông tin | Loại Control | Tên Control yêu cầu | Ghi chú & Chức năng |
| :--- | :--- | :--- | :--- |
| **Thông tin học viên** | `TextBox` | `txtHoTen` | Nhập họ và tên học viên |
| **Thông tin học viên** | `TextBox` | `txtSoDienThoai` | Nhập số điện thoại liên hệ |
| **Thông tin học viên** | `DateTimePicker` | `dtpNgaySinh` | Chọn ngày sinh học viên (Format `dd/MM/yyyy`) |
| **Thông tin học viên** | `CheckBox` | `chkNhanEmail` | Nhận email thông báo (True/False) |
| **Thông tin khóa học** | `ComboBox` | `cboKhoaHoc` | Chọn khóa học (DropDownStyle: `DropDownList`) |
| **Thông tin khóa học** | `RadioButton` | `radOnline` | Chọn hình thức học Online |
| **Thông tin khóa học** | `RadioButton` | `radOffline` | Chọn hình thức học Trực tiếp |
| **Thông tin khóa học** | `NumericUpDown` | `numSoThang` | Số tháng đăng ký (Giới hạn: 1 - 12) |
| **Thông tin khóa học** | `Label` | `lblTongTien` | Hiển thị tổng học phí (Định dạng tiền tệ VNĐ) |
| **Vùng nút lệnh** | `Button` | `btnDangKy` | Xử lý kiểm tra dữ liệu và xuất phiếu đăng ký |
| **Vùng nút lệnh** | `Button` | `btnLamMoi` | Xóa dữ liệu và khôi phục form về trạng thái mặc định |
| **Vùng nút lệnh** | `Button` | `btnThoat` | Hộp thoại xác nhận thoát khỏi chương trình |

---

## 4. Dữ liệu khóa học quy định

Bảng giá học phí theo yêu cầu tài liệu `Lab05_YeuCau.pdf`:

| STT | Khóa học | Học phí / tháng |
| :-: | :--- | :---: |
| 1 | C# WinForms cơ bản | 800.000 VNĐ |
| 2 | SQL Server cơ bản | 700.000 VNĐ |
| 3 | Web Frontend cơ bản | 750.000 VNĐ |
| 4 | Lập trình Python cơ bản | 650.000 VNĐ |

---

## 5. Hiện thực logic nghiệp vụ chi tiết

### 5.1. Khi nạp Form (`Form1_Load`)
1. **Nạp dữ liệu khóa học**: Khởi tạo danh sách đối tượng `KhoaHoc` đưa vào `cboKhoaHoc.Items`.
2. **Chọn mặc định**:
   - Khóa học đầu tiên: `cboKhoaHoc.SelectedIndex = 0` (C# WinForms cơ bản).
   - Hình thức: `radOnline.Checked = true`.
3. **Thiết lập giới hạn**:
   - `numSoThang.Minimum = 1`
   - `numSoThang.Maximum = 12`
   - `numSoThang.Value = 1`
4. **Hiển thị học phí ban đầu**: Tự động tính và gán giá trị khởi điểm lên `lblTongTien`.
5. **Điều hướng con trỏ**: Đặt focus tự động về `txtHoTen.Focus()`.

### 5.2. Tính tổng học phí tự động (`SelectedIndexChanged`, `ValueChanged`)
- Công thức: 
  $$\text{Tổng tiền} = \text{Đơn giá một tháng} \times \text{Số tháng đăng ký}$$
- Bắt sự kiện:
  - `cboKhoaHoc_SelectedIndexChanged`: Mỗi khi người dùng đổi khóa học.
  - `numSoThang_ValueChanged`: Mỗi khi người dùng thay đổi số tháng đăng ký.
- Định dạng hiển thị chuẩn văn hóa Việt Nam: `#,#00 VNĐ` (thông qua `CultureInfo.GetCultureInfo("vi-VN")`).

### 5.3. Nút Đăng ký (`btnDangKy_Click`)
1. **Kiểm tra họ tên**: Không được để trống hoặc chỉ chứa khoảng trắng. Nếu rỗng, hiển thị `MessageBox` cảnh báo và focus về ô họ tên.
2. **Kiểm tra số điện thoại**: Không được để trống. Nếu rỗng, hiển thị `MessageBox` cảnh báo và focus về ô số điện thoại.
3. **Kiểm tra khóa học**: Đảm bảo khóa học hợp lệ đã được lựa chọn.
4. **Xuất phiếu đăng ký**: Khi thông tin hợp lệ, tổng hợp và hiển thị qua `MessageBox` (icon Information) gồm:
   - Họ tên học viên
   - Số điện thoại
   - Ngày sinh
   - Khóa học đăng ký
   - Hình thức học (Online / Trực tiếp)
   - Số tháng đăng ký
   - Tổng tiền học phí
   - Trạng thái nhận email thông báo

### 5.4. Nút Làm mới (`btnLamMoi_Click`)
Khôi phục giao diện về trạng thái nguyên bản:
- Xóa trắng `txtHoTen` và `txtSoDienThoai`.
- Đưa `dtpNgaySinh` về ngày hiện tại (`DateTime.Today`).
- Hủy chọn `chkNhanEmail` (`Checked = false`).
- Chọn lại khóa học đầu tiên và hình thức `Online`.
- Đưa số tháng về `1`.
- Cập nhật lại tổng tiền tương ứng.
- Đặt con trỏ vào ô `txtHoTen`.

### 5.5. Nút Thoát (`btnThoat_Click`)
- Mở hộp thoại xác nhận: `MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question)`.
- Chỉ thực hiện `this.Close()` khi người dùng chọn `Yes`.

---

## 6. Hướng dẫn biên dịch và thực thi

### Cách 1: Sử dụng Visual Studio (Khuyến nghị)
1. Khởi động **Visual Studio 2022** (hoặc mới hơn).
2. Mở file solution: `CourseRegistrationApp.sln` hoặc `CourseRegistrationApp.slnx` nằm trong thư mục `Lab05/`.
3. Chọn cấu hình **Debug** hoặc **Release**, nền tảng **Any CPU**.
4. Nhấn phím `F5` (Start Debugging) hoặc `Ctrl + F5` (Start Without Debugging) để chạy ứng dụng.

### Cách 2: Sử dụng dòng lệnh (MSBuild)
Mở PowerShell hoặc Command Prompt tại thư mục `Lab05/` và chạy:
```powershell
# Biên dịch dự án
msbuild CourseRegistrationApp.sln /t:Build /p:Configuration=Release

# Chạy ứng dụng đã biên dịch
.\CourseRegistrationApp\bin\Release\CourseRegistrationApp.exe
```

---

## 7. Bảng đối chiếu Rubric đánh giá (10.0 / 10.0)

| Tiêu chí đánh giá | Điểm tối đa | Trạng thái hiện thực | Điểm tự đánh giá |
| :--- | :---: | :--- | :---: |
| **Tạo đúng project và Form chạy được** | 1.0 | Project WinForms `CourseRegistrationApp`, biên dịch thành công 0 lỗi 0 cảnh báo. | 1.0 / 1.0 |
| **Giao diện đủ control và bố cục rõ ràng** | 2.0 | Đầy đủ 2 GroupBox, Label tiêu đề, các nút lệnh căn hàng ngay ngắn, TabIndex chuẩn. | 2.0 / 2.0 |
| **Đặt tên control đúng quy ước** | 1.0 | `txtHoTen`, `txtSoDienThoai`, `dtpNgaySinh`, `chkNhanEmail`, `cboKhoaHoc`, `radOnline`, `radOffline`, `numSoThang`, `lblTongTien`, `btnDangKy`, `btnLamMoi`, `btnThoat`. | 1.0 / 1.0 |
| **Nạp dữ liệu khóa học khi Form Load** | 1.0 | Nạp đúng 4 khóa học kèm đơn giá, mặc định khóa đầu tiên, online, 1 tháng. | 1.0 / 1.0 |
| **Tính học phí đúng khi thay đổi khóa học hoặc số tháng** | 1.5 | Bắt đúng sự kiện `SelectedIndexChanged` và `ValueChanged`, tự động nhân đúng học phí. | 1.5 / 1.5 |
| **Nút Đăng ký kiểm tra dữ liệu và hiển thị kết quả đúng** | 2.0 | Kiểm tra rỗng đầy đủ, focus trường lỗi, hiển thị `MessageBox` chi tiết các mục. | 2.0 / 2.0 |
| **Nút Làm mới và Thoát hoạt động đúng** | 1.0 | Làm mới chuẩn xác, focus họ tên; Thoát có hộp thoại xác nhận Yes/No. | 1.0 / 1.0 |
| **Code rõ ràng, dễ đọc** | 0.5 | Mã nguồn phân chia region khoa học, bình luận tiếng Việt chi tiết, chuẩn OOP. | 0.5 / 0.5 |
| **TỔNG ĐIỂM** | **10.0** | **Đáp ứng xuất sắc toàn bộ yêu cầu đề bài** | **10.0 / 10.0** |

---

## 8. Hình ảnh minh họa chạy chương trình

> Các ảnh chụp màn hình minh họa các bước kiểm thử chức năng được lưu trữ tại thư mục [`docs/screenshots/`](docs/screenshots/):

1. **Giao diện khởi động mặc định**:
   ![Giao diện khởi động](docs/screenshots/01_FormLoad.png)

2. **Kiểm tra nhập liệu (Validation cảnh báo rỗng)**:
   ![Cảnh báo rỗng](docs/screenshots/02_Validation.png)

3. **Tính toán học phí động khi thay đổi khóa học và số tháng**:
   ![Tính học phí](docs/screenshots/03_TinhHocPhi.png)

4. **Phiếu đăng ký khóa học xuất thành công bằng MessageBox**:
   ![Phiếu đăng ký](docs/screenshots/04_DangKyThanhCong.png)

5. **Xác nhận thoát chương trình**:
   ![Xác nhận thoát](docs/screenshots/05_XacNhanThoat.png)
