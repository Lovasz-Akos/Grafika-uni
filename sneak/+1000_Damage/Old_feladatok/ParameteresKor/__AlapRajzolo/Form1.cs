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

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            PointF tran = new PointF(canvas.Width / 2, canvas.Height / 2); //eltolás, középpont
            double R = 100.0; //sugara
            double a = 0.0; // szakasz lerakásánk gyakorisága
            double b = 2 * Math.PI; // ez is x
            double t = a; // függvény
            double h = (b - a) / 500.0; //hány csúcsból álljon
            float scale = 2; //nagyítás
            PointF p0 = new PointF(scale * (float)(R * Math.Cos(t)) + tran.X,
                                   scale * (float)(R * Math.Sin(t)) + tran.Y);
            while (t < b)
            {
                t += h;
                PointF p1 = new PointF(scale * (float)(R * Math.Cos(t)) + tran.X,
                                       scale * (float)(R * Math.Sin(t)) + tran.Y);
                g.DrawLine(Pens.Black, p0, p1);
                p0 = p1;
            }

        }

        #region Mouse handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion
    }
}
