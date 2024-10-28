using System.Drawing;

namespace Graph
{
    public class Vertex
    {
        public int value;
        public Point position;

        public Vertex(int value, string buffer)
        {
            this.value = value;
            string[] line = buffer.Split(' ');
            int x = int.Parse(line[0]);
            int y = int.Parse(line[1]);
            position = new Point(x, y);
        }

        public void Draw()
        {
            Graph.graphics.FillEllipse(new SolidBrush(Color.White),
                position.X - 15, position.Y - 15, 31, 31);
            Graph.graphics.DrawEllipse(new Pen(Color.Black, 3),
                position.X - 15, position.Y - 15, 31, 31);
            Graph.graphics.DrawString(value.ToString(), new Font("Arial", 16, FontStyle.Bold),
                new SolidBrush(Color.Black), position.X - 12, position.Y - 12);
        }

        public override string ToString()
        {
            return $"{position.X} {position.Y}";
        }
    }
}
