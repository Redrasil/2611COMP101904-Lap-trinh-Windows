-- =============================================
-- Lab 10 - Bài Lab
-- Thiết kế và cài đặt cơ sở dữ liệu EduManagerDB bằng SQL Server
-- File: 03_Queries.sql
-- Sinh viên: Hoàng Dương Phúc Quang
-- MSSV: 49.01.101.075
-- =============================================

USE EduManagerDB;
GO

-- =============================================
-- CÁC TRUY VẤN YÊU CẦU
-- =============================================

-- =============================================
-- Query 1: Liệt kê toàn bộ sinh viên
-- =============================================
SELECT N'Query 1: Liệt kê toàn bộ sinh viên' AS 'Truy vấn';
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
GO

-- =============================================
-- Query 2: Liệt kê sinh viên kèm tên lớp và tên khoa
-- Sử dụng JOIN để lấy thông tin từ bảng LOP và KHOA
-- =============================================
SELECT N'Query 2: Liệt kê sinh viên kèm tên lớp và tên khoa' AS 'Truy vấn';
SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh,
       l.TenLop, k.TenKhoa
FROM SINHVIEN sv
JOIN LOP l ON sv.MaLop = l.MaLop
JOIN KHOA k ON l.MaKhoa = k.MaKhoa;
GO

-- =============================================
-- Query 3: Tìm sinh viên theo một phần tên bằng LIKE
-- Ví dụ: Tìm sinh viên có tên chứa "An"
-- =============================================
SELECT N'Query 3: Tìm sinh viên theo một phần tên bằng LIKE' AS 'Truy vấn';
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%';
GO

-- =============================================
-- Query 4: Liệt kê sinh viên theo mã lớp
-- Ví dụ: Liệt kê sinh viên của lớp CNTT01
-- =============================================
SELECT N'Query 4: Liệt kê sinh viên theo mã lớp (CNTT01)' AS 'Truy vấn';
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN
WHERE MaLop = 'CNTT01';
GO

-- =============================================
-- Query 5: Cập nhật họ tên hoặc lớp của một sinh viên
-- Ví dụ: Cập nhật họ tên sinh viên SV001
-- =============================================
SELECT N'Query 5: Cập nhật họ tên sinh viên SV001' AS 'Truy vấn';
-- Hiển thị trước khi cập nhật
SELECT MaSV, HoTen FROM SINHVIEN WHERE MaSV = 'SV001';

-- Cập nhật
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (Đã cập nhật)'
WHERE MaSV = 'SV001';

-- Hiển thị sau khi cập nhật
SELECT MaSV, HoTen FROM SINHVIEN WHERE MaSV = 'SV001';

-- Rollback để khôi phục dữ liệu gốc
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An'
WHERE MaSV = 'SV001';
GO

-- =============================================
-- Query 6: Xóa một sinh viên chưa có dữ liệu điểm
-- Kiểm tra sinh viên không có trong bảng KETQUA
-- =============================================
SELECT N'Query 6: Xóa sinh viên chưa có dữ liệu điểm' AS 'Truy vấn';

-- Tìm sinh viên chưa có điểm
SELECT sv.MaSV, sv.HoTen
FROM SINHVIEN sv
LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV
WHERE kq.MaSV IS NULL;

-- Ví dụ: Xóa sinh viên SV006 (nếu chưa có điểm)
DELETE sv
FROM SINHVIEN sv
LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV
WHERE sv.MaSV = 'SV006'
  AND kq.MaSV IS NULL;

-- Kiểm tra lại sau khi xóa
SELECT MaSV, HoTen
FROM SINHVIEN
WHERE MaSV = 'SV006';
GO

-- =============================================
-- Query 7: Liệt kê điểm của từng sinh viên theo từng môn
-- Sử dụng JOIN để lấy tên sinh viên và tên môn học
-- =============================================
SELECT N'Query 7: Liệt kê điểm của từng sinh viên theo từng môn' AS 'Truy vấn';
SELECT sv.MaSV, sv.HoTen, mh.MaMH, mh.TenMH, kq.Diem
FROM SINHVIEN sv
JOIN KETQUA kq ON sv.MaSV = kq.MaSV
JOIN MONHOC mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.MaMH;
GO

