using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RajzAlap
{
    public class RectangleV2{

        public int x;
        public int y;
        public int width;
        public int height;
        public Color col;
        public PointF rightBottom;


        public RectangleV2(int x, int y, int w, int h, Color c)
        {
            this.x = x;
            this.y = y;
            this.width = w;
            this.height = h;
            this.col = c;
            rightBottom = new PointF(x+width,y+height);
        }

    }
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Graphics g;
        List<RectangleV2> R = new List<RectangleV2>();
        bool grab;
        bool resize = false;
        int index = -1;
        public Form1()
        {

            InitializeComponent();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < R.Count; i++)
            {
                if(isGrabbed(R[i].rightBottom,e.Location,5))
                {
                    grab = true;
                    resize = true;
                    index = i;
                    break;
                }
                if(isGrabbed(new Point(R[i].x+R[i].width/2, R[i].y+R[i].height/2), e.Location,R[i].width /2))
                {
                    grab = true;
                    index = i;
                    break;
                }
            }
            if (!grab)
            {
                RectangleV2 r = new RectangleV2(e.Location.X - 25, e.Location.Y - 25, 50, 50, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                R.Add(r);
                grab = true;
                resize = true;
                index = R.Count - 1;
            }

            pictureBox2.Refresh();
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            grab = false;
            resize = false;
            index = -1;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (grab)
            {
                if (resize)
                {
                    R[index].width = (int)(Math.Sqrt((R[index].x - e.Location.X) * (R[index].x - e.Location.X) 
                        + (R[index].y - e.Location.Y) * (R[index].y - e.Location.Y)));
                    R[index].height = (int)(Math.Sqrt((R[index].x - e.Location.X) * (R[index].x - e.Location.X)
                       + (R[index].y - e.Location.Y) * (R[index].y - e.Location.Y)));
                    R[index].rightBottom = new PointF(R[index].x + R[index].width, R[index].y + R[index].height);
                }
                else
                {
                    R[index] = new RectangleV2(e.Location.X - R[index].width / 2, e.Location.Y - R[index].height / 2, R[index].width, R[index].height, R[index].col);
                }
                pictureBox2.Refresh();

            }
        }

        private void pictureBox2_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < R.Count; i++)
            {                
                g.FillRectangle(new SolidBrush(R[i].col),new Rectangle(R[i].x,R[i].y,R[i].width,R[i].height));
                g.DrawRectangle(new Pen(R[i].col), new Rectangle(R[i].x, R[i].y, R[i].width, R[i].height));
            }
           
        }

        private bool isGrabbed(PointF point, PointF mouse, float distance)
        {
            return Math.Sqrt(((point.X - mouse.X) * (point.X - mouse.X)) + ((point.Y - mouse.Y) * (point.Y - mouse.Y))) <= distance;
        }


    }
}
