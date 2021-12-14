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
        int gotcha = -1;
        Color colorControl = Color.Black;
        Color colorCurve = Color.Blue;
        PointF p0, p1, t0, t1, t2, t3;

        public Form1()
        {
            InitializeComponent();
            p0 = new PointF(100, 100);  //tele négyzetek
            p1 = new PointF(500, 250);  //tele négyzetek
            t0 = new PointF(100, 300);  //üres négyzet
            t1 = new PointF(700, 250);  //üres négyzet
            t2 = new PointF(Add(p0, Subs(t0, p0)).X - 5, Add(p0, Subs(t0, p0)).Y - 5);
            t3 = new PointF(Add(p1, Subs(t1, p1)).X - 5, Add(p1, Subs(t1, p1)).Y - 5);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality; //szépségér' xddd
            DrawHermiteArc(new Pen(colorCurve, 3f), p0, p1,
                Mult(Mult(Subs(t0, p0), -1), 2), Mult(Mult(Subs(t1, p1), -1), 2));
            g.DrawLine(new Pen(colorControl), p0, t0);
            g.DrawLine(new Pen(colorControl), p0, Add(p0, Subs(t0, p0)));
            g.DrawLine(new Pen(colorControl), p1, t1);
            g.DrawLine(new Pen(colorControl), p1, Add(p1, Subs(t1, p1)));
            g.FillRectangle(new SolidBrush(colorControl), p0.X - 5, p0.Y - 5, 10, 10);
            g.FillRectangle(new SolidBrush(colorControl), p1.X - 5, p1.Y - 5, 10, 10);
            g.DrawRectangle(new Pen(colorControl), t0.X - 5, t0.Y - 5, 10, 10);
            g.DrawRectangle(new Pen(colorControl), t1.X - 5, t1.Y - 5, 10, 10);
            g.DrawRectangle(new Pen(colorControl),Add(p0, Subs(t0, p0)).X - 5, Add(p0, Subs(t0, p0)).Y - 5, 10, 10);
            g.DrawRectangle(new Pen(colorControl), Add(p1, Subs(t1, p1)).X - 5, Add(p1, Subs(t1, p1)).Y - 5, 10, 10);
        }

        private bool IsGotcha(PointF p, float distance, PointF mousePosition)
        {
            return Math.Abs(p.X - mousePosition.X) <= distance &&
                   Math.Abs(p.Y - mousePosition.Y) <= distance;
        }

        #region Mouse handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsGotcha(p0, 5, e.Location)) gotcha = 0;
            else if (IsGotcha(p1, 5, e.Location)) gotcha = 1;
            else if (IsGotcha(t0, 5, e.Location)) gotcha = 2;
            else if (IsGotcha(t1, 5, e.Location)) gotcha = 3;
            else if (IsGotcha(t2, 5, e.Location)) gotcha = 4;
            else if (IsGotcha(t3, 5, e.Location)) gotcha = 5;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gotcha != -1)
            {
                switch (gotcha)
                {
                    case 0: p0 = e.Location; t2 = new PointF(Add(p0, Subs(t0, p0)).X - 5, Add(p0, Subs(t0, p0)).Y - 5); break;
                    case 1: p1 = e.Location; t3 = new PointF(Add(p1, Subs(t1, p1)).X - 5, Add(p1, Subs(t1, p1)).Y - 5); break;
                    case 2: t0 = e.Location; t2 = new PointF(Add(p0, Subs(t0, p0)).X - 5, Add(p0, Subs(t0, p0)).Y - 5); break;
                    case 3: t1 = e.Location; t3 = new PointF(Add(p1, Subs(t1, p1)).X - 5, Add(p1, Subs(t1, p1)).Y - 5); break;
                    case 4: t2 = e.Location; t0 = new PointF(Add(p0, Subs(t2, p0)).X - 5, Add(p0, Subs(t2, p0)).Y - 5); break;
                    case 5: t3 = e.Location; t1 = new PointF(Add(p1, Subs(t3, p1)).X - 5, Add(p1, Subs(t3, p1)).Y - 5); break;
                    default: break;
                }
                canvas.Refresh();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            gotcha = -1;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion

        private double H0(double t) { return 2 * t * t * t - 3 * t * t + 1; }
        private double H1(double t) { return -2 * t * t * t + 3 * t * t; }
        private double H2(double t) { return t * t * t - 2 * t * t + t; }
        private double H3(double t) { return t * t * t - t * t; }

        private void DrawHermiteArc(Pen pen, PointF p0, PointF p1, PointF t0, PointF t1)
        {
            double t = 0;
            double h = 1.0 / 500.0;
            PointF d0, d1;
            d0 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
                            (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
            while (t < 1)
            {
                t += h;
                d1 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
                                (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
                g.DrawLine(pen, d0, d1);
                d0 = d1;
            }
        }

        private PointF Add(PointF a, PointF b) { return new PointF(b.X + a.X, b.Y + a.Y); }
        private PointF Subs(PointF a, PointF b) { return new PointF(b.X - a.X, b.Y - a.Y); }
        private PointF Mult(PointF a, float l) { return new PointF(a.X * l, a.Y * l); }

    }
}
