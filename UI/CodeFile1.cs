using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class ControlExtensions
{
    public static void ApplyBorderRadius(this Control control, int borderRadius)
    {
        var path = new System.Drawing.Drawing2D.GraphicsPath();
        var rectangle = new RectangleF(0, 0, control.Width, control.Height);
        var cornerRadius = borderRadius * 2;

        path.StartFigure();
        path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
        path.AddLine(rectangle.X + borderRadius, rectangle.Y, rectangle.Width - borderRadius, rectangle.Y);
        path.AddArc(rectangle.X + rectangle.Width - cornerRadius, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
        path.AddLine(rectangle.Width, rectangle.Y + borderRadius, rectangle.Width, rectangle.Height - borderRadius);
        path.AddArc(rectangle.X + rectangle.Width - cornerRadius,
            rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
        path.AddLine(rectangle.Width - borderRadius, rectangle.Height, borderRadius, rectangle.Height);
        path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
        path.AddLine(rectangle.X, rectangle.Height - borderRadius, rectangle.X, borderRadius);
        path.CloseFigure();

        control.Region = new Region(path);
    }

    public static void ApplyBorderColor(this Control control, Color color, int borderWidth)
    {
        control.Paint += (sender, e) =>
        {
            var rectangle = new Rectangle(0, 0, control.Width, control.Height);
            ControlPaint.DrawBorder(e.Graphics, rectangle,
                color, borderWidth, ButtonBorderStyle.Solid,
                color, borderWidth, ButtonBorderStyle.Solid,
                color, borderWidth, ButtonBorderStyle.Solid,
                color, borderWidth, ButtonBorderStyle.Solid);
        };
    }
}





public class CustomButton : Button
{
    private int borderRadius = 0;
    private Color borderColor = Color.Black;

    public int BorderRadius
    {
        get { return borderRadius; }
        set
        {
            if (value < 0)
            {
                borderRadius = 0;
            }
            else if (value > Math.Min(Width, Height) / 2)
            {
                borderRadius = Math.Min(Width, Height) / 2;
            }
            else
            {
                borderRadius = value;
            }
            Invalidate();
        }
    }

    public Color BorderColor
    {
        get { return borderColor; }
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (borderRadius > 0)
        {
            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawRoundedRectangle(pen, ClientRectangle, borderRadius);
            }
        }
    }
}

public static class GraphicsExtensions
{
    public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, RectangleF rectangle, float radius)
    {
        float diameter = radius * 2;
        SizeF sizeF = new SizeF(diameter, diameter);
        RectangleF arc = new RectangleF(rectangle.Location, sizeF);
        pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

        graphics.DrawArc(pen, arc, 180, 90);
        graphics.DrawLine(pen, rectangle.Left + radius, rectangle.Top, rectangle.Right - radius, rectangle.Top);
        arc.X = rectangle.Right - diameter;
        graphics.DrawArc(pen, arc, 270, 90);
        graphics.DrawLine(pen, rectangle.Right, rectangle.Top + radius, rectangle.Right, rectangle.Bottom - radius);
        arc.Y = rectangle.Bottom - diameter;
        graphics.DrawArc(pen, arc, 0, 90);
        graphics.DrawLine(pen, rectangle.Right - radius, rectangle.Bottom, rectangle.Left + radius, rectangle.Bottom);
        arc.X = rectangle.Left;
        graphics.DrawArc(pen, arc, 90, 90);
        graphics.DrawLine(pen, rectangle.Left, rectangle.Bottom - radius, rectangle.Left, rectangle.Top + radius);
    }
}


