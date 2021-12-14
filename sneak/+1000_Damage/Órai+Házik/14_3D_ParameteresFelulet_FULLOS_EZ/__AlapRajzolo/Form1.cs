using _3D_Alap;
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

        Vector3 winCenter;

        private float v1;

        public float V1
        {
            get { return v1; }
            set { v1 = value; }
        }
        private float v2;

        public float V2
        {
            get { return v2; }
            set { v2 = value; }
        }
        private float v3;

        public float V3
        {
            get { return v3; }
            set { v3 = value; }
        }


        float R1 = 50f;
        float R2 = 10f;

        public Form1()
        {
            InitializeComponent();
            winCenter = new Vector3(canvas.Width / 2.0f, canvas.Height / 2.0f, 0.0f);
        }

        //koordináta függvények
        private float X(float u, float v)
        {
            return (float)((R1 + R2 * Math.Cos(v)) * Math.Cos(u));
        }
        private float Y(float u, float v)
        {
            return (float)((R1 + R2 * Math.Cos(v)) * Math.Sin(u));
        }
        private float Z(float u, float v)
        {
            return (float)(R2 * Math.Sin(v));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Vector3 V = new Vector3(0.3f, 0.2f, 0.8f); //Párhuzamos vetítés iránya
            Matrix4 projection = Matrix4.Parallel(V);
            float scale = 4;
            //float alpha = 0.9f;
            //Matrix4 rotX = Matrix4.RotX(alpha);

            float a = 0f;
            float b = 2 * (float)Math.PI;
            float c = 0f;
            float d = 2 * (float)Math.PI;


            float alphaX = v1;
            float alphaY = v2;
            float alphaZ = v3;
            Matrix4 rotX = Matrix4.RotX(alphaX);
            Matrix4 rotY = Matrix4.RotY(alphaY);
            Matrix4 rotZ = Matrix4.RotZ(alphaZ);


            Vertical(c, d, a, scale, b, projection, rotX, rotZ, rotY);
            Horizontal(c, d, a, scale, b, projection, rotX,rotZ,rotY);

        }
        public void Vertical(float c, float d, float a, float scale, float b, Matrix4 projection, Matrix4 rotX, Matrix4 rotZ, Matrix4 rotY)
        {
            float h1 = (b - a) / 35f;
            float h2 = (d - c) / 35f;
            float v = c;
            float u;
            while (v < d)
            {
                u = a;
                Vector3 pv0, pv1;
                Vector3 v0 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                while (u < b)
                {
                    u += h1;
                    Vector3 v1 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                    pv0 = projection * (rotX * (rotY * (rotZ * v0))) + winCenter;
                    pv1 = projection * (rotX * (rotY * (rotZ * v1))) + winCenter;
                    g.DrawLine(Pens.Black, pv0, pv1);
                    v0 = v1;
                }
                v += h2;
            }
        }
        public void Horizontal(float c, float d, float a, float scale, float b, Matrix4 projection, Matrix4 rotX, Matrix4 rotZ, Matrix4 rotY)
        {
            float h1 = (b - a) / 150f;
            float h2 = (d - c) / 150f;
            float u = c;
            float v;
            while (u < b)
            {
                v = a;
                Vector3 pv0, pv1;
                Vector3 v0 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                while (v < d)
                {
                    v += h1;
                    Vector3 v1 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                    pv0 = projection * (rotX * (rotY * (rotZ * v0))) + winCenter;
                    pv1 = projection * (rotX * (rotY * (rotZ * v1))) + winCenter;
                    g.DrawLine(Pens.Black, pv0, pv1);
                    v0 = v1;
                }
                u += h2;
            }
        }

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion

         private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            v2 = (float)hScrollBar1.Value / 100;
            canvas.Refresh();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            v1 = (float)vScrollBar1.Value / 100;
            canvas.Refresh();
        }

        private void vScrollBar2_ValueChanged(object sender, EventArgs e)
        {

            v3 = (float)vScrollBar2.Value / 100;
            canvas.Refresh();
        }
    }


}

