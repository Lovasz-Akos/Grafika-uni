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

namespace GrafikaAlap
{
    public partial class Form1 : Form
    {
        Graphics g;

        double r = 50.0;
        double m = 1.0;
        double alpha = 0.05;
        Vector4 v = new Vector4(6.1, 3.4, 1.2);
        Vector2 center;
        Matrix4 parallel;
        Matrix4 rotX;
        Pen pen = new Pen(Color.Blue, 2f);

        public Form1()
        {
            InitializeComponent();
            parallel = Matrix4.Parallel(v);
            rotX = Matrix4.RotX(alpha);
            center = new Vector2(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawParametricCurve3D(pen,
                t => r * Math.Cos(t),
                t => r * Math.Sin(t),
                t => (m * t) / (2 * Math.PI),
                rotX,
                parallel,
                -4 * Math.PI, 4 * Math.PI,
                center);
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
