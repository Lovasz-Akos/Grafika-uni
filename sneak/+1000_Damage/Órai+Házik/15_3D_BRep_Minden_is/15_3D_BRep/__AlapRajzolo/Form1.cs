using _3D_Alap_gyak;
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

        ObjectBRep3D suzanne;

        float alphaX = 3.0f;
        float alphaY = 0.0f;
        float alphaZ = 0.0f;

        float scale0 = 100.0f;

        public Form1()
        {
            InitializeComponent();
            winCenter = new Vector3(canvas.Width / 2, canvas.Height / 2, 0.0f);
            suzanne = new ObjectBRep3D();
            suzanne.model = FileReader.FromWaveFront("Suzanne.obj");
            scrB_X.Value = 30;
            canvas.MouseWheel += Canvas_MouseWheel;
        }

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            scale0 += e.Delta / 10;
            canvas.Refresh();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Vector3 v = new Vector3(0.3f, 0.2f, 0.8f); // Párhuzamos vetítés iránya
            Matrix4 projection = Matrix4.Parallel(v);
            //scale = 200;
            Matrix4 rotX = Matrix4.RotX(alphaX);
            Matrix4 rotY = Matrix4.RotY(alphaY);
            Matrix4 rotZ = Matrix4.RotZ(alphaZ);
            Matrix4 scale = Matrix4.Scale(scale0, scale0, scale0);

            // HF.: A skálázást is mátrix-szal megoldani
            // HF.: A tükrözést megoldani
            Vector3 V0, V1, V2;
            for (int i = 0; i < suzanne.model.triangles.Count; i++)
            {
                V0 = scale * suzanne.model.triangles[i].v0;
                V1 = scale * suzanne.model.triangles[i].v1;
                V2 = scale * suzanne.model.triangles[i].v2;

                V0 = projection *(rotZ * (rotY * (rotX * V0))) + winCenter;
                V1 = projection *(rotZ * (rotY * (rotX * V1))) + winCenter;
                V2 = projection *(rotZ * (rotY * (rotX * V2))) + winCenter;

                g.DrawLine(Pens.Black, V0, V1);
                g.DrawLine(Pens.Black, V1, V2);
                g.DrawLine(Pens.Black, V2, V0);
            }

            Vector3 V;

            for (int i = 0; i < suzanne.model.vertices.Count; i++)
            {
                V = scale * suzanne.model.vertices[i];
                // (rotX * V) -> Elforgatom, (projection * ...) -> levetítem, (... + winCenter) -> eltolom
                V = projection *(rotZ * (rotY * (rotX * V))) + winCenter;
                g.DrawRectangle(Pens.Red, V.x, V.y, 0.5f, 0.5f);
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

        private void scrB_X_Scroll(object sender, ScrollEventArgs e)
        {
            alphaX = scrB_X.Value / 10.0f;
            canvas.Refresh();
        }

        private void scrB_Y_Scroll(object sender, ScrollEventArgs e)
        {
            alphaY = scrB_Y.Value / 10.0f;
            canvas.Refresh();
        }

        private void scrB_Z_Scroll(object sender, ScrollEventArgs e)
        {
            alphaZ = scrB_Z.Value / 10.0f;
            canvas.Refresh();
        }
    }
}
