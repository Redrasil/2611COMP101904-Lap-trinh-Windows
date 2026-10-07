namespace ShopManagerMini.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbProduct = new System.Windows.Forms.ToolStripButton();
            this.tsbCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDangXuat = new System.Windows.Forms.ToolStripButton();
            this.tsbThoat = new System.Windows.Forms.ToolStripButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblUserInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAppName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.mnMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnMain
            // 
            this.mnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.mnMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mnMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuCuaSo,
            this.mnuTroGiup});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.MdiWindowListItem = this.mnuCuaSo;
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(1132, 29);
            this.mnMain.TabIndex = 1;
            this.mnMain.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.toolStripSeparator1,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(88, 25);
            this.mnuHeThong.Text = "&Hệ thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuDangXuat.Size = new System.Drawing.Size(219, 26);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(219, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProduct,
            this.mnuCustomer});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(93, 25);
            this.mnuDanhMuc.Text = "&Danh mục";
            // 
            // mnuProduct
            // 
            this.mnuProduct.Name = "mnuProduct";
            this.mnuProduct.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.mnuProduct.Size = new System.Drawing.Size(281, 26);
            this.mnuProduct.Text = "Quản lý sản phẩm";
            this.mnuProduct.Click += new System.EventHandler(this.mnuProduct_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mnuCustomer.Size = new System.Drawing.Size(281, 26);
            this.mnuCustomer.Text = "Quản lý khách hàng";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuCuaSo
            // 
            this.mnuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.toolStripSeparator2,
            this.mnuCloseAll});
            this.mnuCuaSo.Name = "mnuCuaSo";
            this.mnuCuaSo.Size = new System.Drawing.Size(73, 25);
            this.mnuCuaSo.Text = "&Cửa sổ";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(232, 26);
            this.mnuCascade.Text = "Sắp xếp nối tầng";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
            // 
            // mnuTileHorizontal
            // 
            this.mnuTileHorizontal.Name = "mnuTileHorizontal";
            this.mnuTileHorizontal.Size = new System.Drawing.Size(232, 26);
            this.mnuTileHorizontal.Text = "Sắp xếp theo hàng";
            this.mnuTileHorizontal.Click += new System.EventHandler(this.mnuTileHorizontal_Click);
            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(232, 26);
            this.mnuTileVertical.Text = "Sắp xếp theo cột";
            this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(232, 26);
            this.mnuCloseAll.Text = "Đóng tất cả cửa sổ";
            this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAll_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(80, 25);
            this.mnuTroGiup.Text = "&Trợ giúp";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuAbout.Size = new System.Drawing.Size(176, 26);
            this.mnuAbout.Text = "Giới thiệu";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.White;
            this.tsMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbProduct,
            this.tsbCustomer,
            this.toolStripSeparator3,
            this.tsbDangXuat,
            this.tsbThoat});
            this.tsMain.Location = new System.Drawing.Point(0, 29);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.tsMain.Size = new System.Drawing.Size(1132, 37);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbProduct
            // 
            this.tsbProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tsbProduct.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsbProduct.Name = "tsbProduct";
            this.tsbProduct.Size = new System.Drawing.Size(161, 26);
            this.tsbProduct.Text = "📦 Quản lý sản phẩm";
            this.tsbProduct.Click += new System.EventHandler(this.mnuProduct_Click);
            // 
            // tsbCustomer
            // 
            this.tsbCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tsbCustomer.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.tsbCustomer.Name = "tsbCustomer";
            this.tsbCustomer.Size = new System.Drawing.Size(178, 26);
            this.tsbCustomer.Text = "👥 Quản lý khách hàng";
            this.tsbCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // tsbDangXuat
            // 
            this.tsbDangXuat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDangXuat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.tsbDangXuat.Name = "tsbDangXuat";
            this.tsbDangXuat.Size = new System.Drawing.Size(85, 26);
            this.tsbDangXuat.Text = "🔓 Đăng xuất";
            this.tsbDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // tsbThoat
            // 
            this.tsbThoat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbThoat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbThoat.ForeColor = System.Drawing.Color.Crimson;
            this.tsbThoat.Name = "tsbThoat";
            this.tsbThoat.Size = new System.Drawing.Size(70, 26);
            this.tsbThoat.Text = "❌ Thoát";
            this.tsbThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // ssMain
            // 
            this.ssMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ssMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ssMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserInfo,
            this.lblAppName,
            this.lblClock});
            this.ssMain.Location = new System.Drawing.Point(0, 686);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(1132, 27);
            this.ssMain.TabIndex = 3;
            this.ssMain.Text = "statusStrip1";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(271, 21);
            this.lblUserInfo.Text = "Người dùng: [Chưa xác định] | Vai trò: ...";
            // 
            // lblAppName
            // 
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(684, 21);
            this.lblAppName.Spring = true;
            this.lblAppName.Text = "ShopManagerMini - Hệ thống quản lý bán hàng đa cửa sổ (MDI)";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClock
            // 
            this.lblClock.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(162, 21);
            this.lblClock.Text = "01/01/2026 00:00:00";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1132, 713);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnMain;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopManagerMini - Hệ thống quản lý cửa hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbProduct;
        private System.Windows.Forms.ToolStripButton tsbCustomer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDangXuat;
        private System.Windows.Forms.ToolStripButton tsbThoat;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblUserInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblAppName;
        private System.Windows.Forms.ToolStripStatusLabel lblClock;
        private System.Windows.Forms.Timer timerClock;
    }
}
