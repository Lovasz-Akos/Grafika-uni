using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __AlapRajzolo
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF p0, p1, p2, p3;
        Color colorControl = Color.Black;
        Color coloCurve = Color.Blue;
        int grab = -1;

        public Form1()
        {
            InitializeComponent();

            p0 = new PointF(100, 100);
            p1 = new PointF(400, 200);
            p2 = new PointF(300, 300);
            p3 = new PointF(700, 200);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            DrawBezier3Arc(new Pen(coloCurve, 3f), p0, p1, p2, p3);
            //DrawHermiteArc(new Pen(coloCurve, 3f), p0, p1, Mult(Subs(p0, t0), 2), Mult(Subs(p1, t1), 2));
            g.DrawLine(new Pen(colorControl), p0, p1);
            g.DrawLine(new Pen(colorControl), p1, p2);
            g.DrawLine(new Pen(colorControl), p2, p3);
            g.FillRectangle(new SolidBrush(colorControl), p0.X - 5, p0.Y - 5, 10, 10);
            g.FillRectangle(new SolidBrush(colorControl), p1.X - 5, p1.Y - 5, 10, 10);
            g.FillRectangle(new SolidBrush(colorControl), p2.X - 5, p2.Y - 5, 10, 10);
            g.FillRectangle(new SolidBrush(colorControl), p3.X - 5, p3.Y - 5, 10, 10);
        }

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsGrab(p0, 5, e.Location)) grab = 0;
            else if (IsGrab(p1, 5, e.Location)) grab = 1;
            else if (IsGrab(p2, 5, e.Location)) grab = 2;
            else if (IsGrab(p3, 5, e.Location)) grab = 3;
            //Kezelni a tükrözött érintő végpontot is!!!
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grab != -1)
            {
                switch (grab)
                {
                    //Ha p0, p1-et mozgatjuk, akkor vigyék magukkal a hozzájuk tartozó
                    //érintő végpontokat (t0, t1)
                    case 0: p0 = e.Location; break;
                    case 1: p1 = e.Location; break;
                    case 2: p2 = e.Location; break;
                    case 3: p3 = e.Location; break;
                    default: break;
                }
                canvas.Refresh();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grab = -1;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion

        private bool IsGrab(PointF p, int s, PointF mouseLocation)
        {
            return p.X - s <= mouseLocation.X && mouseLocation.X <= p.X + s &&
                   p.Y - s <= mouseLocation.Y && mouseLocation.Y <= p.Y + s;
        }

        private double B0(double t) { return (1 - t) * (1 - t) * (1 - t); }
        private double B1(double t) { return 3 * t * (1 - t) * (1 - t); }
        private double B2(double t) { return 3 * t * t * (1 - t); }
        private double B3(double t) { return t * t * t; }

        private void DrawBezier3Arc(Pen pen,
            PointF p0, PointF p1, PointF p2, PointF p3)
        {
            double a = 0;
            double t = a;
            double h = 1.0 / 500.0;
            PointF d0, d1;
            d0 = new PointF((float)(B0(t) * p0.X + B1(t) * p1.X + B2(t) * p2.X + B3(t) * p3.X),
                            (float)(B0(t) * p0.Y + B1(t) * p1.Y + B2(t) * p2.Y + B3(t) * p3.Y));
            while (t < 1)
            {
                t += h;
                d1 = new PointF((float)(B0(t) * p0.X + B1(t) * p1.X + B2(t) * p2.X + B3(t) * p3.X),
                                (float)(B0(t) * p0.Y + B1(t) * p1.Y + B2(t) * p2.Y + B3(t) * p3.Y));
                g.DrawLine(pen, d0, d1);

                d0 = d1;
            }
        }

        //private double H0(double t) { return 2 * t * t * t - 3 * t * t + 1; }
        //private double H1(double t) { return -2 * t * t * t + 3 * t * t; }
        //private double H2(double t) { return t * t * t - 2 * t * t + t; }
        //private double H3(double t) { return t * t * t - t * t; }

        //private void DrawHermiteArc(Pen pen,
        //    PointF p0, PointF p1, PointF t0, PointF t1)
        //{
        //    double a = 0;
        //    double t = a;
        //    double h = 1.0 / 500.0;
        //    PointF d0, d1;
        //    d0 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
        //                    (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
        //    while (t < 1)
        //    {
        //        t += h;
        //        d1 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
        //                        (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
        //        g.DrawLine(pen, d0, d1);
        //        d0 = d1;
        //    }
        //}

        private PointF Add(PointF a, PointF b)
        {
            return new PointF(b.X + a.X, b.Y + a.Y);
        }
        private PointF Subs(PointF a, PointF b)
        {
            return new PointF(b.X - a.X, b.Y - a.Y);
        }
        private PointF Mult(PointF a, float l)
        {
            return new PointF(a.X * l, a.Y * l);
        }
    }
}
