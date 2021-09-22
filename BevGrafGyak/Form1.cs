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

        #region Variables
        int grassHeight = 100;

        int housePositionOffset = 250;
        int houseHeight = 200;
        int houseWidth = 320;

        int roofHeight = 100;

        int windowSize = 100;

        int doorWidth = 80;
        int doorHeight = 150;
        int doorOffset = 20;

        int treeOffset = 600;
        int treeWidth = 45;
        int treeHeight = 200;

        int sunScale = 300;

        int grassLength = 25;
        int grassDensity = 10000;
        #endregion

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

            #region Sun

            g.FillEllipse(Brushes.Yellow, -sunScale / 2, -sunScale / 2, sunScale, sunScale);
            g.DrawEllipse(new Pen(Color.Gold, 5), -sunScale / 2, -sunScale / 2, sunScale, sunScale);

            #endregion

            #region Clouds

            for (int i = 0; i < rng.Next(2, 10); i++)
            {
                g.FillEllipse(Brushes.WhiteSmoke, rng.Next(canvas.Width), rng.Next(0, 20), rng.Next(150, 400), rng.Next(40, 80));
            }

            #endregion

            #region Grass Block

            g.FillRectangle(Brushes.Olive, 0, canvas.Height - grassHeight, canvas.Width, grassHeight);

            #endregion

            #region House Base

            g.FillRectangle(Brushes.LightGoldenrodYellow, housePositionOffset, (canvas.Height - grassHeight) - houseHeight, houseWidth, houseHeight);

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
            g.DrawRectangle(new Pen(Color.Black, 2),treeOffset, canvas.Height - grassHeight - treeHeight, treeWidth, treeHeight);

            for (int i = 0; i < rng.Next(10, 75); i++)
            {
                g.FillRectangle(Brushes.Black, treeOffset + rng.Next(treeWidth - 5), canvas.Height - grassHeight - treeHeight + rng.Next(treeHeight), rng.Next(2, 7), 2);
            }

            #endregion

            #region Leaves

            int rngPosHeight, rngPosWidth, rngRadius;

            for (int i = 0; i < rng.Next(10, 40); i++)
            {
                rngPosHeight = rng.Next(100);
                rngPosWidth = rng.Next(10, 200);
                rngRadius = rng.Next(50, 150);

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

            #region Grass Blade Generation

            for (int i = 0; i < grassDensity; i++)
            {
                PointF grassRoot = new PointF(rng.Next(0, canvas.Width), rng.Next(canvas.Height - grassHeight, canvas.Height));
                g.DrawLine(new Pen(Color.Olive, 2), 
                    grassRoot.X, grassRoot.Y, grassRoot.X + rng.Next(-grassLength, grassLength), 
                    grassRoot.Y - rng.Next(-grassLength, grassLength));
            }

            #endregion
           
        }

       

        private void houseWidthBar_DragDrop(object sender, DragEventArgs e)
        {
            houseWidth = houseWidthslider.Value;
            canvas.Invalidate();
        }

        private void houseWidthBar_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void houseWidthBar_Scroll(object sender, ScrollEventArgs e)
        {
            houseWidth = houseWidthslider.Value;
            
            if (e.Type == ScrollEventType.EndScroll)
            {
                canvas.Invalidate();
            }
        }

        private void roofHeightSlider_Scroll(object sender, ScrollEventArgs e)
        {
            roofHeight = roofHeightSlider.Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                canvas.Invalidate();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            windowSize = windowSizeSlider.Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                canvas.Invalidate();
            }
        }

        private void treeHeightSlider_Scroll(object sender, ScrollEventArgs e)
        {
            treeHeight = treeHeightSlider.Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                canvas.Invalidate();
            }
        }

        private void treePositionSlider_Scroll(object sender, ScrollEventArgs e)
        {
            treeOffset= treePositionSlider.Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                canvas.Invalidate();
            }
        }

        private void housePositionSlider_Scroll(object sender, ScrollEventArgs e)
        {
            housePositionOffset = housePositionSlider.Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                canvas.Invalidate();
            }
        }

        private void grassDensitySlider_Scroll(object sender, ScrollEventArgs e)
        {
            grassDensity = grassDensitySlider.Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                canvas.Invalidate();
            }
        }

        private void randomiserButton_Click(object sender, EventArgs e)
        { 
            canvas.Invalidate();
        }
    }
}
