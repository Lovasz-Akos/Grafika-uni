using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF P = new PointF();
        float size = 200;
        bool gotcha;
        float dx, dy;

        Brush brushSquare = new SolidBrush(Color.Red);

        float speedx = 1, speedy = 1;

        Random rng = new Random();
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.FillRectangle(brushSquare, P.X, P.Y, size, size);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (P.X <= e.X && e.X < P.X + size && P.Y <= e.Y && e.Y < P.Y + size)
            {
                gotcha = true;

                dx = e.X - P.X;
                dy = e.Y - P.Y;

                counter++;
                if (counter == 5)
                {
                    MessageBox.Show("nagyonjó xd", "vagy nem");
                    Application.Exit();
                }

            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gotcha)
            {
                P.X = e.X - dx;
                P.Y = e.Y - dy;

                if (P.X < 0)
                {
                    P.X = 0;
                }
                else if (P.X > canvas.Width - size)
                {
                    P.X = canvas.Width - size;
                }

                if (P.Y < 0)
                {
                    P.Y = 0;
                }
                else if (P.Y > canvas.Height - size)
                {
                    P.Y = canvas.Height - size;
                }
                canvas.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            P.X += speedx;
            P.Y += speedy;

            if (P.X < 0 || (P.X) + size > canvas.Width)
            {
                speedx *= -1;
            }
            if (P.Y < 0 || P.Y > canvas.Height)
            {
                speedy *= -1;
            }

            canvas.Invalidate();

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (gotcha)
            {
                size -= 10;
                speedx = speedx < 0 ? speedx - 2 : speedx + 2;
                speedy = speedy < 0 ? speedy - 2 : speedy + 2;

                if (rng.NextDouble() >= 0.5)
                {
                    speedx *= -1;
                }
                if (rng.NextDouble() >= 0.5)
                {
                    speedy *= -1;
                }

                brushSquare = new SolidBrush(Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256)));
            }

            gotcha = false;
        }
    }
}
