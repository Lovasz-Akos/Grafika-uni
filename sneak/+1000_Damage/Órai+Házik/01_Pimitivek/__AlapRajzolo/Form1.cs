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
        PointF TopLeft = new PointF(300, 100);
        int size = 200;
        Pen p = Pens.Red;
        bool gotcha = false;
        float dx, dy;
        int speedx = 1;
        int speedy = 1;

        public Form1()
        {
            InitializeComponent();
            timer.Start();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            ////Téglalap (négyzet)
            //Pen penBlack = new Pen(Color.Black, 3);
            //g.FillRectangle(new SolidBrush(Color.Orange), 35, 70, 100, 120);
            //g.DrawRectangle(penBlack, 30, 70, 100, 100);

            ////Ellipszis (kör)
            //g.FillEllipse(Brushes.Pink, 30, 70, 100, 100);
            //g.DrawEllipse(Pens.White, 35, 70, 100, 120);

            ////Szakasz
            //g.DrawLine(Pens.Black, 60, 25, 450, 231);
            //PointF p1 = new PointF(70, 35);
            //PointF p2 = new PointF(460, 241);
            //g.DrawLine(new Pen(Color.FromArgb(120, 37, 216)), p1, p2);

            ////Pixel
            //g.DrawRectangle(Pens.Black, 300, 50, 0.5f, 0.5f);
            //int r = 10;
            //g.DrawEllipse(Pens.Magenta, 300 - r, 50 - r, 2 * r, 2 * r);

            ////Színek
            //int x0 = 400;
            //int y0 = 50;
            //for (int i = 0; i < 256; i++)
            //    for (int j = 0; j < 256; j++)
            //        g.DrawRectangle(new Pen(Color.FromArgb((int)(Math.Abs(Math.Sin(i)) * 255), (i + j) % 255, j)), x0 + i, y0 + j, 0.5f, 0.5f);

            g.DrawRectangle(p, TopLeft.X, TopLeft.Y, size, size);
        }

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= TopLeft.X && e.X < TopLeft.X + size &&
                e.Y >= TopLeft.Y && e.Y < TopLeft.Y + size)
            {
                dx = e.X - TopLeft.X;
                dy = e.Y - TopLeft.Y;
                size -= 10;
                gotcha = true;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gotcha)
            {
                TopLeft.X = e.X - dx;
                TopLeft.Y = e.Y - dy;

                if (TopLeft.X < 0) TopLeft.X = 0;

                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            gotcha = false;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!gotcha)
            {
                TopLeft.X += speedx;
                TopLeft.Y += speedy;

                if (TopLeft.Y + size > canvas.Height)
                    speedy *= -1;

                //Játék
                //Addig játszunk, amíg a mérette el nem éri a 10 pixelt
                //Minden elkapásnál gyorsul a méretcsükenés mellett és
                //random színt is vált (a háttér is)

                canvas.Refresh();
            }
        }
    }
}
