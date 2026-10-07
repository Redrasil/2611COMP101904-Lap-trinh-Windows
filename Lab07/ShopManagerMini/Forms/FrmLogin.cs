using System;
using System.Windows.Forms;
using ShopManagerMini.Models;
using ShopManagerMini.Services;

namespace ShopManagerMini.Forms
{
    public partial class FrmLogin : Form
    {
        public User LoggedInUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "123";
            txtUsername.Focus();
            txtUsername.SelectAll();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = (txtUsername.Text ?? string.Empty).Trim();
            string password = (txtPassword.Text ?? string.Empty).Trim();

            // Kiểm tra rỗng theo yêu cầu: "Nếu bỏ trống username hoặc password thì hiển thị cảnh báo"
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Kiểm tra tài khoản mẫu
            User authenticatedUser = DataStore.Authenticate(username, password);

            if (authenticatedUser != null)
            {
                LoggedInUser = authenticatedUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // "Nếu sai thì hiển thị MessageBox thông báo lỗi"
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!\n(Tài khoản mẫu: admin / 123 hoặc user / 123)",
                                "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
