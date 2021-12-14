using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafikaAlap
{
    public partial class Form1 : Form
    {
        Graphics g;
        Random rnd = new Random();
        
        PointF P = new PointF(100, 100);
        float size = 250;
        Brush brushSquare = new SolidBrush(Color.Salmon);

        bool gotcha = false;
        float dx, dy;

        float speedX = 2, speedY = 2;
        int counter = 0;

        public Form1()
        {
            InitializeComponent();

            timer.Start();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.FillRectangle(brushSquare, P.X, P.Y, size, size);
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (P.X <= e.X && e.X < P.X + size &&
                P.Y <= e.Y && e.Y < P.Y + size)
            {
                dx = e.X - P.X;
                dy = e.Y - P.Y;
                gotcha = true;

                counter++;
                if (counter == 5)
                {
                    MessageBox.Show("A siker sukár!");
                    Application.Exit();
                }
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gotcha)
            {
                //P.X = Math.Min(Math.Max(0, e.X - dx), canvas.Width - size);
                //P.Y = Math.Min(Math.Max(0, e.Y - dy), canvas.Height - size);

                P.X = e.X - dx;
                P.Y = e.Y - dy;

                if (P.X < 0) P.X = 0;
                else if (P.X > canvas.Width - size) P.X = canvas.Width - size;
                if (P.Y < 0) P.Y = 0;
                else if (P.Y > canvas.Height - size) P.Y = canvas.Height - size;

                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (gotcha)
            {
                size -= 10;
                speedX = speedX < 0 ? speedX - 2 : speedX + 2;
                speedY = speedY < 0 ? speedY - 2 : speedY + 2;
                if (rnd.NextDouble() >= 0.5) speedX *= -1;
                if (rnd.NextDouble() >= 0.5) speedY *= -1;
                brushSquare = new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            }

            gotcha = false;            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!gotcha)
            {
                P.X += speedX;
                P.Y += speedY;

                if (P.X < 0 || P.X > canvas.Width - size) speedX *= -1;
                if (P.Y < 0 || P.Y > canvas.Height - size) speedY *= -1;

                canvas.Invalidate();
            }
        }
    }
}
