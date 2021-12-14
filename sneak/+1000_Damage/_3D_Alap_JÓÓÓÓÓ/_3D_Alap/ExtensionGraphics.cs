using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Alap
{
    public static class ExtensionGraphics
    {
        public static void DrawLine(this Graphics g, Pen pen, Vector3 v0, Vector3 v1)
        { g.DrawLine(pen, v0.x, v0.y, v1.x, v1.y); }

        public static void DrawPolygon(this Graphics g, Pen pen, params Vector3[] V)
        {
            PointF[] P = new PointF[V.Length];
            for (int i = 0; i < V.Length; i++)
            {
                P[i] = new PointF(V[i].x, V[i].y);
            }
            g.DrawPolygon(pen, P);
        }

        public static void FillPolygon(this Graphics g, Brush brush, params Vector3[] V)
        {
            PointF[] P = new PointF[V.Length];
            for (int i = 0; i < V.Length; i++)
            {
                P[i] = new PointF(V[i].x, V[i].y);
            }
            g.FillPolygon(brush, P);
        }

        //public static void Draw3DParametricCurve...

        //  public static void DrawParametricCurve(this Graphics g, Pen pen,
        //RtoR X, RtoR Y,
        //double a, double b,
        //PointF translate, double scale = 1, int n = 500, bool mirror = false)
        //  {
        //      double t = a;
        //      double h = (b - a) / n;
        //      PointF p0, p1;
        //      p0 = new PointF((float)(scale * X(t)) + translate.X,
        //                      (float)(scale * (mirror ? -1 : 1) * Y(t) + translate.Y));
        //      while (t < b)
        //      {
        //          t += h;
        //          p1 = new PointF((float)(scale * X(t)) + translate.X,
        //                          (float)(scale * (mirror ? -1 : 1) * Y(t)) + translate.Y);
        //          g.DrawLine(pen, p0, p1);
        //          p0 = p1;
        //      }
        //  }
       
    }
}
