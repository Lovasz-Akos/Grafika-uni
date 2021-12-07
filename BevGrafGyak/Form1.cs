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

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black, 5);
        RectangleF[] rectangles = new RectangleF[] { 
            new RectangleF(150,40,100,100), 
            new RectangleF(260, 40, 100, 100),
            new RectangleF(370,40,100,100),
            new RectangleF(480,40,100,100),

            new RectangleF(150,150,100,100),
            new RectangleF(260,150, 100, 100),
            new RectangleF(370,150,100,100),
            new RectangleF(480,150,100,100),

            new RectangleF(150,260,100,100),
            new RectangleF(260,260, 100, 100),
            new RectangleF(370,260,100,100),
            new RectangleF(480,260,100,100),

            new RectangleF(150,370,100,100),
            new RectangleF(260,370, 100, 100),
            new RectangleF(370,370,100,100),
            new RectangleF(480,370,100,100)
        };
        public Form1()
        {
            InitializeComponent();
            
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawRectangles(pen, rectangles);
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
    }
}
