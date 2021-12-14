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

/*
 * 1. Súlyok állítása globálisan
 *    advanced felhasználóknak: ívenként
 * 2. checkbox-szal zárt-nyílt görbe váltása
 * 3. Az érintővektornak rajzolja ki az ellentétes irányú vektorát is, és azzal is lehessen módosítani
 * 4. Ha pontot mozgatunk, mozogjon vele az érintő végpontja is
 * 5. Zárt görbe esetén fillezzék ki a görbét
 */

namespace GrafikaAlap
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Vector2> V = new List<Vector2>();
        int grabbed = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for (int i = 0; i < V.Count - 1; i++)
            {
                g.DrawLine(Pens.Black, V[i], V[i + 1]);
                g.DrawPoint(Pens.Black, Brushes.White, V[i], 5);
            }
            if (V.Count >1 )
            g.DrawPoint(Pens.Black, Brushes.White, V.LastOrDefault(), 5);

            g.DrawBezier(Pens.Blue, V);

            if (V.Count > 3)
            {
                for (int i = 0; i < V.Count - 3; i++)
                {
                    g.DrawBSpline(Pens.Red, V[i], V[i + 1], V[i + 2], V[i + 3]);
                }
            }
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < V.Count; i++)
            {
                if (e.CloseEnough(V[i]))
                    grabbed = i;
            }

            if (grabbed == -1)
            {
                V.Add(new Vector2(e.X, e.Y));
                grabbed = V.Count - 1;
                canvas.Invalidate();
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                V[grabbed] = new Vector2(e.X, e.Y);
                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
