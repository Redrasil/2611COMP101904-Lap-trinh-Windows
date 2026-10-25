# Lab 15 - Mô hình MVP, Kiểm thử và Bàn giao đồ án (StudentMvpDemo)

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại

---

## 1. Mục tiêu & Kiến trúc MVP (Model - View - Presenter)
Ứng dụng minh họa việc tái cấu trúc (refactor) chức năng quản lý sinh viên từ mô hình truyền thống sang **Mô hình MVP (Model - View - Presenter)** nhằm phân tách triệt để giao diện và nghiệp vụ, giúp mã nguồn dễ bảo trì và dễ kiểm thử:

```text
StudentMvpDemo/
├── Models/
│   └── Student.cs              # Model: Thực thể dữ liệu sinh viên
├── Views/
│   ├── IStudentView.cs         # View Interface: Hợp đồng giao tiếp giữa Form và Presenter
│   ├── FrmStudent.cs           # Form GUI: Hiện thực IStudentView, chỉ hiển thị và nhận event
│   └── FrmStudent.Designer.cs
├── Presenters/
│   └── StudentPresenter.cs     # Presenter: Bộ não xử lý nghiệp vụ, điều phối giữa View & Repository
├── Repositories/
│   ├── IStudentRepository.cs   # Repository Interface: Định nghĩa các thao tác CRUD dữ liệu
│   └── StudentRepository.cs    # Repository Implementation: Quản lý danh sách sinh viên trong bộ nhớ
└── Program.cs                  # Khởi tạo và liên kết các thành phần MVP
```

### Quy tắc triển khai MVP:
1. **View (`FrmStudent`)**:
   - Hiện thực `IStudentView`.
   - Các nút bấm (`Button Click`) không chứa logic nghiệp vụ, chỉ phát sinh event hoặc gọi Presenter.
   - Không chứa bất kỳ câu lệnh xử lý CSDL hay tính toán nghiệp vụ nào.
2. **Presenter (`StudentPresenter`)**:
   - Nhận `IStudentView` và `IStudentRepository` qua Dependency Injection (Constructor).
   - Tuyệt đối **không truy cập trực tiếp control Windows Forms** (`TextBox`, `DataGridView`), chỉ giao tiếp thông qua các thuộc tính và sự kiện của `IStudentView`.
3. **Repository (`StudentRepository`)**:
   - Chịu trách nhiệm lưu trữ và truy vấn dữ liệu sinh viên trong bộ nhớ (`List<Student>`), cung cấp sẵn dữ liệu mẫu.

---

## 2. Hướng dẫn chạy chương trình
1. Mở `StudentMvpDemo.csproj` bằng Visual Studio 2022 / .NET 8 trở lên.
2. Build solution và nhấn `F5` (hoặc chạy lệnh: `dotnet run --project StudentMvpDemo/StudentMvpDemo.csproj`).
3. Ứng dụng sẽ nạp dữ liệu mẫu ban đầu gồm 3 sinh viên và sẵn sàng kiểm thử.

---

## 3. Bảng kịch bản kiểm thử (Test Cases)

| Mã TC | Chức năng kiểm thử | Thao tác / Dữ liệu nhập | Kết quả mong đợi |
|:---:|---|---|---|
| **TC01** | Khởi động & Nạp danh sách | Mở ứng dụng Form | Hiển thị đầy đủ danh sách 3 sinh viên mẫu lên DataGridView. |
| **TC02** | Thêm sinh viên để trống | Bấm Thêm khi các ô đang để trống | View hiển thị thông báo lỗi yêu cầu không để trống mã/tên. |
| **TC03** | Thêm sinh viên trùng mã | Nhập mã `SV001` (đã có), tên `Test`, điểm `8.0` | Presenter phát hiện trùng mã, View báo lỗi mã đã tồn tại. |
| **TC04** | Thêm sinh viên hợp lệ | Nhập mã `SV004`, tên `Lê Văn D`, điểm `8.5` | Thêm thành công, DataGridView hiển thị dòng mới, xóa trắng ô nhập. |
| **TC05** | Xóa sinh viên đã chọn | Chọn sinh viên `SV001` trên bảng, bấm Xóa | Xóa thành công, dòng `SV001` biến mất khỏi danh sách. |
| **TC06** | Tìm kiếm sinh viên theo tên/mã | Gõ từ khóa `"Bình"` vào ô tìm kiếm | Bảng chỉ hiển thị sinh viên có tên hoặc mã chứa `"Bình"`. |

---

## 4. Checklist bàn giao đồ án (Delivery Checklist)
- [x] Đã phân tách rõ ràng 4 tầng: `Models`, `Views`, `Presenters`, `Repositories`.
- [x] Các nút lệnh (`Button Click`) không chứa mã nghiệp vụ hay truy xuất CSDL trực tiếp.
- [x] Presenter không phụ thuộc vào `System.Windows.Forms.Control`, chỉ giao tiếp qua `IStudentView`.
- [x] Khởi tạo dữ liệu mẫu sẵn có để kiểm tra ngay khi chạy chương trình.
- [x] Hiện thực đầy đủ kiểm tra dữ liệu: kiểm tra rỗng, kiểm tra định dạng điểm (0-10) và chặn trùng mã.
- [x] Có thông báo kết quả thao tác (`MessageBox`) trực quan cho người dùng.
