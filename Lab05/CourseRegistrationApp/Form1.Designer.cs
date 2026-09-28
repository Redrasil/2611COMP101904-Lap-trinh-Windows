namespace CourseRegistrationApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.grbHocVien = new System.Windows.Forms.GroupBox();
            this.chkNhanEmail = new System.Windows.Forms.CheckBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.grbKhoaHoc = new System.Windows.Forms.GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTieuDeTongTien = new System.Windows.Forms.Label();
            this.lblHocPhiThang = new System.Windows.Forms.Label();
            this.lblTieuDeHocPhi = new System.Windows.Forms.Label();
            this.numSoThang = new System.Windows.Forms.NumericUpDown();
            this.lblSoThang = new System.Windows.Forms.Label();
            this.radOffline = new System.Windows.Forms.RadioButton();
            this.radOnline = new System.Windows.Forms.RadioButton();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.lblKhoaHoc = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.grbHocVien.SuspendLayout();
            this.grbKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(784, 60);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "ĐĂNG KÝ KHÓA HỌC";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbHocVien
            // 
            this.grbHocVien.Controls.Add(this.chkNhanEmail);
            this.grbHocVien.Controls.Add(this.dtpNgaySinh);
            this.grbHocVien.Controls.Add(this.txtSoDienThoai);
            this.grbHocVien.Controls.Add(this.txtHoTen);
            this.grbHocVien.Controls.Add(this.lblNgaySinh);
            this.grbHocVien.Controls.Add(this.lblSoDienThoai);
            this.grbHocVien.Controls.Add(this.lblHoTen);
            this.grbHocVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHocVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.grbHocVien.Location = new System.Drawing.Point(30, 75);
            this.grbHocVien.Name = "grbHocVien";
            this.grbHocVien.Size = new System.Drawing.Size(350, 270);
            this.grbHocVien.TabIndex = 1;
            this.grbHocVien.TabStop = false;
            this.grbHocVien.Text = "Thông tin học viên";
            // 
            // chkNhanEmail
            // 
            this.chkNhanEmail.AutoSize = true;
            this.chkNhanEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNhanEmail.ForeColor = System.Drawing.Color.Black;
            this.chkNhanEmail.Location = new System.Drawing.Point(125, 205);
            this.chkNhanEmail.Name = "chkNhanEmail";
            this.chkNhanEmail.Size = new System.Drawing.Size(154, 21);
            this.chkNhanEmail.TabIndex = 3;
            this.chkNhanEmail.Text = "Nhận email thông báo";
            this.chkNhanEmail.UseVisualStyleBackColor = true;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(125, 145);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 25);
            this.dtpNgaySinh.TabIndex = 2;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(125, 95);
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(200, 25);
            this.txtSoDienThoai.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(125, 45);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 25);
            this.txtHoTen.TabIndex = 0;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.ForeColor = System.Drawing.Color.Black;
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 150);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(69, 17);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDienThoai.ForeColor = System.Drawing.Color.Black;
            this.lblSoDienThoai.Location = new System.Drawing.Point(20, 100);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(88, 17);
            this.lblSoDienThoai.TabIndex = 1;
            this.lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.ForeColor = System.Drawing.Color.Black;
            this.lblHoTen.Location = new System.Drawing.Point(20, 50);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(67, 17);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ và tên:";
            // 
            // grbKhoaHoc
            // 
            this.grbKhoaHoc.Controls.Add(this.lblTongTien);
            this.grbKhoaHoc.Controls.Add(this.lblTieuDeTongTien);
            this.grbKhoaHoc.Controls.Add(this.lblHocPhiThang);
            this.grbKhoaHoc.Controls.Add(this.lblTieuDeHocPhi);
            this.grbKhoaHoc.Controls.Add(this.numSoThang);
            this.grbKhoaHoc.Controls.Add(this.lblSoThang);
            this.grbKhoaHoc.Controls.Add(this.radOffline);
            this.grbKhoaHoc.Controls.Add(this.radOnline);
            this.grbKhoaHoc.Controls.Add(this.lblHinhThuc);
            this.grbKhoaHoc.Controls.Add(this.cboKhoaHoc);
            this.grbKhoaHoc.Controls.Add(this.lblKhoaHoc);
            this.grbKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbKhoaHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.grbKhoaHoc.Location = new System.Drawing.Point(400, 75);
            this.grbKhoaHoc.Name = "grbKhoaHoc";
            this.grbKhoaHoc.Size = new System.Drawing.Size(355, 270);
            this.grbKhoaHoc.TabIndex = 2;
            this.grbKhoaHoc.TabStop = false;
            this.grbKhoaHoc.Text = "Thông tin khóa học";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTien.Location = new System.Drawing.Point(125, 222);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(53, 20);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "0 VNĐ";
            // 
            // lblTieuDeTongTien
            // 
            this.lblTieuDeTongTien.AutoSize = true;
            this.lblTieuDeTongTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTongTien.ForeColor = System.Drawing.Color.Black;
            this.lblTieuDeTongTien.Location = new System.Drawing.Point(20, 224);
            this.lblTieuDeTongTien.Name = "lblTieuDeTongTien";
            this.lblTieuDeTongTien.Size = new System.Drawing.Size(73, 17);
            this.lblTieuDeTongTien.TabIndex = 9;
            this.lblTieuDeTongTien.Text = "Tổng tiền:";
            // 
            // lblHocPhiThang
            // 
            this.lblHocPhiThang.AutoSize = true;
            this.lblHocPhiThang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHocPhiThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblHocPhiThang.Location = new System.Drawing.Point(125, 180);
            this.lblHocPhiThang.Name = "lblHocPhiThang";
            this.lblHocPhiThang.Size = new System.Drawing.Size(46, 17);
            this.lblHocPhiThang.TabIndex = 8;
            this.lblHocPhiThang.Text = "0 VNĐ";
            // 
            // lblTieuDeHocPhi
            // 
            this.lblTieuDeHocPhi.AutoSize = true;
            this.lblTieuDeHocPhi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeHocPhi.ForeColor = System.Drawing.Color.Black;
            this.lblTieuDeHocPhi.Location = new System.Drawing.Point(20, 180);
            this.lblTieuDeHocPhi.Name = "lblTieuDeHocPhi";
            this.lblTieuDeHocPhi.Size = new System.Drawing.Size(95, 17);
            this.lblTieuDeHocPhi.TabIndex = 7;
            this.lblTieuDeHocPhi.Text = "Học phí/tháng:";
            // 
            // numSoThang
            // 
            this.numSoThang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoThang.Location = new System.Drawing.Point(125, 135);
            this.numSoThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numSoThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoThang.Name = "numSoThang";
            this.numSoThang.Size = new System.Drawing.Size(80, 25);
            this.numSoThang.TabIndex = 7;
            this.numSoThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSoThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoThang.ValueChanged += new System.EventHandler(this.numSoThang_ValueChanged);
            // 
            // lblSoThang
            // 
            this.lblSoThang.AutoSize = true;
            this.lblSoThang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoThang.ForeColor = System.Drawing.Color.Black;
            this.lblSoThang.Location = new System.Drawing.Point(20, 137);
            this.lblSoThang.Name = "lblSoThang";
            this.lblSoThang.Size = new System.Drawing.Size(63, 17);
            this.lblSoThang.TabIndex = 5;
            this.lblSoThang.Text = "Số tháng:";
            // 
            // radOffline
            // 
            this.radOffline.AutoSize = true;
            this.radOffline.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOffline.ForeColor = System.Drawing.Color.Black;
            this.radOffline.Location = new System.Drawing.Point(215, 92);
            this.radOffline.Name = "radOffline";
            this.radOffline.Size = new System.Drawing.Size(76, 21);
            this.radOffline.TabIndex = 6;
            this.radOffline.Text = "Trực tiếp";
            this.radOffline.UseVisualStyleBackColor = true;
            // 
            // radOnline
            // 
            this.radOnline.AutoSize = true;
            this.radOnline.Checked = true;
            this.radOnline.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOnline.ForeColor = System.Drawing.Color.Black;
            this.radOnline.Location = new System.Drawing.Point(125, 92);
            this.radOnline.Name = "radOnline";
            this.radOnline.Size = new System.Drawing.Size(63, 21);
            this.radOnline.TabIndex = 5;
            this.radOnline.TabStop = true;
            this.radOnline.Text = "Online";
            this.radOnline.UseVisualStyleBackColor = true;
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThuc.ForeColor = System.Drawing.Color.Black;
            this.lblHinhThuc.Location = new System.Drawing.Point(20, 94);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(66, 17);
            this.lblHinhThuc.TabIndex = 2;
            this.lblHinhThuc.Text = "Hình thức:";
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(125, 45);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(210, 25);
            this.cboKhoaHoc.TabIndex = 4;
            this.cboKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.cboKhoaHoc_SelectedIndexChanged);
            // 
            // lblKhoaHoc
            // 
            this.lblKhoaHoc.AutoSize = true;
            this.lblKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoaHoc.ForeColor = System.Drawing.Color.Black;
            this.lblKhoaHoc.Location = new System.Drawing.Point(20, 50);
            this.lblKhoaHoc.Name = "lblKhoaHoc";
            this.lblKhoaHoc.Size = new System.Drawing.Size(66, 17);
            this.lblKhoaHoc.TabIndex = 0;
            this.lblKhoaHoc.Text = "Khóa học:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnThoat);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Controls.Add(this.btnDangKy);
            this.pnlButtons.Location = new System.Drawing.Point(165, 365);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(450, 55);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(310, 8);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 38);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(165, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 38);
            this.btnLamMoi.TabIndex = 9;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(20, 8);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(110, 38);
            this.btnDangKy.TabIndex = 8;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(784, 445);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.grbKhoaHoc);
            this.Controls.Add(this.grbHocVien);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG KÝ KHÓA HỌC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbHocVien.ResumeLayout(false);
            this.grbHocVien.PerformLayout();
            this.grbKhoaHoc.ResumeLayout(false);
            this.grbKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grbHocVien;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.CheckBox chkNhanEmail;
        private System.Windows.Forms.GroupBox grbKhoaHoc;
        private System.Windows.Forms.Label lblKhoaHoc;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.RadioButton radOnline;
        private System.Windows.Forms.RadioButton radOffline;
        private System.Windows.Forms.Label lblSoThang;
        private System.Windows.Forms.NumericUpDown numSoThang;
        private System.Windows.Forms.Label lblTieuDeHocPhi;
        private System.Windows.Forms.Label lblHocPhiThang;
        private System.Windows.Forms.Label lblTieuDeTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
    }
}
