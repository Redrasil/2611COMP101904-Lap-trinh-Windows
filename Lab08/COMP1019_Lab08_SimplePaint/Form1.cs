using COMP1019_Lab08_SimplePaint.Models;

namespace COMP1019_Lab08_SimplePaint;

public partial class Form1 : Form
{
    private List<DrawItem> drawItems;
    private List<Point> currentPoints;
    private Point startPoint;
    private Point endPoint;
    private bool isDrawing;
    private Color currentColor;
    private Image? backgroundImage;

    public Form1()
    {
        InitializeComponent();

        btnUndo.Click += btnUndo_Click;
        btnClear.Click += btnClear_Click;
        btnColor.Click += btnColor_Click;

        drawItems = new List<DrawItem>();
        currentPoints = new List<Point>();
        isDrawing = false;
        currentColor = Color.Black;
        backgroundImage = null;
    }

    private void canvas_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Draw background image if exists
        if (backgroundImage != null)
        {
            g.DrawImage(backgroundImage, 0, 0, canvas.Width, canvas.Height);
        }

        // Draw all saved items
        foreach (var item in drawItems)
        {
            using (Pen pen = new Pen(item.Color, item.Width))
            {
                switch (item.Mode)
                {
                    case PaintMode.Pen:
                        if (item.Points.Count > 1)
                        {
                            g.DrawLines(pen, item.Points.ToArray());
                        }
                        break;
                    case PaintMode.Line:
                        g.DrawLine(pen, item.StartPoint, item.EndPoint);
                        break;
                    case PaintMode.Rectangle:
                        g.DrawRectangle(pen,
                            Math.Min(item.StartPoint.X, item.EndPoint.X),
                            Math.Min(item.StartPoint.Y, item.EndPoint.Y),
                            Math.Abs(item.EndPoint.X - item.StartPoint.X),
                            Math.Abs(item.EndPoint.Y - item.StartPoint.Y));
                        break;
                    case PaintMode.Ellipse:
                        g.DrawEllipse(pen,
                            Math.Min(item.StartPoint.X, item.EndPoint.X),
                            Math.Min(item.StartPoint.Y, item.EndPoint.Y),
                            Math.Abs(item.EndPoint.X - item.StartPoint.X),
                            Math.Abs(item.EndPoint.Y - item.StartPoint.Y));
                        break;
                }
            }
        }

        // Draw current drawing
        if (isDrawing)
        {
            PaintMode mode = (PaintMode)cboMode.SelectedIndex;
            using (Pen pen = new Pen(currentColor, (float)nudWidth.Value))
            {
                switch (mode)
                {
                    case PaintMode.Pen:
                        if (currentPoints.Count > 1)
                        {
                            g.DrawLines(pen, currentPoints.ToArray());
                        }
                        break;
                    case PaintMode.Line:
                        g.DrawLine(pen, startPoint, endPoint);
                        break;
                    case PaintMode.Rectangle:
                        g.DrawRectangle(pen,
                            Math.Min(startPoint.X, endPoint.X),
                            Math.Min(startPoint.Y, endPoint.Y),
                            Math.Abs(endPoint.X - startPoint.X),
                            Math.Abs(endPoint.Y - startPoint.Y));
                        break;
                    case PaintMode.Ellipse:
                        g.DrawEllipse(pen,
                            Math.Min(startPoint.X, endPoint.X),
                            Math.Min(startPoint.Y, endPoint.Y),
                            Math.Abs(endPoint.X - startPoint.X),
                            Math.Abs(endPoint.Y - startPoint.Y));
                        break;
                }
            }
        }
    }

    private void canvas_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDrawing = true;
            startPoint = e.Location;
            endPoint = e.Location;
            currentPoints.Clear();
            currentPoints.Add(e.Location);
        }
    }

    private void canvas_MouseMove(object sender, MouseEventArgs e)
    {
        // Update status label with mouse coordinates
        lblStatus.Text = $"Status: X={e.X}, Y={e.Y}";

        if (isDrawing)
        {
            PaintMode mode = (PaintMode)cboMode.SelectedIndex;
            endPoint = e.Location;

            if (mode == PaintMode.Pen)
            {
                currentPoints.Add(e.Location);
            }

            canvas.Invalidate();
        }
    }

    private void canvas_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && isDrawing)
        {
            isDrawing = false;
            endPoint = e.Location;

            PaintMode mode = (PaintMode)cboMode.SelectedIndex;
            DrawItem item = new DrawItem(mode, currentColor, (float)nudWidth.Value);

            switch (mode)
            {
                case PaintMode.Pen:
                    item.Points = new List<Point>(currentPoints);
                    break;
                case PaintMode.Line:
                case PaintMode.Rectangle:
                case PaintMode.Ellipse:
                    item.StartPoint = startPoint;
                    item.EndPoint = endPoint;
                    break;
            }

            drawItems.Add(item);
            canvas.Invalidate();
        }
    }

    private void btnColor_Click(object? sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            colorDialog.Color = currentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
                btnColor.BackColor = currentColor;
            }
        }
    }

    private void btnUndo_Click(object? sender, EventArgs e)
    {
        if (drawItems.Count > 0)
        {
            drawItems.RemoveAt(drawItems.Count - 1);
            canvas.Invalidate();
        }
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        drawItems.Clear();
        backgroundImage = null;
        canvas.Invalidate();
    }

    private void menuSaveImage_Click(object? sender, EventArgs e)
    {
        using (SaveFileDialog saveDialog = new SaveFileDialog())
        {
            saveDialog.Filter = "PNG Image|*.png";
            saveDialog.Title = "Save Image as PNG";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height);
                canvas.DrawToBitmap(bitmap, new Rectangle(0, 0, canvas.Width, canvas.Height));
                bitmap.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                bitmap.Dispose();
                MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void menuOpenBackground_Click(object? sender, EventArgs e)
    {
        using (OpenFileDialog openDialog = new OpenFileDialog())
        {
            openDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openDialog.Title = "Open Background Image";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    backgroundImage = Image.FromFile(openDialog.FileName);
                    canvas.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void menuExit_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        // Ctrl+Z for Undo
        if (e.Control && e.KeyCode == Keys.Z)
        {
            btnUndo_Click(null, EventArgs.Empty);
            e.Handled = true;
        }
    }
}
