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
        PointF p0, p1;
        Color color;
        Color color2;
        int size = 5;

        int found = -1;

        public Form1()
        {
            InitializeComponent();
            p0 = new PointF(100, 100);
            p1 = new PointF(600, 300);
            color = Color.Blue;
            color2 = Color.Red;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //g.DrawLine(new Pen(color), p0, p1);
            //Line(g, color, color2, p0, p1);
            BackGround(g, color, color2, p0, p1);
            g.FillRectangle(new SolidBrush(Color.Black), p0.X - size, p0.Y - size, 2 * size, 2 * size);
            g.FillRectangle(new SolidBrush(Color.Black), p1.X - size, p1.Y - size, 2 * size, 2 * size);
        }

        private bool IsGrab(PointF p, int s, PointF mouseLocation)
        {
            return p.X - s <= mouseLocation.X && mouseLocation.X <= p.X + s &&
                   p.Y - s <= mouseLocation.Y && mouseLocation.Y <= p.Y + s;
        }
        private void Line(Graphics g, Color c, PointF p0, PointF p1)
        {
            Pen p = new Pen(c);
            int dx = (int)(p1.X - p0.X);
            int dy = (int)(p1.Y - p0.Y);
            int d = 2 * dy - dx;
            int x = (int)p0.X;
            int y = (int)p0.Y;
            for (int i = 1; i <= dx; i++)
            {
                g.DrawRectangle(p, x, y, 0.5f, 0.5f);
                if (d > 0)
                {
                    y++;
                    d = d + 2 * (dy - dx);
                }
                else d = d + 2 * dy;
                x++;
            }
        }
        private void Line(Graphics g, Color c0, Color c1, PointF p0, PointF p1)
        {
            int dR = c1.R - c0.R;
            int dG = c1.G - c0.G;
            int dB = c1.B - c0.B;

            int dx = (int)(p1.X - p0.X);
            int dy = (int)(p1.Y - p0.Y);
            int d = 2 * dy - dx;
            int x = (int)p0.X;
            int y = (int)p0.Y;
            for (int i = 1; i <= dx; i++)
            {
                Color c = Color.FromArgb((int)(c0.R + i * ((float)dR / dx)),
                                         (int)(c0.G + i * ((float)dG / dx)),
                                         (int)(c0.B + i * ((float)dB / dx)));
                g.DrawRectangle(new Pen(c), x, y, 0.5f, 0.5f);
                if (d > 0)
                {
                    y++;
                    d = d + 2 * (dy - dx);
                }
                else d = d + 2 * dy;
                x++;
            }
        }
        private void BackGround(Graphics g, Color c0, Color c1, PointF p0, PointF p1)
        {
            g.FillRectangle(new SolidBrush(c0), 0, 0, p0.X, canvas.Height);
            g.FillRectangle(new SolidBrush(c1), p1.X, 0, canvas.Width - p1.X, canvas.Height);

            int dR = c1.R - c0.R;
            int dG = c1.G - c0.G;
            int dB = c1.B - c0.B;

            int dx = (int)(p1.X - p0.X);
            int dy = (int)(p1.Y - p0.Y);
            int d = 2 * dy - dx;
            int x = (int)p0.X;
            int y = (int)p0.Y;
            for (int i = 1; i <= dx; i++)
            {
                Color c = Color.FromArgb((int)(c0.R + i * ((float)dR / dx)),
                                         (int)(c0.G + i * ((float)dG / dx)),
                                         (int)(c0.B + i * ((float)dB / dx)));
                //g.DrawRectangle(new Pen(c), x, y, 0.5f, 0.5f);
                g.DrawLine(new Pen(c), x, 0, x, canvas.Height);
                if (d > 0)
                {
                    y++;
                    d = d + 2 * (dy - dx);
                }
                else d = d + 2 * dy;
                x++;
            }
        }
        //private void Line(Graphics g, Color c, PointF p0, PointF p1)
        //{
        //    Pen p = new Pen(c);
        //    int d, dy, dx, sx, sy, x, y;
        //    bool t;
        //    dx = (int)Math.Abs(p1.X - p0.X); sx = (int)Math.Sign(p1.X - p0.X);
        //    dy = (int)Math.Abs(p1.Y - p0.Y); sy = (int)Math.Sign(p1.Y - p0.Y);
        //    if (dx < dy)
        //    {
        //        int r = dx;
        //        dx = dy;
        //        dy = r;
        //        t = true;
        //    }
        //    else t = false;
        //    d = 2 * dy - dx;
        //    x = (int)p0.X; y = (int)p0.Y;
        //    g.DrawRectangle(p, x, y, 0.5f, 0.5f);
        //    while (x != (int)p1.X && y != (float)p1.Y)
        //    {
        //        if (d > 0)
        //        {
        //            if (t) x += sx;
        //            else y += sy;
        //            d = d - 2 * dx;
        //        }
        //        if (t) y += sy;
        //        else x += sx;
        //        d = d + 2 * dy;
        //        g.DrawRectangle(p, x, y, 0.5f, 0.5f);
        //    }
        //}
        //private void Line(Graphics g, Color c1, Color c2, PointF p0, PointF p1)
        //{
        //Pen p = new Pen(c);
        //int d, dy, dx, sx, sy, x, y;
        //bool t;
        //dx = (int)Math.Abs(p1.X - p0.X); sx = (int)Math.Sign(p1.X - p0.X);
        //dy = (int)Math.Abs(p1.Y - p0.Y); sy = (int)Math.Sign(p1.Y - p0.Y);
        //if (dx < dy)
        //{
        //    int r = dx;
        //    dx = dy;
        //    dy = r;
        //    t = true;
        //}
        //else t = false;
        //d = 2 * dy - dx;
        //x = (int)p0.X; y = (int)p0.Y;
        //g.DrawRectangle(p, x, y, 0.5f, 0.5f);
        //while (x != (int)p1.X && y != (float)p1.Y)
        //{
        //    if (d > 0)
        //    {
        //        if (t) x += sx;
        //        else y += sy;
        //        d = d - 2 * dx;
        //    }
        //    if (t) y += sy;
        //    else x += sx;
        //    d = d + 2 * dy;
        //    g.DrawRectangle(p, x, y, 0.5f, 0.5f);
        //}
        //}

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsGrab(p0, size, e.Location)) found = 0;
            else if (IsGrab(p1, size, e.Location)) found = 1;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (found != -1)
            {
                switch (found)
                {
                    case 0: p0 = new PointF(e.X, e.Y); break;
                    case 1: p1 = new PointF(e.X, e.Y); break;
                    default:
                        break;
                }
                canvas.Refresh();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            found = -1;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion
    }
}
