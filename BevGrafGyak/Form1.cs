using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrafikaDLL;

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;

        PointF p1 = new PointF(100, 100);
        PointF p2 = new PointF(100, 300);
        PointF p3 = new Point(300, 100);
        PointF p4 = new Point(300, 300);

        PointF p5 = new Point(0, 0);
        PointF p6 = new Point(400, 700);

        Color[] these = new Color[] { Color.Red, Color.Green };

        public Form1()
        {
            InitializeComponent();
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //g.DrawPolygonDDA(Pens.Red, new PointF[] { p1, p2, p3 }, false);
            //g.DrawPolygonDDA(Pens.Red, new PointF[] { new Point(0, 0), new Point(300, 300) }, false);
            //g.DrawLineMidPoint(Pens.Gold, p1, p3);

            //g.DrawPolygon(these, new PointF[] { p1, p2, p3 }, false);   <-- prob works but color[] doesn't?
            //g.DrawCircle(Pens.DarkRed, p2, 200f);

            g.DrawLine(new Pen(Color.Red, 5), p5, p6);
            g.DrawRectangle(new Pen(Color.BlueViolet, 5), 100, 100, 250, 300);
            g.Clip(new Pen(Color.YellowGreen, 5), new Rectangle(100, 100, 250, 300), p5, p6);
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