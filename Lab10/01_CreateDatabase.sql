-- =============================================
-- Lab 10 - Bài Lab
-- Thiết kế và cài đặt cơ sở dữ liệu EduManagerDB bằng SQL Server
-- File: 01_CreateDatabase.sql
-- Sinh viên: Hoàng Dương Phúc Quang
-- MSSV: 49.01.101.075
-- =============================================

-- Xóa database nếu đã tồn tại
USE master;
GO
DROP DATABASE IF EXISTS EduManagerDB;
GO

-- Tạo database EduManagerDB
CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

-- =============================================
-- Bảng 1: KHOA
-- Lưu thông tin khoa
-- Khóa chính: MaKhoa
-- =============================================
CREATE TABLE KHOA (
    MaKhoa VARCHAR(20) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);
GO

-- =============================================
-- Bảng 2: LOP
-- Lưu thông tin lớp học
-- Khóa chính: MaLop
-- Khóa ngoại: MaKhoa (tham chiếu đến KHOA)
-- Mỗi lớp thuộc một khoa
-- =============================================
CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20) NOT NULL,
    CONSTRAINT FK_LOP_KHOA FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);
GO

-- =============================================
-- Bảng 3: SINHVIEN
-- Lưu thông tin sinh viên
-- Khóa chính: MaSV
-- Khóa ngoại: MaLop (tham chiếu đến LOP)
-- Mỗi sinh viên thuộc một lớp
-- Giới tính chỉ nhận 'Nam' hoặc 'N'
-- =============================================
CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- =============================================
-- Bảng 4: MONHOC
-- Lưu thông tin môn học
-- Khóa chính: MaMH
-- Số tín chỉ phải lớn hơn 0
-- =============================================
CREATE TABLE MONHOC (
    MaMH VARCHAR(20) PRIMARY KEY,
    TenMH NVARCHAR(100) NOT NULL,
    SoTinChi INT CHECK (SoTinChi > 0)
);
GO

-- =============================================
-- Bảng 5: KETQUA
-- Lưu điểm của sinh viên theo môn
-- Khóa chính: (MaSV, MaMH)
-- Khóa ngoại: MaSV (tham chiếu đến SINHVIEN)
-- Khóa ngoại: MaMH (tham chiếu đến MONHOC)
-- Điểm phải trong khoảng 0 đến 10
-- =============================================
CREATE TABLE KETQUA (
    MaSV VARCHAR(20) NOT NULL,
    MaMH VARCHAR(20) NOT NULL,
    Diem DECIMAL(4, 2) CHECK (Diem >= 0 AND Diem <= 10),
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

-- =============================================
-- Bảng 6: TAIKHOAN
-- Lưu tài khoản đăng nhập demo
-- Khóa chính: TenDangNhap
-- =============================================
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(50) NOT NULL,
    VaiTro NVARCHAR(50)
);
GO

PRINT 'Database EduManagerDB và các bảng đã được tạo thành công!';
GO
