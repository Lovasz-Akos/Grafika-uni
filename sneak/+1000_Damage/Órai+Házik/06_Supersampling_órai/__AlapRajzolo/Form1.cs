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

            for (int y = 0; y < bmp.Height - 1; y++)
                for (int x = 0; x < bmp.Width - 1; x++)
                {
                    Color c1 = bmp.GetPixel(x, y);
                    Color c2 = bmp.GetPixel(x + 1, y);
                    Color c3 = bmp.GetPixel(x, y + 1);
                    Color c4 = bmp.GetPixel(x + 1, y + 1);
                    int R = (c1.R + c2.R + c3.R + c4.R) / 4;
                    int G = (c1.G + c2.G + c3.G + c4.G) / 4;
                    int B = (c1.B + c2.B + c3.B + c4.B) / 4;
                    result.SetPixel(x, y, Color.FromArgb(R, G, B));
                }

            for (int y = 0; y < bmp.Height; y++)
                result.SetPixel(bmp.Width - 1, y, bmp.GetPixel(bmp.Width - 1, y));
            for (int x = 0; x < bmp.Width; x++)
                result.SetPixel(x, bmp.Height - 1, bmp.GetPixel(x, bmp.Height - 1));

            return result;
        }
    }
}
