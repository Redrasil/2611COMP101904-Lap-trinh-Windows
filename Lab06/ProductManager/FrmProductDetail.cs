using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProductManager.Models;

namespace ProductManager
{
    public partial class FrmProductDetail : Form
    {
        private readonly Product _product;

        public FrmProductDetail(Product product)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
            InitializeComponent();
        }

        private void FrmProductDetail_Load(object sender, EventArgs e)
        {
            lblMaSP.Text = _product.MaSP;
            lblTenSP.Text = _product.TenSP;
            lblLoaiSP.Text = _product.LoaiSP;
            lblDonGia.Text = string.Format("{0:N0} VNĐ", _product.DonGia);
            lblSoLuong.Text = string.Format("{0:N0} sản phẩm", _product.SoLuong);
            lblThanhTien.Text = string.Format("{0:N0} VNĐ", _product.TongTien);
            lblNgayNhap.Text = _product.NgayNhap.ToString("dd/MM/yyyy");
            
            if (_product.ConKinhDoanh)
            {
                lblTrangThai.Text = "Đang kinh doanh";
                lblTrangThai.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblTrangThai.Text = "Ngừng kinh doanh";
                lblTrangThai.ForeColor = Color.Crimson;
            }

            lblDuongDanAnh.Text = string.IsNullOrWhiteSpace(_product.DuongDanAnh) ? "(Chưa có ảnh)" : _product.DuongDanAnh;

            LoadProductImage(_product.DuongDanAnh);
        }

        private void LoadProductImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
                {
                    picProduct.Image = Image.FromFile(imagePath);
                }
                else
                {
                    picProduct.Image = null;
                }
            }
            catch
            {
                picProduct.Image = null;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
