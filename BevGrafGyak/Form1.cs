using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black, 5);
        int tileGridStartX = 150;
        int tileGridStartY = 40;

        int tileSize = 100;


        Rectangle[,] tiles = new Rectangle[4, 4];

        public Form1()
        {
            InitializeComponent();
            CreateTileGridStruct();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            tiles = new Rectangle[4, 4];
            g = e.Graphics;

            CreateTileGridStruct();
            DrawTileGrid(g);
            FillListboxWithTiles();

        }

        private void CreateTileGridStruct()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tiles[i, j] = new Rectangle(tileGridStartX + (j * 100) + (j * 10), tileGridStartY + (i * 100) + (i * 10), tileSize, tileSize);
                }
            }
        }


        private void DrawTileGrid(Graphics g)
        {
            foreach (var item in tiles)
            {
                g.DrawRectangle(pen, item);
                g.FillRectangle(Brushes.Gray, item);
            }
        }

        private void DeleteTile(int tileID_X, int tileID_Y)
        {
            try
            {
                tiles[tileID_X, tileID_Y] = new Rectangle(0, 0, 0, 0);

            }
            catch (Exception e)
            {
            }
            canvas.Invalidate();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private int GetClickedTileID(MouseEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (((e.Location.X > tiles[i,j].X) && (e.Location.X < tiles[i,j].X + tileSize)) && (e.Location.Y > tiles[i,j].Y) && (e.Location.Y < tiles[i,j].Y + tileSize))
                    {
                        MessageBox.Show("clikced on tile with these coors: " + tiles[i,j].ToString() + " " + i);
                        return i;
                    }
                }
                
            }
            return -1;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            int[] idS = new int[2];
            idS = GetClickedTileID(e);
            DeleteTile(idS[0], idS[1]);
        }


        private void FillListboxWithTiles()
        {
            tileLister.Items.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tileLister.Items.Add(tiles[i, j].ToString() + " " + i + " " + j);
                }
            }
        }
                tileLister.Items.Add("id:" + i + tiles[i].ToString());
            }
        private void StartButton_Click(object sender, EventArgs e)
        {
            CreateTileGridStruct();
            canvas.Invalidate();
        }
    }
}
