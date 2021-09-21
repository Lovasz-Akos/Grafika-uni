using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF center;

        Random rng = new Random();

        int grassHeight = 100;

        int housePositionOffset = 250;
        int houseHeight = 200;
        int houseWidth = 450;

        int roofHeight = 100;

        int windowSize = 100;

        int doorWidth = 80;
        int doorHeight = 150;
        int doorOffset = 20;

        int treeOffset = 750;
        int treeWidth = 45;
        int treeHeight = 200;

        public Form1()
        {
            InitializeComponent();
            center = new PointF(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            #region Sky

            g.FillRectangle(Brushes.LightSkyBlue, 0, 0, canvas.Width, canvas.Height);

            #endregion

            #region Grass

            g.FillRectangle(Brushes.LawnGreen, 0, canvas.Height - grassHeight, canvas.Width, grassHeight);

            #endregion

            #region House Base

            g.FillRectangle(Brushes.Firebrick, housePositionOffset, (canvas.Height - grassHeight) - houseHeight, houseWidth, houseHeight);

            #endregion

            #region Roof

            Point roof1 = new Point(housePositionOffset, (canvas.Height - grassHeight) - houseHeight);
            Point roof2 = new Point(roof1.X + 50, roof1.Y - roofHeight);
            Point roof3 = new Point(roof2.X + houseWidth - 100, roof2.Y);
            Point roof4 = new Point(roof3.X + 25, roof3.Y + 25);
            Point roof5 = new Point(housePositionOffset + houseWidth, (canvas.Height - grassHeight) - houseHeight);

            g.FillPolygon(Brushes.Chocolate, new PointF[5] { roof1, roof2, roof3, roof4, roof5 });

            #endregion

            #region Windows


            for (int i = 1; (150 * i) <= housePositionOffset + houseWidth + windowSize; i++)
            {
                if ((housePositionOffset + (150 * i) + windowSize) < housePositionOffset + houseWidth)
                {
                    g.FillRectangle(Brushes.Turquoise,
                       (housePositionOffset + (150 * i)),
                       (canvas.Height - grassHeight) - (houseHeight / 2) - windowSize / 2, windowSize, windowSize);
                }

            }

            #endregion

            #region Door

            g.FillRectangle(Brushes.SandyBrown, housePositionOffset + doorOffset, (canvas.Height - grassHeight) - doorHeight, doorWidth, doorHeight);
            g.FillEllipse(Brushes.Brown, housePositionOffset + doorOffset + doorWidth - 15, (canvas.Height - grassHeight) - doorHeight / 2, 10, 10);

            #endregion

            #region Tree

            g.FillRectangle(Brushes.BlanchedAlmond, treeOffset, canvas.Height - grassHeight - treeHeight, treeWidth, treeHeight);
            for (int i = 0; i < rng.Next(10,75); i++)
            {
                g.FillRectangle(Brushes.Black, treeOffset + rng.Next(treeWidth - 5), canvas.Height - grassHeight - treeHeight + rng.Next(treeHeight), rng.Next(2,7), 2);
            }

            #endregion

            #region Leaves
            for (int i = 0; i < rng.Next(5,30); i++)
            {
                int rngPosHeight = rng.Next(100);
                int rngPosWidth = rng.Next(10, 200);
                int rngRadius = rng.Next(50, 150);

                g.FillEllipse(Brushes.SpringGreen, 
                    treeOffset - 75 + rngPosHeight, 
                    canvas.Height - grassHeight - treeHeight - rngPosWidth,
                    rngRadius,
                    rngRadius);

                g.DrawEllipse(new Pen(Color.Green, 3),
                    treeOffset - 75 + rngPosHeight,
                    canvas.Height - grassHeight - treeHeight - rngPosWidth,
                    rngRadius,
                    rngRadius);

            }

            #endregion


            /*
            gradient

            PointF pointname = new PointF(450, 300);
            for (int i = 0; i < 250; i++)
            {
                for (int j = 0; j < 250; j++)
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(i, j, 0)), pointname.X + i, pointname.Y + j, 0.5f, 0.5f);
                }
            }
            */
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

        private void rngSpammer_Click(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }
    }
}
