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
    public class Kor
    {
        public static Random rnd = new Random();
        public PointF center;
        public PointF pOnArc;
        public float radius;
        public Color color;
        public Color arcColor;
        public PointF top;
        public PointF bottom;

        public Kor(PointF pOnArc, float radius)
        {
            this.pOnArc = pOnArc;
            this.radius = radius;
            this.color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            this.arcColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            this.center = new PointF(pOnArc.X - radius, pOnArc.Y);
            this.top = new PointF(center.X, center.Y - radius);
            this.bottom = new PointF(center.X, center.Y + radius);
        }
    }
    public partial class Form1 : Form
    {
        Graphics g;
        List<Kor> korok = new List<Kor>();
        double dx;
        double dy;
        Kor grabbed;

        Color colorCurve = Color.Blue;
        PointF p0, p1, t0, t1, t2, t3;

        public Form1()
        {
            InitializeComponent();
        }

        int gotcha = -1;

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            for (int i = 0; i < korok.Count; i++)
            {
                //p0 = new PointF(korok[i].top.X - 100, korok[i].top.Y);  //tele négyzetek
                //p1 = new PointF(korok[i].top.X + 100, korok[i].top.Y);  //tele négyzetek
                //t0 = new PointF(korok[i+1].top.X - 100, korok[i+1].top.Y);  //üres négyzet
                //t1 = new PointF(korok[i+1].top.X + 100, korok[i+1].top.Y);  //üres négyzet
                //t2 = new PointF(Add(p0, Subs(t0, p0)).X - 5, Add(p0, Subs(t0, p0)).Y - 5);
                //t3 = new PointF(Add(p1, Subs(t1, p1)).X - 5, Add(p1, Subs(t1, p1)).Y - 5);


                g.FillEllipse(new SolidBrush(korok[i].color), new Rectangle((int)(korok[i].center.X - korok[i].radius), (int)(korok[i].center.Y - korok[i].radius), (int)(2 * korok[i].radius), (int)(2 * korok[i].radius)));
                g.FillRectangle(Brushes.Black, korok[i].center.X - 5, korok[i].center.Y - 5, 10, 10);
                g.DrawLine(Pens.Black, korok[i].center, korok[i].pOnArc);
                Circle(korok[i].arcColor, (int)Math.Sqrt((korok[i].center.X - korok[i].pOnArc.X) * (korok[i].center.X - korok[i].pOnArc.X) +
                                                  (korok[i].center.Y - korok[i].pOnArc.Y) * (korok[i].center.Y - korok[i].pOnArc.Y)), korok[i].center);
                g.FillRectangle(Brushes.Black, korok[i].pOnArc.X - 5, korok[i].pOnArc.Y - 5, 10, 10);
               
                
                if (i < korok.Count - 1)
                {
                    p0 = korok[i].top;  //tele négyzetek
                    p1 = korok[i + 1].top;  //tele négyzetek
                    t0 = new PointF(korok[i].top.X + korok[i].radius *2, korok[i].top.Y);  //üres négyzet
                    t1 = new PointF(korok[i + 1].top.X + korok[i+1].radius * 2, korok[i + 1].top.Y);  //üres négyzet
                    t2 = new PointF(Add(p0, Subs(t0, p0)).X - 5, Add(p0, Subs(t0, p0)).Y - 5);
                    t3 = new PointF(Add(p1, Subs(t1, p1)).X - 5, Add(p1, Subs(t1, p1)).Y - 5);
                    DrawHermiteArc(korok[i].arcColor, Color.Green, korok[i+1].arcColor, p0, p1,
                Mult(Mult(Subs(t0, p0), -1), 2), Mult(Mult(Subs(t1, p1), -1), 2));
                    p0 = korok[i].bottom;  //tele négyzetek
                    p1 = korok[i + 1].bottom;  //tele négyzetek
                    t0 = new PointF(korok[i].bottom.X + korok[i].radius * 2, korok[i].bottom.Y);  //üres négyzet
                    t1 = new PointF(korok[i + 1].bottom.X + korok[i+1].radius * 2, korok[i + 1].bottom.Y);  //üres négyzet
                    t2 = new PointF(Add(p0, Subs(t0, p0)).X - 5, Add(p0, Subs(t0, p0)).Y - 5);
                    t3 = new PointF(Add(p1, Subs(t1, p1)).X - 5, Add(p1, Subs(t1, p1)).Y - 5);
                    DrawHermiteArc(korok[i].arcColor, Color.Green, korok[i + 1].arcColor, p0, p1,
                Mult(Mult(Subs(t0, p0), -1), 2), Mult(Mult(Subs(t1, p1), -1), 2));
                }


            }
        }

        #region Mouse handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < korok.Count; i++)
            {
                if (isGotcha(korok[i].center, korok[i].radius-4f, e.Location))
                {
                    grabbed = korok[i];
                    gotcha = 0;
                }
                else if (isGotcha(korok[i].pOnArc, 10, e.Location))
                {
                    grabbed = korok[i];
                    gotcha = 1;
                }
            }
            if (gotcha == -1)
            {
                grabbed = new Kor(new PointF(e.X, e.Y), 50);
                korok.Add(grabbed);
                gotcha = 1;
            }
            canvas.Refresh();
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (gotcha != -1)
            {
                dx = e.X - (double)grabbed.center.X;
                dy = e.Y - (double)grabbed.center.Y;
                switch (gotcha)
                {
                    case 0:
                        grabbed.center = new PointF(e.X,e.Y);
                        grabbed.pOnArc = new PointF(grabbed.pOnArc.X + (float)dx, grabbed.pOnArc.Y + (float)dy);
                        grabbed.radius = (float)Math.Sqrt(Math.Pow((double)grabbed.center.X - (double)grabbed.pOnArc.X, 2) + Math.Pow((double)grabbed.center.Y - (double)grabbed.pOnArc.Y, 2));

                        grabbed.top = new PointF(grabbed.center.X, grabbed.center.Y - grabbed.radius);
                        grabbed.bottom = new PointF(grabbed.center.X, grabbed.center.Y + grabbed.radius);
                        break;
                    case 1: 
                        grabbed.pOnArc = new PointF(e.X, e.Y);
                        grabbed.radius = (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

                        grabbed.top = new PointF(grabbed.center.X, grabbed.center.Y - grabbed.radius);
                        grabbed.bottom = new PointF(grabbed.center.X, grabbed.center.Y + grabbed.radius);
                        break;

                    default: break;
                }
                canvas.Refresh();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            gotcha = -1;
            canvas.Refresh();
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion

        private bool isGotcha(PointF p, float distance, PointF mousePos)
        {
            return Math.Abs(p.X - mousePos.X) <= distance &&
                   Math.Abs(p.Y - mousePos.Y) <= distance;
        }

        private void CirclePoint(Color c, PointF p, PointF trans)
        {
            Pen pen = new Pen(c);
            g.DrawRectangle(pen, p.X + trans.X, p.Y + trans.Y, 2f, 2f);   
            g.DrawRectangle(pen, -p.X + trans.X, -p.Y + trans.Y, 2f, 2f); 
            g.DrawRectangle(pen, -p.X + trans.X, p.Y + trans.Y, 2f, 2f);  
            g.DrawRectangle(pen, p.X + trans.X, -p.Y + trans.Y, 2f, 2f);  
            g.DrawRectangle(pen, p.Y + trans.X, p.X + trans.Y, 2f, 2f);   
            g.DrawRectangle(pen, -p.Y + trans.X, -p.X + trans.Y, 2f, 2f); 
            g.DrawRectangle(pen, -p.Y + trans.X, p.X + trans.Y, 2f, 2f);  
            g.DrawRectangle(pen, p.Y + trans.X, -p.X + trans.Y, 2f, 2f);
        }

        private void Circle(Color c, int R, PointF O)
        {
            int x = 0;
            int y = R;
            int h = 1 - R;
            CirclePoint(c, new PointF(x, y), O);
            while (y > x)
            {
                if (h < 0) h += 2 * x + 3;
                else
                {
                    h += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                CirclePoint(c, new PointF(x, y), O);
            }
        }


        private double H0(double t) { return 2 * t * t * t - 3 * t * t + 1; }
        private double H1(double t) { return -2 * t * t * t + 3 * t * t; }
        private double H2(double t) { return t * t * t - 2 * t * t + t; }
        private double H3(double t) { return t * t * t - t * t; }

        private void DrawHermiteArc(Color c0, Color c1, Color c2, PointF p0, PointF p1, PointF t0, PointF t1)
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

            double incR = (double)dR / 250;
            double incG = (double)dG / 250;
            double incB = (double)dB / 250;

            double c2R = c1.R;
            double c2G = c1.G;
            double c2B = c1.B;

            int d2R = c2.R - c1.R;
            int d2G = c2.G - c1.G;
            int d2B = c2.B - c1.B;

            double inc2R = (double)d2R / 250;
            double inc2G = (double)d2G / 250;
            double inc2B = (double)d2B / 250;

            while (t < 1.0)
            {
                t += h;
                if (t < 0.50)
                {
                    d1 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
                                (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
                    g.DrawLine(new Pen(Color.FromArgb((int)(cR), (int)(cG), (int)(cB)), 2f), d0, d1);
                    cR += incR; cG += incG; cB += incB;
                    d0 = d1;
                }
                else
                {
                    d1 = new PointF((float)(H0(t) * p0.X + H1(t) * p1.X + H2(t) * t0.X + H3(t) * t1.X),
                                    (float)(H0(t) * p0.Y + H1(t) * p1.Y + H2(t) * t0.Y + H3(t) * t1.Y));
                    g.DrawLine(new Pen(Color.FromArgb((int)(c2R), (int)(c2G), (int)(c2B)), 2f), d0, d1);
                    c2R += inc2R; c2G += inc2G; c2B += inc2B;
                    d0 = d1;
                }
            }
        }
        private PointF Add(PointF a, PointF b) { return new PointF(b.X + a.X, b.Y + a.Y); }
        private PointF Subs(PointF a, PointF b) { return new PointF(b.X - a.X, b.Y - a.Y); }
        private PointF Mult(PointF a, float l) { return new PointF(a.X * l, a.Y * l); }
    }
}
