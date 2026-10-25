-- =============================================
-- Lab 10 - Bài Lab
-- Thiết kế và cài đặt cơ sở dữ liệu EduManagerDB bằng SQL Server
-- File: 02_InsertSampleData.sql
-- Sinh viên: Hoàng Dương Phúc Quang
-- MSSV: 49.01.101.075
-- =============================================

USE EduManagerDB;
GO

-- =============================================
-- Nhập dữ liệu bảng KHOA (2 khoa)
-- =============================================
INSERT INTO KHOA (MaKhoa, TenKhoa) VALUES
('CNTT', N'Công nghệ thông tin'),
('KT', N'Kinh tế');
GO

-- =============================================
-- Nhập dữ liệu bảng LOP (3 lớp)
-- Mỗi lớp thuộc một khoa
-- =============================================
INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES
('CNTT01', N'Công nghệ thông tin 01', 'CNTT'),
('CNTT02', N'Công nghệ thông tin 02', 'CNTT'),
('KT01', N'Kinh tế 01', 'KT');
GO

-- =============================================
-- Nhập dữ liệu bảng SINHVIEN (6 sinh viên)
-- Mỗi sinh viên thuộc một lớp
-- =============================================
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) VALUES
('SV001', N'Nguyễn Văn An', '2000-05-15', N'Nam', 'CNTT01'),
('SV002', N'Trần Thị Bình', '2001-03-20', N'Nữ', 'CNTT01'),
('SV003', N'Lê Văn Cường', '2000-08-10', N'Nam', 'CNTT01'),
('SV004', N'Phạm Thị Dung', '2001-12-05', N'Nữ', 'CNTT02'),
('SV005', N'Hoàng Văn Em', '2000-07-25', N'Nam', 'CNTT02'),
('SV006', N'Ngô Thị Giang', '2001-09-30', N'Nữ', 'KT01');
GO

-- =============================================
-- Nhập dữ liệu bảng MONHOC (4 môn học)
-- Số tín chỉ phải lớn hơn 0
-- =============================================
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES
('MH001', N'Lập trình trên Windows', 3),
('MH002', N'Cơ sở dữ liệu', 4),
('MH003', N'Cấu trúc dữ liệu và giải thuật', 4),
('MH004', N'Toán rời rạc', 3);
GO

-- =============================================
-- Nhập dữ liệu bảng KETQUA (8 kết quả học tập)
-- Điểm phải trong khoảng 0 đến 10
-- =============================================
INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES
('SV001', 'MH001', 8.5),
('SV001', 'MH002', 7.0),
('SV002', 'MH001', 9.0),
('SV002', 'MH003', 8.0),
('SV003', 'MH001', 7.5),
('SV003', 'MH004', 6.5),
('SV004', 'MH002', 8.5),
('SV005', 'MH003', 7.0);
GO

-- =============================================
-- Nhập dữ liệu bảng TAIKHOAN (2 tài khoản)
-- =============================================
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, VaiTro) VALUES
('admin', '123456', N'Quản trị viên'),
('user', '123456', N'Người dùng');
GO

PRINT 'Dữ liệu mẫu đã được nhập thành công!';
GO

-- =============================================
-- Kiểm tra dữ liệu đã nhập
-- =============================================
SELECT N'=== KHOA ===' AS 'Bảng';
SELECT * FROM KHOA;

SELECT N'=== LOP ===' AS 'Bảng';
SELECT * FROM LOP;

SELECT N'=== SINHVIEN ===' AS 'Bảng';
SELECT * FROM SINHVIEN;

SELECT N'=== MONHOC ===' AS 'Bảng';
SELECT * FROM MONHOC;

SELECT N'=== KETQUA ===' AS 'Bảng';
SELECT * FROM KETQUA;

SELECT N'=== TAIKHOAN ===' AS 'Bảng';
SELECT * FROM TAIKHOAN;
GO
