using System.Drawing;

namespace Graph
{
    public class Vertex
    {
        public int value;
        public Point location;

        public Vertex(int value, string line)
        {
            this.value = value;
            string[] coordinates = line.Split(' ');
            location = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
        }

        public override string ToString()
        {
            return $"{location.X} {location.Y}";
        }
    }
}
