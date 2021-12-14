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
        Point center;
        Point pOnCircle;
        int dx;
        int dy;

        public Form1()
        {
            InitializeComponent();
            center = new Point(340, 260);
            pOnCircle = new Point(center.X + 130, center.Y);
        }

        int gotcha = -1;

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.FillRectangle(Brushes.Black, center.X - 5, center.Y - 5, 10, 10);
            g.DrawLine(Pens.Black, center, pOnCircle);
            g.FillRectangle(Brushes.Black, pOnCircle.X - 5, pOnCircle.Y - 5, 10, 10);
            Circle(Color.Black, (int)Math.Sqrt((center.X - pOnCircle.X) * (center.X - pOnCircle.X) +
                                              (center.Y - pOnCircle.Y) * (center.Y - pOnCircle.Y)),
                               center);
        }

        #region Mouse handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (isGotcha(center, 10, e.Location))
            {
                gotcha = 0;
            }
            else if (isGotcha(pOnCircle, 10, e.Location))
            {
                gotcha = 1;
            }
            
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            dx = e.X - center.X; 
            dy = e.Y - center.Y;
            if (gotcha != -1)
            {
                switch (gotcha)
                {
                    case 0: center = new Point(e.X, e.Y);  pOnCircle = new Point(pOnCircle.X + dx, pOnCircle.Y + dy); break;
                    case 1: pOnCircle = new Point(e.X, e.Y); break;

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

        private bool isGotcha(PointF p, float distance, PointF mousePos)
        {
            return Math.Abs(p.X - mousePos.X) <= distance &&
                   Math.Abs(p.Y - mousePos.Y) <= distance;
        }

        private void CirclePoint(Color c, Point p, Point trans)
        {
            Pen pen = new Pen(c);
            g.DrawRectangle(pen, p.X + trans.X, p.Y + trans.Y, 0.5f, 0.5f);   
            g.DrawRectangle(pen, -p.X + trans.X, -p.Y + trans.Y, 0.5f, 0.5f); 
            g.DrawRectangle(pen, -p.X + trans.X, p.Y + trans.Y, 0.5f, 0.5f);  
            g.DrawRectangle(pen, p.X + trans.X, -p.Y + trans.Y, 0.5f, 0.5f);  
            g.DrawRectangle(pen, p.Y + trans.X, p.X + trans.Y, 0.5f, 0.5f);   
            g.DrawRectangle(pen, -p.Y + trans.X, -p.X + trans.Y, 0.5f, 0.5f); 
            g.DrawRectangle(pen, -p.Y + trans.X, p.X + trans.Y, 0.5f, 0.5f);  
            g.DrawRectangle(pen, p.Y + trans.X, -p.X + trans.Y, 0.5f, 0.5f);
        }
        //Kérejenek be még egy színt
        private void Circle(Color c, int R, Point O)
        {
            int x = 0;
            int y = R;
            int h = 1 - R;
            CirclePoint(c, new Point(x, y), O);
            while (y > x)
            {
                if (h < 0) h += 2 * x + 3;
                else
                {
                    h += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                CirclePoint(c, new Point(x, y), O);
            }
        }
    }
}
