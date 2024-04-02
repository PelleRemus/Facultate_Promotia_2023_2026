using System;
using System.Drawing;
using System.Windows.Forms;

namespace The_2048_Game
{
    public class Tile
    {
        static Color emptySpace = Color.FromArgb(195, 188, 176);
        static Color[] colors = new Color[]
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
        public static int size; // Size-ul picturebox-urilor

        public int Value { get; set; }
        public PictureBox PictureBox { get; set; }

        public Tile(Panel panel, int size, int i, int j)
        {
            Bitmap bitmap = new Bitmap(size, size);         // Facem o imagine de dimensiunile picturebox-urilor
            Graphics graphics = Graphics.FromImage(bitmap); // Graphics va desena in interiorul imaginii nou create
            graphics.Clear(emptySpace);                     // Metoda Clear "sterge" toata imaginea si lasa o singura culoare in schimb

            Tile.size = size;
            PictureBox = new PictureBox();
            PictureBox.Parent = panel;
            PictureBox.Image = bitmap;          // In locul culorii de fundal, afisam acum in schimb imaginea
            PictureBox.Size = new Size(size, size);
            PictureBox.Location = new Point(10 + j * (size + 10), 10 + i * (size + 10));
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
        }

        public void Render() // Metoda pentru afisarea modificarilor din tile
        {
            // Pentru fiecare picturebox, facem o noua imagine. Altfel, am vedea pentru fiecare ultima imagine creata
            // (Imaginea este de tip referinta, spre deosebire de int sau alte tipuri de date primitive. Sugerez sa vedeti de ce se manifesta asa)
            Bitmap bitmap = new Bitmap(size, size);
            Graphics graphics = Graphics.FromImage(bitmap);

            if (Value == 0)
            {
                graphics.Clear(emptySpace); // Daca un tile are inapoi valoarea 0, afisam inapoi culoarea default
                PictureBox.Image = bitmap;
                return;
            }

            // Indexul in vectorul de culori incepe de la 0, si este cu 1 mai mic decat puterea lui 2 a valorii afisate
            int index = Value - 1;
            string displayValue = Math.Pow(2, Value).ToString(); // Valoarea ce trebuie afisata este 2 la puterea valorii din matrice
            int nrOfCharacters = Math.Max(displayValue.Length, 2);

            // Dimensiunea caracterelor in fontul Courier este aproximativ aceeasi si in pixeli,
            // deci putem lua dimensiunea tile-ului si sa o impartim la numarul de caractere
            Font font = new Font("Courier", (float)(size - 10) / nrOfCharacters, FontStyle.Bold);

            // "a" ? "b" : "c" se numeste operator tertiar. Codul de mai jos este echivalent cu:
            // if (colors[index].GetBrightness() < 0.8)
            //      fontColor = Color.White;
            // else
            //      fontColor = Color.FromArgb(120, 110, 100);
            Color fontColor = colors[index].GetBrightness() < 0.8 ? Color.White : Color.FromArgb(120, 110, 100);

            // Putem formata stringul pe aria pe care este afisat, deci daca luam intreg size-ul tile-ului, putem folosi aliniamentul Center
            var format = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            graphics.Clear(colors[index]);
            graphics.DrawString(displayValue, font, new SolidBrush(fontColor), new Rectangle(0, 0, size, size), format);
            PictureBox.Image = bitmap;
        }
    }
}
