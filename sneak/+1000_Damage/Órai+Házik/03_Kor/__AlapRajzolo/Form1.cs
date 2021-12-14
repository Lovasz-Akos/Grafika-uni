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
        Point p;

        Color colorDef = Color.Black;
        float s = 5;
        int found = -1;

        Color colorCircle = Color.Blue;

        public Form1()
        {
            InitializeComponent();

            center = new Point(canvas.Width / 2, canvas.Height / 2);
            p = new Point(170, 180);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            
            g.DrawLine(new Pen(colorDef), center, p);
            Circle(g, colorCircle, (int)Math.Sqrt((center.X - p.X) * (center.X - p.X) +
                                                  (center.Y - p.Y) * (center.Y - p.Y)),
                                                  center);
            g.FillRectangle(new SolidBrush(colorDef), center.X - s, center.Y - s, 2 * s, 2 * s);
            g.FillRectangle(new SolidBrush(colorDef), p.X - s, p.Y - s, 2 * s, 2 * s);
        }

        //Hf.: Mozgás -> done
        //Ha körpontot fogok meg, akko center marad a helyén, és a sugár újraszámolódik -> done
        //Ha a centert mozgatom, akkor a körpont is mozog vele, tehát a sugár nem változik -> done
        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (Math.Abs(center.X - e.X) <= s && Math.Abs(center.Y - e.Y) <= s)
                found = 0;
            else if (Math.Abs(p.X - e.X) <= s && Math.Abs(p.Y - e.Y) <= s)
                found = 1;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (found != -1)
            {
                switch (found)
                {
                    case 0:
                        p = new Point(p.X + (e.X - center.X), p.Y + (e.Y - center.Y));
                        center = e.Location; break;
                    case 1: p = e.Location; break;
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

        //Itt kjérjenek be 2 színt (ez extra) -> kész
        private void CirclePoints(Graphics g, Color color, int x, int y, Point translate)
        {
            Pen p = new Pen(color);
            //Ezek most nem sorban vannak, azaz
            //nem feltétlenül egymás utání síknyolcdok pontjai
            g.DrawRectangle(p,  x + translate.X,  y + translate.Y, 0.5f, 0.5f);
            g.DrawRectangle(p, -x + translate.X, -y + translate.Y, 0.5f, 0.5f);
            g.DrawRectangle(p, -x + translate.X,  y + translate.Y, 0.5f, 0.5f);
            g.DrawRectangle(p,  x + translate.X, -y + translate.Y, 0.5f, 0.5f);
            g.DrawRectangle(p,  y + translate.X,  x + translate.Y, 0.5f, 0.5f);
            g.DrawRectangle(p, -y + translate.X, -x + translate.Y, 0.5f, 0.5f);
            g.DrawRectangle(p, -y + translate.X,  x + translate.Y, 0.5f, 0.5f);
            g.DrawRectangle(p,  y + translate.X, -x + translate.Y, 0.5f, 0.5f);
        }
        private void Circle(Graphics g, Color color, int R, Point translate)
        {
            int x = 0;
            int y = R;
            int h = 1-R;
            CirclePoints(g, color, x, y, translate);

            while (y > x)
            {
                if (h < 0)
                    h = h + 2 * x + 3;
                else
                {
                    h = h + 2 * (x - y) + 5;
                    y--;
                }
                x++;
                CirclePoints(g, color, x, y, translate);
            }
        }
    }
}
