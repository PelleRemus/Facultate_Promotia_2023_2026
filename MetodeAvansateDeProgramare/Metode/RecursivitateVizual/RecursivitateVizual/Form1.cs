using System;
using System.Drawing;
using System.Windows.Forms;

namespace RecursivitateVizual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics graphics;
        Bitmap bitmap;

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            DrawSquareRecursive(new Point(700, 400), 400);

            pictureBox1.Image = bitmap;
        }

        void DrawSquareRecursive(Point center, int length)
        {
            if (length < 2)
                return;

            Point topLeft = new Point(center.X - length / 2, center.Y - length / 2);
            Point topRight = new Point(center.X + length / 2, center.Y - length / 2);
            Point bottomLeft = new Point(center.X - length / 2, center.Y + length / 2);
            Point bottomRight = new Point(center.X + length / 2, center.Y + length / 2);

            DrawSquare(topLeft, topRight, bottomLeft, bottomRight);
            DrawSquareRecursive(topLeft, length / 2);
            DrawSquareRecursive(topRight, length / 2);
            DrawSquareRecursive(bottomLeft, length / 2);
            DrawSquareRecursive(bottomRight, length / 2);
        }

        void DrawSquare(Point topLeft, Point topRight,
            Point bottomLeft, Point bottomRight)
        {
            graphics.DrawLine(Pens.White, topLeft, topRight);
            graphics.DrawLine(Pens.White, topRight, bottomRight);
            graphics.DrawLine(Pens.White, bottomRight, bottomLeft);
            graphics.DrawLine(Pens.White, bottomLeft, topLeft);
        }
    }
}
