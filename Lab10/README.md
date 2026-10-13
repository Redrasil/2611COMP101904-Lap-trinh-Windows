# Lab 10 - Thiết kế và cài đặt cơ sở dữ liệu EduManagerDB bằng SQL Server

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Nhóm**: 11
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại
- **Buổi thực hành**: Buổi 10 (Lab 10) - Thiết kế và cài đặt cơ sở dữ liệu EduManagerDB bằng SQL Server

---

## 1. Mục tiêu bài thực hành
- Thiết kế cơ sở dữ liệu quan hệ cho bài toán quản lý sinh viên.
- Tạo database, bảng, khóa chính, khóa ngoại và ràng buộc bằng T-SQL.
- Nhập dữ liệu mẫu đúng quan hệ giữa các bảng.
- Viết các truy vấn SELECT, JOIN, GROUP BY, UPDATE và DELETE.
- Kiểm thử ràng buộc dữ liệu bằng các trường hợp nhập sai.

---

## 2. Mô tả bài toán
Xây dựng cơ sở dữ liệu EduManagerDB cho ứng dụng quản lý sinh viên. Cơ sở dữ liệu cần quản lý các thông tin: khoa, lớp, sinh viên, môn học, kết quả học tập và tài khoản đăng nhập.

---

## 3. Danh sách bảng bắt buộc

| Bảng | Khóa chính | Khóa ngoại | Ghi chú |
| :--- | :--- | :--- | :--- |
| KHOA | MaKhoa | - | Lưu thông tin khoa |
| LOP | MaLop | MaKhoa | Mỗi lớp thuộc một khoa |
| SINHVIEN | MaSV | MaLop | Mỗi sinh viên thuộc một lớp |
| MONHOC | MaMH | - | Lưu thông tin môn học |
| KETQUA | MaSV, MaMH | MaSV, MaMH | Lưu điểm của sinh viên theo môn |
| TAIKHOAN | TenDangNhap | - | Lưu tài khoản đăng nhập demo |

---

## 4. Yêu cầu chi tiết

1. Tạo database tên EduManagerDB.
2. Tạo đủ 6 bảng theo danh sách bắt buộc.
3. Mỗi bảng phải có khóa chính.
4. Bảng LOP phải tham chiếu KHOA.
5. Bảng SINHVIEN phải tham chiếu LOP.
6. Bảng KETQUA phải tham chiếu SINHVIEN và MONHOC.
7. Cột điểm trong bảng KETQUA phải có ràng buộc từ 0 đến 10.
8. Cột giới tính trong bảng SINHVIEN chỉ nhận 'Nam' hoặc 'N'.
9. Cột số tín chỉ trong bảng MONHOC phải lớn hơn 0.
10. Nhập tối thiểu: 2 khoa, 3 lớp, 6 sinh viên, 4 môn học, 8 kết quả học tập, 2 tài khoản.

---

## 5. Cấu trúc file SQL

```text
Lab10/
├── README.md                              # Báo cáo chi tiết Lab 10
├── 01_CreateDatabase.sql                 # Tạo database và 6 bảng
├── 02_InsertSampleData.sql               # Nhập dữ liệu mẫu
└── 03_Queries.sql                        # Các truy vấn yêu cầu
```

---

## 6. Các truy vấn phải viết

1. **Liệt kê toàn bộ sinh viên**: SELECT tất cả từ bảng SINHVIEN.
2. **Liệt kê sinh viên kèm tên lớp và tên khoa**: JOIN 3 bảng SINHVIEN, LOP, KHOA.
3. **Tìm sinh viên theo một phần tên bằng LIKE**: Sử dụng WHERE với LIKE '%...%'.
4. **Liệt kê sinh viên theo mã lớp**: WHERE MaLop = '...'.
5. **Cập nhật họ tên hoặc lớp của một sinh viên**: UPDATE với WHERE.
6. **Xóa một sinh viên chưa có dữ liệu điểm**: DELETE với LEFT JOIN để kiểm tra.
7. **Liệt kê điểm của từng sinh viên theo từng môn**: JOIN SINHVIEN, KETQUA, MONHOC.
8. **Tính điểm trung bình của từng sinh viên**: GROUP BY với AVG.
9. **Thống kê số sinh viên theo từng lớp**: GROUP BY với COUNT.
10. **Liệt kê các lớp có từ 2 sinh viên trở lên**: GROUP BY với HAVING COUNT >= 2.
11. **Test lỗi khi thêm sinh viên vào lớp không tồn tại**: Thử INSERT với MaLop không tồn tại → Lỗi khóa ngoại.
12. **Test lỗi khi nhập điểm ngoài khoảng 0 đến 10**: Thử INSERT với điểm = 15 hoặc -5 → Lỗi CHECK.

