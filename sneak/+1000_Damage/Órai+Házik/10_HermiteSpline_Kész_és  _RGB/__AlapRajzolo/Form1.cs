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
        List<PointF> P = new List<PointF>();
        List<PointF> P2 = new List<PointF>();
        Color colorControl = Color.Gray;
        Color coloCurve = Color.Blue;
        int grab = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            float dx, dy;
            for (int i = 0; i < P.Count - 3; i += 2)
            DrawHermiteArc(Color.Red,Color.Blue, 
                P[i], P[i + 2],
                Mult(Subs(P[i], P[i + 1]), 2), Mult(Subs(P[i + 2], P[i + 3]), 2));

            for (int i = 0; i < P.Count - 1; i += 2) { 
                g.DrawLine(new Pen(colorControl), P[i], P[i + 1]);

                dx = P[i + 1].X - P[i].X;
                dy = P[i + 1].Y - P[i].Y;
                g.DrawLine(new Pen(colorControl), new Point((int)(P[i ].X - dx), (int)(P[i].Y - dy)), P[i]);
            }
            for (int i = 0; i < P.Count; i += 2) {
                dx = P[i + 1].X - P[i].X;
                dy = P[i + 1].Y - P[i].Y;
                g.FillRectangle(new SolidBrush(colorControl), P[i].X - 5, P[i].Y - 5, 10, 10);
                g.FillRectangle(new SolidBrush(colorControl), (int)(P[i].X - dx) - 5, (int)(P[i].Y - dy) - 5, 10, 10);
                g.FillRectangle(new SolidBrush(colorControl), P[i+1].X - 5, P[i+1].Y - 5, 10, 10);
            }
            //Hf.: Berajzolni az éintő véponját 
            //Megjeleníteni a tüközött érintőket
        }

        #region Mouse Handling
        //Kezelni a tükrözöt érintőket is meg a végpontok
        //mozgatását úgy, ahogy az előző feladatban kiírtuk
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < P.Count; i++)
            {
                if (IsGrab(P[i], 5, e.Location))
                {
                    grab = i;
                    break;
                }
            }

            if (grab == -1)
            {
                P.Add(e.Location);
                P.Add(e.Location);
                grab = P.Count - 1;
                canvas.Refresh();
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grab != -1)
            {
                P[grab] = e.Location;
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

        private double H0(double t) { return 2 * t * t * t - 3 * t * t + 1; }
        private double H1(double t) { return -2 * t * t * t + 3 * t * t; }
        private double H2(double t) { return t * t * t - 2 * t * t + t; }
        private double H3(double t) { return t * t * t - t * t; }

        //Kiterjesztő metódusai a Graphics osztály
        //private void DrawHermiteArc(Pen pen, HermiteArc arc)
        //private void DrawHermiteSpline(Pen pen, HermiteSpline spline)
        private void DrawHermiteArc(Color c0,Color c1,
            PointF p0, PointF p1, PointF t0, PointF t1)
        {
            double a = 0;
            double t = a;
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
            while (t < 1)
            {
                t += h;
                d1 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
                                (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
                g.DrawLine(new Pen(Color.FromArgb((int)(cR), (int)(cG), (int)(cB))), d0, d1);
                cR += incR; cG += incG; cB += incB;
                d0 = d1;
            }
        }

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
