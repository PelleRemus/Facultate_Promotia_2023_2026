using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Graph
{
    public static class Graph
    {
        public static List<Vertex> vertices = new List<Vertex>();
        public static List<Edge> edges = new List<Edge>();
        public static int[,] matrix;
        public static int n;

        public static Form1 form;
        public static Bitmap bitmap;
        public static Graphics graphics;

        public static void Init(Form1 f)
        {
            form = f;
        }

        public static void ReadFromFile(string path)
        {
            using (var reader = new StreamReader(path))
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
            ConvertToMatrix();
        }

        public static void ConvertToMatrix()
        {
            matrix = new int[n, n];
            foreach (Edge edge in edges)
            {
                int i = edge.start.value - 1;
                int j = edge.end.value - 1;
                matrix[i, j] = 1;
                matrix[j, i] = 1;
            }
        }

        public static void DrawGraph()
        {
            bitmap = new Bitmap(form.pictureBox1.Width, form.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

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

        public static void DisplayGraph()
        {
            form.listBox1.Items.Clear();
            form.listBox1.Items.Add(n.ToString());
            foreach (Vertex vertex in vertices)
            {
                form.listBox1.Items.Add(vertex.ToString());
            }
            foreach (Edge edge in edges)
            {
                form.listBox1.Items.Add(edge.ToString());
            }

            form.listBox1.Items.Add("");
            for (int i = 0; i < n; i++)
            {
                string s = "";
                for (int j = 0; j < n; j++)
                {
                    s = $"{s}{matrix[i, j]} ";
                }
                form.listBox1.Items.Add(s);
            }
        }
    }
}
