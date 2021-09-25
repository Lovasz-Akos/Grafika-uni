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

        PointF p1 = new PointF(100, 20);
        PointF p2 = new PointF(200, 500);
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //g.DrawLineDDA(Color.Red, Color.Blue, p1, p2);
            g.DrawCircle(Pens.Black, p2, 100.0f);

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
