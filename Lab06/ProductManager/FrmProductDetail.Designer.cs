namespace ProductManager
{
    partial class FrmProductDetail
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
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblDuongDanAnh = new System.Windows.Forms.Label();
            this.lblDuongDanTitle = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTrangThaiTitle = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblNgayNhapTitle = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblThanhTienTitle = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblSoLuongTitle = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblDonGiaTitle = new System.Windows.Forms.Label();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.lblLoaiSPTitle = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblTenSPTitle = new System.Windows.Forms.Label();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblMaSPTitle = new System.Windows.Forms.Label();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lblDuongDanAnh);
            this.grpDetail.Controls.Add(this.lblDuongDanTitle);
            this.grpDetail.Controls.Add(this.lblTrangThai);
            this.grpDetail.Controls.Add(this.lblTrangThaiTitle);
            this.grpDetail.Controls.Add(this.lblNgayNhap);
            this.grpDetail.Controls.Add(this.lblNgayNhapTitle);
            this.grpDetail.Controls.Add(this.lblThanhTien);
            this.grpDetail.Controls.Add(this.lblThanhTienTitle);
            this.grpDetail.Controls.Add(this.lblSoLuong);
            this.grpDetail.Controls.Add(this.lblSoLuongTitle);
            this.grpDetail.Controls.Add(this.lblDonGia);
            this.grpDetail.Controls.Add(this.lblDonGiaTitle);
            this.grpDetail.Controls.Add(this.lblLoaiSP);
            this.grpDetail.Controls.Add(this.lblLoaiSPTitle);
            this.grpDetail.Controls.Add(this.lblTenSP);
            this.grpDetail.Controls.Add(this.lblTenSPTitle);
            this.grpDetail.Controls.Add(this.lblMaSP);
            this.grpDetail.Controls.Add(this.lblMaSPTitle);
            this.grpDetail.Controls.Add(this.picProduct);
            this.grpDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetail.Location = new System.Drawing.Point(16, 15);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetail.Size = new System.Drawing.Size(600, 360);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Thông tin chi tiết sản phẩm";
            // 
            // lblDuongDanAnh
            // 
            this.lblDuongDanAnh.AutoEllipsis = true;
            this.lblDuongDanAnh.Location = new System.Drawing.Point(340, 318);
            this.lblDuongDanAnh.Name = "lblDuongDanAnh";
            this.lblDuongDanAnh.Size = new System.Drawing.Size(245, 23);
            this.lblDuongDanAnh.TabIndex = 17;
            this.lblDuongDanAnh.Text = "...";
            // 
            // lblDuongDanTitle
            // 
            this.lblDuongDanTitle.AutoSize = true;
            this.lblDuongDanTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDuongDanTitle.Location = new System.Drawing.Point(230, 318);
            this.lblDuongDanTitle.Name = "lblDuongDanTitle";
            this.lblDuongDanTitle.Size = new System.Drawing.Size(89, 21);
            this.lblDuongDanTitle.TabIndex = 16;
            this.lblDuongDanTitle.Text = "Tệp ảnh:";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.Location = new System.Drawing.Point(340, 280);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(26, 21);
            this.lblTrangThai.TabIndex = 15;
            this.lblTrangThai.Text = "...";
            // 
            // lblTrangThaiTitle
            // 
            this.lblTrangThaiTitle.AutoSize = true;
            this.lblTrangThaiTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiTitle.Location = new System.Drawing.Point(230, 280);
            this.lblTrangThaiTitle.Name = "lblTrangThaiTitle";
            this.lblTrangThaiTitle.Size = new System.Drawing.Size(91, 21);
            this.lblTrangThaiTitle.TabIndex = 14;
            this.lblTrangThaiTitle.Text = "Trạng thái:";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(340, 242);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(25, 23);
            this.lblNgayNhap.TabIndex = 13;
            this.lblNgayNhap.Text = "...";
            // 
            // lblNgayNhapTitle
            // 
            this.lblNgayNhapTitle.AutoSize = true;
            this.lblNgayNhapTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayNhapTitle.Location = new System.Drawing.Point(230, 242);
            this.lblNgayNhapTitle.Name = "lblNgayNhapTitle";
            this.lblNgayNhapTitle.Size = new System.Drawing.Size(99, 21);
            this.lblNgayNhapTitle.TabIndex = 12;
            this.lblNgayNhapTitle.Text = "Ngày nhập:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblThanhTien.Location = new System.Drawing.Point(340, 204);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(26, 21);
            this.lblThanhTien.TabIndex = 11;
            this.lblThanhTien.Text = "...";
            // 
            // lblThanhTienTitle
            // 
            this.lblThanhTienTitle.AutoSize = true;
            this.lblThanhTienTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblThanhTienTitle.Location = new System.Drawing.Point(230, 204);
            this.lblThanhTienTitle.Name = "lblThanhTienTitle";
            this.lblThanhTienTitle.Size = new System.Drawing.Size(97, 21);
            this.lblThanhTienTitle.TabIndex = 10;
            this.lblThanhTienTitle.Text = "Thành tiền:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(340, 166);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(25, 23);
            this.lblSoLuong.TabIndex = 9;
            this.lblSoLuong.Text = "...";
            // 
            // lblSoLuongTitle
            // 
            this.lblSoLuongTitle.AutoSize = true;
            this.lblSoLuongTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongTitle.Location = new System.Drawing.Point(230, 166);
            this.lblSoLuongTitle.Name = "lblSoLuongTitle";
            this.lblSoLuongTitle.Size = new System.Drawing.Size(83, 21);
            this.lblSoLuongTitle.TabIndex = 8;
            this.lblSoLuongTitle.Text = "Số lượng:";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDonGia.Location = new System.Drawing.Point(340, 128);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(25, 23);
            this.lblDonGia.TabIndex = 7;
            this.lblDonGia.Text = "...";
            // 
            // lblDonGiaTitle
            // 
            this.lblDonGiaTitle.AutoSize = true;
            this.lblDonGiaTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDonGiaTitle.Location = new System.Drawing.Point(230, 128);
            this.lblDonGiaTitle.Name = "lblDonGiaTitle";
            this.lblDonGiaTitle.Size = new System.Drawing.Size(75, 21);
            this.lblDonGiaTitle.TabIndex = 6;
            this.lblDonGiaTitle.Text = "Đơn giá:";
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Location = new System.Drawing.Point(340, 90);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(25, 23);
            this.lblLoaiSP.TabIndex = 5;
            this.lblLoaiSP.Text = "...";
            // 
            // lblLoaiSPTitle
            // 
            this.lblLoaiSPTitle.AutoSize = true;
            this.lblLoaiSPTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiSPTitle.Location = new System.Drawing.Point(230, 90);
            this.lblLoaiSPTitle.Name = "lblLoaiSPTitle";
            this.lblLoaiSPTitle.Size = new System.Drawing.Size(70, 21);
            this.lblLoaiSPTitle.TabIndex = 4;
            this.lblLoaiSPTitle.Text = "Loại SP:";
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.ForeColor = System.Drawing.Color.Navy;
            this.lblTenSP.Location = new System.Drawing.Point(340, 52);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(25, 23);
            this.lblTenSP.TabIndex = 3;
            this.lblTenSP.Text = "...";
            // 
            // lblTenSPTitle
            // 
            this.lblTenSPTitle.AutoSize = true;
            this.lblTenSPTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenSPTitle.Location = new System.Drawing.Point(230, 52);
            this.lblTenSPTitle.Name = "lblTenSPTitle";
            this.lblTenSPTitle.Size = new System.Drawing.Size(68, 21);
            this.lblTenSPTitle.TabIndex = 2;
            this.lblTenSPTitle.Text = "Tên SP:";
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaSP.Location = new System.Drawing.Point(340, 24);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(25, 23);
            this.lblMaSP.TabIndex = 1;
            this.lblMaSP.Text = "...";
            // 
            // lblMaSPTitle
            // 
            this.lblMaSPTitle.AutoSize = true;
            this.lblMaSPTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaSPTitle.Location = new System.Drawing.Point(230, 24);
            this.lblMaSPTitle.Name = "lblMaSPTitle";
            this.lblMaSPTitle.Size = new System.Drawing.Size(65, 21);
            this.lblMaSPTitle.TabIndex = 0;
            this.lblMaSPTitle.Text = "Mã SP:";
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(16, 32);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(195, 245);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(516, 386);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 36);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(634, 434);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grpDetail);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết sản phẩm";
            this.Load += new System.EventHandler(this.FrmProductDetail_Load);
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label lblMaSPTitle;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblTenSPTitle;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblLoaiSPTitle;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.Label lblDonGiaTitle;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblSoLuongTitle;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblThanhTienTitle;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblNgayNhapTitle;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblTrangThaiTitle;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblDuongDanTitle;
        private System.Windows.Forms.Label lblDuongDanAnh;
        private System.Windows.Forms.Button btnDong;
    }
}
