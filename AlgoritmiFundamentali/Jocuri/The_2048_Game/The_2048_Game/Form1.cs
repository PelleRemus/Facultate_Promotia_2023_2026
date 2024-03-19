using System;
using System.Drawing;
using System.Windows.Forms;

namespace The_2048_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 4;
        int[,] values;
        PictureBox[,] matrix;
        Random random = new Random();
        Color emptySpace = Color.FromArgb(195, 188, 176);
        Color[] colors = new Color[]
        {
            Color.FromArgb(237, 228, 219),
            Color.FromArgb(237, 224, 201),
            Color.FromArgb(244, 177, 122),
            Color.FromArgb(247, 150, 99),
            Color.FromArgb(246, 125, 98),
            Color.FromArgb(246, 94, 57),
            Color.FromArgb(237, 206, 115),
            Color.FromArgb(237, 202, 100),
            Color.FromArgb(237, 198, 81),
            Color.FromArgb(238, 199, 68),
            Color.FromArgb(236, 194, 48),
            Color.FromArgb(255, 32, 33),
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            matrix = new PictureBox[n, n];
            int size = (panel1.Width - 10) / n - 10;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    PictureBox picturebox = new PictureBox();
                    picturebox.Parent = panel1;
                    picturebox.BackColor = emptySpace;
                    picturebox.Size = new Size(size, size);
                    picturebox.Location = new Point(10 + j * (size + 10), 10 + i * (size + 10));

                    matrix[i, j] = picturebox;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            values = new int[n, n];
            GenerateNewTile();
            GenerateNewTile();
            Render();
        }

        private void GenerateNewTile()
        {
            int i, j;
            do
            {
                i = random.Next(n);
                j = random.Next(n);
            } while (values[i, j] != 0);

            values[i, j] = 1;
        }

        private void Render()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (values[i, j] == 0)
                    {
                        matrix[i, j].BackColor = emptySpace;
                        continue;
                    }

                    int index = values[i, j] - 1;
                    matrix[i, j].BackColor = colors[index];
                }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (values == null)
                return;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                MoveLeft();
                GenerateNewTile();
            }
            Render();
        }

        private void MoveLeft()
        {
            for (int i = 0; i < n; i++)
                for (int j = 1; j < n; j++)
                {
                    int index = j;
                    while (index > 0 && values[i, index - 1] == 0)
                    {
                        values[i, index - 1] = values[i, index];
                        values[i, index] = 0;
                        index--;
                    }
                }
        }
    }
}
