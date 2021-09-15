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
        PointF center;
        Pen penColorSys = new Pen(Color.Black);

        public Form1()
        {
            InitializeComponent();
            center = new PointF(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLine(penColorSys, 0, center.Y, canvas.Width, center.Y);

            g.DrawLine(penColorSys, center.X, 0, center.X, canvas.Height);

            g.FillRectangle(Brushes.YellowGreen, 100,100,150,350);
            g.DrawRectangle(Pens.Black, 100, 100, 150, 350);

            g.FillEllipse(new SolidBrush(Color.GreenYellow), 200,200,150,150);
            g.DrawEllipse(new Pen(Color.Black,10), 200, 200, 150, 150);

            PointF point = new PointF(400, 100);
            float r = 50;
            g.DrawEllipse(new Pen(Color.Salmon, 5), point.X - r, point.Y - r, 2 * r, 2 * r);
            g.DrawRectangle(new Pen(Color.Salmon, 1), point.X, point.Y, 2,2);

            PointF pointname = new PointF(450, 300);
            for (int i = 0; i < 250; i++)
            {
                for (int j = 0; j < 250; j++)
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(i, j, 0)), pointname.X + i, pointname.Y + j, 0.5f, 0.5f);
                }
            }

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
