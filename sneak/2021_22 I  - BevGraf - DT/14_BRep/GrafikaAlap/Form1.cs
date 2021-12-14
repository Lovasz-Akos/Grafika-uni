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
        double lambda = 100;
        Vector4 v = new Vector4(1.1, 1.0, 10.2);
        Vector2 center;
        Matrix4 parallel;
        Matrix4 rotX;
        Matrix4 scale;
        Matrix4 transformation;
        List<Matrix4> transformations = new List<Matrix4>();
        Pen pen = new Pen(Color.Blue, 1f);

        //BRep cube = new BRep();
        //BRep suzanne = new BRep();
        //BRep bunny = new BRep();
        ObjectBRep cube = new ObjectBRep();
        ObjectBRep suzanne = new ObjectBRep();
        ObjectBRep bunny = new ObjectBRep();

        public Form1()
        {
            InitializeComponent();
            //cube.LoadFromFile(@"Obj\cube.obj", ModelFileType.Wavefront);
            //suzanne.LoadFromFile(@"Obj\suzanne.obj", ModelFileType.Wavefront);
            //bunny.LoadFromFile(@"Obj\bunny.obj", ModelFileType.Wavefront);
            
            cube.model.LoadFromFile(@"Obj\cube.obj", ModelFileType.Wavefront);
            cube.transformation = Matrix4.Scale(100) * Matrix4.RotX(alpha);
            cube.color = Color.Blue;

            suzanne.model.LoadFromFile(@"Obj\suzanne.obj", ModelFileType.Wavefront);
            suzanne.transformation = Matrix4.Scale(150) * Matrix4.RotX(2 * alpha);
            suzanne.color = Color.Salmon;

            bunny.model.LoadFromFile(@"Obj\bunny.obj", ModelFileType.Wavefront);
            bunny.transformation = Matrix4.Scale(2000) * Matrix4.RotX(3 * alpha);
            bunny.color = Color.Green;

            parallel = Matrix4.Parallel(v);
            //rotX = Matrix4.RotX(alpha);
            //scale = Matrix4.Scale(lambda);
            //transformation = scale * rotX;
            center = new Vector2(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.DrawObjectBRepWithEdges(cube, parallel, center);
            //g.DrawObjectBRepWithEdges(suzanne, parallel, center);
            //g.DrawObjectBRepWithEdges(bunny, parallel, center);

            //g.DrawObjectBRepWithTriangles(suzanne, parallel, (-1) * v, center);
            g.FillObjectBRepWithTriangles(suzanne, parallel, (-1) * v, center);

            //g.DrawBRepWithEdges(Pens.Blue, cube, transformation, parallel, center);
            //g.DrawBRepWithEdges(Pens.Red, suzanne, transformation, parallel, center);
            //g.DrawBRepWithEdges(Pens.Green, bunny, transformation, parallel, center);
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
            cube.transformation = Matrix4.Scale(100) * Matrix4.RotX(alpha);
            suzanne.transformation = Matrix4.Scale(150) * Matrix4.RotX(2 * alpha);
            bunny.transformation = Matrix4.Scale(2000) * Matrix4.RotX(3 * alpha);
            canvas.Invalidate();
        }
    }
}
