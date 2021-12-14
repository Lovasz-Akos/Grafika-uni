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

        ObjectBRep3D felulet;

        Vector3 winCenter;
        private float a;
        public float A
        {
            get { return a; }
            set { a = value; }
        }
        private float b;

        public float B
        {
            get { return b; }
            set { b = value; }
        }

        private float v1;

        public float V1
        {
            get { return v1; }
            set { v1 = value; }
        }

        //float a = 1.0f;
        //float b = 1.0f;

        public Form1()
        {
            InitializeComponent();
            winCenter = new Vector3(canvas.Width / 2.0f, canvas.Height / 2.0f, 0.0f);
            A=1.0f;
            B = 1.0f;

            felulet = new ObjectBRep3D();
            //felulet.model = ;
        }

        //koordináta függvények
        private float X(float u, float v)
        {
            return u;
        }
        private float Y(float u, float v)
        {
            return v;
        }
        private float Z(float u, float v)
        {
            return (float)(Math.Cos(b*v)*Math.Sin(a*u));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Vector3 v = new Vector3(0.3f, 0.2f, 0.8f); //Párhuzamos vetítés iránya
            Matrix4 projection = Matrix4.Parallel(v);
            float scale = 50;
           // float alpha = 0.9f;
            float alphaY = v1;
           // Matrix4 rotX = Matrix4.RotX(alpha);
            Matrix4 rotY = Matrix4.RotY(alphaY);
            float a1 =  -2 *a* (float)Math.PI; ;
            float b1 = 2 *a* (float)Math.PI;
            float c = -2 * b * (float)Math.PI;
            float d = 2 * b*(float)Math.PI;

            Vector3 V0, V1, V2;
            felulet.model.triangles = felulet.model.triangles.OrderBy(t => t.GetWeightZ).ToList();

            for (int i = 0; i < felulet.model.triangles.Count; i++)
            {
                for (int j = 0; j < felulet.model.triangles.Count; j++)
                {
                    if (felulet.model.triangles[i].IsVisible(v) && felulet.model.triangles[j].IsVisible(v))
                    {
                        V0 = felulet.model.triangles[i].v0* scale ;
                        V1 = felulet.model.triangles[i].v1* scale ;
                        V2 = felulet.model.triangles[i].v2 * scale;

                        Vertical(c, d, a1, scale, b1, projection, rotY);
                        Horizontal(c, d, a1, scale, b1, projection, rotY);

                        Color color = Color.Salmon;

                        float colorIntensity = felulet.model.triangles[i].GetColorInternsity(v);
                        g.FillPolygon(new SolidBrush(Color.FromArgb((int)(colorIntensity * color.R),
                                                                    (int)(colorIntensity * color.G),
                                                                    (int)(colorIntensity * color.B))),
                                      V0, V1, V2);
                    }
                    
                }
            }
            
        }
        public void Vertical(float c, float d, float a1, float scale, float b1, Matrix4 projection, Matrix4 rotY)
        {
            float h1 = (b1 - a1) / 35f;
            float h2 = (d - c) / 35f;
            float v = c;
            float u;
            while (v < d)
            {
                u = a1;
                Vector3 pv0, pv1;
                Vector3 v0 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                while (u < b1)
                {
                    u += h1;
                    Vector3 v1 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                    pv0 = projection * (rotY * v0) + winCenter;
                    pv1 = projection * (rotY *  v1) + winCenter;
                    g.DrawLine(Pens.Red, pv0, pv1);
                    v0 = v1;
                }
                v += h2;
            }
        }
        public void Horizontal(float c, float d, float a1, float scale, float b1, Matrix4 projection, Matrix4 rotY)
        {
            float h1 = (b1 - a1) / 150f;
            float h2 = (d - c) / 150f;
            float u = c;
            float v;
            while (u < b1)
            {
                v = a1;
                Vector3 pv0, pv1;
                Vector3 v0 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                while (v < d)
                {
                    v += h1;
                    Vector3 v1 = new Vector3(X(u, v), Y(u, v), Z(u, v)) * scale;
                    pv0 = projection *(rotY * v0)  + winCenter;
                    pv1 = projection * (rotY * v1) + winCenter;
                    g.DrawLine(Pens.Blue, pv0, pv1);
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
            A = (float)hScrollBar1.Value / 100;
            B= (float)hScrollBar1.Value / 100;
            canvas.Refresh();
        }

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            v1 = (float)hScrollBar2.Value / 100;
            canvas.Refresh();
        }
    }


}

