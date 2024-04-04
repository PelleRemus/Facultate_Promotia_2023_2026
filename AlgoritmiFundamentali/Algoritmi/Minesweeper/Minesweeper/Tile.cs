using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Tile
    {
        // Constantele sunt automat variabile statice, si apartin clasei curente
        // Adica le apelam direct cu numele clasei, in loc sa apelam cu un obiect al clasei
        // Adica Tile.size (este valabil si pentru variabilele statice)
        // Vrem sa avem acelasi size pentru toate tile-urile, de aceea vrem sa fie o variabila statica
        // Si vrem sa nu il putem modifica, de aceea este o constanta
        public const int size = 50;
        public int Line { get; set; }
        public int Column { get; set; }
        public int Value { get; set; } // Valoarea afisata pe buton cand se descopera tile-ul
        public bool IsMine { get; set; }
        // Prin variabila IsFlagged, putem spune jocului ca stim ca aici se afla o mina
        // Doar cand toate minele sunt flagged (si niciun alt tile), jocul este castigat
        public bool IsFlagged { get; set; }
        public bool IsUncovered { get; set; }
        public Button Button { get; set; } // Variabila pentru a putea afisa vizual informatia tile-ului

        public Tile(int i, int j)
        {
            Line = i;
            Column = j;
            Button = new Button();

            // Initializam butonul ca si in orice alt proiect cu o matrice vizuala
            Button.Parent = Form1.Instance.panel1;
            Button.BackColor = Color.DarkGray;
            Button.Size = new Size(size, size);
            Button.Location = new Point(j * size, i * size);
            // Putem schimba fontul pentru a vedea mai bine textul, si Margin pentru a schimba grosimea bordurii butonului
            Button.Font = new Font("Arial", size / 2, FontStyle.Bold);
            Button.Margin = Padding.Empty;

            // Adaugam metoda Button_Click la evenimentul Click al butonului
            // (Observati ca nu apelam metoda, ii scriem doar numele, si folosim "+=" in loc de egal)
            Button.Click += Button_Click;
        }

        public void ResetTile()
        {
            // Aducem proprietatile la valorile originale
            Value = 0;
            IsMine = false;
            IsUncovered = false;
            IsFlagged = false;
            Button.BackColor = Color.DarkGray;
            Button.Text = string.Empty;
        }

        // In aceasta metoda, ar trebui sa decidem ce facem la diferitele click-uri
        // La click stanga, ar trebui sa apelam DepthTraversal, la click dreapta ar trebui sa facem tile-ul flagged
        private void Button_Click(object sender, System.EventArgs e)
        {
            Engine.DepthTraversal(Line, Column);
        }

        // In aceasta metoda, spunem ce se intampla cand traversam acest tile
        public void Traverse()
        {
            // Descoperim tile-ul si indicam asta cu culoarea de fundal mai deschisa
            IsUncovered = true;
            Button.BackColor = Color.LightGray;

            // Afisam valoarea tile-ului, dar numai daca este diferita de 0 (0 reprezinta o "camera goala")
            if (Value != 0)
                Button.Text = Value.ToString();
            // Cu toate acestea, daca este mina, valoarea este inlocuita cu un "X" rosu
            if (IsMine)
            {
                Button.ForeColor = Color.Crimson;
                Button.Text = "X";
            }
        }
    }
}
