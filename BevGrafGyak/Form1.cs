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
        int tileGridStartX;
        int tileGridStartY;

        const int tileSize = 100;
        bool whiteSpace = false;
        int flippedCounter = 0;
        int matchCounter = 0;

        Rectangle[,] tiles = new Rectangle[4, 4];
        Rectangle[,] pictureTiles = new Rectangle[4, 4];

        int[] firstTile = new int[2];
        int[] secondTile = new int[2];

        String[,] pictures = new String[4, 4];
        String[] pictureTitles = new String[] { "calculator", "diamond", "fish", "hotdog", "orange", "pyramid", "sun", "viking" };

        Random rng;
        public Form1()
        {
            InitializeComponent();

            tileGridStartX = canvas.Left + 50;
            tileGridStartY = canvas.Top;

            StartGame();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            DrawAllPictures(g);
            DrawTileGrid(g);
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
                    if (k == 8)
                    {
                        k = 0;
                    }
                }
            }
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
            int[] idS = GetClickedTileID(e);

            if (idS[0] == -1)
            {
                whiteSpace = true;
            }
            else
            {
                whiteSpace = false;
            }

            if (!whiteSpace)
            {
                ShowIMG(idS[0], idS[1]);

                if (flippedCounter == 1)
                {
                    firstTile = idS;
                }
                if (flippedCounter == 2)
                {
                    secondTile = idS;
                    canvas.Invalidate();
                    CheckMatches(firstTile, secondTile);
                }
            }
        }

        private int[] GetClickedTileID(MouseEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((e.Location.X > tiles[i, j].X) && (e.Location.X < tiles[i, j].X + tileSize) && (e.Location.Y > tiles[i, j].Y) && (e.Location.Y < tiles[i, j].Y + tileSize))
                    {
                        flippedCounter++;
                        return new int[] { i, j, 0 };
                    }
                    else if ((e.Location.X > pictureTiles[i, j].X) && (e.Location.X < pictureTiles[i, j].X + tileSize) && ((e.Location.Y > pictureTiles[i, j].Y) && (e.Location.Y < pictureTiles[i, j].Y + tileSize)))
                    {
                        //flippedCounter--;
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

        }

        private void CheckMatches(int[] tile1, int[] tile2)
        {

            Task.Delay(500).Wait();

            if (pictures[tile1[0], tile1[1]] == pictures[tile2[0], tile2[1]])
            {
                MatchFound(tile1, tile2);
            }
            else
            {
                HideIMG(tile1[0], tile1[1]);
                HideIMG(tile2[0], tile2[1]);
                flippedCounter = 0;
            }
        }

        private void AddTile(int tileID_X, int tileID_Y)
        {
            tiles[tileID_X, tileID_Y] = new Rectangle(tileGridStartX + (tileID_Y * 100) + (tileID_Y * 10), tileGridStartY + (tileID_X * 100) + (tileID_X * 10), tileSize, tileSize);
            canvas.Invalidate();
        }

        private void ShowIMG(int tileID_X, int tileID_Y)
        {
            DeleteTile(tileID_X, tileID_Y, 0);
        }

        private void MatchFound(int[] tile1, int[] tile2)
        {
            DeleteTile(tile1[0], tile1[1], 1);
            DeleteTile(tile2[0], tile2[1], 1);
            flippedCounter = 0;
            matchCounter++;
            scoreLabel.Text = "Score: " + matchCounter.ToString();
            if (matchCounter == 8)
            {
                EndGame();
            }

        }

        private void HideIMG(int tileID_X, int tileID_Y)
        {

            AddTile(tileID_X, tileID_Y);
        }

        private void DeleteTile(int tileID_X, int tileID_Y, int level)
        {
            if (level == 0)
            {
                tiles[tileID_X, tileID_Y] = new Rectangle(0, 0, 0, 0);
            }
            if (level == 1)
            {
                pictureTiles[tileID_X, tileID_Y] = new Rectangle(0, 0, 0, 0);
            }
            canvas.Invalidate();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void hideAllGreyBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    DeleteTile(i, j, 0);
                }
            }
        }

        private void showAllGreyBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    AddTile(i, j);
                }
            }
        }

        private void StartGame()
        {
            scoreLabel.Text = "Score: 0";
            CreateTileGridStruct();
            GeneratePictureGrid();
            GeneratePictureTileGrid();

            rng = new Random();
            Shuffle(rng, pictures);
            canvas.Invalidate();
        }

        private void EndGame()
        {
            string message = "You Win!";
            string title = ":)";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.OK)
            {
                StartGame();
            }
        }
    }
}
