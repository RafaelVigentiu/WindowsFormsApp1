using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics g; // Obiectul Graphics pentru desenare
        Bitmap b;   // Imaginea bitmap

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inițializăm Bitmap și Graphics
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            // Apelăm metoda principală pentru a desena casa
            DeseneazaCasa();

            // Setăm imaginea în PictureBox
            pictureBox1.Image = b;
        }

        // Metoda principală pentru desenarea casei
        private void DeseneazaCasa()
        {
            // Setăm fundalul
            DeseneazaFundal();

            // Desenăm componentele casei
            DeseneazaPereti(150, 200, 200, 200);
            DeseneazaAcoperis(150, 200, 200, 100);
            DeseneazaUsa(230, 300, 40, 100);
            DeseneazaFereastra(180, 230, 50, 50);
            DeseneazaFereastra(270, 230, 50, 50);
        }

        // Metoda pentru a desena fundalul  .p
        private void DeseneazaFundal()
        {
            g.Clear(Color.SkyBlue); // Cerul
            g.FillRectangle(Brushes.Green, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2); // Iarba
        }

        // Metoda pentru a desena pereții casei
        private void DeseneazaPereti(int x, int y, int width, int height)
        {
            g.FillRectangle(Brushes.BurlyWood, x, y, width, height); // Pereții casei
            g.DrawRectangle(Pens.Black, x, y, width, height);        // Contur
        }

        // Metoda pentru a desena acoperișul casei
        private void DeseneazaAcoperis(int x, int y, int width, int height)
        {
            Point[] puncteAcoperis =
            {
                new Point(x, y),                    // Stânga jos
                new Point(x + width / 2, y - height), // Vârful
                new Point(x + width, y)             // Dreapta jos
            };

            g.FillPolygon(Brushes.DarkRed, puncteAcoperis); // Umplere acoperiș
            g.DrawPolygon(Pens.Black, puncteAcoperis);      // Contur acoperiș
        }

        // Metoda pentru a desena ușa casei
        private void DeseneazaUsa(int x, int y, int width, int height)
        {
            g.FillRectangle(Brushes.SaddleBrown, x, y, width, height); // Umplere ușă
            g.DrawRectangle(Pens.Black, x, y, width, height);          // Contur
            g.FillEllipse(Brushes.Gold, x + width - 10, y + height / 2, 8, 8); // Mânerul ușii
        }

        // Metoda pentru a desena o fereastră
        private void DeseneazaFereastra(int x, int y, int width, int height)
        {
            g.FillRectangle(Brushes.LightBlue, x, y, width, height); // Umplere fereastră
            g.DrawRectangle(Pens.Black, x, y, width, height);       // Contur
            g.DrawLine(Pens.Black, x, y + height / 2, x + width, y + height / 2); // Linie orizontală
            g.DrawLine(Pens.Black, x + width / 2, y, x + width / 2, y + height);  // Linie verticală
        }
    }
}
