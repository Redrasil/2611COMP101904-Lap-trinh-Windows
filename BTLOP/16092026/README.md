# BÀI TẬP TRÊN LỚP – QUẢN LÝ NHÂN VIÊN (16/09/2026)

## 📌 Thông tin sinh viên
- **Họ và tên:** Hoàng Dương Phúc Quang
- **MSSV:** 49.01.101.075
- **Lớp:** 49.01.TOAN.SN
- **Môn học:** Lập trình Windows (COMP1019)
- **Thời gian thực hiện:** 16/09/2026

---

## 📖 Mô tả đề bài
Xây dựng chương trình **Console C# Quản lý nhân viên**, vận dụng toàn diện các kiến thức hướng đối tượng (OOP):
- **Class & Property:** Định nghĩa các lớp với thuộc tính đầy đủ getter/setter.
- **Constructor & Encapsulation:** Đóng gói dữ liệu an toàn (`private` fields), khởi tạo hợp lệ.
- **Kế thừa (Inheritance):** `NhanVienVanPhong`, `NhanVienKinhDoanh`, `NhanVienThoiVu` kế thừa từ `NhanVien`, tái sử dụng logic thông qua `base(...)`.
- **Đa hình (Polymorphism):** Định nghĩa phương thức ảo `virtual` ở lớp cha và ghi đè `override` ở các lớp con.

---

## 🏛️ Cấu trúc các lớp (Class Hierarchy)

### 1. Lớp cha: `NhanVien`
- Thuộc tính: `MaNV`, `HoTen`, `LuongCoBan` (> 0).
- Constructor: Khởi tạo thông tin cơ bản.
- Phương thức ảo:
  - `virtual double TinhLuong()`: Trả về lương cơ bản.
  - `virtual void HienThiThongTin()`: Xuất thông tin nhân viên theo định dạng chuẩn.

### 2. Lớp con: `NhanVienVanPhong` (kế thừa `NhanVien`)
- Thuộc tính bổ sung: `SoNgayLamViec` (ràng buộc 0–31).
- Constructor: Dùng `base(maNV, hoTen, luongCoBan)`.
- Ghi đè phương thức:
  - `override double TinhLuong()`: `LuongCoBan + SoNgayLamViec * 200.000`
  - `override void HienThiThongTin()`: Bổ sung số ngày công và tổng lương.

### 3. Lớp con: `NhanVienKinhDoanh` (kế thừa `NhanVien`)
- Thuộc tính bổ sung: `DoanhSo` (ràng buộc >= 0).
- Constructor: Dùng `base(maNV, hoTen, luongCoBan)`.
- Ghi đè phương thức:
  - `override double TinhLuong()`: `LuongCoBan + 5% * DoanhSo`
  - `override void HienThiThongTin()`: Bổ sung doanh số bán hàng và tổng lương.

### 4. Lớp Bonus: `NhanVienThoiVu` (kế thừa `NhanVien`)
- Thuộc tính bổ sung: `SoGioLam`, `LuongTheoGio`.
- Constructor: Dùng `base(maNV, hoTen, 0)` do nhân viên thời vụ không hưởng lương cứng cố định.
- Ghi đè phương thức:
  - `override double TinhLuong()`: `SoGioLam * LuongTheoGio`
  - `override void HienThiThongTin()`: Bổ sung số giờ làm việc, đơn giá theo giờ và tổng lương.

---

## 🎯 Ứng dụng Tính Đa hình (Polymorphism)
Chương trình tuân thủ nghiêm ngặt yêu cầu:
- **Không dùng `if` / `switch` / `is` / `as`** để kiểm tra loại nhân viên khi xuất thông tin và tính lương.
- Mọi thao tác tính toán lương và hiển thị đều gọi trực tiếp qua `nv.TinhLuong()` và `nv.HienThiThongTin()`.
- **Open/Closed Principle (OCP):** Khi bổ sung thêm loại nhân viên mới (`NhanVienThoiVu`), các thuật toán tìm nhân viên lương cao nhất và tính tổng lương **hoàn toàn giữ nguyên**, không cần chỉnh sửa một dòng code nào.

---

## 📋 Menu chức năng
```text
========== MENU ==========
1. Xuất danh sách nhân viên
2. Tìm nhân viên theo mã
3. Tìm nhân viên có lương cao nhất
4. Tính tổng lương công ty phải trả
5. Nhập thêm nhân viên mới
0. Thoát
```

---

## 🚀 Hướng dẫn chạy chương trình
1. Mở file solution `QuanLyNhanVien.sln` (hoặc `QuanLyNhanVien.slnx`) bằng **Visual Studio**.
2. Nhấn tổ hợp phím **Ctrl + F5** (hoặc nút **Start**) để biên dịch và chạy chương trình.
3. Thử nghiệm các chức năng từ 1 đến 5 trên menu console.
