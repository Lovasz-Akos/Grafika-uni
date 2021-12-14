using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __RajzAlap
{

    //hf: link driveban 
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        double R = 100;
        private double CircX(double alpha)
        {
            return R * Math.Cos(alpha);
        }
        private double CircY(double alpha)
        {
            return R * Math.Sin(alpha);
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {

            g = e.Graphics;

            //g.DrawParametricCurve(Pens.Black, 0, (float)(2 * Math.PI), CircX, CircY);
            //g.DrawParametricCurve(new Pen(Color.FromArgb(255, 102, 0)), 0, (float)(2 * Math.PI),
            //x => R * Math.Cos(x),
            //y => R * Math.Sin(y),
            //1f, 10,
            //canvas.Width / 2,
            //canvas.Height / 2);

            g.DrawParametricCurve(new Pen(Color.Red),
                (float)(-4 * Math.PI), (float)(4 * Math.PI),
                t => t,
                t => Math.Sin(t),
                100f, 500,
                canvas.Width / 2,
                canvas.Height / 2, true
                );

            //g.DrawParametricCurve(new Pen(Color.FromArgb(255, 102, 0)), 0, (float)(4 * Math.PI),

            //          t => t * Math.Cos(2 * t),
            //          t => t * Math.Sin(t),
            //          15f, 500,
            //          canvas.Width / 2,
            //          canvas.Height / 2, true);

            //g.DrawParametricCurve(new Pen(Color.FromArgb(255, 102, 0)), 0, (float)(80 * Math.PI),

            //         t => (20*t) * Math.Cos(0.2 * t),
            //         t => 10 * Math.Sin(t),
            //         1f, 500,
            //         canvas.Width / 2,
            //         canvas.Height / 2, false);

            g.DrawLine(Pens.Black, 0, canvas.Height / 2, canvas.Width, canvas.Height / 2);
            g.DrawLine(Pens.Black, canvas.Width / 2, 0, canvas.Width / 2, canvas.Height);
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
