using System.Drawing;

namespace TowerDefence
{
    public abstract class Tower
    {
        public Point Location { get; set; }
        public Color Color { get; set; }
        public int Footprint { get; set; }
        public int ImageSize { get; set; }
        public int Range { get; set; }
        public bool IsPlaced { get; set; }

        public Tower(Point location, Color color, int footprint, int imageSize,
            int range)
        {
            Location = location;
            Color = color;
            Footprint = footprint;
            ImageSize = imageSize;
            Range = range;
            IsPlaced = false;
        }
    }
}
