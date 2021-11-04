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
using GrafikaDLL.Extensions;

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;

        double r = 100;
        double scale = 50;
        Vector2 o;

        public Form1()
        {
            InitializeComponent();
            o = new Vector2(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawLine(Pens.Black, 0, (float)o.y, canvas.Width, (float)o.y);
            g.DrawLine(Pens.Black, (float)o.x, 0, (float)o.x, canvas.Height);

            //r sugarú o középpontú kör
            //g.DrawParametricCurve2D(Pens.Black,
            //    t => r * Math.Cos(t) + o.x,
            //    t => r * Math.Sin(t) + o.y,
            //    0, 2 * Math.PI);

            //sin függvény
            //g.DrawParametricCurve2D(new Pen(Color.Blue, 3f),
            //    t => scale * t + o.x,
            //    t => scale * -Math.Sin(t) + o.y,
            //    -2 * Math.PI, 2 * Math.PI);

            //Hf.: https://en.wikipedia.org/wiki/Butterfly_curve_(transcendental)#/media/File:Animated_construction_of_butterfly_curve.gif
            //Hf.: https://www.google.com/search?q=logarithmic+spiral+parametric+equation&sxsrf=AOaemvLM5r0Fyvu46wRI1H08tKnCfjYkDQ:1634123395269&tbm=isch&source=iu&ictx=1&fir=fy635NqUj7ec6M%252Cr2T2DT4G1WSzCM%252C_%253BAQYPq0UCJjFsnM%252Cfnoj2m-4tGiHcM%252C_%253B44VUPIBqzc37HM%252CJjoPqo4MzfhrZM%252C_%253Bin4L5sWgTGYJXM%252C3erKFH6iVCM8fM%252C_&vet=1&usg=AI4_-kT7tNMiYsK1-U78RmkY3DAmAiLlyg&sa=X&ved=2ahUKEwixvvmDoMfzAhXKlYsKHfTEAwEQ_h16BAg7EAE#imgrc=AQYPq0UCJjFsnM

            //butterfly görbe
            g.DrawParametricCurve2D(new Pen(Color.Red, 2f),
                t => scale * Math.Sin(t) * (Math.Exp(Math.Cos(t)) - 2 * Math.Cos(4 * t) - Math.Pow(Math.Sin(t / 12.0), 5)) + o.x,
                t => scale * -Math.Cos(t) * (Math.Exp(Math.Cos(t)) - 2 * Math.Cos(4 * t) - Math.Pow(Math.Sin(t / 12.0), 5)) + o.y,
                0, 12 * Math.PI, 1500);
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
