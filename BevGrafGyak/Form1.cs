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
        Pen penColorSys = new Pen(Color.Black);
        int grassHeight = 150;

        int housePositionOffset = 350;
        int houseHeight = 200;
        int houseWidth = 500;

        int roofHeight = 100;

        int windowSize = 100;

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


            for (int i = 1; i <= ((housePositionOffset + houseWidth)); i++)
            {
                if ((housePositionOffset + (150 * i) + windowSize) < housePositionOffset + houseWidth)
                {
                    g.FillRectangle(Brushes.Turquoise,
                       (housePositionOffset + (150 * i)),
                       (canvas.Height - grassHeight) - (houseHeight / 2) - windowSize / 2, windowSize, windowSize);
                }

            }

            #endregion


            //g.DrawRectangle(Pens.Black, 100, 100, 150, 350);

            /*g.FillEllipse(new SolidBrush(Color.GreenYellow), 200,200,150,150);
            g.DrawEllipse(new Pen(Color.Black,10), 200, 200, 150, 150);

            PointF point = new PointF(400, 100);
            float r = 50;
            g.DrawEllipse(new Pen(Color.Salmon, 5), point.X - r, point.Y - r, 2 * r, 2 * r);
            g.DrawRectangle(new Pen(Color.Salmon, 1), point.X, point.Y, 2,2);

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
    }
}
