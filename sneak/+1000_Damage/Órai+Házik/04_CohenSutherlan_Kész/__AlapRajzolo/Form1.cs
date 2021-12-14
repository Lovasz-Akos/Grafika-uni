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

        Rectangle window = new Rectangle(100, 100, 300, 120);
        Pen penWindow = new Pen(Color.Black, 3);
        Brush brushWindow = new SolidBrush(Color.LightGreen);

        PointF p0 = new PointF(30, 60);
        PointF p1 = new PointF(430, 340);
        Color colorFullLine = Color.Gray;
        bool gotcha = false;

        int dx, dy;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.FillRectangle(brushWindow, window.X, window.Y, window.Width, window.Height);
            g.DrawLine(penWindow, window.X, 0, window.X, canvas.Height);
            g.DrawLine(penWindow, window.X + window.Width, 0, window.X + window.Width, canvas.Height);
            g.DrawLine(penWindow, 0, window.Y, canvas.Width, window.Y);
            g.DrawLine(penWindow, 0, window.Y + window.Height, canvas.Width, window.Y + window.Height);

            g.DrawLine(new Pen(colorFullLine), p0, p1);
        }

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= window.X && e.X < window.X + window.Width &&
               e.Y >= window.Y && e.Y < window.Y + window.Height)
            {
                dx = e.X - window.X;
                dy = e.Y - window.Y;
                gotcha = true;
            }

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gotcha)
            {
                window.X = e.X - dx;
                window.Y = e.Y - dy;
            }
            canvas.Refresh();
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            gotcha = false;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion

        byte LEFT = 8;      //00001000
        byte RIGHT = 4;     //00000100
        byte TOP = 2;       //00000010
        byte BOTTOM = 1;    //00000001

        private byte OutCode(PointF p)
        {
            byte code = 0;  //00000000

            if (p.X < window.X)
                code |= LEFT;
            else if (p.X > window.X + window.Width)
                code |= RIGHT;

            if (p.Y < window.Y)
                code |= TOP;
            else if (p.Y > window.Y + window.Height)
                code |= BOTTOM;

            return code;
        }


        //Hf.: Befejezeni
        //Megmozhatni a vágóablakot és a szakaszt
        //Extra, ezt úgy megoldani, hogy átmenő paraméterekkel adja vissza, hogy történt-e vágás, és hol, ami
        //arra használható majd, hogy akár több vágóablakot is felhelyezzek a síkra
        private void Clip(Color c, PointF p0, PointF p1)
        {
            byte code0 = OutCode(p0);
            byte code1 = OutCode(p1);
            bool accept = false;
            float x0 = p0.X, y0 = p0.Y, x1 = p1.X, y1 = p1.Y;

            while (true)
            {
                if ((code0 | code1) == 0)
                {
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != 0)
                {
                    break;
                }
                else
                {
                    byte code = code0 != 0 ? code0 : code1;

                    float x = 0, y = 0;
                    if ((code & LEFT) != 0)
                    {
                        x = window.X;
                        y = y0 + (y1 - y0) * (window.X - x0) / (x1 - x0);
                    }
                    //Jöhet a többi vágás

                    if (code0 != 0)
                    {
                        x0 = x;
                        y0 = y;
                        code0 = OutCode(new PointF(x0, y0));
                    }
                    else
                    {
                        x1 = x;
                        y1 = y;
                        code1 = OutCode(new PointF(x1, y1));
                    }
                }
            }

            if (accept)
                g.DrawLine(new Pen(c), x0, y0, x1, y1);
        }
    }
}
