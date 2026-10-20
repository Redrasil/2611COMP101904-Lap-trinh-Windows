using COMP1019_Lab09_StudentCard.Models;
using System.Drawing.Printing;

namespace COMP1019_Lab09_StudentCard;

public partial class FrmStudentCard : Form
{
    private Student currentStudent;
    private Image? studentPhoto;

    public FrmStudentCard()
    {
        InitializeComponent();
        currentStudent = new Student();
        studentPhoto = null;
        InitializePrintComponents();
    }

    private void InitializePrintComponents()
    {
        printDocument = new PrintDocument();
        printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

        printPreviewDialog = new PrintPreviewDialog();
        printPreviewDialog.Document = printDocument;

        printDialog = new PrintDialog();
        printDialog.Document = printDocument;
    }

    private void btnSelectPhoto_Click(object? sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Image tempImage = Image.FromFile(openFileDialog.FileName))
                    {
                        studentPhoto = new Bitmap(tempImage);
                        picPhoto.Image = studentPhoto;
                        currentStudent.Photo = studentPhoto;
                        pnlPreview.Invalidate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void pnlPreview_Paint(object? sender, PaintEventArgs e)
    {
        if (e?.Graphics == null) return;

        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        DrawStudentCard(g, pnlPreview.Width, pnlPreview.Height);
    }

    private void DrawStudentCard(Graphics g, int width, int height)
    {
        // Background
        using (SolidBrush bgBrush = new SolidBrush(Color.White))
        {
            g.FillRectangle(bgBrush, 0, 0, width, height);
        }

        // Border
        using (Pen borderPen = new Pen(Color.Black, 2))
        {
            g.DrawRectangle(borderPen, 5, 5, width - 10, height - 10);
        }

        // Title
        using (Font titleFont = new Font("Arial", 16, FontStyle.Bold))
        using (SolidBrush titleBrush = new SolidBrush(Color.Black))
        {
            string title = "THẺ SINH VIÊN";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, titleBrush, (width - titleSize.Width) / 2, 20);
        }

        // Photo (left side)
        if (studentPhoto != null)
        {
            int photoWidth = 120;
            int photoHeight = 150;
            int photoX = 30;
            int photoY = 60;

            using (Pen photoBorder = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(photoBorder, photoX, photoY, photoWidth, photoHeight);
            }

            g.DrawImage(studentPhoto, photoX + 1, photoY + 1, photoWidth - 2, photoHeight - 2);
        }

        // Student info (right side)
        int infoX = 180;
        int infoY = 60;
        int lineHeight = 30;

        using (Font infoFont = new Font("Arial", 11))
        using (Font labelFont = new Font("Arial", 11, FontStyle.Bold))
        using (SolidBrush textBrush = new SolidBrush(Color.Black))
        {
            g.DrawString($"Mã SV: {currentStudent.StudentId}", labelFont, textBrush, infoX, infoY);
            g.DrawString($"Họ tên: {currentStudent.FullName}", labelFont, textBrush, infoX, infoY + lineHeight);
            g.DrawString($"Lớp: {currentStudent.Class}", infoFont, textBrush, infoX, infoY + lineHeight * 2);
            g.DrawString($"Khoa: {currentStudent.Faculty}", infoFont, textBrush, infoX, infoY + lineHeight * 3);
            g.DrawString($"Khóa: {currentStudent.Course}", infoFont, textBrush, infoX, infoY + lineHeight * 4);
            g.DrawString($"Ngày sinh: {currentStudent.DateOfBirth:dd/MM/yyyy}", infoFont, textBrush, infoX, infoY + lineHeight * 5);
            g.DrawString($"Giới tính: {currentStudent.Gender}", infoFont, textBrush, infoX, infoY + lineHeight * 6);
        }

        // Footer with school name
        using (Font footerFont = new Font("Arial", 10, FontStyle.Italic))
        using (SolidBrush footerBrush = new SolidBrush(Color.Gray))
        {
            string footer = "Trường Đại học Sư Phạm TP. Hồ Chí Minh";
            SizeF footerSize = g.MeasureString(footer, footerFont);
            g.DrawString(footer, footerFont, footerBrush, (width - footerSize.Width) / 2, height - 30);
        }
    }

    private void btnPrintPreview_Click(object? sender, EventArgs e)
    {
        if (!ValidateData())
        {
            return;
        }

        printPreviewDialog.ShowDialog();
    }

    private void btnPrint_Click(object? sender, EventArgs e)
    {
        if (!ValidateData())
        {
            return;
        }

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            printDocument.Print();
        }
    }

    private void printDocument_PrintPage(object? sender, PrintPageEventArgs e)
    {
        if (e?.Graphics != null)
        {
            DrawStudentCard(e.Graphics, e.PageBounds.Width, e.PageBounds.Height);
        }
    }

    private void btnRefresh_Click(object? sender, EventArgs e)
    {
        txtStudentId.Clear();
        txtFullName.Clear();
        cboClass.SelectedIndex = -1;
        cboFaculty.SelectedIndex = -1;
        cboCourse.SelectedIndex = -1;
        cboGender.SelectedIndex = -1;
        dtpDateOfBirth.Value = DateTime.Now;
        picPhoto.Image = null;
        studentPhoto = null;
        currentStudent = new Student();
        pnlPreview.Invalidate();
    }

    private bool ValidateData()
    {
        currentStudent.StudentId = txtStudentId.Text.Trim();
        currentStudent.FullName = txtFullName.Text.Trim();
        currentStudent.Class = cboClass.SelectedItem?.ToString() ?? string.Empty;
        currentStudent.Faculty = cboFaculty.SelectedItem?.ToString() ?? string.Empty;
        currentStudent.Course = cboCourse.SelectedItem?.ToString() ?? string.Empty;
        currentStudent.DateOfBirth = dtpDateOfBirth.Value;
        currentStudent.Gender = cboGender.SelectedItem?.ToString() ?? string.Empty;
        currentStudent.Photo = studentPhoto;

        if (string.IsNullOrWhiteSpace(currentStudent.StudentId))
        {
            MessageBox.Show("Vui lòng nhập mã sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtStudentId.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(currentStudent.FullName))
        {
            MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtFullName.Focus();
            return false;
        }

        if (studentPhoto == null)
        {
            MessageBox.Show("Vui lòng chọn ảnh đại diện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void FrmStudentCard_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.F1:
                btnSelectPhoto_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
            case Keys.F2:
                pnlPreview.Invalidate();
                e.Handled = true;
                break;
            case Keys.F3:
                ValidateData();
                e.Handled = true;
                break;
            case Keys.F4:
                btnPrintPreview_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
            case Keys.F5:
                btnPrint_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
            case Keys.F6:
                btnRefresh_Click(null, EventArgs.Empty);
                e.Handled = true;
                break;
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        studentPhoto?.Dispose();
        printDocument?.Dispose();
        printPreviewDialog?.Dispose();
        printDialog?.Dispose();
        base.OnFormClosing(e);
    }
}
