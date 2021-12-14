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
        Color colorControl = Color.Black;
        Color colorCurve = Color.Blue;
        Color colorCurve2 = Color.Red;
        Color colorCurve3 = Color.Black;
        List<PointF> P = new List<PointF>();
        int grab = -1;



        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < P.Count; i++)
            {
                drawCasteljau(new Pen(colorCurve3, 3f));
            }

            if (P.Count > 1)
              //  DrawBezier(new Pen(colorCurve, 3f), P);

            for (int i = 0; i < P.Count - 3; i++)
            {
                //DrawBSplineArc(new Pen(colorCurve2, 3f), P[i], P[i + 1], P[i + 2], P[i + 3]);
               // DrawBSplineClosed(new Pen(colorCurve2, 3f), P);
            }

            for (int i = 0; i < P.Count; i++)
                g.FillRectangle(new SolidBrush(colorControl), P[i].X - 5, P[i].Y - 5, 10, 10);

            for (int i = 0; i < P.Count - 1; i++)
                g.DrawLine(new Pen(colorControl), P[i], P[i + 1]);
        }

        #region Mouse Handling
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < P.Count; i++)
            {
                if (IsGrab(P[i], e.Location))
                    grab = i;
            }

            if (grab == -1)
            {
                P.Add(e.Location);
                grab = P.Count - 1;
                canvas.Refresh();
            }
        }


        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grab != -1)
            {
                P[grab] = e.Location;
                canvas.Refresh();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grab = -1;
        }
        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        private bool IsGrab(PointF p, PointF mouseLocation)
        {
            return p.X - 5 <= mouseLocation.X && mouseLocation.X <= p.X + 5 &&
                   p.Y - 5 <= mouseLocation.Y && mouseLocation.Y <= p.Y + 5;
        }

        private bool IsGrab2(PointF p, PointF mouseLocation)
        {
            return p.X - 25 <= mouseLocation.X && mouseLocation.X <= p.X + 25 &&
                   p.Y - 25 <= mouseLocation.Y && mouseLocation.Y <= p.Y + 25;
        }
        #endregion


        private float binomialMultiple(int n, int k)
        {
            float res = 1;
            for (int i = 1; i <= k; i++)
            {
                res = res * (n + 1 - i) / i;
            }
            return res;
        }


        private float Binom(int n, int k)
        {
            if (k == 0) return 1;
            if (k == n) return 1;
            if (n == 0) return 0;
            return Binom(n - 1, k - 1) + Binom(n - 1, k);
        }


        //Hf.: DrawBezier megírása deCasteljou algoritmussal (rekurzív)



        #region casteljauProb
        /*
        public Transform startPoint;
        public Transform endPoint;
        public Transform controlPointStart;
        public Transform controlPointEnd;

        //Easier to use ABCD for the positions of the points so they are the same as in the tutorial image
        Vector3 A, B, C, D;
        void OnDrawGizmos()
        {
            A = startPoint.position;
            B = controlPointStart.position;
            C = controlPointEnd.position;
            D = endPoint.position;

            //The Bezier curve's color
            Gizmos.color = Color.white;

            //The start position of the line
            Vector3 lastPos = A;

            //The resolution of the line
            //Make sure the resolution is adding up to 1, so 0.3 will give a gap at the end, but 0.2 will work
            float resolution = 0.02f;

            //How many loops?
            int loops = Mathf.FloorToInt(1f / resolution);

            for (int i = 1; i <= loops; i++)
            {
                //Which t position are we at?
                float t = i * resolution;

                //Find the coordinates between the control points with a Catmull-Rom spline
                Vector3 newPos = DeCasteljausAlgorithm(t);

                //Draw this line segment
                Gizmos.DrawLine(lastPos, newPos);

                //Save this pos so we can draw the next line segment
                lastPos = newPos;
            }

            //Also draw lines between the control points and endpoints
            Gizmos.color = Color.green;

            Gizmos.DrawLine(A, B);
            Gizmos.DrawLine(C, D);
        }

        //The De Casteljau's Algorithm
        Vector3 DeCasteljausAlgorithm(float t)
        {
            //Linear interpolation = lerp = (1 - t) * A + t * B
            //Could use Vector3.Lerp(A, B, t)

            //To make it faster
            float oneMinusT = 1f - t;

            //Layer 1
            Vector3 Q = oneMinusT * A + t * B;
            Vector3 R = oneMinusT * B + t * C;
            Vector3 S = oneMinusT * C + t * D;

            //Layer 2
            Vector3 P = oneMinusT * Q + t * R;
            Vector3 T = oneMinusT * R + t * S;

            //Final interpolated position
            Vector3 U = oneMinusT * P + t * T;

            return U;
        }
        */

        #endregion

        private void drawCasteljau(Pen pen)
        {
            PointF tmp;
            List<PointF> list = new List<PointF>();
            for (double t = 0; t <= 1; t += 0.001)
            {
                tmp = getCasteljauPoint(P.Count - 1, 0, t);
                //g.FillRectangle(pen.Brush, tmp.X, tmp.Y, 1, 1);
                list.Add(tmp);
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                g.DrawLine(Pens.Green, list[i], list[i + 1]);
            }
        }
        private PointF getCasteljauPoint(int r, int i, double t)
        {
            if (r == 0) return P[i];

            PointF p1 = getCasteljauPoint(r - 1, i, t);
            PointF p2 = getCasteljauPoint(r - 1, i + 1, t);

            return new PointF((float)((1 - t) * p1.X + t * p2.X), (float)((1 - t) * p1.Y + t * p2.Y));
        }


        private void DrawBezier(Pen pen, List<PointF> P)
        {
            double a = 0;
            double t = a;
            double h = 1.0 / 500.0;
            int n = P.Count - 1;
            PointF d0, d1;
            d0 = new PointF(0, 0);
            d1 = new PointF(0, 0);
            for (int i = 0; i < P.Count; i++)
            {

                d0.X += (float)(binomialMultiple(n, i) * Math.Pow(1 - t, n - i) * Math.Pow(t, i) * P[i].X);
                d0.Y += (float)(binomialMultiple(n, i) * Math.Pow(1 - t, n - i) * Math.Pow(t, i) * P[i].Y);
            }
            while (t < 1)
            {
                t += h;
                d1 = new PointF(0, 0);
                for (int i = 0; i < P.Count; i++)
                {

                    d1.X += (float)(binomialMultiple(n, i) * Math.Pow(1 - t, n - i) * Math.Pow(t, i) * P[i].X);
                    d1.Y += (float)(binomialMultiple(n, i) * Math.Pow(1 - t, n - i) * Math.Pow(t, i) * P[i].Y);
                }
                g.DrawLine(pen, d0, d1);
                d0 = d1;
            }
        }

        private double N0(double t) { return 1.0 / 6.0 * (1 - t) * (1 - t) * (1 - t); }
        private double N1(double t) { return 0.5 * t * t * t - t * t + 2.0 / 3.0; }
        private double N2(double t) { return -0.5 * t * t * t + 0.5 * t * t + 0.5 * t + 1.0 / 6.0; }
        private double N3(double t) { return 1.0 / 6.0 * t * t * t; }

        //Hf.: Végpontokat interpoláló B-Spline

        //Ennek vezérlését pl. legördülő menüvel (vagy radiobutton-nel) vezéerelni
        private void DrawBSplineArc(Pen pen, PointF p0, PointF p1, PointF p2, PointF p3)
        {
            double a = 0;
            double t = a;
            double h = 1.0 / 500.0;
            PointF d0, d1;
            d0 = new PointF((float)(N0(t) * p0.X + N1(t) * p1.X + N2(t) * p2.X + N3(t) * p3.X),
                            (float)(N0(t) * p0.Y + N1(t) * p1.Y + N2(t) * p2.Y + N3(t) * p3.Y));

            while (t < 1)
            {
                t += h;
                d1 = new PointF((float)(N0(t) * p0.X + N1(t) * p1.X + N2(t) * p2.X + N3(t) * p3.X),
                                (float)(N0(t) * p0.Y + N1(t) * p1.Y + N2(t) * p2.Y + N3(t) * p3.Y));
                g.DrawLine(pen, d0, d1);
                d0 = d1;
            }
        }


        private void DrawBSplineClosed(Pen pen, List<PointF> P)
        {
            double a = 0;
            double t = a;
            double h = 1.0 / 500.0;
            PointF d0, d1;
            int n = P.Count - 1;

            for (int i = 0; i < n - 2; i++)
            {
                t = a;
                d0 = new PointF((float)(N0(t) * P[i].X + N1(t) * P[i + 1].X + N2(t) * P[i + 2].X + N3(t) * P[i + 3].X),
                            (float)(N0(t) * P[i].Y + N1(t) * P[i + 1].Y + N2(t) * P[i + 2].Y + N3(t) * P[i + 3].Y));
                while (t < 1)
                {
                    t += h;
                    d1 = new PointF((float)(N0(t) * P[i].X + N1(t) * P[i + 1].X + N2(t) * P[i + 2].X + N3(t) * P[i + 3].X),
                            (float)(N0(t) * P[i].Y + N1(t) * P[i + 1].Y + N2(t) * P[i + 2].Y + N3(t) * P[i + 3].Y));

                    g.DrawLine(pen, d0, d1);
                    d0 = d1;
                }
            }

            t = a;

            d0 = new PointF((float)(N0(t) * P[n - 2].X + N1(t) * P[n - 1].X + N2(t) * P[n].X + N3(t) * P[0].X),
                            (float)(N0(t) * P[n - 2].Y + N1(t) * P[n - 1].Y + N2(t) * P[n].Y + N3(t) * P[0].Y));

            if (IsGrab2(P.First(), P.Last()))
            {
                while (t < 1)
                {
                    t += h;
                    d1 = new PointF((float)(N0(t) * P[n - 2].X + N1(t) * P[n - 1].X + N2(t) * P[n].X + N3(t) * P[0].X),
                                (float)(N0(t) * P[n - 2].Y + N1(t) * P[n - 1].Y + N2(t) * P[n].Y + N3(t) * P[0].Y));

                    g.DrawLine(pen, d0, d1);
                    d0 = d1;
                } 
            }

            t = a;

            d0 = new PointF((float)(N0(t) * P[n - 1].X + N1(t) * P[n].X + N2(t) * P[0].X + N3(t) * P[1].X),
                            (float)(N0(t) * P[n - 1].Y + N1(t) * P[n].Y + N2(t) * P[0].Y + N3(t) * P[1].Y));
            if (IsGrab2(P.First(), P.Last()))
            {
                while (t < 1)
                {
                    t += h;
                    d1 = new PointF((float)(N0(t) * P[n - 1].X + N1(t) * P[n].X + N2(t) * P[0].X + N3(t) * P[1].X),
                                (float)(N0(t) * P[n - 1].Y + N1(t) * P[n].Y + N2(t) * P[0].Y + N3(t) * P[1].Y));

                    g.DrawLine(pen, d0, d1);
                    d0 = d1;
                } 
            }

            t = a;

            d0 = new PointF((float)(N0(t) * P[n].X + N1(t) * P[0].X + N2(t) * P[1].X + N3(t) * P[2].X),
                            (float)(N0(t) * P[n].Y + N1(t) * P[0].Y + N2(t) * P[1].Y + N3(t) * P[2].Y));
            if (IsGrab2(P.First(), P.Last()))
            {
                while (t < 1)
                {
                    t += h;
                    d1 = new PointF((float)(N0(t) * P[n].X + N1(t) * P[0].X + N2(t) * P[1].X + N3(t) * P[2].X),
                                (float)(N0(t) * P[n].Y + N1(t) * P[0].Y + N2(t) * P[1].Y + N3(t) * P[2].Y));

                    g.DrawLine(pen, d0, d1);
                    d0 = d1;
                } 
            }
        }

        //private void DrawBSplineArcWithEndpoints(Pen pen, List<PointF> P)
        //{
        //    double a = 0;
        //    double t = a;
        //    double h = 1.0 / 500.0;
        //    PointF d0, d1;
        //    int n = P.Count - 1;

        //    for (int i = 0; i < n - 2; i++)
        //    {
        //        t = a;
        //        if (i == 0)
        //        {
        //            d0 = new PointF((float)(N0(t) * P[i].X + N0(t) * P[i].X + N0(t) * P[i].X + N1(t) * P[i + 1].X + N2(t) * P[i + 2].X + N3(t) * P[i + 3].X),
        //                        (float)(N0(t) * P[i].Y + N0(t) * P[i].Y + N0(t) * P[i].Y + N1(t) * P[i + 1].Y + N2(t) * P[i + 2].Y + N3(t) * P[i + 3].Y));
        //            d0 = new PointF((float)(N0(t) * P[i].X + N1(t) * P[i].X + N2(t) * P[i].X + N3(t) * P[i + 1].X),
        //                        (float)(N0(t) * P[i].Y + N1(t) * P[i].Y + N2(t) * P[i].Y + N3(t) * P[i + 1].Y));
        //            d0 = new PointF((float)(N0(t) * P[i].X + N0(t) * P[i].X + N0(t) * P[i].X + N1(t) * P[i + 1].X),
        //                        (float)(N0(t) * P[i].Y + N0(t) * P[i].Y + N0(t) * P[i].Y + N1(t) * P[i + 1].Y));
        //        }
        //        else
        //        {
        //            d0 = new PointF((float)(N0(t) * P[i].X + N1(t) * P[i + 1].X + N2(t) * P[i + 2].X + N3(t) * P[i + 3].X),
        //                        (float)(N0(t) * P[i].Y + N1(t) * P[i + 1].Y + N2(t) * P[i + 2].Y + N3(t) * P[i + 3].Y));
        //        }
        //        while (t < 1)
        //        {
        //            t += h;
        //            if (i == n - 1)
        //            {
        //                d1 = new PointF((float)(N0(t) * P[i].X + N1(t) * P[i + 1].X + N2(t) * P[i + 2].X + N3(t) * P[i + 3].X + N3(t) * P[i + 3].X + N3(t) * P[i + 3].X),
        //                            (float)(N0(t) * P[i].Y + N1(t) * P[i + 1].Y + N2(t) * P[i + 2].Y + N3(t) * P[i + 3].Y + N3(t) * P[i + 3].Y + N3(t) * P[i + 3].Y));
        //                d1 = new PointF((float)(N0(t) * P[i].X + N1(t) * P[i + 1].X + N2(t) * P[i + 1].X + N3(t) * P[i + 1].X),
        //                        (float)(N0(t) * P[i].Y + N1(t) * P[i + 1].Y + N2(t) * P[i + 1].Y + N3(t) * P[i + 1].Y));
        //            }
        //            else
        //            {
        //                d1 = new PointF((float)(N0(t) * P[i].X + N1(t) * P[i + 1].X + N2(t) * P[i + 2].X + N3(t) * P[i + 3].X),
        //                        (float)(N0(t) * P[i].Y + N1(t) * P[i + 1].Y + N2(t) * P[i + 2].Y + N3(t) * P[i + 3].Y));
        //            }
        //            g.DrawLine(pen, d0, d1);
        //            d0 = d1;
        //        }
        //    }
        //}
    }
}
