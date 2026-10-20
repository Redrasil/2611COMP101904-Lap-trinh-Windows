# Lab 10 - Thiết kế cơ sở dữ liệu EduManagerDB

## Thông tin sinh viên
- Họ tên: Hoàng Dương Phúc Quang
- MSSV: 49.01.101.075
- Lớp: 49.01.TOAN.SN
- Nhóm: 11

## Mô tả
Thiết kế cơ sở dữ liệu quản lý sinh viên bằng SQL Server. Cơ sở dữ liệu gồm khoa, lớp, sinh viên, môn học, kết quả học tập và tài khoản.

## Cấu trúc file
```text
Lab10/
├── 01_CreateDatabase.sql
├── 02_InsertSampleData.sql
├── 03_Queries.sql
└── README.md
```

## Nội dung thực hiện
- Tạo database `EduManagerDB`.
- Tạo 6 bảng: `KHOA`, `LOP`, `SINHVIEN`, `MONHOC`, `KETQUA`, `TAIKHOAN`.
- Khai báo khóa chính, khóa ngoại và các ràng buộc dữ liệu.
- Nhập dữ liệu mẫu gồm 2 khoa, 3 lớp, 6 sinh viên, 4 môn học, 8 kết quả và 2 tài khoản.
- Viết truy vấn `SELECT`, `JOIN`, `LIKE`, `GROUP BY`, `HAVING`, `UPDATE` và `DELETE`.
- Kiểm tra lỗi khóa ngoại và lỗi điểm ngoài khoảng từ 0 đến 10.

## Cách chạy
Mở SQL Server Management Studio hoặc dùng SQL Server Express, sau đó chạy lần lượt:
1. `01_CreateDatabase.sql`
2. `02_InsertSampleData.sql`
3. `03_Queries.sql`

Connection string đang dùng cho Lab 11:
```text
Server=.\SQLEXPRESS;Database=EduManagerDB;Integrated Security=True;TrustServerCertificate=True;
```

## Kết quả kiểm tra
Sau khi chạy hai file đầu, dữ liệu mẫu có:
- KHOA: 2 dòng
- LOP: 3 dòng
- SINHVIEN: 6 dòng
- MONHOC: 4 dòng
- KETQUA: 8 dòng
- TAIKHOAN: 2 dòng

Trong Query 6, thao tác xóa được đặt trong transaction và rollback sau khi kiểm tra để không làm mất dữ liệu mẫu.
