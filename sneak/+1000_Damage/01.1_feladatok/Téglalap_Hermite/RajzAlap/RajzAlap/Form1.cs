using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RajzAlap
{
    public class RectangleV2
    {

        public int x;
        public int y;
        public int width;
        public int height;
        public Color col;
        public PointF rightBottom;
        public PointF rightTop;
        public PointF leftBottom;
        public PointF leftTop;


        public RectangleV2(int x, int y, int w, int h, Color c)
        {
            this.x = x;
            this.y = y;
            this.width = w;
            this.height = h;
            this.col = c;
            rightBottom = new PointF(x + width, y + height);
            rightTop = new PointF(x + width, y);
            leftBottom = new PointF(x,y + height);
            leftTop = new PointF(x,y);
        }

    }
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Graphics g;
        List<RectangleV2> R = new List<RectangleV2>();
        bool grab;
        bool resize = false;
        int index = -1;

        public Form1()
        {

            InitializeComponent();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < R.Count; i++)
            {
                if (isGrabbed(R[i].rightBottom, e.Location, 5))
                {
                    grab = true;
                    resize = true;
                    index = i;
                    break;
                }
                if (isGrabbed(new Point(R[i].x + R[i].width / 2, R[i].y + R[i].height / 2), e.Location, R[i].width/2))
                {
                    grab = true;
                    index = i;
                    break;
                }
            }
            if (!grab)
            {
                RectangleV2 r = new RectangleV2(e.Location.X - 25, e.Location.Y - 25, 50, 50, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                R.Add(r);
                grab = true;
                resize = true;
                index = R.Count - 1;
            }

            pictureBox2.Refresh();
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            grab = false;
            resize = false;
            index = -1;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (grab)
            {
                if (resize)
                {
                    R[index].width = (int)(Math.Sqrt((R[index].x - e.Location.X) * (R[index].x - e.Location.X)
                        + (R[index].y - e.Location.Y) * (R[index].y - e.Location.Y)));
                    R[index].height = (int)(Math.Sqrt((R[index].x - e.Location.X) * (R[index].x - e.Location.X)
                       + (R[index].y - e.Location.Y) * (R[index].y - e.Location.Y)));
                    R[index].rightBottom = new PointF(R[index].x + R[index].width, R[index].y + R[index].height);
                    R[index].rightTop = new PointF(R[index].x + R[index].width, R[index].y);
                    R[index].leftBottom = new PointF(R[index].x, R[index].y + R[index].height);
                    R[index].leftTop = new PointF(R[index].x , R[index].y);
                }
                else
                {
                    R[index] = new RectangleV2(e.Location.X - R[index].width / 2, e.Location.Y - R[index].height / 2, R[index].width, R[index].height, R[index].col);
                }
                pictureBox2.Refresh();

            }
        }

        private void pictureBox2_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < R.Count; i++)
            {
                g.FillRectangle(new SolidBrush(R[i].col), new Rectangle(R[i].x, R[i].y, R[i].width, R[i].height));
                g.DrawRectangle(new Pen(R[i].col), new Rectangle(R[i].x, R[i].y, R[i].width, R[i].height));
                if (R.Count >=3)
                {
                    for (int j = 0; j < R.Count-1; j++)
                    {
                        DrawHermiteArc(R[j].col,R[j+1].col,R[j].rightTop,R[j+1].leftTop, R[j].rightTop, R[j+ 1].leftTop);
                        DrawHermiteArc(R[j].col, R[j + 1].col, R[j].rightBottom, R[j + 1].leftBottom, R[j].rightBottom, R[j + 1].leftBottom);
                    }
                }

            }
        }

        private bool isGrabbed(PointF point, PointF mouse, float distance)
        {
            return Math.Sqrt(((point.X - mouse.X) * (point.X - mouse.X)) + ((point.Y - mouse.Y) * (point.Y - mouse.Y))) <= distance;
        }

        private double H0(double t) { return 2 * t * t * t - 3 * t * t + 1; }
        private double H1(double t) { return -2 * t * t * t + 3 * t * t; }
        private double H2(double t) { return t * t * t - 2 * t * t + t; }
        private double H3(double t) { return t * t * t - t * t; }

        private void DrawHermiteArc(Color c0, Color c1, PointF p0, PointF p1, PointF t0, PointF t1)
        {
            int dx = (int)(p1.X - p0.X);
            double t = 0.0f;
            double h = 1.0 / 500.0;
            PointF d0, d1;
            d0 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
                            (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));

            double cR = c0.R;
            double cG = c0.G;
            double cB = c0.B;

            int dR = c1.R - c0.R;
            int dG = c1.G - c0.G;
            int dB = c1.B - c0.B;

            double incR = (double)dR / 500;
            double incG = (double)dG / 500;
            double incB = (double)dB /500;

            while (t < 1.0)
            {
                t += h;
                d1 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
                                (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
                g.DrawLine(new Pen(Color.FromArgb((int)(cR), (int)(cG), (int)(cB))), d0, d1);
                cR += incR; cG += incG; cB += incB;
                d0 = d1;
            }
        }

        private PointF Sub(PointF a, PointF b) { return new PointF(b.X - a.X, b.Y - a.Y); }
        private PointF Add(PointF a, PointF b) { return new PointF(b.X + a.X, b.Y + a.Y); }
        private PointF Mult(PointF a, float l) { return new PointF(a.X * l, a.Y * l); }
    }
}
