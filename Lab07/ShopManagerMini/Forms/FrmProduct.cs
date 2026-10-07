using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;
using ShopManagerMini.Services;

namespace ShopManagerMini.Forms
{
    public partial class FrmProduct : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        private BindingList<Product> _displayList = new BindingList<Product>();
        private Product _selectedProduct = null;

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            // Nạp loại sản phẩm
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.AddRange(new[] { "Điện tử", "Văn phòng phẩm", "Gia dụng", "Thời trang" });
            cboLoaiSP.SelectedIndex = 0;

            // Cấu hình DataGridView
            dgvProducts.AutoGenerateColumns = false;
            _bindingSource.DataSource = _displayList;
            dgvProducts.DataSource = _bindingSource;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;

            RefreshData();
            ClearForm();
        }

        private void RefreshData(string keyword = "")
        {
            _displayList.Clear();

            var query = DataStore.Products.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLowerInvariant();
                query = query.Where(p => p.MaSP.ToLowerInvariant().Contains(kw) || p.TenSP.ToLowerInvariant().Contains(kw));
            }

            foreach (var item in query)
            {
                _displayList.Add(item);
            }

            _bindingSource.ResetBindings(false);
        }

        private bool ValidateInput(bool isEditing)
        {
            bool isValid = true;
            errProvider.Clear();

            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSP))
            {
                errProvider.SetError(txtMaSP, "Mã sản phẩm không được rỗng!");
                isValid = false;
            }
            else
            {
                bool isDuplicate = DataStore.Products.Any(p =>
                    p.MaSP.Equals(maSP, StringComparison.OrdinalIgnoreCase) &&
                    (!isEditing || _selectedProduct == null || !p.MaSP.Equals(_selectedProduct.MaSP, StringComparison.OrdinalIgnoreCase)));

                if (isDuplicate)
                {
                    errProvider.SetError(txtMaSP, "Mã sản phẩm đã tồn tại! Không được trùng.");
                    isValid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text.Trim()))
            {
                errProvider.SetError(txtTenSP, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            if (cboLoaiSP.SelectedIndex < 0)
            {
                errProvider.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm!");
                isValid = false;
            }

            // Không cho đơn giá hoặc số lượng âm
            if (numDonGia.Value < 0)
            {
                errProvider.SetError(numDonGia, "Đơn giá không được âm!");
                isValid = false;
            }

            if (numSoLuong.Value < 0)
            {
                errProvider.SetError(numSoLuong, "Số lượng không được âm!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;

            txtMaSP.ReadOnly = false;
            _selectedProduct = null;
            errProvider.Clear();
            txtMaSP.Focus();
        }

        private void LoadProductToControls(Product p)
        {
            if (p == null) return;
            _selectedProduct = p;

            txtMaSP.Text = p.MaSP;
            txtMaSP.ReadOnly = true;
            txtTenSP.Text = p.TenSP;

            int catIndex = cboLoaiSP.FindStringExact(p.LoaiSP);
            cboLoaiSP.SelectedIndex = catIndex >= 0 ? catIndex : 0;

            numDonGia.Value = p.DonGia;
            numSoLuong.Value = p.SoLuong;
            errProvider.Clear();
        }

        private Product GetSelectedRowProduct()
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.Index >= 0)
            {
                return dgvProducts.CurrentRow.DataBoundItem as Product;
            }
            return null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isEditing: false))
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập theo cảnh báo!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newP = new Product(
                txtMaSP.Text.Trim(),
                txtTenSP.Text.Trim(),
                cboLoaiSP.SelectedItem.ToString(),
                numDonGia.Value,
                (int)numSoLuong.Value
            );

            DataStore.Products.Add(newP);
            RefreshData();
            ClearForm();
            MessageBox.Show($"Thêm sản phẩm '{newP.TenSP}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                var rowItem = GetSelectedRowProduct();
                if (rowItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trên danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadProductToControls(rowItem);
                return;
            }

            if (!ValidateInput(isEditing: true))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin chỉnh sửa!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedProduct.TenSP = txtTenSP.Text.Trim();
            _selectedProduct.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            _selectedProduct.DonGia = numDonGia.Value;
            _selectedProduct.SoLuong = (int)numSoLuong.Value;

            RefreshData();
            ClearForm();
            MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Product toDelete = _selectedProduct ?? GetSelectedRowProduct();
            if (toDelete == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trên danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm [{toDelete.MaSP}] {toDelete.TenSP}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                DataStore.Products.Remove(toDelete);
                RefreshData();
                ClearForm();
                MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtTimKiem.Clear();
            RefreshData();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            var p = GetSelectedRowProduct();
            if (p != null)
            {
                LoadProductToControls(p);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            RefreshData(txtTimKiem.Text);
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            RefreshData();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
