using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence
{
    public class Path
    {
        public const int thickness = 30;
        public List<Point> Points { get; set; }
        public List<Rectangle> Bounds { get; set; }

        public Path(List<Point> points)
        {
            Points = points;
            CalculateBounds();
        }

        public void CalculateBounds()
        {
            Bounds = new List<Rectangle>();
            for (int i = 1; i < Points.Count; i++)
            {
                Rectangle rectangle = new Rectangle();
                if (Points[i - 1].X == Points[i].X)
                {
                    rectangle.X = Points[i].X - thickness;
                    rectangle.Y = Math.Min(Points[i - 1].Y, Points[i].Y) - thickness;
                    rectangle.Width = 2 * thickness;
                    rectangle.Height = Math.Abs(Points[i - 1].Y - Points[i].Y) + 2 * thickness;
                }
                else
                {
                    rectangle.X = Math.Min(Points[i - 1].X, Points[i].X) - thickness;
                    rectangle.Y = Points[i].Y - thickness;
                    rectangle.Width = Math.Abs(Points[i - 1].X - Points[i].X) + 2 * thickness;
                    rectangle.Height = 2 * thickness;
                }
                Bounds.Add(rectangle);
            }
        }
    }
}
