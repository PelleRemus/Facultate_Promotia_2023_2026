using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Graph
{
    public static partial class Graph
    {
        public static int n, index;
        public static List<Vertex> vertices = new List<Vertex>();
        public static List<Edge> edges = new List<Edge>();
        public static int[,] adiacenta;
        public static Color[] colors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.YellowGreen, Color.Green, Color.Blue, Color.Indigo, Color.BlueViolet };
        public static bool[] visited;

        public static Form1 form;
        public static Graphics graphics;
        public static Bitmap bitmap;

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

                adiacenta = new int[n, n];
                while ((buffer = reader.ReadLine()) != null)
                {
                    edges.Add(new Edge(buffer));
                    string[] values = buffer.Split(' ');
                    int i = int.Parse(values[0]) - 1;
                    int j = int.Parse(values[1]) - 1;
                    adiacenta[i, j] = 1;
                    adiacenta[j, i] = 1;
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

        public static void DrawGraph()
        {
            bitmap = new Bitmap(form.pictureBox1.Width, form.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.CornflowerBlue);
            foreach (Edge edge in edges)
            {
                edge.Draw();
            }
            foreach (Vertex vertex in vertices)
            {
                vertex.Draw();
            }

            form.pictureBox1.Image = bitmap;
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

        // Colorarea hartii
        public static void ColorMap()
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            visited = new bool[n];
            queue.Enqueue(vertices[0]);
            visited[0] = true;

            while (queue.Count > 0)
            {
                Vertex current = queue.Dequeue();
                bool[] colorTaken = new bool[colors.Length];

                foreach (Edge edge in edges)
                {
                    if (edge.start == current)
                    {
                        if (edge.end.color != Color.White)
                        {
                            int index = Array.IndexOf(colors, edge.end.color);
                            colorTaken[index] = true;
                        }
                        if (!visited[edge.end.value - 1])
                        {
                            queue.Enqueue(edge.end);
                            visited[edge.end.value - 1] = true;
                        }
                    }
                    if (edge.end == current)
                    {
                        if (edge.start.color != Color.White)
                        {
                            int index = Array.IndexOf(colors, edge.start.color);
                            colorTaken[index] = true;
                        }
                        if (!visited[edge.start.value - 1])
                        {
                            queue.Enqueue(edge.start);
                            visited[edge.start.value - 1] = true;
                        }
                    }
                }

                for (int i = 0; i < colors.Length; i++)
                {
                    if (!colorTaken[i])
                    {
                        current.color = colors[i];
                        break;
                    }
                }
            }
        }

        // Componente tare conexe
        static List<List<Vertex>> components = new List<List<Vertex>>();

        public static void ComponenteTareConexe()
        {
            form.listBox1.Items.Clear();
            visited = new bool[n];

            foreach (Vertex vertex in vertices)
            {
                if (!visited[vertex.value - 1])
                {
                    components.Add(new List<Vertex>());
                    ComponenteTareConexeRecursiv(vertex);
                }
            }

            foreach (List<Vertex> component in components)
            {
                string line = "";
                foreach (Vertex vertex in component)
                {
                    line = $"{line} {vertex.value}";
                }
                form.listBox1.Items.Add(line);
            }
        }

        public static void ComponenteTareConexeRecursiv(Vertex vertex)
        {
            List<Vertex> currentComponent = components.Last();
            visited[vertex.value - 1] = true;
            currentComponent.Add(vertex);

            foreach (Edge edge in edges)
            {
                if (edge.start == vertex && !visited[edge.end.value - 1])
                {
                    ComponenteTareConexeRecursiv(edge.end);
                }
                if (edge.end == vertex && !visited[edge.start.value - 1])
                {
                    ComponenteTareConexeRecursiv(edge.start);
                }
            }
        }

        // Eulerian
        public static void EsteEulerian()
        {
            if (!EsteConectat())
            {
                form.listBox1.Items.Add("Graful nu este conectat");
                form.listBox1.Items.Add("Graful nu este Eulerian");
                return;
            }
            if (NoduriCuGradImpar() > 2)
            {
                form.listBox1.Items.Add("Graful nu este Eulerian");
                return;
            }
            form.listBox1.Items.Add("Graful este Eulerian");
        }

        public static bool EsteConectat()
        {
            foreach (Vertex vertex in vertices)
            {
                if (vertex.grad > 0)
                {
                    DepthFirstSearchRecursive(vertex);
                    break;
                }
            }

            foreach (Vertex vertex in vertices)
            {
                if (vertex.grad > 0 && !visited[vertex.value - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static int NoduriCuGradImpar()
        {
            int count = 0;
            foreach (Vertex vertex in vertices)
            {
                if (vertex.grad % 2 != 0)
                {
                    count++;
                }
            }
            return count;
        }

        // Hamiltonian
        public static List<List<Vertex>> drumuriHamiltoniene = new List<List<Vertex>>();
        public static void EsteHamiltonian()
        {
            index = 0;
            visited = new bool[n];
            int[] solution = new int[n];
            Backtracking(solution, 0);
            for (int i = 0; i < n; i++)
            {
                drumuriHamiltoniene[index][i].color = colors[i];
            }
        }

        public static void Backtracking(int[] solution, int k) // Permutari
        {
            if (k >= n)
            {
                if (VerificareDrum(solution))
                {
                    List<Vertex> drumHamiltonian = new List<Vertex>();
                    for (int i = 0; i < n; i++)
                    {
                        drumHamiltonian.Add(vertices[solution[i]]);
                    }
                    drumuriHamiltoniene.Add(drumHamiltonian);
                }
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    solution[k] = i;
                    Backtracking(solution, k + 1);
                    visited[i] = false;
                }
            }
        }

        public static bool VerificareDrum(int[] solution)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (adiacenta[solution[i], solution[i + 1]] == 0)
                {
                    return false;
                }
            }
            // Decomentati pentru ciclu hamiltonian
            // if (adiacenta[solution[0], solution[n - 1]] == 0)
            //     return false;
            return true;
        }
    }
}