---

## 7. Hướng dẫn thực hiện

### Bước 1: Tạo database và bảng
Chạy file `01_CreateDatabase.sql` trong SQL Server Management Studio (SSMS):

```sql
-- Mở file 01_CreateDatabase.sql trong SSMS
-- Nhấn Execute hoặc F5 để chạy script
```

### Bước 2: Nhập dữ liệu mẫu
Chạy file `02_InsertSampleData.sql` sau khi đã tạo database:

```sql
-- Mở file 02_InsertSampleData.sql trong SSMS
-- Nhấn Execute hoặc F5 để chạy script
```

### Bước 3: Chạy các truy vấn
Chạy file `03_Queries.sql` để kiểm tra các truy vấn:

```sql
-- Mở file 03_Queries.sql trong SSMS
-- Nhấn Execute hoặc F5 để chạy tất cả truy vấn
-- Hoặc chạy từng truy vấn một cách riêng lẻ
```

### Bước 4: Xóa database nếu muốn chạy lại từ đầu
```sql
USE master;
GO
DROP DATABASE IF EXISTS EduManagerDB;
GO
```

---

## 8. Rubric chấm điểm

| Tiêu chí | Điểm |
| :--- | :--- |
| Tạo đúng database, bảng và kiểu dữ liệu | 2.0 |
| Khóa chính, khóa ngoại, ràng buộc hợp lý | 2.0 |
| Dữ liệu mẫu đầy đủ, có quan hệ đúng | 1.5 |
| Truy vấn SELECT, JOIN, GROUP BY đúng | 2.0 |
| UPDATE, DELETE và kiểm thử ràng buộc | 1.5 |
| Script rõ ràng, có comment | 1.0 |
| **Tổng** | **10.0** |

---

## 9. Kết quả demo

Sau khi chạy các file SQL, database EduManagerDB sẽ có:

- **KHOA**: 2 khoa (CNTT, KT)
- **LOP**: 3 lớp (CNTT01, CNTT02, KT01)
- **SINHVIEN**: 6 sinh viên
- **MONHOC**: 4 môn học
- **KETQUA**: 8 kết quả học tập
- **TAIKHOAN**: 2 tài khoản (admin, user)

Các truy vấn trong file `03_Queries.sql` sẽ hiển thị kết quả tương ứng cho từng yêu cầu.

---

## 10. Lưu ý quan trọng

- Chạy script theo thứ tự: tạo database → tạo bảng → nhập dữ liệu mẫu → chạy truy vấn kiểm tra.
- Nếu muốn chạy lại từ đầu, hãy xóa database trước hoặc dùng lệnh DROP DATABASE sau khi đã đóng tất cả kết nối.
- Các ràng buộc (PRIMARY KEY, FOREIGN KEY, CHECK) đảm bảo tính toàn vẹn dữ liệu.
- Sử dụng JOIN thay vì subquery khi có thể để tối ưu hiệu suất.
- Luôn sử dụng transaction khi thực hiện nhiều thao tác liên quan.

---

## 11. Hướng dẫn kết nối từ Lab 11

Connection string mẫu để sử dụng trong Lab 11 (Windows Forms):

```csharp
// Connection string cho SQL Server LocalDB
string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EduManagerDB;Integrated Security=True;";

// Hoặc cho SQL Server Express
string connectionString = "Server=.\\SQLEXPRESS;Database=EduManagerDB;Integrated Security=True;";

// Hoặc cho SQL Server đầy đủ
string connectionString = "Server=YOUR_SERVER_NAME;Database=EduManagerDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;";
```

Thay thế YOUR_SERVER_NAME, YOUR_USERNAME, YOUR_PASSWORD bằng thông tin SQL Server của bạn.
