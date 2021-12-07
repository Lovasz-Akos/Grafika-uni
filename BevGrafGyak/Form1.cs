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

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black, 5);
        int tileGridStartX = 150;
        int tileGridStartY = 40;

        int tileSize = 100;

        List<Rectangle> tiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            tiles = new List<Rectangle>();
            
            createTileGridStruct();
            fillListboxWithTiles();

            g = e.Graphics;

            drawTileGrid();

        }

        private void createTileGridStruct()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tiles.Add(new Rectangle(tileGridStartX + (j * 100) + (j * 10), tileGridStartY + (i * 100) + (i * 10), tileSize, tileSize));
                }
            }
        }

        private void fillListboxWithTiles()
        {
            for (int i = 0; i < tiles.Count(); i++)
            {
                tileLister.Items.Add("id:" + i + tiles[i].ToString());
            }
        }

        private void drawTileGrid()
        {
            g.DrawRectangles(pen, tiles.ToArray());

            foreach (var item in tiles)
            {
                g.FillRectangle(Brushes.Gray, item);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            int xd = findClickedTile(e);
        }

        private int findClickedTile(MouseEventArgs e)
        {
            int i;
            for (i = 0; i < tiles.Count(); i++)
            {
                if (((e.Location.X > tiles[i].X) && (e.Location.X < tiles[i].X + tileSize)) && (e.Location.Y > tiles[i].Y) && (e.Location.Y < tiles[i].Y + tileSize))
                {
                    MessageBox.Show("clikced on tile with these coors: " + tiles[i].ToString() + " with ID: " + i);
                }
            }
            
            return i;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
