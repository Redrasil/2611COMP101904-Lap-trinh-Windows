using Microsoft.Data.SqlClient;

namespace COMP1019_Lab11_ClassManager;

public partial class FrmClassManager : Form
{
    // Connection string - thay đổi theo cấu hình SQL Server của bạn
    // cho SQL Server LocalDB
    private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EduManagerDB;Integrated Security=True;";

    // cho SQL Server Express
    // private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=EduManagerDB;Integrated Security=True;";

    public FrmClassManager()
    {
        InitializeComponent();
    }

    private void FrmClassManager_Load(object? sender, EventArgs e)
    {
        LoadData();
    }

    // F1: Khi mở Form, chương trình tự động load danh sách lớp từ SQL Server lên DataGridView
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

                    // Đặt tên cột hiển thị
                    dgvLop.Columns[0].HeaderText = "Mã Lớp";
                    dgvLop.Columns[1].HeaderText = "Tên Lớp";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // F2: Khi chọn một dòng trong DataGridView, dữ liệu được đưa lên txtMaLop và txtTenLop
    private void dgvLop_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
            txtTenLop.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
        }
    }

    // F3: Nút Thêm: thêm lớp mới
    // Không cho thêm nếu mã lớp rỗng, tên lớp rỗng hoặc mã lớp đã tồn tại
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
                        txtMaLop.Focus();
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

    // F4: Nút Sửa: cập nhật tên lớp theo mã lớp đang chọn
    // Không cho sửa nếu chưa chọn lớp
    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMaLop.Text))
        {
            MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTenLop.Text))
        {
            MessageBox.Show("Tên lớp không được rỗng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenLop.Focus();
            return;
        }

        string maLop = txtMaLop.Text.Trim();
        string tenLop = txtTenLop.Text.Trim();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE LOP SET TenLop = @TenLop WHERE MaLop = @MaLop";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.Add("@TenLop", System.Data.SqlDbType.NVarChar, 100).Value = tenLop;
                    command.Parameters.Add("@MaLop", System.Data.SqlDbType.VarChar, 20).Value = maLop;
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInput();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi cập nhật lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // F5: Nút Xóa: hỏi xác nhận trước khi xóa
    // Không cho xóa lớp đang có sinh viên
    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMaLop.Text))
        {
            MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string maLop = txtMaLop.Text.Trim();

        DialogResult result = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa lớp {maLop}?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            return;
        }

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
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInput();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi xóa lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // F6: Nút Tìm kiếm: tìm theo mã lớp hoặc tên lớp bằng LIKE và parameter
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

                        dgvLop.Columns[0].HeaderText = "Mã Lớp";
                        dgvLop.Columns[1].HeaderText = "Tên Lớp";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // F7: Nút Làm mới: xóa nội dung TextBox, mở khóa txtMaLop và load lại dữ liệu
    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        ClearInput();
        LoadData();
    }

    // Xóa nội dung TextBox
    private void ClearInput()
    {
        txtMaLop.Clear();
        txtTenLop.Clear();
        txtTimKiem.Clear();
        txtMaLop.ReadOnly = false;
    }

    // Validate input
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtMaLop.Text))
        {
            MessageBox.Show("Mã lớp không được rỗng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaLop.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtTenLop.Text))
        {
            MessageBox.Show("Tên lớp không được rỗng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenLop.Focus();
            return false;
        }

        return true;
    }

    // Xử lý phím tắt F1-F7
    private void FrmClassManager_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.F1:
                LoadData();
                e.Handled = true;
                break;
            case Keys.F2:
                // F2: Xử lý khi chọn dòng trong DataGridView (đã có trong dgvLop_CellClick)
                e.Handled = true;
                break;
            case Keys.F3:
                btnThem_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
            case Keys.F4:
                btnSua_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
            case Keys.F5:
                btnXoa_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
            case Keys.F6:
                btnTimKiem_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
            case Keys.F7:
                btnLamMoi_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
        }
    }
}
