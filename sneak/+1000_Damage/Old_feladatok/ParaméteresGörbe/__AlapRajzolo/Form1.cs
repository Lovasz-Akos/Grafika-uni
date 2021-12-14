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
            g.DrawParametricCurve(new Pen(Color.Red, 3f),
               (float)(0), (float)(20 * Math.PI),
               t => Math.Sin(t) - Math.Sin(2.3 * t),
               t => Math.Cos(t),
               500, 200, canvas.Width / 2, canvas.Height / 2, false);

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
