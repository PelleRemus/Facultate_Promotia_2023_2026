using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Graphics graphics;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
            panel1.Height = Height - 100;

            List<Point> points = new List<Point>
            {
                new Point(0, Height / 2),
                new Point(Width / 5, Height / 2),
                new Point(Width / 5, Height / 5),
                new Point(Width / 3, Height / 5),
                new Point(Width / 3, 7 * Height / 10),
                new Point(Width / 7, 7 * Height / 10),
                new Point(Width / 7, 9 * Height / 10),
                new Point(7 * Width / 10, 9 * Height / 10),
                new Point(7 * Width / 10, 2 * Height / 3),
                new Point(Width / 2, 2 * Height / 3),
                new Point(Width / 2, 2 * Height / 5),
                new Point(7 * Width / 10, 2 * Height / 5),
                new Point(7 * Width / 10, Height / 10),
                new Point(2 * Width / 5, Height / 10),
                new Point(2 * Width / 5, 0),
            };
            Path path = new Path(points);

            bitmap = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.ForestGreen);

            foreach (Rectangle rectangle in path.Bounds)
                graphics.FillRectangle(new SolidBrush(Color.DarkGray), rectangle);
            pictureBox1.Image = bitmap;
        }
    }
}
