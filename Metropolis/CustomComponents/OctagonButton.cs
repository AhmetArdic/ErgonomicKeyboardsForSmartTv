using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Metropolis.CustomComponents
{
    public class OctagonButton : Button
    {
        //Fields
        private int borderSize = 0;
        private Color borderColor = Color.PaleVioletRed;

        //Properties
        [Category("OctagonButton")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("OctagonButton")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("OctagonButton")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("OctagonButton")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        //Constructor
        public OctagonButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
            this.FlatStyle = FlatStyle.System;
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        //Methods
        private GraphicsPath GetOctagonPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            float width = rect.Width;
            float height = rect.Height;

            float sideLength = Math.Min(width, height) / 3f;

            PointF[] points = new PointF[8];
            points[0] = new PointF(rect.X + sideLength, rect.Y);
            points[1] = new PointF(rect.X + width - sideLength, rect.Y);
            points[2] = new PointF(rect.X + width, rect.Y + sideLength);
            points[3] = new PointF(rect.X + width, rect.Y + height - sideLength);
            points[4] = new PointF(rect.X + width - sideLength, rect.Y + height);
            points[5] = new PointF(rect.X + sideLength, rect.Y + height);
            points[6] = new PointF(rect.X, rect.Y + height - sideLength);
            points[7] = new PointF(rect.X, rect.Y + sideLength);

            path.AddPolygon(points);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            using (GraphicsPath pathSurface = GetOctagonPath(rectSurface))
            using (GraphicsPath pathBorder = GetOctagonPath(rectBorder))
            using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //Button surface
                this.Region = new Region(pathSurface);
                //Draw surface border for HD result
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                //Button border                    
                if (borderSize >= 1)
                {
                    //Draw control border
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
