using System.Drawing;

namespace TowerDefence
{
    public abstract class Tower
    {
        public Point Location { get; set; }
        public Image Image { get; set; }
        public int Footprint { get; set; }
        public int ImageSize { get; set; }
        public int Range { get; set; }
        public bool IsPlaced { get; set; }

        public Tower(Point location, Image image, int footprint, int imageSize, int range)
        {
            Location = location;
            Image = image;
            Footprint = footprint;
            ImageSize = imageSize;
            Range = range;
            IsPlaced = false;
        }

        public void Draw(Graphics graphics)
        {
            if (Engine.selectedTower != null && Engine.selectedTower == this)
            {
                // Decidem culoarea razei, este rosie daca nu putem plasa tower-ul
                Color rangeColor = Color.FromArgb(100, Color.White);
                if (!Engine.CanPlaceSelectedTower())
                    rangeColor = Color.FromArgb(100, Color.Red);

                // Intai afisam raza tower-ului selectat
                graphics.FillEllipse(new SolidBrush(rangeColor),
                    Location.X - Range, Location.Y - Range, Range * 2, Range * 2);
            }

            // Calculam unghiul la care trebuie rotit tower-ul: orientat spre cel mai apropiat balon
            Bloon closest = Engine.GetClosestBloon(Location, out float min);
            float angle = 90;
            if (IsPlaced && closest != null && min < Range)
            {
                angle = Engine.Angle(Location, new Point(closest.Location.X + closest.Size / 2,
                    closest.Location.Y + closest.Size / 2));
            }

            // Afisam tower-ul cu imaginea sa
            // Pentru ca locatia tower-ului reprezinta mijlocul sau, pentru a ajunge la coltul din stanga sus,
            // scadem din locatie jumatate din dimensiunea imaginii tower-ului
            graphics.DrawImage(Engine.RotateImage(Image, angle - 90), Location.X - ImageSize, Location.Y - ImageSize,
                ImageSize * 2, ImageSize * 2);
            // Decomentam daca dorim sa vedem footprint-ul
            /*graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.Black)),
                Location.X - Footprint / 2, Location.Y - Footprint / 2,
                Footprint, Footprint);*/
        }
    }
}
