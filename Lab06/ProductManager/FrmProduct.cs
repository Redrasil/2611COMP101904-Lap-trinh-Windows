using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductManager.Models;

namespace ProductManager
{
    public partial class FrmProduct : Form
    {
        private BindingList<Product> _allProducts = new BindingList<Product>();
        private BindingList<Product> _displayedProducts = new BindingList<Product>();
        private BindingSource _bindingSource = new BindingSource();
        private Product _selectedProduct = null;

        public FrmProduct()
        {
            InitializeComponent();
        }

        #region Form Lifecycle & Khởi tạo

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            InitializeCategoryList();
            InitializeSampleData();
            SetupDataBindings();
            ClearInput();
            UpdateStatus("Khởi tạo hệ thống thành công. Sẵn sàng làm việc.");
        }

        private void InitializeCategoryList()
        {
            string[] categories = new[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" };

            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.AddRange(categories);
            if (cboLoaiSP.Items.Count > 0)
            {
                cboLoaiSP.SelectedIndex = 0;
            }

            cboLocLoaiSP.Items.Clear();
            cboLocLoaiSP.Items.Add("-- Tất cả loại SP --");
            cboLocLoaiSP.Items.AddRange(categories);
            cboLocLoaiSP.SelectedIndex = 0;
        }

        private void InitializeSampleData()
        {
            _allProducts.Clear();
            _allProducts.Add(new Product("SP001", "Laptop ASUS Zenbook 14", "Điện tử", 22500000m, 12, new DateTime(2026, 9, 15), true));
            _allProducts.Add(new Product("SP002", "Bàn phím cơ DareU EK87", "Văn phòng", 650000m, 35, new DateTime(2026, 9, 20), true));
            _allProducts.Add(new Product("SP003", "Nồi chiên không dầu Philips", "Gia dụng", 2490000m, 18, new DateTime(2026, 9, 25), true));
            _allProducts.Add(new Product("SP004", "Áo sơ mi nam công sở", "Thời trang", 350000m, 60, new DateTime(2026, 9, 28), true));
            _allProducts.Add(new Product("SP005", "Chuột không dây Logitech M331", "Văn phòng", 320000m, 40, new DateTime(2026, 10, 1), true));

            ApplyFilterAndDisplay();
        }

        private void SetupDataBindings()
        {
            dgvProducts.AutoGenerateColumns = false;
            _bindingSource.DataSource = _displayedProducts;
            dgvProducts.DataSource = _bindingSource;

            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
        }

        #endregion

        #region Các hàm phụ trợ (Tách hàm theo yêu cầu kỹ thuật)

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập
        /// </summary>
        private bool ValidateInput(bool isEditing)
        {
            bool isValid = true;
            errProvider.Clear();

            // 1. Kiểm tra Mã sản phẩm
            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSP))
            {
                errProvider.SetError(txtMaSP, "Mã sản phẩm không được để trống!");
                isValid = false;
            }
            else
            {
                // Kiểm tra trùng mã
                bool isDuplicate = _allProducts.Any(p =>
                    p.MaSP.Equals(maSP, StringComparison.OrdinalIgnoreCase) &&
                    (!isEditing || _selectedProduct == null || !p.MaSP.Equals(_selectedProduct.MaSP, StringComparison.OrdinalIgnoreCase)));

                if (isDuplicate)
                {
                    errProvider.SetError(txtMaSP, "Mã sản phẩm đã tồn tại trong danh sách! Vui lòng chọn mã khác.");
                    isValid = false;
                }
            }