-- =============================================
-- Query 8: Tính điểm trung bình của từng sinh viên
-- Sử dụng GROUP BY và AVG
-- =============================================
SELECT N'Query 8: Tính điểm trung bình của từng sinh viên' AS 'Truy vấn';
SELECT sv.MaSV, sv.HoTen, l.TenLop,
       AVG(kq.Diem) AS DiemTrungBinh,
       COUNT(kq.MaMH) AS SoMonHoc
FROM SINHVIEN sv
JOIN LOP l ON sv.MaLop = l.MaLop
LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen, l.TenLop
ORDER BY DiemTrungBinh DESC;
GO

-- =============================================
-- Query 9: Thống kê số sinh viên theo từng lớp
-- Sử dụng GROUP BY và COUNT
-- =============================================
SELECT N'Query 9: Thống kê số sinh viên theo từng lớp' AS 'Truy vấn';
SELECT l.MaLop, l.TenLop, k.TenKhoa,
       COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
JOIN KHOA k ON l.MaKhoa = k.MaKhoa
GROUP BY l.MaLop, l.TenLop, k.TenKhoa
ORDER BY SoSinhVien DESC;
GO

-- =============================================
-- Query 10: Liệt kê các lớp có từ 2 sinh viên trở lên
-- Sử dụng GROUP BY và HAVING
-- =============================================
SELECT N'Query 10: Liệt kê các lớp có từ 2 sinh viên trở lên' AS 'Truy vấn';
SELECT l.MaLop, l.TenLop, k.TenKhoa,
       COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
JOIN KHOA k ON l.MaKhoa = k.MaKhoa
GROUP BY l.MaLop, l.TenLop, k.TenKhoa
HAVING COUNT(sv.MaSV) >= 2
ORDER BY SoSinhVien DESC;
GO

-- =============================================
-- Query 11: Test lỗi khi thêm sinh viên vào lớp không tồn tại
-- Thử thêm sinh viên với MaLop không tồn tại trong bảng LOP
-- Kết quả: Lỗi do ràng buộc khóa ngoại
-- =============================================
SELECT N'Query 11: Test lỗi khi thêm sinh viên vào lớp không tồn tại' AS 'Truy vấn';

-- Thử thêm sinh viên với MaLop không tồn tại
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV999', N'Sinh viên test', '2000-01-01', 'Nam', 'LOP999');
    PRINT N'Thêm thành công (không nên xảy ra)';
END TRY
BEGIN CATCH
    PRINT N'Lỗi ràng buộc khóa ngoại: Lớp không tồn tại!';
    PRINT ERROR_MESSAGE();
END CATCH;
GO

-- =============================================
-- Query 12: Test lỗi khi nhập điểm ngoài khoảng 0 đến 10
-- Thử nhập điểm = 15 (vượt quá 10)
-- Kết quả: Lỗi do ràng buộc CHECK
-- =============================================
SELECT N'Query 12: Test lỗi khi nhập điểm ngoài khoảng 0 đến 10' AS 'Truy vấn';

-- Thử nhập điểm = 15
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem)
    VALUES ('SV001', 'MH001', 15);
    PRINT N'Thêm thành công (không nên xảy ra)';
END TRY
BEGIN CATCH
    PRINT N'Lỗi ràng buộc CHECK: Điểm phải trong khoảng 0 đến 10!';
    PRINT ERROR_MESSAGE();
END CATCH;

-- Thử nhập điểm = -5 (nhỏ hơn 0)
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem)
    VALUES ('SV001', 'MH001', -5);
    PRINT N'Thêm thành công (không nên xảy ra)';
END TRY
BEGIN CATCH
    PRINT N'Lỗi ràng buộc CHECK: Điểm phải trong khoảng 0 đến 10!';
    PRINT ERROR_MESSAGE();
END CATCH;
GO

PRINT 'Đã thực hiện xong tất cả các truy vấn!';
GO
