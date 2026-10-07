using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;
using ShopManagerMini.Services;

namespace ShopManagerMini.Forms
{
    public partial class FrmCustomer : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        private BindingList<Customer> _displayList = new BindingList<Customer>();
        private Customer _selectedCustomer = null;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cboLoaiKH.Items.Clear();
            cboLoaiKH.Items.AddRange(new[] { "Thường", "Thân thiết", "VIP", "Đại lý" });
            cboLoaiKH.SelectedIndex = 0;

            dgvCustomers.AutoGenerateColumns = false;
            _bindingSource.DataSource = _displayList;
            dgvCustomers.DataSource = _bindingSource;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;

            RefreshData();
            ClearForm();
        }

        private void RefreshData(string keyword = "")
        {
            _displayList.Clear();

            var query = DataStore.Customers.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLowerInvariant();
                query = query.Where(c => c.MaKH.ToLowerInvariant().Contains(kw) || c.TenKH.ToLowerInvariant().Contains(kw) || c.SoDienThoai.Contains(kw));
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

            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrWhiteSpace(maKH))
            {
                errProvider.SetError(txtMaKH, "Mã khách hàng không được để trống!");
                isValid = false;
            }
            else
            {
                bool isDuplicate = DataStore.Customers.Any(c =>
                    c.MaKH.Equals(maKH, StringComparison.OrdinalIgnoreCase) &&
                    (!isEditing || _selectedCustomer == null || !c.MaKH.Equals(_selectedCustomer.MaKH, StringComparison.OrdinalIgnoreCase)));

                if (isDuplicate)
                {
                    errProvider.SetError(txtMaKH, "Mã khách hàng đã tồn tại trong hệ thống!");
                    isValid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text.Trim()))
            {
                errProvider.SetError(txtTenKH, "Họ tên khách hàng không được để trống!");
                isValid = false;
            }

            string sdt = txtSoDienThoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                errProvider.SetError(txtSoDienThoai, "Số điện thoại không được để trống!");
                isValid = false;
            }
            else if (sdt.Length < 9 || !sdt.All(char.IsDigit))
            {
                errProvider.SetError(txtSoDienThoai, "Số điện thoại phải từ 9 đến 11 chữ số!");
                isValid = false;
            }

            if (cboLoaiKH.SelectedIndex < 0)
            {
                errProvider.SetError(cboLoaiKH, "Vui lòng chọn loại khách hàng!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSoDienThoai.Clear();
            if (cboLoaiKH.Items.Count > 0) cboLoaiKH.SelectedIndex = 0;

            txtMaKH.ReadOnly = false;
            _selectedCustomer = null;
            errProvider.Clear();
            txtMaKH.Focus();
        }

        private void LoadCustomerToControls(Customer c)
        {
            if (c == null) return;
            _selectedCustomer = c;

            txtMaKH.Text = c.MaKH;
            txtMaKH.ReadOnly = true;
            txtTenKH.Text = c.TenKH;
            txtSoDienThoai.Text = c.SoDienThoai;

            int catIndex = cboLoaiKH.FindStringExact(c.LoaiKH);
            cboLoaiKH.SelectedIndex = catIndex >= 0 ? catIndex : 0;
            errProvider.Clear();
        }

        private Customer GetSelectedRowCustomer()
        {
            if (dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.Index >= 0)
            {
                return dgvCustomers.CurrentRow.DataBoundItem as Customer;
            }
            return null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isEditing: false))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin khách hàng!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newC = new Customer(
                txtMaKH.Text.Trim(),
                txtTenKH.Text.Trim(),
                txtSoDienThoai.Text.Trim(),
                cboLoaiKH.SelectedItem.ToString()
            );

            DataStore.Customers.Add(newC);
            RefreshData();
            ClearForm();
            MessageBox.Show($"Thêm khách hàng '{newC.TenKH}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                var rowItem = GetSelectedRowCustomer();
                if (rowItem == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadCustomerToControls(rowItem);
                return;
            }

            if (!ValidateInput(isEditing: true))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin chỉnh sửa!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedCustomer.TenKH = txtTenKH.Text.Trim();
            _selectedCustomer.SoDienThoai = txtSoDienThoai.Text.Trim();
            _selectedCustomer.LoaiKH = cboLoaiKH.SelectedItem.ToString();

            RefreshData();
            ClearForm();
            MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Customer toDelete = _selectedCustomer ?? GetSelectedRowCustomer();
            if (toDelete == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng [{toDelete.MaKH}] {toDelete.TenKH}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                DataStore.Customers.Remove(toDelete);
                RefreshData();
                ClearForm();
                MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtTimKiem.Clear();
            RefreshData();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            var c = GetSelectedRowCustomer();
            if (c != null)
            {
                LoadCustomerToControls(c);
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
