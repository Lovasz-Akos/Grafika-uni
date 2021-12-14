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
        Pen pen = Pens.Black;

        public int Hv= 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //Kör
            double a = 0;
            double b = 2 * Math.PI;
            double t = a;
           
            double h = (b - a) / Hv;
            
            double R = 50.0;
            double scale = 3;
            PointF translate = new PointF(canvas.Width / 2, canvas.Height / 2);
            PointF p0, p1;
            p0 = new PointF((float)(scale * (R * Math.Cos(t))) + translate.X,
                            (float)(scale * (R * Math.Sin(t))) + translate.Y);
            while(t < b)
            {
                t += h;
                p1 = new PointF((float)(scale * (R * Math.Cos(t))) + translate.X,
                                (float)(scale * (R * Math.Sin(t))) + translate.Y);
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }

        #region Mouse Handling
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

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            Hv = hScrollBar1.Value;
            canvas.Refresh();
        }
    }
}
