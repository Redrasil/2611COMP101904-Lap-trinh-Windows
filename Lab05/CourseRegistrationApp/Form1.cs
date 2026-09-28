using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseRegistrationApp
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Lớp đại diện cho thông tin khóa học
        /// </summary>
        public class KhoaHoc
        {
            public string TenKhoaHoc { get; set; }
            public decimal HocPhiMotThang { get; set; }

            public KhoaHoc(string tenKhoaHoc, decimal hocPhiMotThang)
            {
                TenKhoaHoc = tenKhoaHoc;
                HocPhiMotThang = hocPhiMotThang;
            }

            public override string ToString()
            {
                return TenKhoaHoc;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        #region Xử lý Sự kiện Form Load
        /// <summary>
        /// 5.1. Khởi tạo dữ liệu và trạng thái ban đầu khi Form được nạp
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp danh sách khóa học vào ComboBox theo Mục 4
            cboKhoaHoc.Items.Clear();
            cboKhoaHoc.Items.Add(new KhoaHoc("C# WinForms cơ bản", 800000));
            cboKhoaHoc.Items.Add(new KhoaHoc("SQL Server cơ bản", 700000));
            cboKhoaHoc.Items.Add(new KhoaHoc("Web Frontend cơ bản", 750000));
            cboKhoaHoc.Items.Add(new KhoaHoc("Lập trình Python cơ bản", 650000));

            // Chọn mặc định khóa học đầu tiên
            if (cboKhoaHoc.Items.Count > 0)
            {
                cboKhoaHoc.SelectedIndex = 0;
            }

            // Chọn mặc định hình thức Online
            radOnline.Checked = true;

            // Thiết lập số tháng tối thiểu là 1, tối đa là 12
            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            // Đặt ngày sinh mặc định là ngày hiện tại
            dtpNgaySinh.Value = DateTime.Today;
            dtpNgaySinh.MaxDate = DateTime.Today;

            // Bỏ chọn email mặc định
            chkNhanEmail.Checked = false;

            // Hiển thị tổng học phí ban đầu
            CapNhatTongTien();

            // Đặt con trỏ vào ô nhập họ tên
            txtHoTen.Focus();
        }
        #endregion

        #region Tính toán học phí
        /// <summary>
        /// Tính tổng học phí = học phí một tháng x số tháng
        /// và cập nhật hiển thị lên giao diện
        /// </summary>
        private void CapNhatTongTien()
        {
            if (cboKhoaHoc.SelectedItem is KhoaHoc selectedKhoaHoc)
            {
                decimal hocPhiMotThang = selectedKhoaHoc.HocPhiMotThang;
                int soThang = (int)numSoThang.Value;
                decimal tongTien = hocPhiMotThang * soThang;

                // Định dạng hiển thị tiền tệ Việt Nam: 800.000 VNĐ
                lblHocPhiThang.Text = hocPhiMotThang.ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
                lblTongTien.Text = tongTien.ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            }
            else
            {
                lblHocPhiThang.Text = "0 VNĐ";
                lblTongTien.Text = "0 VNĐ";
            }
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }
        #endregion

        #region Xử lý các nút lệnh

        /// <summary>
        /// 5.2. Nút Đăng ký: Kiểm tra dữ liệu và hiển thị phiếu đăng ký bằng MessageBox
        /// </summary>
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra họ tên không được rỗng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên học viên!",
                    "Cảnh báo nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtHoTen.Focus();
                return;
            }

            // 2. Kiểm tra số điện thoại không được rỗng
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại!",
                    "Cảnh báo nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtSoDienThoai.Focus();
                return;
            }

            // 3. Kiểm tra phải chọn khóa học
            if (!(cboKhoaHoc.SelectedItem is KhoaHoc selectedKhoaHoc))
            {
                MessageBox.Show(
                    "Vui lòng chọn khóa học!",
                    "Cảnh báo nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cboKhoaHoc.Focus();
                return;
            }

            // 4. Tính toán tổng học phí
            int soThang = (int)numSoThang.Value;
            decimal tongTien = selectedKhoaHoc.HocPhiMotThang * soThang;
            string hinhThucHoc = radOnline.Checked ? "Online" : "Trực tiếp";
            string trangThaiEmail = chkNhanEmail.Checked ? "Có nhận email thông báo" : "Không nhận email thông báo";

            CultureInfo viCulture = CultureInfo.GetCultureInfo("vi-VN");
            string donGiaStr = selectedKhoaHoc.HocPhiMotThang.ToString("#,##0", viCulture);
            string tongTienStr = tongTien.ToString("#,##0", viCulture);

            // 5. Chuẩn bị nội dung phiếu đăng ký
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=========== PHIẾU ĐĂNG KÝ KHÓA HỌC ===========");
            sb.AppendLine();
            sb.AppendLine($"• Họ và tên: {txtHoTen.Text.Trim()}");
            sb.AppendLine($"• Số điện thoại: {txtSoDienThoai.Text.Trim()}");
            sb.AppendLine($"• Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}");
            sb.AppendLine($"• Khóa học: {selectedKhoaHoc.TenKhoaHoc}");
            sb.AppendLine($"• Hình thức học: {hinhThucHoc}");
            sb.AppendLine($"• Số tháng đăng ký: {soThang} tháng");
            sb.AppendLine($"• Đơn giá: {donGiaStr} VNĐ/tháng");
            sb.AppendLine($"• Tổng học phí: {tongTienStr} VNĐ");
            sb.AppendLine($"• Nhận email thông báo: {trangThaiEmail}");
            sb.AppendLine();
            sb.AppendLine("================================================");

            // Hiển thị thông báo bằng MessageBox
            MessageBox.Show(
                sb.ToString(),
                "Thông tin đăng ký thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// 5.3. Nút Làm mới: Khôi phục toàn bộ form về trạng thái mặc định
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa họ tên và số điện thoại
            txtHoTen.Clear();
            txtSoDienThoai.Clear();

            // Đưa ngày sinh về ngày hiện tại
            dtpNgaySinh.Value = DateTime.Today;

            // Bỏ chọn nhận email
            chkNhanEmail.Checked = false;

            // Chọn lại khóa học đầu tiên
            if (cboKhoaHoc.Items.Count > 0)
            {
                cboKhoaHoc.SelectedIndex = 0;
            }

            // Chọn lại hình thức Online
            radOnline.Checked = true;

            // Đưa số tháng về 1
            numSoThang.Value = 1;

            // Cập nhật lại tổng học phí hiển thị
            CapNhatTongTien();

            // Đưa con trỏ về ô họ tên
            txtHoTen.Focus();
        }

        /// <summary>
        /// 5.4. Nút Thoát: Hiển thị hộp thoại xác nhận, chỉ đóng Form khi chọn Yes
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion
    }
}
