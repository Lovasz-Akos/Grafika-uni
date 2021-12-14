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

        int gotcha = -1;
        List<PointF> pontok = new List<PointF>();

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (PointF p in pontok)
            {
                g.DrawRectangle(new Pen(Color.Blue), p.X, p.Y, 2F, 2F);
                g.DrawEllipse(new Pen(Color.Pink), p.X - 4, p.Y - 4, 10F,10F);
                //Azé -4 mer' így a jó!
            }
            for (int i = 0; i < pontok.Count-1; i++)
            {
                g.DrawLine(new Pen(Color.Green), pontok[i].X, pontok[i].Y, pontok[i + 1].X, pontok[i + 1].Y);
            }
        }

        #region Mouse handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < pontok.Count; i++)
            {
                if (e.X <= pontok[i].X + 5 && e.X >= pontok[i].X - 5 && e.Y <= pontok[i].Y + 5 && e.Y >= pontok[i].Y - 5)
                {
                    gotcha = i;
                } 
            }
            if (gotcha == -1)
            {
                pontok.Add(new PointF(e.X, e.Y));
            }

        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gotcha != -1)
            {
                pontok[gotcha] = new PointF(e.X, e.Y);
            }
            canvas.Refresh();
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            canvas.Refresh();
            gotcha = -1;   
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion
    }
}
