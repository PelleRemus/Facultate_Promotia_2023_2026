using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GraphCurbeBezier
{
    public static class Engine
    {
        public static Form1 form;
        public static Bitmap bitmap;
        public static Graphics graphics;
        public static Bezier bezier;
        public static int n;
        public static int[,] adiacenta;
        public static PointF[] graphPoints;

        public static void Initialize(Form1 form)
        {
            Engine.form = form;
            //bezier = new Bezier(new PointF(100, 100), new PointF(350, 400),
            //    new PointF(400, 200), 100);
            n = 7;
            adiacenta = new int[,]
            {
                {0, 2, 0, 0, 0, 0, 0},
                {2, 0, 1, 0, 0, 0, 0},
                {0, 1, 0, 4, 0, 0, 0},
                {0, 0, 4, 0, 1, 0, 0},
                {0, 0, 0, 1, 0, 3, 1},
                {0, 0, 0, 0, 3, 0, 0},
                {0, 0, 0, 0, 1, 0, 0}
            };
            graphPoints = new PointF[]
            {
                new PointF(100, 400),
                new PointF(200, 100),
                new PointF(300, 400),
                new PointF(400, 400),
                new PointF(500, 300),
                new PointF(600, 400),
                new PointF(700, 100)
            };
        }

        public static void Draw()
        {
            bitmap = new Bitmap(form.pictureBox1.Width, form.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            //bezier.Draw();
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    for (int k = 0; k < adiacenta[i, j]; k++)
                    {
                        PointF A = graphPoints[i];
                        PointF B = graphPoints[j];
                        PointF middle = new PointF((A.X + B.X) / 2, (A.Y + B.Y) / 2);

                        int d = (k - adiacenta[i, j] / 2) * 50;
                        double thetha = Math.Atan((B.Y - A.Y) / (B.X - A.X));
                        float x = middle.X + d * (float)Math.Cos(90 + thetha);
                        float y = middle.Y + d * (float)Math.Sin(thetha - 90);
                        PointF C = new PointF(x, y);

                        bezier = new Bezier(A, B, C, 100);
                        bezier.Draw();
                    }
                }
            }

            form.pictureBox1.Image = bitmap;
        }
    }
}
