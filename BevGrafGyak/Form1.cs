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
            if (P.X <= e.X && e.X < P.X+size&&P.Y<=e.Y&&e.Y<P.Y+size)
            {
                gotcha = true;

                dx = e.X - P.X;
                dy = e.Y - P.Y;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gotcha)
            {
                P.X = e.X - dx;
                P.Y = e.Y - dy;

                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            gotcha = false;
        }
    }
}
