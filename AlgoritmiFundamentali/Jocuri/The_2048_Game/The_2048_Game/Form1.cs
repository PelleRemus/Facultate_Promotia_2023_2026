using System;
using System.Drawing;
using System.Windows.Forms;

namespace The_2048_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 4;                    // Jocul are dimensiunea 4x4 
        int[,] values;                // Valorile numerice
        PictureBox[,] matrix;         // Tile-urile afisate
        Random random = new Random(); // Genereaza valori la intamplare

        Color emptySpace = Color.FromArgb(195, 188, 176);
        Color[] colors = new Color[]
        {
            Color.FromArgb(237, 228, 219),  // Culoarea lui 2
            Color.FromArgb(237, 224, 201),  // Culoarea lui 4
            Color.FromArgb(244, 177, 122),
            Color.FromArgb(247, 150, 99),
            Color.FromArgb(246, 125, 98),
            Color.FromArgb(246, 94, 57),
            Color.FromArgb(237, 206, 115),
            Color.FromArgb(237, 202, 100),
            Color.FromArgb(237, 198, 81),
            Color.FromArgb(238, 199, 68),
            Color.FromArgb(236, 194, 48),   // Culoarea lui 2048
            Color.FromArgb(255, 32, 33),    // Culoarea valorilor peste 2048
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            matrix = new PictureBox[n, n];
            int size = (panel1.Width - 20) / n - 10; // Scadem pixelii ce vor ramane spatiu liber intre tile-uri

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    PictureBox picturebox = new PictureBox();
                    picturebox.Parent = panel1;
                    picturebox.BackColor = emptySpace;
                    picturebox.Size = new Size(size, size);
                    picturebox.Location = new Point(10 + j * (size + 10), 10 + i * (size + 10));
                    /* Daca punem locatia la (j * size, i * size), avem tile-urile lipite (si nu acoperim tot ecranul):
                     * +---+---+---+------+
                     * |   |   |   |      |
                     * +---+---+---+      |
                     * |   |   |   |      |
                     * +---+---+---+      |
                     * |                  |
                     * |                  |
                     * +------------------+
                     * 
                     * Daca punem locatia la (j * (size + 10), i * (size + 10)), avem spatiu intre tile-uri:
                     * +---+-+---+-+---+---+
                     * |   | |   | |   |   |
                     * +---+ +---+ +---+   |
                     * +---+ +---+ +---+   |
                     * |   | |   | |   |   |
                     * +---+ +---+ +---+   |
                     * |                   |
                     * +-------------------+
                     * 
                     * Daca punem locatia la (10 + j * (size + 10), 10 + i * (size + 10)), 
                     * avem spatiu si inainte de fiecare tile, in stanga si in sus:
                     * +-------------------+
                     * | +---+ +---+ +---+ |
                     * | |   | |   | |   | |
                     * | +---+ +---+ +---+ |
                     * | +---+ +---+ +---+ |
                     * | |   | |   | |   | |
                     * | +---+ +---+ +---+ |
                     * +-------------------+
                     */

                    matrix[i, j] = picturebox;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            values = new int[n, n]; // Reinitializam vectorul de valori, pentru a "goli" matricea existenta
            GenerateNewTile();
            GenerateNewTile();      // Si generam doua tile-uri noi
            Render();
        }

        private void GenerateNewTile()
        {
            int i, j;
            do
            {
                i = random.Next(n);
                j = random.Next(n);      // Luam valori la intamplare pt indicii din matrice 
            } while (values[i, j] != 0); // Si repetam atata timp cat suntem pe un tile care are deja valoare

            values[i, j] = 1;            // Pentru a nu suprascrie o valoare existenta
            // Vom pune in matricea de values puterea lui 2 a valorii care trebuie afisate
            // Adica pentru 2, avem 1, pentru 4 avem 2, pentru 8 avem 3...
        }

        private void Render() // Metoda pentru afisarea modificarilor din matricea values
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (values[i, j] == 0)
                    {
                        matrix[i, j].BackColor = emptySpace; // Daca un tile are inapoi valoarea 0, afisam inapoi culoarea default
                        continue;
                    }

                    // Indexul in vectorul de culori incepe de la 0, si este cu 1 mai mic decat puterea lui 2 a valorii afisate
                    int index = values[i, j] - 1;
                    matrix[i, j].BackColor = colors[index];
                }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (values == null) // Daca nu am apasat inca pe New Game, nu facem nimic
                return;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                MoveLeft();
                GenerateNewTile();
            }
            Render();
        }

        private void MoveLeft()
        {
            for (int i = 0; i < n; i++)
                for (int j = 1; j < n; j++)
                {
                    int index = j; // Incepem de la coloana curenta
                    // Si, cat timp in stanga avem valoarea 0
                    while (index > 0 && values[i, index - 1] == 0)
                    {
                        values[i, index - 1] = values[i, index]; // Mutam valoarea curenta in stanga
                        values[i, index] = 0; // Si o stergem de pe coloana pe care a fost
                        index--;
                    }
                }
        }
    }
}
