using COMP1019_Lab09_StudentCard.Models;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace COMP1019_Lab09_StudentCard;

public partial class FrmStudentCard : Form
{
    private Student _currentStudent;
    private Image? _studentPhoto;

    public FrmStudentCard()
    {
        InitializeComponent();
        _currentStudent = new Student();
        _studentPhoto = null;
        InitializePrintComponents();
        txtStudentId.TextChanged += StudentInputChanged;
        txtFullName.TextChanged += StudentInputChanged;
        cboClass.SelectedIndexChanged += StudentInputChanged;
        cboFaculty.SelectedIndexChanged += StudentInputChanged;
        cboCourse.SelectedIndexChanged += StudentInputChanged;
        dtpDateOfBirth.ValueChanged += StudentInputChanged;
        cboGender.SelectedIndexChanged += StudentInputChanged;
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
                        Image newPhoto = new Bitmap(tempImage);
                        _studentPhoto?.Dispose();
                        _studentPhoto = newPhoto;
                        picPhoto.Image = _studentPhoto;
                        _currentStudent.Photo = _studentPhoto;
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
        const float cardRatio = 1.586f;
        int cardWidth = Math.Max(1, width - 40);
        int cardHeight = (int)(cardWidth / cardRatio);
        if (cardHeight > height - 40)
        {
            cardHeight = Math.Max(1, height - 40);
            cardWidth = (int)(cardHeight * cardRatio);
        }

        float scale = cardWidth / 760f;
        float cardX = (width - cardWidth) / 2f;
        float cardY = (height - cardHeight) / 2f;
        GraphicsState state = g.Save();
        g.TranslateTransform(cardX, cardY);
        g.ScaleTransform(scale, scale);

        using (SolidBrush bgBrush = new SolidBrush(Color.White))
        {
            g.FillRectangle(bgBrush, 0, 0, 760, 480);
        }

        using (Pen borderPen = new Pen(Color.Black, 2))
        {
            g.DrawRectangle(borderPen, 5, 5, 750, 470);
        }

        using (Font titleFont = new Font("Arial", 24, FontStyle.Bold))
        using (SolidBrush titleBrush = new SolidBrush(Color.Black))
        {
            const string title = "THẺ SINH VIÊN";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, titleBrush, (760 - titleSize.Width) / 2, 20);
        }

        if (_studentPhoto != null)
        {
            Rectangle photoBounds = new Rectangle(30, 85, 180, 225);

            using (Pen photoBorder = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(photoBorder, photoBounds);
            }

            DrawImageFit(g, _studentPhoto, Rectangle.Inflate(photoBounds, -2, -2));
        }

        const int infoX = 245;
        const int infoY = 90;
        const int lineHeight = 42;

        using (Font infoFont = new Font("Arial", 16))
        using (Font labelFont = new Font("Arial", 16, FontStyle.Bold))
        using (SolidBrush textBrush = new SolidBrush(Color.Black))
        {
            g.DrawString($"Mã SV: {_currentStudent.StudentId}", labelFont, textBrush, infoX, infoY);
            g.DrawString($"Họ tên: {_currentStudent.FullName}", labelFont, textBrush, infoX, infoY + lineHeight);
            g.DrawString($"Lớp: {_currentStudent.Class}", infoFont, textBrush, infoX, infoY + lineHeight * 2);
            g.DrawString($"Khoa: {_currentStudent.Faculty}", infoFont, textBrush, infoX, infoY + lineHeight * 3);
            g.DrawString($"Khóa: {_currentStudent.Course}", infoFont, textBrush, infoX, infoY + lineHeight * 4);
            g.DrawString($"Ngày sinh: {_currentStudent.DateOfBirth:dd/MM/yyyy}", infoFont, textBrush, infoX, infoY + lineHeight * 5);
            g.DrawString($"Giới tính: {_currentStudent.Gender}", infoFont, textBrush, infoX, infoY + lineHeight * 6);
        }

        using (Font footerFont = new Font("Arial", 14, FontStyle.Italic))
        using (SolidBrush footerBrush = new SolidBrush(Color.Gray))
        {
            string footer = "Trường Đại học Sư Phạm TP. Hồ Chí Minh";
            SizeF footerSize = g.MeasureString(footer, footerFont);
            g.DrawString(footer, footerFont, footerBrush, (760 - footerSize.Width) / 2, 435);
        }

        g.Restore(state);
    }

    private static void DrawImageFit(Graphics graphics, Image image, Rectangle bounds)
    {
        float imageRatio = (float)image.Width / image.Height;
        float boundsRatio = (float)bounds.Width / bounds.Height;
        int drawWidth;
        int drawHeight;

        if (imageRatio > boundsRatio)
        {
            drawWidth = bounds.Width;
            drawHeight = (int)(drawWidth / imageRatio);
        }
        else
        {
            drawHeight = bounds.Height;
            drawWidth = (int)(drawHeight * imageRatio);
        }

        Rectangle destination = new Rectangle(
            bounds.X + (bounds.Width - drawWidth) / 2,
            bounds.Y + (bounds.Height - drawHeight) / 2,
            drawWidth,
            drawHeight);
        graphics.DrawImage(image, destination);
    }

    private void StudentInputChanged(object? sender, EventArgs e)
    {
        UpdateStudentFromForm();
        pnlPreview.Invalidate();
    }

    private void UpdateStudentFromForm()
    {
        _currentStudent.StudentId = txtStudentId.Text.Trim();
        _currentStudent.FullName = txtFullName.Text.Trim();
        _currentStudent.Class = cboClass.SelectedItem?.ToString() ?? string.Empty;
        _currentStudent.Faculty = cboFaculty.SelectedItem?.ToString() ?? string.Empty;
        _currentStudent.Course = cboCourse.SelectedItem?.ToString() ?? string.Empty;
        _currentStudent.DateOfBirth = dtpDateOfBirth.Value;
        _currentStudent.Gender = cboGender.SelectedItem?.ToString() ?? string.Empty;
        _currentStudent.Photo = _studentPhoto;
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
        _studentPhoto?.Dispose();
        _studentPhoto = null;
        _currentStudent = new Student();
        pnlPreview.Invalidate();
    }

    private bool ValidateData()
    {
        UpdateStudentFromForm();

        if (string.IsNullOrWhiteSpace(_currentStudent.StudentId))
        {
            MessageBox.Show("Vui lòng nhập mã sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtStudentId.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(_currentStudent.FullName))
        {
            MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtFullName.Focus();
            return false;
        }

        if (_studentPhoto == null)
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
        _studentPhoto?.Dispose();
        printDocument?.Dispose();
        printPreviewDialog?.Dispose();
        printDialog?.Dispose();
        base.OnFormClosing(e);
    }
}
