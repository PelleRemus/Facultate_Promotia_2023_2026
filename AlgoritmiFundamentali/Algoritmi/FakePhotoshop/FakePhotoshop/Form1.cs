using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FakePhotoshop
{
    public partial class Form1 : Form
    {
        Bitmap image = (Bitmap)Image.FromFile("../../Imagini/Copac.png");
        Bitmap destination;

        public Form1()
        {
            InitializeComponent();
            destination = new Bitmap(image.Width, image.Height);
            pictureBox1.Image = image;
        }

        // Reset
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }

        // Gray Scale
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color source = image.GetPixel(i, j);
                    int media = MediaAritmetica(source);
                    Color dest = Color.FromArgb(media, media, media);
                    destination.SetPixel(i, j, dest);
                }
            pictureBox1.Image = destination;
        }

        // Contrast
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color source = image.GetPixel(i, j);
                    int media = MediaAritmetica(source);
                    Color dest;

                    if (media < 128) // jumatate din 255, valoarea maxima posibila
                        dest = ChangeColorBy(source, -20);
                    else
                        dest = ChangeColorBy(source, 20);

                    destination.SetPixel(i, j, dest);
                }
            pictureBox1.Image = destination;
        }

        // Complementary
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color source = image.GetPixel(i, j);

                    int red = 255 - source.R;
                    int green = 255 - source.G;
                    int blue = 255 - source.B;
                    Color dest = Color.FromArgb(red, green, blue);

                    destination.SetPixel(i, j, dest);
                }
            pictureBox1.Image = destination;
        }

        // Blur
        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    List<Color> colors = new List<Color>();
                    for (int k = i - 3; k <= i + 3; k++)
                        for (int l = j - 3; l <= j + 3; l++)
                        {
                            if (k >= 0 && k < image.Width && l >= 0 && l < image.Height)
                                colors.Add(image.GetPixel(k, l));
                        }

                    Color dest = MediaAritmetica(colors);
                    destination.SetPixel(i, j, dest);
                }
            pictureBox1.Image = destination;
        }

        private int MediaAritmetica(Color color)
        {
            return (color.R + color.G + color.B) / 3;
        }

        private Color MediaAritmetica(List<Color> colors)
        {
            int red = 0, green = 0, blue = 0;
            for (int i = 0; i < colors.Count; i++)
            {
                red = red + colors[i].R;
                green = green + colors[i].G;
                blue = blue + colors[i].B;
            }
            red = red / colors.Count;
            green = green / colors.Count;
            blue = blue / colors.Count;
            return Color.FromArgb(red, green, blue);
        }

        private Color ChangeColorBy(Color source, int value)
        {
            int red = source.R + value;
            int green = source.G + value;
            int blue = source.B + value;

            if (red < 0) red = 0;
            if (green < 0) green = 0;
            if (blue < 0) blue = 0;

            if (red > 255) red = 255;
            if (green > 255) green = 255;
            if (blue > 255) blue = 255;

            return Color.FromArgb(red, green, blue);
        }
    }
}
