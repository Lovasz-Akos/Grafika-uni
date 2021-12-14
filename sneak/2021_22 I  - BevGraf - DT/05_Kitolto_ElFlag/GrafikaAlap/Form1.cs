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
        Bitmap bmp;
        bool isDrawing = false;
        Point p0;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(canvas.Width, canvas.Height);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                    bmp.SetPixel(x, y, Color.White);
            canvas.Image = bmp;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;            
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    isDrawing = true;
                    p0 = e.Location;
                    break;
                case MouseButtons.Right:
                    bmp.FillEdgeFlag(canvas.BackColor, Color.Yellow);
                    canvas.Invalidate();
                    break;
                default:
                    break;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                //bmp.SetPixel(e.X, e.Y, Color.Black);
                bmp.SetLine(p0.X, p0.Y, e.X, e.Y, Color.Black);
                p0 = e.Location;
                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
    }
}
