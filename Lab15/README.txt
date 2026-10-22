LAB 15 - MVP, kiểm thử và bàn giao

Chạy StudentMvpDemo.csproj bằng Visual Studio 2022/.NET 8. Form chỉ phát sinh event và hiển thị dữ liệu; StudentPresenter xử lý nghiệp vụ; StudentRepository lưu dữ liệu mẫu trong bộ nhớ.

Test case:
1. Mở ứng dụng: danh sách 3 sinh viên hiển thị.
2. Thêm với ô rỗng: hiển thị lỗi validation.
3. Thêm mã SV001: từ chối mã trùng.
4. Thêm sinh viên hợp lệ: danh sách tăng thêm một dòng.
5. Chọn một dòng và xóa: dòng bị xóa, có thông báo thành công.
6. Nhập từ khóa vào Tìm kiếm: chỉ các sinh viên phù hợp được hiển thị.

Checklist bàn giao:
- [x] Tách Models, Views, Presenters, Repositories.
- [x] Button không chứa logic nghiệp vụ.
- [x] Có dữ liệu mẫu để kiểm tra ngay.
- [x] Có validation rỗng, sai mã và trùng mã.
- [ ] Chụp màn hình chạy thực tế.
