using System.Drawing;
using System.Linq;

namespace Graph
{
    public class Edge
    {
        public Vertex start, end;

        public Edge(string buffer)
        {
            string[] line = buffer.Split(' ');
            int startValue = int.Parse(line[0]);
            int endValue = int.Parse(line[1]);

            start = Graph.vertices.First(v => v.value == startValue);
            end = Graph.vertices.First(v => v.value == endValue);
        }

        public void Draw()
        {
            Graph.graphics.DrawLine(new Pen(Color.Black, 3), start.position, end.position);
        }

        public override string ToString()
        {
            return $"{start.value} {end.value}";
        }
    }
}
