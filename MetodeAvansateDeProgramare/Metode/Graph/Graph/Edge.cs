using System.Linq;

namespace Graph
{
    public class Edge
    {
        public Vertex start, end;

        public Edge(string line)
        {
            string[] values = line.Split(' ');

            for (int i = 0; i < Graph.vertices.Count; i++)
            {
                Vertex vertex = Graph.vertices[i];
                if (vertex.value == int.Parse(values[0]))
                {
                    start = vertex;
                }
                if (vertex.value == int.Parse(values[1]))
                {
                    end = vertex;
                }
            }

            // Echivalent, folosind LINQ
            //start = Graph.vertices.First(vertex => vertex.value == int.Parse(values[0]));
            //end = Graph.vertices.First(vertex => vertex.value == int.Parse(values[1]));
        }

        public override string ToString()
        {
            return $"{start.value} {end.value}";
        }
    }
}
