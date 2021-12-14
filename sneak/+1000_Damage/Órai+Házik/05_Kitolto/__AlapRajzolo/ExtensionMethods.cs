using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __AlapRajzolo
{
    public static class ExtensionMethods
    {
        public static void DrawLine(this Bitmap bmp, Color c,
            PointF p0, PointF p1)
        {
            float dx = p1.X - p0.X;
            float dy = p1.Y - p0.Y;
            float length = Math.Abs(dx);
            if (length < Math.Abs(dy))
                length = Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float x = p0.X;
            float y = p0.Y;
            bmp.SetPixel((int)x, (int)y, c);
            for (int i = 0; i < length; i++)
            {
                x += incX;
                y += incY;
                bmp.SetPixel((int)x, (int)y, c);
            }
        }
    }
}
