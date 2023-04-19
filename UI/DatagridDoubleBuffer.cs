using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TGMacro.UI
{
    public class DatagridDoubleBuffer : DataGridView
    {

        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.Black;

        public DatagridDoubleBuffer()
        {
            DoubleBuffered= true;
        }
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            /*path.AddLine(rect.X + 50, rect.Y, rect.X + rect.Width, rect.Y);*/
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);

            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);



            return path;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 20, this.Width - 0.8F, this.Height);
            /*this.ClientRectangle.Intersect(rectBorder);*/
            rectBorder.Intersect(this.ClientRectangle);
            
            
            /*this[0, 0].Style.BackColor = SystemColors.Highlight;*/
            if (borderRadius > 0)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(this.ClientRectangle, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    e.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        e.Graphics.DrawPath(penBorder, pathBorder);
                }

            }
            else
            {
                /*this.Region = new Region(rectSurface);*/
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);

                    }
                }
            }
        }
    }
}
