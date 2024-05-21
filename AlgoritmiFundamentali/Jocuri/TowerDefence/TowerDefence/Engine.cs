using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                    graphics.DrawImage(bloon.Image, bloon.Location.X, bloon.Location.Y, bloon.Size, bloon.Size);

                // Intai afisam toate tower-urile, mai putin cel selectat
                foreach (Tower tower in towers)
                    if (tower != selectedTower)
                        tower.Draw(graphics);
                // Apoi afisam doar tower-ul selectat (pentru a afisa si raza peste celelalte)
                if (selectedTower != null)
                    selectedTower.Draw(graphics);
            }
            Form1.Instance.pictureBox1.Image = bitmap;
        }

        public static Image RotateImage(Image image, float angle)
        {
            // Create a new empty bitmap to hold rotated image
            Bitmap rotated = new Bitmap(image.Width * 2, image.Height * 2);

            // Make a graphics object from the empty bitmap
            using (Graphics graphics = Graphics.FromImage(rotated))
            {
                // Put the rotation point in the center of the image
                graphics.TranslateTransform(image.Width, image.Height);
                // Rotate the image
                graphics.RotateTransform(angle);
                // Move the image back
                graphics.TranslateTransform(-image.Width, -image.Height);

                // Draw passed in image onto graphics object
                graphics.DrawImage(image, image.Width / 2, image.Height / 2, image.Width, image.Height);
            }
            return rotated;
        }

        public static bool CanPlaceSelectedTower()
        {
            Tower closest = GetClosestTower(selectedTower.Location, out float distance,
                towers.Where(t => t != selectedTower).ToList());
            // towers.Where(...) e echivalent cu
            //List<Tower> temporary = new List<Tower>();
            //foreach(Tower t in towers)
            //    if(t != selectedTower)
            //        temporary.Add(t);

            if (closest != null && distance < selectedTower.Footprint / 2 + closest.Footprint / 2)
                return false;
            return !path.IntersectsWithTower(selectedTower);
        }

        public static Tower GetClosestTower(Point point, out float min, List<Tower> towers)
        {
            // Verificam daca avem vreun tower
            if (towers.Count == 0)
            {
                min = float.MaxValue;
                return null;
            }

            // Consideram initial ca primul tower este cel mai apropiat
            Tower tower = towers[0];
            min = Distance(point, tower.Location);

            // Dupa care, pentru fiecare alt tower din lista
            for (int i = 1; i < towers.Count; i++)
            {
                // Calculam distanta
                float distance = Distance(point, towers[i].Location);
                // Si daca aceasta este mai mica decat minimul curent, stim ca am gasit un nou minim
                if (distance < min)
                {
                    min = distance;
                    tower = towers[i];
                }
            }
            return tower;
        }

        public static Bloon GetClosestBloon(Point point, out float min)
        {
            // Verificam daca avem vreun balon
            if (bloons.Count == 0)
            {
                min = float.MaxValue;
                return null;
            }

            // Consideram initial ca primul balon este cel mai apropiat
            Bloon bloon = bloons[0];
            min = Distance(point, bloon.Location);

            // Dupa care, pentru fiecare alt balon din lista
            for (int i = 1; i < bloons.Count; i++)
            {
                // Calculam distanta
                float distance = Distance(point, bloons[i].Location);
                // Si daca aceasta este mai mica decat minimul curent, stim ca am gasit un nou minim
                if (distance < min)
                {
                    min = distance;
                    bloon = bloons[i];
                }
            }
            return bloon;
        }

        public static float Distance(Point p1, Point p2)
            => (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

        public static float Angle(Point p1, Point p2)
            => (float)(Math.Atan2(p1.Y - p2.Y, p1.X - p2.X) * 180 / Math.PI);
    }
}
