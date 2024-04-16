using System.Collections.Generic;
using System.Drawing;
using TowerDefence.BloonTypes;

namespace TowerDefence
{
    public static class Engine
    {
        public static Bitmap bitmap;
        public static Graphics graphics;
        public static Path path;
        public static List<Bloon> bloons;
        public static int time = 0;

        public static void Initialize()
        {
            List<Point> points = new List<Point>
            {
                new Point(0, Form1.Instance.Height / 2),
                new Point(Form1.Instance.Width / 5, Form1.Instance.Height / 2),
                new Point(Form1.Instance.Width / 5, Form1.Instance.Height / 5),
                new Point(Form1.Instance.Width / 3, Form1.Instance.Height / 5),
                new Point(Form1.Instance.Width / 3, 7 * Form1.Instance.Height / 10),
                new Point(Form1.Instance.Width / 7, 7 * Form1.Instance.Height / 10),
                new Point(Form1.Instance.Width / 7, 9 * Form1.Instance.Height / 10),
                new Point(7 * Form1.Instance.Width / 10, 9 * Form1.Instance.Height / 10),
                new Point(7 * Form1.Instance.Width / 10, 2 * Form1.Instance.Height / 3),
                new Point(Form1.Instance.Width / 2, 2 * Form1.Instance.Height / 3),
                new Point(Form1.Instance.Width / 2, 2 * Form1.Instance.Height / 5),
                new Point(7 * Form1.Instance.Width / 10, 2 * Form1.Instance.Height / 5),
                new Point(7 * Form1.Instance.Width / 10, Form1.Instance.Height / 10),
                new Point(2 * Form1.Instance.Width / 5, Form1.Instance.Height / 10),
                new Point(2 * Form1.Instance.Width / 5, 0),
            };
            path = new Path(points);

            bloons = new List<Bloon>();
            bloons.Add(new RedBloon(0));
            bloons.Add(new BlueBloon(15));
            bloons.Add(new GreenBloon(30));
            bloons.Add(new YellowBloon(45));
            bloons.Add(new BlackBloon(60));
            bloons.Add(new WhiteBloon(75));
        }

        public static void Draw()
        {
            bitmap = new Bitmap(Form1.Instance.Width, Form1.Instance.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.ForestGreen);

            foreach (Rectangle rectangle in path.Bounds)
                graphics.FillRectangle(new SolidBrush(Color.DarkGray), rectangle);

            foreach (Bloon bloon in bloons)
                graphics.FillRectangle(new SolidBrush(bloon.Color), bloon.Location.X, bloon.Location.Y,
                    bloon.Size, bloon.Size);
            Form1.Instance.pictureBox1.Image = bitmap;
        }
    }
}
