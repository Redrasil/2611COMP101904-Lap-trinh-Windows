using System;
using System.Drawing;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmMain : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsLoggedOut { get; private set; } = false;

        public FrmMain() : this(new User("admin", "123", "Quản trị viên", "Admin"))
        {
        }

        public FrmMain(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng và vai trò lên StatusStrip
            lblUserInfo.Text = $"Người dùng: {CurrentUser.FullName} | Vai trò: {CurrentUser.Role}";
            UpdateClock();

            // Tự động mở sẵn màn hình Quản lý sản phẩm khi khởi chạy
            OpenChildForm<FrmProduct>();
        }

        /// <summary>
        /// Mở Form con MDI và ngăn không cho mở trùng Form cùng loại
        /// (Nếu Form đã mở thì kích hoạt Form cũ theo đúng yêu cầu đề bài)
        /// </summary>
        public void OpenChildForm<T>() where T : Form, new()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)
                {
                    child.Activate();
                    if (child.WindowState == FormWindowState.Minimized)
                    {
                        child.WindowState = FormWindowState.Normal;
                    }
                    return;
                }
            }

            T newChild = new T();
            newChild.MdiParent = this;
            newChild.WindowState = FormWindowState.Maximized;
            newChild.Show();
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmProduct>();
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmCustomer>();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            using (var about = new FrmAbout())
            {
                about.ShowDialog(this);
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có muốn đăng xuất khỏi tài khoản hiện tại không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                IsLoggedOut = true;
                this.Close();
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsLoggedOut) return;

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        #region Quản lý bố cục cửa sổ MDI

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        #endregion
    }
}
