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

/*
 * A vektor hosszainak szorzóját scrollbar-ral módosítani
 */

namespace GrafikaAlap
{
    public partial class Form1 : Form
    {
        Graphics g;
        Vector2 p0, p1, p2, p3;

        public Form1()
        {
            InitializeComponent();
            p0 = new Vector2(200, 300);
            p1 = new Vector2(450, 50);
            p2 = new Vector2(600, 200);
            p3 = new Vector2(650, 400);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawLine(Pens.Black, p0, p1);
            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p2, p3);            
            g.DrawPoint(Pens.Black, Brushes.White, p0, 5);
            g.DrawPoint(Pens.Black, Brushes.White, p1, 5);
            g.DrawPoint(Pens.Black, Brushes.White, p2, 5);
            g.DrawPoint(Pens.Black, Brushes.White, p3, 5);
            g.DrawBezier3Arc(Pens.Blue, p0, p1, p2, p3);
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
