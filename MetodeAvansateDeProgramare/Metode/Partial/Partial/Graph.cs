using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    // Eercitiul 2
    public static class Graph
    {
        public static int n;
        public static int[,] adiacenta;
        public static List<Vertex> vertices;
        public static List<Edge> edges;

        public static void Initialize(int[,] adiacenta)
        {
            n = adiacenta.GetLength(0);
            Graph.adiacenta = adiacenta;

            for (int i = 0; i < n; i++)
            {
                vertices.Add(new Vertex(i + 1));
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (adiacenta[i, j] != 0)
                    {
                        Vertex start = vertices[i];
                        Vertex end = vertices[j];
                        edges.Add(new Edge(start, end));
                    }
                }
            }
        }
    }
}
