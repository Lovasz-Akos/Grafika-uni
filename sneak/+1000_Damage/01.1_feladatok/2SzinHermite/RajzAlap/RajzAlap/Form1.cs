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
    public partial class Form1 : Form
    {
        Graphics g;
        PointF p0, p1, t0, t1;
        Color colorControl = Color.Black;
        Color colorCurve = Color.Blue;
        int grab = -1;

        public Form1()
        {

            InitializeComponent();
            p0 = new PointF(400, 100);
            p1 = new PointF(300, 300);
            t0 = new PointF(200, 100);
            t1 = new PointF(100, 400);
        }
        #region
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            DrawHermiteArc(Color.Red,Color.Blue, p0, p1,
                Mult(Mult(Sub(t0, p0), -1), 2), Mult(Mult(Sub(t1, p1), -1), 2));

            g.DrawLine(new Pen(colorControl), p0, t0);
            g.DrawLine(new Pen(colorControl), p1, t1);
            g.DrawLine(new Pen(colorControl), p0, Add(p0, Sub(t0, p0)));
            g.DrawLine(new Pen(colorControl), p1, Add(p1, Sub(t1, p1)));
        }

        private double H0(double t) { return 2 * t * t * t - 3 * t * t + 1; }
        private double H1(double t) { return -2 * t * t * t + 3 * t * t; }
        private double H2(double t) { return t * t * t - 2 * t * t + t; }
        private double H3(double t) { return t * t * t - t * t; }

        private void DrawHermiteArc(Color c0, Color c1, PointF p0, PointF p1, PointF t0, PointF t1)
        {
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
            double incB = (double)dB / 500;

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
