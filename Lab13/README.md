# Lab 13 - Báo cáo sinh viên bằng LINQ (StudentReportDemo)

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại

---

## 1. Mô tả bài toán
Ứng dụng Windows Forms `StudentReportDemo` phục vụ việc truy vấn, lọc, sắp xếp và thống kê danh sách sinh viên theo lớp và kết quả học tập sử dụng hoàn toàn công nghệ **Language Integrated Query (LINQ)** trong C#, đồng thời hỗ trợ xuất dữ liệu ra định dạng `.csv` hoặc `.txt`.

---

## 2. Dữ liệu mẫu & Cấu trúc
- **Model `SinhVien`**: Gồm các thuộc tính `MaSV`, `HoTen`, `MaLop`, `TenLop`, `Diem`, và thuộc tính chỉ đọc `KetQua` (trả về `"Đạt"` nếu `Diem >= 5.0`, ngược lại trả về `"Không đạt"`).
- **Dữ liệu mẫu**: Gồm 12 sinh viên thuộc 3 lớp khác nhau (`CNTT1`, `CNTT2`, `CNTT3`), đa dạng các mức điểm từ 2.5 đến 9.0 để kiểm thử chính xác các tiêu chí lọc.

---

## 3. Các chức năng chính (Hiện thực bằng LINQ)
1. **Lọc dữ liệu đa điều kiện**:
   - Lọc theo Lớp (`cboLop`): `"Tất cả"` hoặc từng lớp cụ thể.
   - Lọc theo Kết quả (`cboKetQua`): `"Tất cả"`, `"Đạt"`, `"Không đạt"`.
   - Lọc theo Từ khóa (`txtTuKhoa`): Tìm kiếm không phân biệt hoa thường theo Mã hoặc Họ tên sinh viên.
2. **Sắp xếp tự động**:
   - Sử dụng `.OrderByDescending(s => s.Diem)` để luôn hiển thị danh sách có thứ tự điểm từ cao xuống thấp.
3. **Thống kê tổng hợp & theo lớp**:
   - Sử dụng `.GroupBy(s => s.TenLop)` và các hàm tổng hợp LINQ (`.Count()`, `.Average()`) để tính tổng số sinh viên, số lượng đạt/không đạt, điểm trung bình toàn bộ và điểm trung bình của từng lớp, hiển thị trực quan trên `StatusStrip / Label`.
4. **Xuất báo cáo (Export)**:
   - Sử dụng `SaveFileDialog` hỗ trợ xuất file CSV/TXT mã hóa UTF-8. Đã đính kèm file mẫu [BaoCaoSinhVien.csv](file:///d:/Driver_E/Ho%20so%20tot%20nghiep/CNTT/Lap%20trinh%20tren%20window/2611COMP101904-Lap-trinh-Windows/Lab13/BaoCaoSinhVien.csv).

---

## 4. Bảng kiểm thử (Test Cases)
| STT | Tình huống kiểm thử | Dữ liệu đầu vào | Kết quả mong đợi |
|:---:|---|---|---|
| 1 | Mở Form lần đầu | Mặc định (Tất cả, Tất cả, từ khóa rỗng) | Hiển thị đầy đủ 12 sinh viên, sắp xếp giảm dần theo điểm (cao nhất 9.0, thấp nhất 2.5). |
| 2 | Lọc theo lớp CNTT1 | Chọn `cboLop = "Công nghệ thông tin 1"` | Chỉ hiển thị 4 sinh viên lớp CNTT1. Thống kê cập nhật theo lớp CNTT1. |
| 3 | Lọc sinh viên Đạt | Chọn `cboKetQua = "Đạt"` | Chỉ hiển thị sinh viên có điểm >= 5.0. |
| 4 | Lọc sinh viên Không đạt | Chọn `cboKetQua = "Không đạt"` | Chỉ hiển thị sinh viên có điểm < 5.0. |
| 5 | Tìm theo từ khóa | Nhập `"An"` vào ô Từ khóa | Hiển thị sinh viên có tên chứa `"An"` (Nguyễn An, Bùi Lan, Hoàng Nam,...). |
| 6 | Tìm không thấy kết quả | Nhập từ khóa `"XYZ123"` | Bảng không có dòng nào, status hiển thị Tổng: 0. |
| 7 | Bấm Thống kê | Bấm nút "Thống kê" | Hiển thị chi tiết số lượng SV và điểm TB từng lớp trên thanh trạng thái. |
| 8 | Xuất file CSV | Bấm nút "Xuất file", lưu tên `BaoCaoSinhVien.csv` | File được tạo thành công, có tiêu đề cột và danh sách sinh viên đang lọc. |
