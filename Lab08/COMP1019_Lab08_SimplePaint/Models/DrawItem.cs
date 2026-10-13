namespace COMP1019_Lab08_SimplePaint.Models;

public enum PaintMode
{
    Pen,
    Line,
    Rectangle,
    Ellipse
}

public class DrawItem
{
    public PaintMode Mode { get; set; }
    public Color Color { get; set; }
    public float Width { get; set; }
    public List<Point> Points { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public DrawItem()
    {
        Points = new List<Point>();
    }

    public DrawItem(PaintMode mode, Color color, float width)
    {
        Mode = mode;
        Color = color;
        Width = width;
        Points = new List<Point>();
    }
}
