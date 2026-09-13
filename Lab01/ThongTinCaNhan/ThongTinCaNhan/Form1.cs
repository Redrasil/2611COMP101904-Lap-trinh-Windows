using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThongTinCaNhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNamSinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Toán học");
            cboKhoa.Items.Add("Vật lý");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtNamSinh.Text = "";
            txtEmail.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1; // Bỏ chọn ComboBox
            txtKetQua.Text = "";
            txtHoTen.Focus(); // Đưa con trỏ chuột về ô Họ tên
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtNamSinh.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên, Năm sinh và Email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Kiểm tra năm sinh
            int namSinh;
            bool isNumber = int.TryParse(txtNamSinh.Text, out namSinh);
            int namHienTai = DateTime.Now.Year;

            if (!isNumber || namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show("Năm sinh phải là số hợp lệ (từ 1900 đến nay).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra Giới tính & Khoa
            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa/Lớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Tính toán và Hiển thị
            int tuoi = namHienTai - namSinh;
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string khoa = cboKhoa.SelectedItem.ToString();

            string ketQua = "THÔNG TIN SINH VIÊN\r\n";
            ketQua += $"Họ tên: {txtHoTen.Text}\r\n";
            ketQua += $"Tuổi: {tuoi}\r\n";
            ketQua += $"Email: {txtEmail.Text}\r\n";
            ketQua += $"Giới tính: {gioiTinh}\r\n";
            ketQua += $"Khoa/Lớp: {khoa}";

            txtKetQua.Text = ketQua;
        }
    }
}
