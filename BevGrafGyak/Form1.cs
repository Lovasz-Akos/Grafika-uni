using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        Rectangle[,] pictureTiles = new Rectangle[4, 4];

        String[,] pictures = new String[4, 4];
        String[] pictureTitles = new String[] { "calculator", "diamond", "fish", "hotdog", "orange", "pyramid", "sun", "viking",
                                                "calculator", "diamond", "fish", "hotdog", "orange", "pyramid", "sun", "viking" };
        //Please I beg you, find a better solution for this...

        Random rng;
        public Form1()
        {
            InitializeComponent();
            CreateTileGridStruct();
            GeneratePictureGrid();
            GeneratePictureTileGrid();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            DrawAllPictures(g);
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

        private void GeneratePictureTileGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pictureTiles[i, j] = new Rectangle(tileGridStartX + (j * 100) + (j * 10), tileGridStartY + (i * 100) + (i * 10), tileSize, tileSize);
                }
            }
            rng = new Random();
            Shuffle(rng, pictures);
        }

        private void GeneratePictureGrid()
        {
            int k = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pictures[i, j] = pictureTitles[k];
                    k++;
                }
            }
            rng = new Random();
            Shuffle(rng, pictures);
        }

        private void DrawAllPictures(Graphics g)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    try
                    {
                        g.DrawImage(Image.FromFile(Path.Combine(Application.StartupPath, "Images\\" + pictures[i, j] + ".png")), pictureTiles[i, j]);
                    }
                    catch { };
                }
            }
        }

        public static void Shuffle<T>(Random random, T[,] array)
        {
            int lengthRow = array.GetLength(1);

            for (int i = array.Length - 1; i > 0; i--)
            {
                int i0 = i / lengthRow;
                int i1 = i % lengthRow;

                int j = random.Next(i + 1);
                int j0 = j / lengthRow;
                int j1 = j % lengthRow;

                T temp = array[i0, i1];
                array[i0, i1] = array[j0, j1];
                array[j0, j1] = temp;
            }
        }
        //Fisher-Yates shuffle from https://stackoverflow.com/questions/30164019/shuffling-2d-array-of-cards

        private void DrawTileGrid(Graphics g)
        {
            foreach (var item in tiles)
            {
                g.DrawRectangle(pen, item);
                g.FillRectangle(Brushes.Gray, item);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private int[] GetClickedTileID(MouseEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (((e.Location.X > tiles[i, j].X) && (e.Location.X < tiles[i, j].X + tileSize)) && (e.Location.Y > tiles[i, j].Y) && (e.Location.Y < tiles[i, j].Y + tileSize))
                    {
                        return new int[] { i, j, 0 };
                    }
                    else if (((e.Location.X > pictureTiles[i, j].X) && (e.Location.X < pictureTiles[i, j].X + tileSize)) && ((e.Location.Y > pictureTiles[i, j].Y) && (e.Location.Y < pictureTiles[i, j].Y + tileSize)))
                    {
                        return new int[] { i, j, 1 };
                    }
                }

            }
            return new int[] { -1, -1, -1 };
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            int[] idS = new int[2];
            idS = GetClickedTileID(e);
            //MessageBox.Show(idS[0].ToString() + "  " + idS[1].ToString());
            if (idS[2] == 0)
            {
                ShowIMG(idS[0], idS[1]);
            }
            else if (idS[2] == 1)
            {
                HideIMG(idS[0], idS[1]);
            }
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

        private void AddTile(int tileID_X, int tileID_Y)
        {
            tiles[tileID_X, tileID_Y] = new Rectangle(tileGridStartX + (tileID_Y * 100) + (tileID_Y * 10), tileGridStartY + (tileID_X * 100) + (tileID_X * 10), tileSize, tileSize);
            canvas.Invalidate();
        }

        private void ShowIMG(int tileID_X, int tileID_Y)
        {
            DeleteTile(tileID_X, tileID_Y);
            canvas.Invalidate(true);
        }

        private void HideIMG(int tileID_X, int tileID_Y)
        {
            //TODO: hide image
            AddTile(tileID_X, tileID_Y);
        }

        private void DeleteTile(int tileID_X, int tileID_Y)
        {
            if (!(tileID_X == -1 || tileID_Y == -1))
            {
                tiles[tileID_X, tileID_Y] = new Rectangle(0, 0, 0, 0);
            }
            canvas.Invalidate();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            CreateTileGridStruct();
            GeneratePictureGrid();
            GeneratePictureTileGrid();

            rng = new Random();
            Shuffle(rng, pictures);
            canvas.Invalidate();
        }
    }
}
