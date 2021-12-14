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
            pontok.Add(new PointF(0, 0));
            pontok.Add(new PointF(canvas.Width - 2, 0));
            pontok.Add(new PointF(canvas.Width - 2, canvas.Height - 2));
            pontok.Add(new PointF(0, canvas.Height - 2));

            for (int i = 0; i < 4; i++)
            {
                PointF pont = new PointF(rnd.Next(canvas.Width), rnd.Next(canvas.Height));
                pontok.Add(pont);
            }
        }

        Random rnd = new Random();
        List<PointF> pontok = new List<PointF>();
        int gotcha = -1;

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (PointF pont in pontok)
            {
                g.DrawRectangle(Pens.Black, pont.X, pont.Y,1f, 1f);
            }

            //3szög
            g.DrawLine(Pens.Blue, pontok[0].X, pontok[0].Y, pontok[2].X, pontok[2].Y);
            g.DrawLine(Pens.Blue, pontok[2].X, pontok[2].Y, pontok[5].X, pontok[5].Y);
            g.DrawLine(Pens.Blue, pontok[5].X, pontok[5].Y, pontok[0].X, pontok[0].Y);
            //Poligon#1:
            //B:
            g.DrawLine(Pens.Red,pontok[1].X, pontok[1].Y, pontok[6].X,pontok[6].Y);
            //G:
            g.DrawLine(Pens.Red, pontok[6].X, pontok[6].Y, pontok[7].X, pontok[7].Y);
            //H:
            g.DrawLine(Pens.Red, pontok[7].X, pontok[7].Y, pontok[3].X, pontok[3].Y);
            //D:
            g.DrawLine(Pens.Red, pontok[3].X, pontok[3].Y, pontok[1].X, pontok[1].Y);
           
            //Poligon#2:
            PointF[] polygon = new PointF[4];
            for (int i = 0; i < polygon.Length-1; i++)
            {
                polygon[i] = pontok[i+4];
            }
            g.FillPolygon(new SolidBrush(Color.Green), polygon);
        }

        private bool isGotcha(PointF p, float distance, PointF mousePos)
        {
            return Math.Abs(p.X - mousePos.X) <= distance &&
                   Math.Abs(p.Y - mousePos.Y) <= distance;
        }

        #region Mouse handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (isGotcha(pontok[0], 10, e.Location))
            {
                gotcha = 0;
            }
            else if (isGotcha(pontok[1], 10, e.Location))
            {
                gotcha = 1;
            }
            else if (isGotcha(pontok[2], 10, e.Location))
            {
                gotcha = 2;
            }
            else if (isGotcha(pontok[3], 10, e.Location))
            {
                gotcha = 3;
            }
            else if (isGotcha(pontok[4], 10, e.Location))
            {
                gotcha = 4;
            }
            else if (isGotcha(pontok[5], 10, e.Location))
            {
                gotcha = 5;
            }
            else if (isGotcha(pontok[6], 10, e.Location))
            {
                gotcha = 6;
            }
            else if (isGotcha(pontok[7], 10, e.Location))
            {
                gotcha = 7;
            }
        }

            private void canvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (gotcha != -1)
                {
                    switch (gotcha)
                    {
                        case 0: pontok[0] = new PointF(e.X, e.Y); break;
                        case 1: pontok[1] = new PointF(e.X, e.Y); break;
                        case 2: pontok[2] = new PointF(e.X, e.Y); break;
                        case 3: pontok[3] = new PointF(e.X, e.Y); break;
                        case 4: pontok[4] = new PointF(e.X, e.Y); break;
                        case 5: pontok[5] = new PointF(e.X, e.Y); break;
                        case 6: pontok[6] = new PointF(e.X, e.Y); break;
                        case 7: pontok[7] = new PointF(e.X, e.Y); break;

                        default: break;
                    }
                    canvas.Refresh();
            }

            }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            gotcha = -1;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion
    }
}
