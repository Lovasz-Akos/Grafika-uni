using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __RajzAlap
{
    public static class ExtensionMethods
    {
        public delegate double RtoR(double x);
        public static void DrawParametricCurve(this Graphics g, Pen pen, float a, float b,
                                                RtoR x, RtoR y, float scale = 1, float n = 500, float tranX = 0, float tranY = 0, bool mirror = false)
        {

            float t = a;
            float h = (b - a) / n;


            PointF p0 = new PointF(scale * (float)x(t) + tranX,
                                   scale * (mirror ? -1 : 1) * (float)y(t) + tranY);
            PointF p1;
            while (t < b)
            {
                t += h;
                p1 = new PointF(scale * (float)x(t) + tranX,
                                scale * (mirror ? -1 : 1) * (float)y(t) + tranY);
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }



    }
}
