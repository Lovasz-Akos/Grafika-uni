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

        public Form1()
        {
            InitializeComponent();
            winCenter = new Vector3(canvas.Width / 2.0f, canvas.Height / 2.0f, 0.0f);
        }


        private float X(float t, float R)
        {
            return R * (float)Math.Cos(t);

        }
        private float Y(float t, float R)
        {
            return R * (float)Math.Sin(t);
        }

        private float Z(float t, float m)
        {
            return m / (2.0f * (float)Math.PI) * t;
        }
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
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;


            float R = 5.0f;
            float m = 2.0f;
            Vector3 v = new Vector3(0.3f, 0.2f, 0.8f); //Párhuzamos vetítés iránya
            Matrix4 projection = Matrix4.Parallel(v);
            float scale = 10;
            float alphaX = v1;
            float alphaY = v2;
            float alphaZ = v3;

            Matrix4 rotX = Matrix4.RotX(alphaX);
            Matrix4 rotY = Matrix4.RotY(alphaY);
            Matrix4 rotZ = Matrix4.RotZ(alphaZ);

            float a = 0.0f;
            float b = 5.0f * 2.0f * (float)Math.PI;
            float t = a;
            float h = (b - a) / 500.0f;
            Vector3 pv0, pv1;
          
            Vector3 v0 = new Vector3(X(t, R), Y(t, R), Z(t, m)) * scale;
            while (t < b)
            {
                t += h;
              
                Vector3 v1 = new Vector3(X(t, R), Y(t, R), Z(t, m)) * scale;
                pv0 = projection * (rotX * (rotY * (rotZ * v0))) + winCenter;
                pv1 = projection * (rotX * (rotY * (rotZ * v1))) + winCenter;
                g.DrawLine(Pens.Black, pv0, pv1);
                v0 = v1;
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

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            v2 = (float)hScrollBar2.Value / 100;
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
