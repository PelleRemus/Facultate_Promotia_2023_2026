using System.Drawing;

namespace Graph
{
    public class Edge
    {
        public Vertex start, end;
        public int cost;

        public Edge(string line)
        {
            string[] values = line.Split(' ');
            cost = int.Parse(values[2]);

            for (int i = 0; i < Graph.vertices.Count; i++)
            {
                Vertex vertex = Graph.vertices[i];
                if (vertex.value == int.Parse(values[0]))
                {
                    start = vertex;
                    start.grad++;
                }
                if (vertex.value == int.Parse(values[1]))
                {
                    end = vertex;
                    end.grad++;
                }
            }

            // Echivalent, folosind LINQ
            //start = Graph.vertices.First(vertex => vertex.value == int.Parse(values[0]));
            //end = Graph.vertices.First(vertex => vertex.value == int.Parse(values[1]));
        }

        public void Draw()
        {
            Graph.graphics.DrawLine(new Pen(Color.Black, 3), start.location, end.location);

            float x = (float)(start.location.X + end.location.X) / 2;
            float y = (float)(start.location.Y + end.location.Y) / 2;
            Graph.graphics.DrawString(cost.ToString(), new Font("Arial", 24, FontStyle.Bold),
                new SolidBrush(Color.White), x - 12, y - 12);
        }

        public override string ToString()
        {
            return $"{start.value} {end.value}";
        }
    }
}