            // 2. Kiểm tra Tên sản phẩm
            if (string.IsNullOrWhiteSpace(txtTenSP.Text.Trim()))
            {
                errProvider.SetError(txtTenSP, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Loại sản phẩm
            if (cboLoaiSP.SelectedIndex < 0)
            {
                errProvider.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm!");
                isValid = false;
            }

            // 4. Kiểm tra Đơn giá > 0
            if (numDonGia.Value <= 0)
            {
                errProvider.SetError(numDonGia, "Đơn giá phải lớn hơn 0!");
                isValid = false;
            }

            // 5. Kiểm tra Số lượng >= 0
            if (numSoLuong.Value < 0)
            {
                errProvider.SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0!");
                isValid = false;
            }

            // 6. Kiểm tra Ngày nhập <= Ngày hiện tại
            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                errProvider.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại!");
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Xóa nội dung nhập liệu và xóa thông báo lỗi
        /// </summary>
        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            if (cboLoaiSP.Items.Count > 0)
            {
                cboLoaiSP.SelectedIndex = 0;
            }
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;
            txtDuongDanAnh.Clear();
            picProduct.Image = null;

            txtMaSP.ReadOnly = false;
            _selectedProduct = null;
            errProvider.Clear();

            txtMaSP.Focus();
        }

        /// <summary>
        /// Nạp dữ liệu một sản phẩm lên các điều khiển của form
        /// </summary>
        private void LoadProductToForm(Product p)
        {
            if (p == null) return;

            _selectedProduct = p;
            txtMaSP.Text = p.MaSP;
            txtMaSP.ReadOnly = true; // Khóa mã SP khi đang sửa
            txtTenSP.Text = p.TenSP;

            int catIndex = cboLoaiSP.FindStringExact(p.LoaiSP);
            cboLoaiSP.SelectedIndex = catIndex >= 0 ? catIndex : 0;

            numDonGia.Value = p.DonGia;
            numSoLuong.Value = p.SoLuong;

            if (p.NgayNhap <= dtpNgayNhap.MaxDate && p.NgayNhap >= dtpNgayNhap.MinDate)
            {
                dtpNgayNhap.Value = p.NgayNhap;
            }
            else
            {
                dtpNgayNhap.Value = DateTime.Today;
            }

            chkConKinhDoanh.Checked = p.ConKinhDoanh;
            txtDuongDanAnh.Text = p.DuongDanAnh;

            LoadProductImage(p.DuongDanAnh);
            errProvider.Clear();
        }

        /// <summary>
        /// Cập nhật thanh trạng thái và tính toán số lượng + tổng giá trị tồn kho
        /// </summary>
        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
            int totalCount = _allProducts.Count;
            decimal totalValue = _allProducts.Sum(p => p.TongTien);

            lblTotalCount.Text = $"Tổng số sản phẩm: {totalCount}";
            lblTotalValue.Text = $"Tổng giá trị tồn: {totalValue:N0} VNĐ";
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

        private Product GetCurrentSelectedProductFromGrid()
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.Index >= 0)
            {
                return dgvProducts.CurrentRow.DataBoundItem as Product;
            }
            return null;
        }

        private void ApplyFilterAndDisplay()
        {
            string keyword = (txtQuickSearch.Text ?? string.Empty).Trim().ToLowerInvariant();
            string selectedCat = cboLocLoaiSP.SelectedIndex > 0 ? cboLocLoaiSP.SelectedItem.ToString() : null;

            var filtered = _allProducts.Where(p =>
            {
                bool matchesKeyword = string.IsNullOrEmpty(keyword) ||
                                     p.MaSP.ToLowerInvariant().Contains(keyword) ||
                                     p.TenSP.ToLowerInvariant().Contains(keyword);

                bool matchesCategory = string.IsNullOrEmpty(selectedCat) ||
                                       p.LoaiSP.Equals(selectedCat, StringComparison.OrdinalIgnoreCase);

                return matchesKeyword && matchesCategory;
            }).ToList();

            _displayedProducts.Clear();
            foreach (var item in filtered)
            {
                _displayedProducts.Add(item);
            }

            _bindingSource.ResetBindings(false);
        }

        #endregion

        #region Các chức năng CRUD

        /// <summary>
        /// Thêm sản phẩm mới vào danh sách
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isEditing: false))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin sản phẩm theo các biểu tượng cảnh báo lỗi!",
                                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newProduct = new Product(
                txtMaSP.Text.Trim(),
                txtTenSP.Text.Trim(),
                cboLoaiSP.SelectedItem.ToString(),
                numDonGia.Value,
                (int)numSoLuong.Value,
                dtpNgayNhap.Value.Date,
                chkConKinhDoanh.Checked,
                txtDuongDanAnh.Text.Trim()
            );

            _allProducts.Add(newProduct);
            ApplyFilterAndDisplay();
            ClearInput();
            UpdateStatus($"Đã thêm thành công sản phẩm: [{newProduct.MaSP}] {newProduct.TenSP}");
            MessageBox.Show($"Thêm sản phẩm '{newProduct.TenSP}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Sửa sản phẩm đang chọn
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                var rowProduct = GetCurrentSelectedProductFromGrid();
                if (rowProduct == null)
                {
                    MessageBox.Show("Vui lòng chọn một dòng sản phẩm trên bảng để chỉnh sửa!",
                                    "Chưa chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadProductToForm(rowProduct);
                UpdateStatus($"Đang chỉnh sửa sản phẩm [{rowProduct.MaSP}] {rowProduct.TenSP}. Hãy nhấn 'Sửa' lần nữa sau khi cập nhật dữ liệu.");
                return;
            }

            if (!ValidateInput(isEditing: true))
            {
                MessageBox.Show("Vui lòng kiểm tra lại các trường bị báo lỗi!",
                                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật thông tin
            _selectedProduct.TenSP = txtTenSP.Text.Trim();
            _selectedProduct.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            _selectedProduct.DonGia = numDonGia.Value;
            _selectedProduct.SoLuong = (int)numSoLuong.Value;
            _selectedProduct.NgayNhap = dtpNgayNhap.Value.Date;
            _selectedProduct.ConKinhDoanh = chkConKinhDoanh.Checked;
            _selectedProduct.DuongDanAnh = txtDuongDanAnh.Text.Trim();

            ApplyFilterAndDisplay();
            UpdateStatus($"Đã cập nhật sản phẩm [{_selectedProduct.MaSP}] {_selectedProduct.TenSP}");
            MessageBox.Show($"Cập nhật sản phẩm '{_selectedProduct.TenSP}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInput();
        }

        /// <summary>
        /// Xóa sản phẩm khỏi danh sách có xác nhận
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Product toDelete = _selectedProduct ?? GetCurrentSelectedProductFromGrid();

            if (toDelete == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm cần xóa trên bảng!",
                                "Chưa chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm:\n- Mã SP: {toDelete.MaSP}\n- Tên SP: {toDelete.TenSP}?",
                "Xác nhận xóa sản phẩm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (confirm == DialogResult.Yes)
            {
                string deletedName = toDelete.TenSP;
                string deletedCode = toDelete.MaSP;

                _allProducts.Remove(toDelete);
                ApplyFilterAndDisplay();
                ClearInput();
                UpdateStatus($"Đã xóa sản phẩm: [{deletedCode}] {deletedName}");
                MessageBox.Show($"Đã xóa sản phẩm '{deletedName}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Làm mới nội dung nhập và tải lại danh sách
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            txtQuickSearch.Clear();
            tstxtTimKiem.Clear();
            cboLocLoaiSP.SelectedIndex = 0;
            ApplyFilterAndDisplay();
            UpdateStatus("Đã làm mới dữ liệu và khôi phục form nhập liệu.");
        }

        #endregion

        #region Xử lý Chọn ảnh & Sự kiện DataGridView

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog(this) == DialogResult.OK)
            {
                txtDuongDanAnh.Text = ofdImage.FileName;
                LoadProductImage(ofdImage.FileName);
                UpdateStatus($"Đã chọn ảnh: {Path.GetFileName(ofdImage.FileName)}");
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            var p = GetCurrentSelectedProductFromGrid();
            if (p != null)
            {
                LoadProductToForm(p);
                lblStatus.Text = $"Đã chọn sản phẩm: [{p.MaSP}] {p.TenSP}";
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowProductDetailDialog();
            }
        }

        private void tsmXemChiTiet_Click(object sender, EventArgs e)
        {
            ShowProductDetailDialog();
        }

        private void ShowProductDetailDialog()
        {
            var p = GetCurrentSelectedProductFromGrid();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new FrmProductDetail(p))
            {
                dlg.ShowDialog(this);
            }
        }

        #endregion

        #region Tìm kiếm & Lọc

        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = (tstxtTimKiem.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa (mã hoặc tên) vào ô tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tstxtTimKiem.Focus();
                return;
            }

            txtQuickSearch.Text = keyword;
            UpdateStatus($"Kết quả tìm kiếm cho từ khóa: '{keyword}' ({_displayedProducts.Count} kết quả)");
        }

        private void tstxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsbTimKiem_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtQuickSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndDisplay();
        }

        private void cboLocLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndDisplay();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtQuickSearch.Clear();
            tstxtTimKiem.Clear();
            cboLocLoaiSP.SelectedIndex = 0;
            ApplyFilterAndDisplay();
            UpdateStatus("Đã bỏ bộ lọc danh sách.");
        }

        #endregion

        #region Mở rộng: Sắp xếp & Xuất file văn bản

        private void mnuSortPriceAsc_Click(object sender, EventArgs e)
        {
            var sorted = _allProducts.OrderBy(p => p.DonGia).ToList();
            _allProducts = new BindingList<Product>(sorted);
            ApplyFilterAndDisplay();
            UpdateStatus("Đã sắp xếp danh sách theo đơn giá tăng dần.");
        }

        private void mnuSortPriceDesc_Click(object sender, EventArgs e)
        {
            var sorted = _allProducts.OrderByDescending(p => p.DonGia).ToList();
            _allProducts = new BindingList<Product>(sorted);
            ApplyFilterAndDisplay();
            UpdateStatus("Đã sắp xếp danh sách theo đơn giá giảm dần.");
        }

        private void mnuSortQuantityDesc_Click(object sender, EventArgs e)
        {
            var sorted = _allProducts.OrderByDescending(p => p.SoLuong).ToList();
            _allProducts = new BindingList<Product>(sorted);
            ApplyFilterAndDisplay();
            UpdateStatus("Đã sắp xếp danh sách theo số lượng giảm dần.");
        }

        private void mnuFileExportTxt_Click(object sender, EventArgs e)
        {
            sfdExport.FileName = $"DanhSachSanPham_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            if (sfdExport.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("=========================================================================================");
                    sb.AppendLine("                             BÁO CÁO DANH SÁCH SẢN PHẨM");
                    sb.AppendLine($"                    Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sb.AppendLine($"                    Sinh viên: Hoàng Dương Phúc Quang - MSSV: 49.01.101.075");
                    sb.AppendLine("=========================================================================================");
                    sb.AppendLine(string.Format("{0,-8} | {1,-28} | {2,-12} | {3,14} | {4,8} | {5,15} | {6,-14}",
                        "Mã SP", "Tên sản phẩm", "Loại", "Đơn giá", "SL", "Thành tiền", "Trạng thái"));
                    sb.AppendLine(new string('-', 105));

                    foreach (var p in _allProducts)
                    {
                        sb.AppendLine(string.Format("{0,-8} | {1,-28} | {2,-12} | {3,14:N0} | {4,8} | {5,15:N0} | {6,-14}",
                            p.MaSP,
                            p.TenSP.Length > 28 ? p.TenSP.Substring(0, 25) + "..." : p.TenSP,
                            p.LoaiSP,
                            p.DonGia,
                            p.SoLuong,
                            p.TongTien,
                            p.TrangThaiKinhDoanh));
                    }

                    sb.AppendLine(new string('=', 105));
                    sb.AppendLine($"Tổng số mặt hàng: {_allProducts.Count}");
                    sb.AppendLine($"Tổng số lượng tồn: {_allProducts.Sum(p => p.SoLuong):N0}");
                    sb.AppendLine($"Tổng giá trị kho:  {_allProducts.Sum(p => p.TongTien):N0} VNĐ");

                    File.WriteAllText(sfdExport.FileName, sb.ToString(), Encoding.UTF8);
                    UpdateStatus($"Đã xuất danh sách thành công ra file: {Path.GetFileName(sfdExport.FileName)}");
                    MessageBox.Show("Xuất file báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
            string msg = "HƯỚNG DẪN THAO TÁC SỬ DỤNG:\n\n" +
                         "- Thêm mới: Nhập đầy đủ thông tin bên trái, nhấn [Thêm] (Ctrl+N).\n" +
                         "- Chỉnh sửa: Chọn dòng trên bảng, chỉnh sửa thông tin, nhấn [Sửa] (Ctrl+E).\n" +
                         "- Xóa: Chọn dòng trên bảng, nhấn [Xóa] (Delete).\n" +
                         "- Làm mới: Nhấn [Làm mới] (F5) để dọn sạch form và nạp lại danh sách.\n" +
                         "- Xem chi tiết: Nhấn chuột phải trên bảng chọn 'Xem chi tiết' hoặc nhấp đúp dòng.\n" +
                         "- Sắp xếp & Xuất file: Sử dụng các mục trên thanh Menu.";
            MessageBox.Show(msg, "Hướng dẫn sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            string msg = "BÀI THỰC HÀNH LAB 06 - PRODUCT MANAGER\n" +
                         "Windows Forms Nâng cao và DataGridView\n\n" +
                         "Sinh viên: Hoàng Dương Phúc Quang\n" +
                         "MSSV: 49.01.101.075\n" +
                         "Lớp: 49.01.TOAN.SN - Nhóm 11\n" +
                         "Học phần: COMP1019 - Lập trình trên Windows\n" +
                         "Giảng viên hướng dẫn: ThS. Lê Thanh Thoại";
            MessageBox.Show(msg, "Thông tin ứng dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
