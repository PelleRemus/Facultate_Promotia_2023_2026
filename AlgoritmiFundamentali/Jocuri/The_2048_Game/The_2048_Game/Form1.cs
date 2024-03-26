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
        int size;                     // Size-ul picturebox-urilor
        int[,] values;                // Valorile numerice
        PictureBox[,] matrix;         // Tile-urile afisate
        Random random = new Random(); // Genereaza valori la intamplare

        Bitmap bitmap;                // Bitmap reprezinta o imagine
        Graphics graphics;            // Obiectele Graphics pot "desena" peste imagini
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
            size = (panel1.Width - 20) / n - 10;     // Calculam size-ul picturebox-urilor. Scadem pixelii ce vor ramane spatiu liber intre tile-uri

            bitmap = new Bitmap(size, size);         // Facem o imagine de dimensiunile picturebox-urilor
            graphics = Graphics.FromImage(bitmap);   // Graphics va desena in interiorul imaginii nou create
            graphics.Clear(emptySpace);              // Metoda Clear "sterge" toata imaginea si lasa o singura culoare in schimb

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    PictureBox picturebox = new PictureBox();
                    picturebox.Parent = panel1;
                    picturebox.Image = bitmap;       // In locul culorii de fundal, afisam acum in schimb imaginea
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
                    // Pentru fiecare picturebox, facem o noua imagine. Altfel, am vedea pentru fiecare ultima imagine creata
                    // (Imaginea este de tip referinta, spre deosebire de int sau alte tipuri de date primitive. Sugerez sa vedeti de ce se manifesta asa)
                    bitmap = new Bitmap(size, size);
                    graphics = Graphics.FromImage(bitmap);

                    if (values[i, j] == 0)
                    {
                        graphics.Clear(emptySpace); // Daca un tile are inapoi valoarea 0, afisam inapoi culoarea default
                        matrix[i, j].Image = bitmap;
                        continue;
                    }

                    // Indexul in vectorul de culori incepe de la 0, si este cu 1 mai mic decat puterea lui 2 a valorii afisate
                    int index = values[i, j] - 1;
                    string displayValue = Math.Pow(2, values[i, j]).ToString(); // Valoarea ce trebuie afisata este 2 la puterea valorii din matrice
                    int nrOfCharacters = Math.Max(displayValue.Length, 2);

                    // Dimensiunea caracterelor in fontul Courier este aproximativ aceeasi si in pixeli,
                    // deci putem lua dimensiunea tile-ului si sa o impartim la numarul de caractere
                    Font font = new Font("Courier", (float)(size - 10) / nrOfCharacters, FontStyle.Bold);

                    // "a" ? "b" : "c" se numeste operator tertiar. Codule de mai jos este echivalent cu:
                    // if (colors[index].GetBrightness() < 0.8)
                    //      fontColor = Color.White;
                    // else
                    //      fontColor = Color.FromArgb(120, 110, 100);
                    Color fontColor = colors[index].GetBrightness() < 0.8 ? Color.White : Color.FromArgb(120, 110, 100);

                    // Putem formata stringul pe aria pe care este afisat, deci daca luam intreg size-ul tile-ului, putem folosi aliniamentul Center
                    var format = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                    graphics.Clear(colors[index]);
                    graphics.DrawString(displayValue, font, new SolidBrush(fontColor), new Rectangle(0, 0, size, size), format);
                    matrix[i, j].Image = bitmap;
                }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (values == null) // Daca nu am apasat inca pe New Game, nu facem nimic
                return;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                MoveLeft();
                CombineLeft();
                MoveLeft();
                GenerateNewTile();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                MoveRight();
                CombineRight();
                MoveRight();
                GenerateNewTile();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                MoveUp();
                CombineUp();
                MoveUp();
                GenerateNewTile();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                MoveDown();
                CombineDown();
                MoveDown();
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
        private void CombineLeft()
        {
            for (int i = 0; i < n; i++)
                for (int j = 1; j < n; j++)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (values[i, j] != 0 && values[i, j] == values[i, j - 1])
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        values[i, j - 1]++;
                        values[i, j] = 0;
                    }
                }
        }

        private void MoveRight()
        {
            for (int i = 0; i < n; i++)
                for (int j = n - 2; j >= 0; j--)
                {
                    int index = j; // Incepem de la coloana curenta
                    // Si, cat timp in dreapta avem valoarea 0
                    while (index < n - 1 && values[i, index + 1] == 0)
                    {
                        values[i, index + 1] = values[i, index]; // Mutam valoarea curenta in dreapta
                        values[i, index] = 0; // Si o stergem de pe coloana pe care a fost
                        index++;
                    }
                }
        }
        private void CombineRight()
        {
            for (int i = 0; i < n; i++)
                for (int j = n - 2; j >= 0; j--)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (values[i, j] != 0 && values[i, j] == values[i, j + 1])
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        values[i, j + 1]++;
                        values[i, j] = 0;
                    }
                }
        }

        private void MoveUp()
        {
            for (int i = 1; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    int index = i; // Incepem de la linia curenta
                    // Si, cat timp in sus avem valoarea 0
                    while (index > 0 && values[index - 1, j] == 0)
                    {
                        values[index - 1, j] = values[index, j]; // Mutam valoarea curenta in sus
                        values[index, j] = 0; // Si o stergem de pe linia pe care a fost
                        index--;
                    }
                }
        }
        private void CombineUp()
        {
            for (int i = 1; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (values[i, j] != 0 && values[i, j] == values[i - 1, j])
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        values[i - 1, j]++;
                        values[i, j] = 0;
                    }
                }
        }

        private void MoveDown()
        {
            for (int i = n - 2; i >= 0; i--)
                for (int j = 0; j < n; j++)
                {
                    int index = i; // Incepem de la linia curenta
                    // Si, cat timp in jos avem valoarea 0
                    while (index < n - 1 && values[index + 1, j] == 0)
                    {
                        values[index + 1, j] = values[index, j]; // Mutam valoarea curenta in jos
                        values[index, j] = 0; // Si o stergem de pe linia pe care a fost
                        index++;
                    }
                }
        }
        private void CombineDown()
        {
            for (int i = n - 2; i >= 0; i--)
                for (int j = 0; j < n; j++)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (values[i, j] != 0 && values[i, j] == values[i + 1, j])
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        values[i + 1, j]++;
                        values[i, j] = 0;
                    }
                }
        }
    }
}
