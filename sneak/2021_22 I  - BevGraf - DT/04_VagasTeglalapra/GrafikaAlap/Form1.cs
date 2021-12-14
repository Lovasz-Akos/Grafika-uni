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

namespace GrafikaAlap
{
    public partial class Form1 : Form
    {
        Graphics g;
        Random rnd = new Random();
        List<Rectangle> windows;
        Line[] lines = new Line[500];
        //Generáljanak minden szakasznak saját színt

        public Form1()
        {
            InitializeComponent();
            windows = new List<Rectangle>()
            {
                new Rectangle(30, 40, 100, 130),
                new Rectangle(150, 200, 70, 160),
                new Rectangle(510, 10, 40, 350)
            };
            
            for (int i = 0; i < lines.Length; i++)
                lines[i] = new Line(rnd.Next(canvas.Width), rnd.Next(canvas.Height),
                                    rnd.Next(canvas.Width), rnd.Next(canvas.Height));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < windows.Count; i++)
                g.DrawRectangle(Pens.Black, windows[i]);

            for (int i = 0; i < lines.Length; i++)
                for (int j = 0; j < windows.Count; j++)
                    g.Clip(Pens.Red, windows[j], lines[i]);
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            //Ha valamelyik téglalapot elkapom -> mozgatás
            //Egyébként
            //  Létrehozok egy új 0x0-es téglalapot
            //  ami rögtön meg is van fogva
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //Ha valami meg van fogva (külön kell kezelni, hogy mozgatás miatt, vagy méretezés miatt)
            //  mozgatom, vagy méretezem
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            //Elengedem
        }
    }
}
