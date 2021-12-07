﻿using System;
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


        Rectangle[,] tiles;
        List<String> pictureTitles = new List<String>() { "calculator", "diamond", "fish", "hotdog", "orange", "pyramid", "sun", "viking" };
        List<String> pictureAssignmentTable = new List<String>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public Form1()
        {
            InitializeComponent();
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
            int tileID = GetClickedTileID(e);
            //DeleteTile(tileID);
            //canvas.Invalidate();
        }


        private void FillListboxWithTiles()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tileLister.Items.Add("id:" + i + tiles[i].ToString());
            }
        }
    }
}
