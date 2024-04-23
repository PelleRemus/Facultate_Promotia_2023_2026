using System.Collections.Generic;
using System.Drawing;
using TowerDefence.BloonTypes;

namespace TowerDefence
{
    public static class Engine
    {
        public static Bitmap bitmap;
        public static Path path;
        public static List<Bloon> bloons;
        public static List<Tower> towers;
        public static Tower selectedTower;
        public static int time = 0;     // Tine minte de cate ori a fost apelat Tick-ul din timer

        public static void Initialize()
        {
            // Punctele care reprezinta marginile path-ului
            List<Point> points = new List<Point>
            {
                new Point(0, Form1.Instance.Height / 2),
                new Point(Form1.Instance.Width / 5, Form1.Instance.Height / 2),
                new Point(Form1.Instance.Width / 5, Form1.Instance.Height / 5),
                new Point(Form1.Instance.Width / 3, Form1.Instance.Height / 5),
                new Point(Form1.Instance.Width / 3, 7 * Form1.Instance.Height / 10),
                new Point(Form1.Instance.Width / 7, 7 * Form1.Instance.Height / 10),
                new Point(Form1.Instance.Width / 7, 9 * Form1.Instance.Height / 10),
                new Point(7 * Form1.Instance.Width / 10, 9 * Form1.Instance.Height / 10),
                new Point(7 * Form1.Instance.Width / 10, 2 * Form1.Instance.Height / 3),
                new Point(Form1.Instance.Width / 2, 2 * Form1.Instance.Height / 3),
                new Point(Form1.Instance.Width / 2, 2 * Form1.Instance.Height / 5),
                new Point(7 * Form1.Instance.Width / 10, 2 * Form1.Instance.Height / 5),
                new Point(7 * Form1.Instance.Width / 10, Form1.Instance.Height / 10),
                new Point(2 * Form1.Instance.Width / 5, Form1.Instance.Height / 10),
                new Point(2 * Form1.Instance.Width / 5, 0),
            };
            path = new Path(points);
            towers = new List<Tower>();

            // Adaugam baloanele de test in lista de baloane
            bloons = new List<Bloon>();
            bloons.Add(new RedBloon(0));
            bloons.Add(new BlueBloon(15));
            bloons.Add(new GreenBloon(30));
            bloons.Add(new YellowBloon(45));
            bloons.Add(new BlackBloon(60));
            bloons.Add(new WhiteBloon(75));
        }

        public static void Draw()
        {
            // Pentru a nu da de eroarea OutOfMemory, stergem din memorie imaginea precedenta
            if (bitmap != null)
                bitmap.Dispose();

            // Imaginea pe care vrem sa o afisam 
            bitmap = new Bitmap(Form1.Instance.Width, Form1.Instance.Height);
            // Folosim cuvantul cheie 'using' tot pentru eliberare de memorie
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.ForestGreen); // Afisam culoarea de fundal
                // Afisam toate dreptunghiurile care formeaza path-ul
                foreach (Rectangle rectangle in path.Bounds)
                    graphics.FillRectangle(new SolidBrush(Color.DarkGray), rectangle);

                // Afisam toate baloanele la locatia si cu dimensiunile fiecaruia
                foreach (Bloon bloon in bloons)
                    graphics.FillRectangle(new SolidBrush(bloon.Color), bloon.Location.X, bloon.Location.Y,
                        bloon.Size, bloon.Size);

                // Intai afisam toate tower-urile
                foreach (Tower tower in towers)
                {
                    // Afisam tower-ul cu culoarea sa
                    // Pentru ca locatia tower-ului reprezinta mijlocul sau, pentru a ajunge la coltul din stanga sus,
                    // scadem din locatie jumatate din dimensiunea imaginii tower-ului
                    graphics.FillEllipse(new SolidBrush(tower.Color),
                        tower.Location.X - tower.ImageSize / 2, tower.Location.Y - tower.ImageSize / 2,
                        tower.ImageSize, tower.ImageSize);
                    // Temporar, afisam footprint-ul, ne va ajuta la implementare
                    graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.Black)),
                        tower.Location.X - tower.Footprint / 2, tower.Location.Y - tower.Footprint / 2,
                        tower.Footprint, tower.Footprint);
                }
                // Apoi afisam din nou tower-ul selectat, impreuna cu raza sa
                if (selectedTower != null)
                {
                    // Intai afisam raza tower-ului selectat
                    graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.White)),
                        selectedTower.Location.X - selectedTower.Range, selectedTower.Location.Y - selectedTower.Range,
                        selectedTower.Range * 2, selectedTower.Range * 2);
                    // Apoi afisam tower-ul selectat cu culoarea sa
                    graphics.FillEllipse(new SolidBrush(selectedTower.Color),
                        selectedTower.Location.X - selectedTower.ImageSize / 2, selectedTower.Location.Y - selectedTower.ImageSize / 2,
                        selectedTower.ImageSize, selectedTower.ImageSize);
                    // Temporar, afisam footprint-ul
                    graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.Black)),
                        selectedTower.Location.X - selectedTower.Footprint / 2, selectedTower.Location.Y - selectedTower.Footprint / 2,
                        selectedTower.Footprint, selectedTower.Footprint);
                }
            }
            Form1.Instance.pictureBox1.Image = bitmap;
        }
    }
}
