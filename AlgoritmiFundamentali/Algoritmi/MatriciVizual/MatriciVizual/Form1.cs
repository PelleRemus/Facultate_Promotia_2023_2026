using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatriciVizual
{
    public partial class Form1 : Form
    {
        Color[] colors = new Color[]
        {
            Color.White,
            Color.Red,
            Color.OrangeRed,
            Color.Orange,
            Color.Yellow,
            Color.YellowGreen,
            Color.Green,
            Color.Blue,
            Color.Indigo,
            Color.BlueViolet
        };
        Point colorsStartLocation = new Point(737, 683);
        Button[] colorButtons;
        PictureBox[,] matrix = new PictureBox[0, 0];

        public Form1()
        {
            InitializeComponent();
            colorButtons = new Button[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                Button button = new Button();
                button.Parent = this;

                button.Size = new Size(50, 50);
                button.Location = new Point(colorsStartLocation.X + i * 55, colorsStartLocation.Y);
                button.BackColor = colors[i];

                button.Click += ColorButton_Click;
                colorButtons[i] = button;
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                int index = Array.IndexOf(colorButtons, sender as Button);
                colors[index] = colorPicker.Color;
                (sender as Button).BackColor = colorPicker.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j].Parent = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j].Parent = null;

            string[][] textBoxText = new string[textBox1.Lines.Length][];
            for (int i = 0; i < textBox1.Lines.Length; i++)
                textBoxText[i] = textBox1.Lines[i].Split(' ');

            int n = textBoxText.Length;
            int m = textBoxText[0].Length;
            matrix = new PictureBox[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = new PictureBox();
                    matrix[i, j].Parent = pictureBox1;

                    int sizeX = pictureBox1.Width / m, sizeY = pictureBox1.Height / n;
                    matrix[i, j].Size = new Size(sizeX, sizeY);
                    matrix[i, j].Location = new Point(j * sizeX, i * sizeY);

                    int index = int.Parse(textBoxText[i][j]) % colors.Length;
                    matrix[i, j].BackColor = colors[index];
                }
        }

        private void AddMatrixToTextBox(int[,] matrix, int n, int m)
        {
            textBox1.Text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                    textBox1.Text += matrix[i, j] + " ";
                textBox1.Text += matrix[i, m - 1];
                if (i < n - 1)
                    textBox1.Text += Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = 9;
            int[,] matrix = new int[n, n];

            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i < n / 2 && j < n / 2)
                        matrix[i, j] = 1;
                    if (i < n / 2 && j > n / 2)
                        matrix[i, j] = 2;
                    if (i > n / 2 && j < n / 2)
                        matrix[i, j] = 3;
                    if (i > n / 2 && j > n / 2)
                        matrix[i, j] = 4;
                }*/

            // Mai eficient.
            for (int i = 0; i < n / 2; i++)
                for (int j = 0; j < n / 2; j++)
                {
                    matrix[i, j] = 1;
                    matrix[i, j + n / 2 + 1] = 2;
                    matrix[i + n / 2 + 1, j] = 3;
                    matrix[i + n / 2 + 1, j + n / 2 + 1] = 4;
                }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = 15;
            int[,] matrix = new int[n, n];

            // Cele doua diagonale.
            /*for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1;
                matrix[i, n - i - 1] = 1;
            }*/

            // Elementele de deasupra sau de dedesubtul diagonalelor.
            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    //if (i < j)
                    //    matrix[i, j] = 1;
                    //else if (i > j)
                    //    matrix[i, j] = 5;
                    if (i < n - j - 1)
                        matrix[i, j] = 1;
                    else if (i > n - j - 1)
                        matrix[i, j] = 5;
                }*/

            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i < j && i + j < n - 1)
                        matrix[i, j] = 1;
                    if (i < j && i + j > n - 1)
                        matrix[i, j] = 2;
                    if (i > j && i + j < n - 1)
                        matrix[i, j] = 3;
                    if (i > j && i + j > n - 1)
                        matrix[i, j] = 4;
                }*/

            // Mai eficient.
            for (int i = 0; i < n / 2; i++)
                for (int j = i + 1; j < n - i - 1; j++)
                {
                    matrix[i, j] = 1;
                    matrix[j, n - i - 1] = 2;
                    matrix[n - i - 1, j] = 3;
                    matrix[j, i] = 4;
                }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = 9;
            int[,] matrix = new int[n, n];

            // Parcurgerea chenarului exterior.
            /*for (int j = 0; j < n - 1; j++)
                matrix[0, j] = 1;
            for (int i = 0; i < n - 1; i++)
                matrix[i, n - 1] = 2;
            for (int j = n - 1; j > 0; j--)
                matrix[n - 1, j] = 3;
            for (int i = n - 1; i > 0; i--)
                matrix[i, 0] = 4;*/

            // Parcurgerea in spirala.
            int count = 1;
            for (int k = 0; k < (n + 1) / 2; k++)
            {
                for (int j = k; j < n - k - 1; j++)
                    matrix[k, j] = count;
                count++;
                for (int i = k; i < n - k - 1; i++)
                    matrix[i, n - k - 1] = count;
                count++;
                for (int j = n - k - 1; j > k; j--)
                    matrix[n - k - 1, j] = count;
                count++;
                for (int i = n - k - 1; i > k; i--)
                    matrix[i, k] = count;
                count++;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = 10;
            int[] array = { 1, 0, 1, 3, 1, 2, 5, 3, 2, 5 };
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i < array[j])
                        matrix[n - i - 1, j] = 1;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    int left = j, right = j;

                    while (matrix[i, left] == 0 && left > 0)
                        left--;
                    while (matrix[i, right] == 0 && right < n - 1)
                        right++;

                    if (matrix[i, j] == 0 && matrix[i, left] != 0 && matrix[i, right] != 0)
                        matrix[i, j] = 2;
                }

            AddMatrixToTextBox(matrix, n, n);
        }
    }
}
