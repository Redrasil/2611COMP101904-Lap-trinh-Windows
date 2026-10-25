# Lab 14 - Entity Framework Core và Mô hình ba lớp (EduManager)

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại

---

## 1. Mô tả bài toán & Kiến trúc 3 lớp
Chương trình Windows Forms quản lý danh mục môn học (`MONHOC`) kết nối cơ sở dữ liệu `EduManagerDB` trên SQL Server, được tổ chức phân tầng nghiêm ngặt theo **Mô hình 3 lớp (3-Tier Architecture)** kết hợp Entity Framework Core:

```text
EduManager/
├── Models/
│   └── MonHoc.cs            # Entity Model ánh xạ bảng MONHOC
├── Data/
│   └── EduManagerContext.cs # DbContext của Entity Framework Core
├── DAL/
│   └── MonHocDAL.cs         # Data Access Layer: truy vấn và tương tác CSDL qua EF Core
├── BLL/
│   └── MonHocBLL.cs         # Business Logic Layer: kiểm tra ràng buộc & nghiệp vụ
├── GUI/
│   ├── FrmMonHoc.cs         # Presentation Layer: hiển thị giao diện và nhận tương tác
│   └── FrmMonHoc.Designer.cs
└── Program.cs               # Điểm khởi chạy ứng dụng
```

- **Quy tắc phân tầng**:
  - `GUI (FrmMonHoc)`: Tuyệt đối không chứa câu lệnh SQL hay DbContext. Chỉ nhận sự kiện từ người dùng, gọi `MonHocBLL` và hiển thị kết quả / thông báo lỗi.
  - `BLL (MonHocBLL)`: Chịu trách nhiệm toàn bộ logic nghiệp vụ và validation (kiểm tra rỗng, độ dài, số tín chỉ 1-6, kiểm tra trùng mã trước khi thêm).
  - `DAL (MonHocDAL)`: Chuyên trách truy xuất CSDL bằng `EduManagerContext` (EF Core), thực hiện các thao tác LINQ to Entities: `GetAll`, `GetById`, `Add`, `Update`, `Delete`, `Search`.

---

## 2. Hướng dẫn cài đặt & Chạy chương trình
1. Mở SQL Server Management Studio (SSMS).
2. Chạy file script `Database.sql` để tạo CSDL `EduManagerDB`, bảng `MONHOC` và dữ liệu mẫu.
3. Kiểm tra chuỗi kết nối trong `Data/EduManagerContext.cs` (mặc định hỗ trợ LocalDB và SQL Server Express).
4. Mở `EduManager.csproj` bằng Visual Studio 2022/.NET 8 (hoặc .NET CLI: `dotnet run --project EduManager/EduManager.csproj`).

---

## 3. Trả lời câu hỏi nộp kèm (Mục 9 Yêu cầu)

### Câu 1: Vì sao không nên viết toàn bộ code CRUD trong sự kiện Button Click?
- **Vi phạm nguyên lý Single Responsibility (Đơn nhiệm)**: Form vừa phải đảm nhận vai trò hiển thị giao diện, vừa kiểm tra nghiệp vụ, vừa mở kết nối cơ sở dữ liệu.
- **Khó bảo trì và nâng cấp**: Khi cấu trúc cơ sở dữ liệu hoặc logic nghiệp vụ thay đổi, ta buộc phải chỉnh sửa trực tiếp vào mã nguồn giao diện (code-behind).
- **Không thể tái sử dụng code**: Các chức năng như lấy danh sách môn học, kiểm tra mã trùng không thể tái sử dụng ở các màn hình khác (như màn hình đăng ký môn học, nhập điểm).
- **Khó viết Unit Test**: Code gắn chặt với các WinForms control (`TextBox`, `Button`), không thể viết kiểm thử tự động độc lập.

### Câu 2: BLL và DAL khác nhau ở điểm nào?
- **DAL (Data Access Layer)**:
  - **Mục đích**: Chuyên trách giao tiếp với nguồn dữ liệu (CSDL SQL Server, file, API).
  - **Nhiệm vụ**: Thực hiện các câu lệnh truy vấn dữ liệu thô (CRUD), ánh xạ bảng thành đối tượng (Entity) thông qua EF Core/ADO.NET. DAL không quan tâm đến quy tắc nghiệp vụ người dùng.
- **BLL (Business Logic Layer)**:
  - **Mục đích**: Là "bộ não" của hệ thống, nằm giữa GUI và DAL.
  - **Nhiệm vụ**: Áp dụng các quy tắc, chính sách nghiệp vụ (validation logic, kiểm tra trùng lặp, tính toán dữ liệu, kiểm tra quyền hạn) trước khi quyết định gọi DAL để lưu hoặc trả dữ liệu cho GUI.

