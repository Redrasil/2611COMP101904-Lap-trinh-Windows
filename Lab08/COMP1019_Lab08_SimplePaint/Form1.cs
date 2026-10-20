using COMP1019_Lab08_SimplePaint.Models;

namespace COMP1019_Lab08_SimplePaint;

public partial class Form1 : Form
{
    private readonly List<DrawItem> _drawItems;
    private readonly List<Point> _currentPoints;
    private Point _startPoint;
    private Point _endPoint;
    private bool _isDrawing;
    private Color _currentColor;
    private Image? _backgroundImage;

    public Form1()
    {
        InitializeComponent();
        _drawItems = new List<DrawItem>();
        _currentPoints = new List<Point>();
        _isDrawing = false;
        _currentColor = Color.Black;
        _backgroundImage = null;
    }

    private static Image LoadImageCopy(string fileName)
    {
        using FileStream stream = File.OpenRead(fileName);
        using Image source = Image.FromStream(stream);
        return new Bitmap(source);
    }

    private void canvas_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (_backgroundImage != null)
        {
            g.DrawImage(_backgroundImage, 0, 0, canvas.Width, canvas.Height);
        }

        foreach (DrawItem item in _drawItems)
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

        if (_isDrawing)
        {
            PaintMode mode = (PaintMode)cboMode.SelectedIndex;
            using (Pen pen = new Pen(_currentColor, (float)nudWidth.Value))
            {
                switch (mode)
                {
                    case PaintMode.Pen:
                        if (_currentPoints.Count > 1)
                        {
                            g.DrawLines(pen, _currentPoints.ToArray());
                        }
                        break;
                    case PaintMode.Line:
                        g.DrawLine(pen, _startPoint, _endPoint);
                        break;
                    case PaintMode.Rectangle:
                        g.DrawRectangle(pen,
                            Math.Min(_startPoint.X, _endPoint.X),
                            Math.Min(_startPoint.Y, _endPoint.Y),
                            Math.Abs(_endPoint.X - _startPoint.X),
                            Math.Abs(_endPoint.Y - _startPoint.Y));
                        break;
                    case PaintMode.Ellipse:
                        g.DrawEllipse(pen,
                            Math.Min(_startPoint.X, _endPoint.X),
                            Math.Min(_startPoint.Y, _endPoint.Y),
                            Math.Abs(_endPoint.X - _startPoint.X),
                            Math.Abs(_endPoint.Y - _startPoint.Y));
                        break;
                }
            }
        }
    }

    private void canvas_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _isDrawing = true;
            _startPoint = e.Location;
            _endPoint = e.Location;
            _currentPoints.Clear();
            _currentPoints.Add(e.Location);
        }
    }

    private void canvas_MouseMove(object sender, MouseEventArgs e)
    {
        lblStatus.Text = $"Status: X={e.X}, Y={e.Y}";

        if (_isDrawing)
        {
            PaintMode mode = (PaintMode)cboMode.SelectedIndex;
            _endPoint = e.Location;

            if (mode == PaintMode.Pen)
            {
                _currentPoints.Add(e.Location);
            }

            canvas.Invalidate();
        }
    }

    private void canvas_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && _isDrawing)
        {
            _isDrawing = false;
            _endPoint = e.Location;

            PaintMode mode = (PaintMode)cboMode.SelectedIndex;
            DrawItem item = new DrawItem(mode, _currentColor, (float)nudWidth.Value);

            switch (mode)
            {
                case PaintMode.Pen:
                    item.Points = new List<Point>(_currentPoints);
                    break;
                case PaintMode.Line:
                case PaintMode.Rectangle:
                case PaintMode.Ellipse:
                    item.StartPoint = _startPoint;
                    item.EndPoint = _endPoint;
                    break;
            }

            _drawItems.Add(item);
            canvas.Invalidate();
        }
    }

    private void btnColor_Click(object? sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            colorDialog.Color = _currentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _currentColor = colorDialog.Color;
                btnColor.BackColor = _currentColor;
            }
        }
    }

    private void btnUndo_Click(object? sender, EventArgs e)
    {
        if (_drawItems.Count > 0)
        {
            _drawItems.RemoveAt(_drawItems.Count - 1);
            canvas.Invalidate();
        }
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        _drawItems.Clear();
        _backgroundImage?.Dispose();
        _backgroundImage = null;
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
                try
                {
                    using Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height);
                    canvas.DrawToBitmap(bitmap, new Rectangle(0, 0, canvas.Width, canvas.Height));
                    bitmap.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    Image loadedImage = LoadImageCopy(openDialog.FileName);
                    _backgroundImage?.Dispose();
                    _backgroundImage = loadedImage;
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

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _backgroundImage?.Dispose();
        base.OnFormClosing(e);
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
