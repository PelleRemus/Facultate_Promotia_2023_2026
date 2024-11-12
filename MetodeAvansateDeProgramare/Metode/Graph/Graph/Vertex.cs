using System.Drawing;

namespace Graph
{
    public class Vertex
    {
        public int value;
        public int grad;
        public Point location;
        public Color color = Color.White;

        public Vertex(int value, string line)
        {
            this.value = value;
            this.grad = 0;
            string[] coordinates = line.Split(' ');
            location = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
        }

        public void Draw()
        {
            Graph.graphics.FillEllipse(new SolidBrush(color), location.X - 20, location.Y - 20, 41, 41);
            Graph.graphics.DrawEllipse(new Pen(Color.Black, 3), location.X - 20, location.Y - 20, 41, 41);
            Graph.graphics.DrawString(value.ToString(), new Font("Arial", 24), new SolidBrush(Color.Black),
                location.X - 20, location.Y - 15);
        }

        public override string ToString()
        {
            return $"{location.X} {location.Y}";
        }
    }
}
