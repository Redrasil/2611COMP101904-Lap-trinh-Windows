# Lab 11 - ADO.NET và CRUD với SQL Server

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Nhóm**: 11
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại
- **Buổi thực hành**: Buổi 11 (Lab 11) - ADO.NET và CRUD với SQL Server

---

## 1. Mục tiêu bài thực hành
- Kết nối ứng dụng Windows Forms với database EduManagerDB trong SQL Server.
- Hiển thị dữ liệu từ bảng LOP lên DataGridView.
- Thực hiện thêm, sửa, xóa và tìm kiếm lớp học bằng câu SQL có tham số.
- Kiểm tra dữ liệu nhập, kiểm tra trùng mã lớp và xử lý lỗi khóa ngoại khi xóa.
- Viết code rõ ràng, có tách hàm xử lý cơ bản để kiểm thử.

---

## 2. Yêu cầu chuẩn bị
- Hoàn thành database EduManagerDB của buổi 10.
- Database phải có tối thiểu hai bảng LOP và SINHVIEN.
- Bảng SINHVIEN có khóa ngoại MaLop tham chiếu đến bảng LOP.
- Tạo project Windows Forms App bằng C#.
- Cài package Microsoft.Data.SqlClient nếu project chưa có thư viện kết nối SQL Server.

---

## 3. Mô tả bài toán
Sinh viên xây dựng Form quản lý lớp học. Dữ liệu lớp học được lưu trong SQL Server, không lưu tạm bằng List<T>.

---

## 4. Giao diện yêu cầu

| Control | Tên control | Mô tả |
| :--- | :--- | :--- |
| Label | lblMaLop | Hiển thị Mã lớp |
| TextBox | txtMaLop | Nhập mã lớp |
| Label | lblTenLop | Hiển thị Tên lớp |
| TextBox | txtTenLop | Nhập tên lớp |
| TextBox | txtTimKiem | Tìm theo mã hoặc tên lớp |
| DataGridView | dgvLop | Hiển thị danh sách lớp |
| Button | btnThem | Thêm lớp |
| Button | btnSua | Cập nhật lớp |
| Button | btnXoa | Xóa lớp |
| Button | btnLamMoi | Xóa dữ liệu đang nhập và load lại |
| Button | btnTimKiem | Tìm kiếm |

---

## 5. Yêu cầu chức năng

- **F1**: Khi mở Form, chương trình tự động load danh sách lớp từ SQL Server lên DataGridView.
- **F2**: Khi chọn một dòng trong DataGridView, dữ liệu được đưa lên txtMaLop và txtTenLop.
- **F3**: Nút Thêm: thêm lớp mới. Không cho thêm nếu mã lớp rỗng, tên lớp rỗng hoặc mã lớp đã tồn tại.
- **F4**: Nút Sửa: cập nhật tên lớp theo mã lớp đang chọn. Không cho sửa nếu chưa chọn lớp.
- **F5**: Nút Xóa: hỏi xác nhận trước khi xóa. Không cho xóa lớp đang có sinh viên.
- **F6**: Nút Tìm kiếm: tìm theo mã lớp hoặc tên lớp bằng LIKE và parameter.
- **F7**: Nút Làm mới: xóa nội dung TextBox, mở khóa txtMaLop và load lại dữ liệu.
- **F8**: Tất cả câu SQL nhận dữ liệu từ người dùng phải dùng SqlParameter, không nối chuỗi trực tiếp.

---

## 6. Script database tối thiểu

```sql
CREATE DATABASE EduManagerDB;
GO
USE EduManagerDB;
GO

CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

INSERT INTO LOP(MaLop, TenLop) VALUES
('CNTT01', N'Công nghệ thông tin 01'),
('CNTT02', N'Công nghệ thông tin 02'),
('SPTIN01', N'Sư phạm Tin học 01');

INSERT INTO SINHVIEN(MaSV, HoTen, MaLop) VALUES
('SV001', N'Nguyễn Văn An', 'CNTT01');
```

---

## 7. Connection String

Connection string đang sử dụng trên máy nhận:

```csharp
// SQL Server Express trên máy hiện tại
private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=EduManagerDB;Integrated Security=True;TrustServerCertificate=True;";

// Hoặc cho SQL Server LocalDB
// private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EduManagerDB;Integrated Security=True;";

// Hoặc cho SQL Server đầy đủ
private readonly string connectionString = "Server=YOUR_SERVER_NAME;Database=EduManagerDB;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;";
```

Thay thế thông tin kết nối theo cấu hình SQL Server của bạn.

---

## 8. Hiện thực kỹ thuật cốt lõi

