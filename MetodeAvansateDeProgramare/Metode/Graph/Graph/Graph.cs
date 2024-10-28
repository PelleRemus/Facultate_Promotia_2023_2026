using System.Collections.Generic;
using System.IO;

namespace Graph
{
    public static class Graph
    {
        public static int n;
        public static List<Vertex> vertices = new List<Vertex>();
        public static List<Edge> edges = new List<Edge>();
        public static bool[] visited;
        public static Form1 form;

        public static void Initialize(Form1 form)
        {
            Graph.form = form;
        }

        public static void ReadFromFile(string path)
        {
            using (TextReader reader = new StreamReader(path))
            {
                string buffer = reader.ReadLine();
                n = int.Parse(buffer);

                for (int i = 0; i < n; i++)
                {
                    buffer = reader.ReadLine();
                    vertices.Add(new Vertex(i + 1, buffer));
                }

                while ((buffer = reader.ReadLine()) != null)
                {
                    edges.Add(new Edge(buffer));
                }
            }
        }

        public static void DisplayGraph()
        {
            form.listBox1.Items.Add(n.ToString());
            foreach (Vertex vertex in vertices)
            {
                form.listBox1.Items.Add(vertex.ToString());
            }
            foreach (Edge edge in edges)
            {
                form.listBox1.Items.Add(edge.ToString());
            }
        }

        // Parcurgere in adancime
        public static void DepthFirstSearch()
        {
            form.listBox1.Items.Clear();
            visited = new bool[n];
            DepthFirstSearchRecursive(vertices[0]);
        }

        public static void DepthFirstSearchRecursive(Vertex vertex)
        {
            visited[vertex.value - 1] = true;
            form.listBox1.Items.Add(vertex.value.ToString());

            foreach (Edge edge in edges)
            {
                if (edge.start == vertex && !visited[edge.end.value - 1])
                {
                    DepthFirstSearchRecursive(edge.end);
                }
                if (edge.end == vertex && !visited[edge.start.value - 1])
                {
                    DepthFirstSearchRecursive(edge.start);
                }
            }
        }

        // Parcurgere in latime
        public static void BreadthFirstSearch()
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            form.listBox1.Items.Clear();

            visited = new bool[n];
            queue.Enqueue(vertices[0]);
            visited[vertices[0].value - 1] = true;

            while (queue.Count > 0)
            {
                Vertex current = queue.Dequeue();
                form.listBox1.Items.Add(current.value.ToString());

                foreach (Edge edge in edges)
                {
                    if (edge.start == current && !visited[edge.end.value - 1])
                    {
                        queue.Enqueue(edge.end);
                        visited[edge.end.value - 1] = true;
                    }
                    if (edge.end == current && !visited[edge.start.value - 1])
                    {
                        queue.Enqueue(edge.start);
                        visited[edge.start.value - 1] = true;
                    }
                }
            }
        }
    }
}
