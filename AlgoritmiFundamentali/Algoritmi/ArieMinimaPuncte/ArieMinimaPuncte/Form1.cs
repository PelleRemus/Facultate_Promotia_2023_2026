using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArieMinimaPuncte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        Graphics graphics;
        Bitmap bitmap;
        List<Point> points = new List<Point>();

        private void button1_Click(object sender, EventArgs e)
        {
            // Cand generam puncte, putem calcula aria triungiului minim si a poligonului
            button3.Enabled = button4.Enabled = true;
            for (int i = 0; i < 10; i++)
            {
                // Generam 10 puncte la intamplare
                int x = random.Next(pictureBox1.Width);
                int y = random.Next(pictureBox1.Height);
                points.Add(new Point(x, y));
            }
            DisplayPoints();
        }

        void DisplayPoints()
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            for (int i = 0; i < points.Count; i++)
            {
                // Pentru a afisa punctele, desenam cercuri de dimensiunea 11 pentru a le observa usor
                graphics.FillEllipse(new SolidBrush(Color.Black),
                    points[i].X - 5, points[i].Y - 5, 11, 11);
            }

            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            points.Clear();
            DisplayPoints();
            // Cand stergem toate punctele din lista,
            // nu mai putem da click pe butoanele care calculeaza ariile
            button3.Enabled = button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float min = float.MaxValue;
            Point[] minTriangle = new Point[3];

            // Parcurgem astfel incat sa generam toate combinarile posibile
            for (int i = 0; i < points.Count - 2; i++)
                for (int j = i + 1; j < points.Count - 1; j++)
                    for (int k = j + 1; k < points.Count; k++)
                    {
                        // Calculam aria si verificam daca am gasit un nou triunghi minim
                        float area = Area(points[i], points[j], points[k]);
                        if (area < min)
                        {
                            min = area;
                            minTriangle[0] = points[i];
                            minTriangle[1] = points[j];
                            minTriangle[2] = points[k];
                        }
                    }
            // Afisam aria minima
            textBox1.Text = min.ToString();
            // Si afisam triunghiul cu aceasta arie
            graphics.FillPolygon(new SolidBrush(Color.ForestGreen), minTriangle);
            pictureBox1.Image = bitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point[] pointsArray = points.ToArray();
            if (checkBox1.Checked)
                Shuffle(pointsArray);
            textBox1.Text = Area(pointsArray).ToString();

            DisplayPoints();
            graphics.FillPolygon(new SolidBrush(Color.ForestGreen), pointsArray);
            pictureBox1.Image = bitmap;
        }

        void Shuffle(Point[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                int j = random.Next(v.Length);
                Point aux = v[i];
                v[i] = v[j];
                v[j] = aux;
            }
        }

        // Formula pentru aria triunghiului bazata pe cele 3 coordonate ale punctelor
        float Area(Point A, Point B, Point C)
        {
            return Math.Abs(A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y)
                + C.X * (A.Y - B.Y)) * 0.5F;
        }

        // Formula pentru aria unui poligon
        float Area(Point[] p)
        {
            float s = 0;
            for (int i = 0; i < p.Length - 1; i++)
                s += 0.5f * (p[i].X * p[i + 1].Y - p[i + 1].X * p[i].Y);
            s += 0.5f * (p[p.Length - 1].X * p[0].Y - p[0].X * p[p.Length - 1].Y);
            return Math.Abs(s);
        }
    }
}
