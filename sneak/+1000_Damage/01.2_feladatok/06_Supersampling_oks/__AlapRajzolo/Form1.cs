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
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap("zool.jpg");
            canvas.Width = bmp.Width;
            this.Width = bmp.Width + 40;
            canvas.Height = bmp.Height;
            this.Height = bmp.Height + 63;
            canvas.Image = bmp;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            
        }

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            canvas.Image = Supesampling(bmp);
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

        //private Bitmap Supesampling(Bitmap bmp, int size)
        private Bitmap Supesampling(Bitmap bmp)
        {
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 0; y < bmp.Height - 6; y=y+6)
                for (int x = 0; x < bmp.Width - 7; x=x+7)
                {
                    Color c;
                    int R = 0;
                    int G = 0;
                    int B = 0;
                    for (int i = y; i < y+6; i++)
                    {
                        for (int j = x; j < x+7; j++)
                        {
                            c = bmp.GetPixel(j, i);
                            R += c.R;
                            G += c.G;
                            B += c.B;
                        }
                    }
                    R = R / 42;
                    G = G / 42;
                    B = B / 42;
                    for (int i = y; i < y + 6; i++)
                    {
                        for (int j = x; j < x + 7; j++)
                        {
                            result.SetPixel(j, i, Color.FromArgb(R, G, B));
                        }
                    }
                }
            for (int i = 1; i <= 3; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    result.SetPixel(bmp.Width - i, y, bmp.GetPixel(bmp.Width - i, y));
                for (int x = 0; x < bmp.Width; x++)
                    result.SetPixel(x, bmp.Height - i, bmp.GetPixel(x, bmp.Height - i));

            }
            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    result.SetPixel(0 + i, y, bmp.GetPixel(0 + i, y));
                for (int x = 0; x < bmp.Width; x++)
                    result.SetPixel(x, 0 + i, bmp.GetPixel(x, 0+ i));
            }


            
            return result;
        }
    }
}
