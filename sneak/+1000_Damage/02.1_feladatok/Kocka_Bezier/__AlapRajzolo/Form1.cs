using _3D_Alap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        float scale0 = 100.0f;

        Vector3[] kp = new Vector3[8];

        Vector3 A = new Vector3(-1, 1, -1);
        Vector3 B = new Vector3(-1, 1, 1);
        Vector3 C = new Vector3(-1, -1, -1);
        Vector3 D = new Vector3(-1, -1, 1);
        Vector3 E = new Vector3(1, -1, 1);
        Vector3 F = new Vector3(1, 1, 1);
        Vector3 G = new Vector3(1, 1, -1);
        Vector3 H = new Vector3(1, -1, -1);
        public Form1()
        {
            InitializeComponent();
            winCenter = new Vector3(canvas.Width / 2, canvas.Height / 2, 0.0f);

            kp[0] = A;
            kp[1] = B;
            kp[2] = C;
            kp[3] = D;
            kp[4] = E;
            kp[5] = F;
            kp[6] = G;
            kp[7] = H;
            
            hScrollBar1.Value = 50;
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Vector3 v = new Vector3(0.3f, 0.2f, 0.8f); 
            Matrix4 scale = Matrix4.Scale(scale0, scale0, scale0);
           

            Matrix4 mirrorXY ;
            Matrix4 mirrorXZ ;
            Matrix4 mirrorYZ;
            Matrix4 projection = Matrix4.Parallel(v);
            if (checkBox1.Checked)
            {
                mirrorXY = Matrix4.TransXY();
                projection *= mirrorXY;
            }
            if (checkBox2.Checked)
            {
                mirrorXZ = Matrix4.TransXZ();
                projection *= mirrorXZ;
            }
            if (checkBox3.Checked)
            {
                mirrorYZ = Matrix4.TransYZ();
                projection *= mirrorYZ;
            }


            Vector3 V0, V1;
            
            for (int i = 0; i < kp.Length - 1; i++)
            {

                V0 = scale * kp[i];
                V1 = scale * kp[i + 1];
                V0 = projection * V0 + winCenter;
                V1 = projection *  V1  + winCenter;

                g.DrawLine(Pens.Black, V0, V1);
            }

            for (int i = 0; i < kp.Length; i++)
            {
                V0 = kp[i];
                V0 = scale * projection * V0 + winCenter;
                g.FillEllipse(new SolidBrush(Color.Black), V0.x - 5, V0.y - 5, 10, 10);
            }

            Vector3 P0, P1, P2, P3;

            for (int j = 0; j < kp.Length - 3; j++)
            {
                P0 = kp[j];
                P0 = scale * projection * P0 + winCenter;
                P1 = kp[j + 1];
                P1 = scale * projection * P1+ winCenter;
                P2 = kp[j + 2];
                P2 = scale * projection *  P2 + winCenter;
                P3 = kp[j + 3];
                P3 = scale * projection *  P3 + winCenter;
                DrawBSplineArc(Color.Blue,Color.Red,new Pen(Color.Black, 3f), P0, P1, P2, P3);
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

     

        private void DrawBSplineArc(Color c0, Color c1, Pen pen, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            

            double a = 0;
            double t = a;
            double h = 1.0 / 500.0;
            Vector3 d0, d1;
            
            d0 = new Vector3((float)(N0(t) * p0.x + N1(t) * p1.x + N2(t) * p2.x + N3(t) * p3.x),
                            (float)(N0(t) * p0.y + N1(t) * p1.y + N2(t) * p2.y + N3(t) * p3.y),
                            (float)(N0(t) * p0.z + N1(t) * p1.z + N2(t) * p2.z + N3(t) * p3.z));

            double cR = c0.R;
            double cG = c0.G;
            double cB = c0.B;

            int dR = (c1.R - c0.R);
            int dG = (c1.G - c0.G);
            int dB = (c1.B - c0.B);

            double incR = (double)dR /500;
            double incG = (double)dG / 500;
            double incB = (double)dB / 500;

        
            //    Color c = Color.FromArgb((int)(c0.R + i * ((float)dR / dx)),
            //                             (int)(c0.G + i * ((float)dG / dx)),
            //                             (int)(c0.B + i * ((float)dB / dx)));
            //    //g.DrawRectangle(new Pen(c), x, y, 0.5f, 0.5f);
            //    g.DrawLine(new Pen(c), x, 0, x, canvas.Height);
            //    if (d > 0)
            //    {
            //        y++;
            //        d = d + 2 * (dy - dx);
            //    }
            //    else d = d + 2 * dy;
            //    x++;
            //
            
            while (t < 1)
            {
             
                t += h;
                d1 = new Vector3((float)(N0(t) * p0.x + N1(t) * p1.x + N2(t) * p2.x + N3(t) * p3.x),
                            (float)(N0(t) * p0.y + N1(t) * p1.y + N2(t) * p2.y + N3(t) * p3.y),
                            (float)(N0(t) * p0.z + N1(t) * p1.z + N2(t) * p2.z + N3(t) * p3.z));
                  
                g.DrawLine(new Pen(Color.FromArgb((int)(cR), (int)(cG), (int)(cB)),2f), d0, d1);
                cR += incR ; cG += incG; cB += incB;
           
                  d0 = d1;
            }
        }
        private double N0(double t) { return 1.0 / 6.0 * (1 - t) * (1 - t) * (1 - t); }
        private double N1(double t) { return (1.0 / 2.0 * t * t * t) - (t * t) + 2.0 / 3.0; }
        private double N2(double t) { return (-1.0 / 2.0 * t * t * t) + (1.0 / 2.0 * t * t) + (1.0 / 2.0 * t) + 1.0 / 6.0; }
        private double N3(double t) { return 1.0 / 6.0 * t * t * t; }

       


        //xy
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            canvas.Refresh();
        }
        //xz
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            canvas.Refresh();
        }
        //yz
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            canvas.Refresh();
        }
   
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scale0 = hScrollBar1.Value;
            canvas.Refresh();
        }
    }
}
