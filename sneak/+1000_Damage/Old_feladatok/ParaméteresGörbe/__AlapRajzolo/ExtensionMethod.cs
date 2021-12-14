using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __AlapRajzolo
{
    public static class ExtensionMethod
    {
        public delegate double RtoR(double x);

        public static void DrawParametricCurve(this Graphics g, Pen pen,
            float a, float b,
            //Func<double, double> X, Func<double, double> Y,
            RtoR X, RtoR Y,
            int n = 500,
            float scale = 1,
            float tranX = 0,
            float tranY = 0,
            bool mirror = false)
        {
            float t = a;
            float h = (b - a) / n;
            PointF p0 = new PointF(scale * (float)X(t) + tranX,
                                   scale * (mirror ? -1 : 1) * (float)Y(t) + tranY);
            PointF p1;
            while (t < b)
            {
                t += h;
                p1 = new PointF(scale * (float)X(t) + tranX,
                                scale * (mirror ? -1 : 1) * (float)Y(t) + tranY);
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }
    }
}