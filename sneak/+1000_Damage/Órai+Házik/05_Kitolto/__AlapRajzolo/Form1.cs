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

        PointF p = new PointF();

        bool IsDraw = false;

        Bitmap bmp;

        Color cBorder = Color.Black;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(canvas.Width, canvas.Height);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                    bmp.SetPixel(x, y, Color.White);            
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            canvas.Image = bmp;
        }

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    IsDraw = true;
                    p = e.Location;
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    //Fill(bmp, canvas.BackColor, Color.Pink);
                    //FillRek4(bmp, e.Location, canvas.BackColor, Color.Pink);
                    FillStack4(bmp, e.Location, canvas.BackColor, Color.Pink);
                    canvas.Refresh();
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDraw)
            {
                //DrawLine(bmp, Color.Black, p, e.Location);
                bmp.DrawLine(cBorder, p, e.Location);
                p = e.Location;
                canvas.Refresh();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            IsDraw = false;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }
        #endregion

        //private void DrawLine(Bitmap bmp, Color c, 
        //    PointF p0, PointF p1)
        //{
        //    float dx = p1.X - p0.X;
        //    float dy = p1.Y - p0.Y;
        //    float length = Math.Abs(dx);
        //    if (length < Math.Abs(dy))
        //        length = Math.Abs(dy);
        //    float incX = dx / length;
        //    float incY = dy / length;
        //    float x = p0.X;
        //    float y = p0.Y;
        //    bmp.SetPixel((int)x, (int)y, c);
        //    for (int i = 0; i < length; i++)
        //    {
        //        x += incX;
        //        y += incY;
        //        bmp.SetPixel((int)x, (int)y, c);
        //    }
        //}

        private void Fill(Bitmap bmp, Color bg, Color c)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                bool inSide = false;
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color cc = bmp.GetPixel(x, y);                    
                    if (cc.R != bg.R && cc.G != bg.G && cc.B != bg.B)
                    {
                        //Megvizsgálni, hogy az előző körben állítotam-e a flag-et!
                        //Mert ha igen, akkor most nem kell
                        inSide = !inSide;
                        continue;
                    }
                    if (inSide)
                        bmp.SetPixel(x, y, c);
                }
            }
        }
        
        //private void FillRek8(Bitmap bmp, Point p, Color bg, Color c)
        private void FillRek4(Bitmap bmp, Point p, Color bg, Color c)
        {
            Color cc = bmp.GetPixel(p.X, p.Y);
            if (cc.R == bg.R && cc.G == bg.G && cc.B == bg.B)
            {
                bmp.SetPixel(p.X, p.Y, c);
                FillRek4(bmp, new Point(p.X, p.Y + 1), bg, c);
                FillRek4(bmp, new Point(p.X + 1, p.Y), bg, c);
                FillRek4(bmp, new Point(p.X, p.Y - 1), bg, c);
                FillRek4(bmp, new Point(p.X - 1, p.Y), bg, c);
            }
        }
        //private void FillStack8Bitmap bmp, Point p, Color bg, Color c)
        private void FillStack4(Bitmap bmp, Point p, Color bg, Color c)
        {
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { 1, 0, -1, 0 };
            Stack<Point> stack = new Stack<Point>();
            stack.Push(p);
            while (stack.Count != 0)
            {
                Point _p = stack.Pop();
                bmp.SetPixel(_p.X, _p.Y, c);
                for (int i = 0; i < dx.Length; i++)
                {
                    int incX = dx[i];
                    int incY = dy[i];
                    Color cc = bmp.GetPixel(_p.X + incX, _p.Y + incY);
                    if (cc.R == bg.R && cc.G == bg.G && cc.B == bg.B)
                    {
                        stack.Push(new Point(_p.X + incX, _p.Y + incY));
                    }
                }
            }
        }
    }
}
