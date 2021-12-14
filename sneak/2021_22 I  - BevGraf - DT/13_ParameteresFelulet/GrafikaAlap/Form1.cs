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
        double R = 100.0;
        double alpha = 0.0;
        double lambda = 0.5;
        Vector4 v = new Vector4(1.1, 1.0, 1.2);
        Vector2 center;
        Matrix4 parallel;
        Matrix4 rotX;
        Matrix4 scale;
        Matrix4 transformation;
        List<Matrix4> transformations = new List<Matrix4>();
        Pen pen = new Pen(Color.Blue, 1f);

        public Form1()
        {
            InitializeComponent();
            parallel = Matrix4.Parallel(v);
            rotX = Matrix4.RotX(alpha);
            scale = Matrix4.Scale(lambda);
            transformation = scale * rotX;
            center = new Vector2(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawParametricSurfaceWithParameterLines(
                pen,
                (t, u) => (R + r * Math.Cos(t)) * Math.Cos(u),
                (t, u) => (R + r * Math.Cos(t)) * Math.Sin(u),
                (t, u) => r * Math.Sin(t),
                0, 2 * Math.PI,
                0, 2 * Math.PI,
                transformation,
                parallel,
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

        private void sbAlpha_ValueChanged(object sender, EventArgs e)
        {
            alpha = sbAlpha.Value / 100.0;
            rotX = Matrix4.RotX(alpha);
            transformation = scale * rotX;
            canvas.Invalidate();
        }
    }
}