### Câu 3: Entity Framework khác ADO.NET ở điểm nào?
| Tiêu chí | ADO.NET | Entity Framework (EF Core) |
| :--- | :--- | :--- |
| **Bản chất** | Thư viện truy cập dữ liệu mức thấp (Data Access Provider). | Framework ORM (Object-Relational Mapping) mức cao. |
| **Cách viết truy vấn** | Viết chuỗi SQL tường minh (`SELECT`, `INSERT`, `UPDATE`), ghép tham số bằng `SqlParameter`. | Viết truy vấn hướng đối tượng bằng C# và LINQ (`_context.MonHocs.Where(...)`). |
| **Ánh xạ dữ liệu** | Thủ công: lập trình viên tự đọc từng dòng qua `SqlDataReader`/`DataTable` gán vào Object. | Tự động: EF Core tự sinh SQL và ánh xạ tự động vào các đối tượng Entity. |
| **Quản lý thay đổi** | Thủ công viết câu lệnh `UPDATE` tương ứng từng trường. | Tự động với cơ chế Change Tracker (`SaveChanges()`). |
| **Năng suất lập trình** | Tốn nhiều dòng code boilerplate, dễ sai chính tả trong chuỗi SQL. | Viết code nhanh, an toàn kiểu dữ liệu (compile-time checking). |

### Câu 4: Trong bài lab này, validation nào nên đặt ở BLL?
Các validation mang tính **nghiệp vụ và dữ liệu logic** đều phải được đặt ở **BLL**:
1. **Kiểm tra bắt buộc (Not Empty)**: Mã môn học và Tên môn học không được để trống hoặc chỉ chứa khoảng trắng.
2. **Kiểm tra độ dài & định dạng**: Mã môn học tối đa 10 ký tự, Tên môn học tối đa 100 ký tự.
3. **Kiểm tra miền giá trị (Domain Rule)**: Số tín chỉ bắt buộc phải nằm trong đoạn `[1, 6]`.
4. **Kiểm tra tính duy nhất (Uniqueness)**: Khi thêm mới, mã môn học không được trùng lặp với môn học đã có trong CSDL (BLL gọi DAL để kiểm tra sự tồn tại).
5. **Kiểm tra tồn tại khi sửa/xóa**: Kiểm tra môn học cần cập nhật hoặc xóa có thực sự tồn tại trong CSDL hay không.

*(Lưu ý: GUI chỉ nên kiểm tra sơ bộ về định dạng nhập liệu như ngăn người dùng gõ chữ vào ô số, còn toàn bộ tính hợp lệ bắt buộc phải qua BLL).*

---

## 4. Bảng kịch bản kiểm thử (Test Cases)
| STT | Kịch bản kiểm thử | Dữ liệu đầu vào | Kết quả mong đợi |
|:---:|---|---|---|
| TC01 | Thêm mới với Mã môn học để trống | Mã: `""`, Tên: `"Toán cao cấp"`, TC: `3` | BLL chặn lại, hiển thị cảnh báo yêu cầu nhập mã môn học |
| TC02 | Thêm mới với Tên môn học để trống | Mã: `"MATH01"`, Tên: `""`, TC: `3` | BLL chặn lại, hiển thị cảnh báo yêu cầu nhập tên môn học |
| TC03 | Thêm mới với Số tín chỉ ngoài khoảng [1, 6] | Mã: `"MATH01"`, Tên: `"Toán"`, TC: `0` hoặc `7` | BLL chặn lại, báo lỗi số tín chỉ phải từ 1 đến 6 |
| TC04 | Thêm mới với Mã môn học đã tồn tại | Mã: `"COMP1019"` (đã có trong DB) | BLL kiểm tra trùng mã, từ chối thêm và báo lỗi mã đã tồn tại |
| TC05 | Thêm môn học hợp lệ | Mã: `"CS101"`, Tên: `"Nhập môn Tin học"`, TC: `3` | Thêm thành công, DataGridView tự động cập nhật dòng mới |
| TC06 | Chọn dòng trên DataGridView | Click vào dòng `"COMP1019"` | Dữ liệu đổ đầy đủ lên các ô TextBox, NumericUpDown, CheckBox |
| TC07 | Sửa môn học | Đổi tên môn thành `"Lập trình Windows nâng cao"`, bấm Sửa | Cập nhật thành công, dữ liệu trên DataGridView đổi theo |
| TC08 | Xóa môn học - Chọn Hủy xác nhận | Chọn môn, bấm Xóa -> Hộp thoại hiện -> Chọn "No" | Hủy thao tác, môn học vẫn còn nguyên trong danh sách |
| TC09 | Xóa môn học - Xác nhận | Chọn môn, bấm Xóa -> Chọn "Yes" | Xóa thành công khỏi CSDL, dòng biến mất khỏi DataGridView |
| TC10 | Tìm kiếm theo tên hoặc mã | Nhập `"Windows"` vào ô tìm kiếm | DataGridView chỉ hiển thị các môn học có chứa từ khóa `"Windows"` |