### 8.1. Load dữ liệu lên DataGridView
```csharp
private void LoadData()
{
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT MaLop, TenLop FROM LOP ORDER BY MaLop";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);
                dgvLop.DataSource = table;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

### 8.2. Thêm lớp với SqlParameter
```csharp
private void btnThem_Click(object? sender, EventArgs e)
{
    if (!ValidateInput())
    {
        return;
    }

    string maLop = txtMaLop.Text.Trim();
    string tenLop = txtTenLop.Text.Trim();

    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Kiểm tra mã lớp đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM LOP WHERE MaLop = @MaLop";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.Add("@MaLop", System.Data.SqlDbType.VarChar, 20).Value = maLop;
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã lớp đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Thêm lớp mới
            string insertQuery = "INSERT INTO LOP (MaLop, TenLop) VALUES (@MaLop, @TenLop)";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.Add("@MaLop", System.Data.SqlDbType.VarChar, 20).Value = maLop;
                insertCommand.Parameters.Add("@TenLop", System.Data.SqlDbType.NVarChar, 100).Value = tenLop;
                insertCommand.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearInput();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi khi thêm lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

### 8.3. Tìm kiếm với LIKE và parameter
```csharp
private void btnTimKiem_Click(object? sender, EventArgs e)
{
    string keyword = txtTimKiem.Text.Trim();

    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT MaLop, TenLop FROM LOP WHERE MaLop LIKE @Keyword OR TenLop LIKE @Keyword ORDER BY MaLop";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Keyword", System.Data.SqlDbType.NVarChar, 100).Value = $"%{keyword}%";
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    System.Data.DataTable table = new System.Data.DataTable();
                    adapter.Fill(table);
                    dgvLop.DataSource = table;
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

### 8.4. Kiểm tra khóa ngoại khi xóa
```csharp
private void btnXoa_Click(object? sender, EventArgs e)
{
    // ... confirmation dialog ...

    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Kiểm tra lớp có sinh viên không
            string checkQuery = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @MaLop";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.Add("@MaLop", System.Data.SqlDbType.VarChar, 20).Value = maLop;
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa lớp đang có sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Xóa lớp
            string deleteQuery = "DELETE FROM LOP WHERE MaLop = @MaLop";
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.Add("@MaLop", System.Data.SqlDbType.VarChar, 20).Value = maLop;
                command.ExecuteNonQuery();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi khi xóa lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

---

## 9. Hướng dẫn biên dịch và kiểm thử

### Bước 1: Tạo database
Chạy các file SQL từ Lab10 theo thứ tự:
1. `01_CreateDatabase.sql`
2. `02_InsertSampleData.sql`

### Bước 2: Cấu hình Connection String
Mở file `FrmClassManager.cs` và thay đổi `connectionString` theo cấu hình SQL Server của bạn.

### Bước 3: Biên dịch và chạy
```powershell
cd Lab11/COMP1019_Lab11_ClassManager
dotnet build
dotnet run
```

Hoặc mở project trong Visual Studio và nhấn F5.

---

## 10. Rubric chấm điểm

| Tiêu chí | Điểm |
| :--- | :--- |
| Giao diện đầy đủ control, đặt tên rõ ràng, dễ sử dụng | 1.0 |
| Kết nối SQL Server và hiển thị dữ liệu lên DataGridView | 2.0 |
| CRUD đúng yêu cầu, có dùng parameter | 3.0 |
| Tìm kiếm theo mã/tên; click dòng đưa dữ liệu lên Form | 1.0 |
| Kiểm tra rỗng, trùng mã, lớp đang có sinh viên | 2.0 |
| Code dễ đọc, có tách hàm, try-catch hợp lý | 1.0 |
| **Tổng** | **10.0** |

---

## 11. Yêu cầu nộp bài

- Push Github
- Nộp file script SQL tạo database và dữ liệu mẫu.
- Chụp màn hình Form đang load dữ liệu từ SQL Server.
- Ghi chú connection string đang sử dụng trên máy nhận.
- Không nộp project chỉ có giao diện nhưng chưa kết nối database.

---

## 12. Cấu trúc thư mục

```text
Lab11/
├── README.md                              # Báo cáo chi tiết Lab 11
└── COMP1019_Lab11_ClassManager/
    ├── COMP1019_Lab11_ClassManager.csproj # File cấu hình dự án
    ├── Program.cs                         # Điểm khởi chạy
    ├── FrmClassManager.cs                 # Form chính chứa logic CRUD
    └── FrmClassManager.Designer.cs        # Thiết kế giao diện
```
