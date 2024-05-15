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
                // Intai afisam raza tower-ului selectat
                graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.White)),
                    Location.X - Range, Location.Y - Range, Range * 2, Range * 2);
            }
            // Afisam tower-ul cu imaginea sa
            // Pentru ca locatia tower-ului reprezinta mijlocul sau, pentru a ajunge la coltul din stanga sus,
            // scadem din locatie jumatate din dimensiunea imaginii tower-ului
            graphics.DrawImage(Image, Location.X - ImageSize / 2, Location.Y - ImageSize / 2,
                ImageSize, ImageSize);
            // Decomentam daca dorim sa vedem footprint-ul
            /*graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.Black)),
                Location.X - Footprint / 2, Location.Y - Footprint / 2,
                Footprint, Footprint);*/
        }
    }
}
