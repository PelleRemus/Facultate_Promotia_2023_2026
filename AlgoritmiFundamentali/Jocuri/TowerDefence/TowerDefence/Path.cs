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
                // Daca dreptunghiul este mai lung vertical
                if (Points[i - 1].X == Points[i].X)
                {
                    // Pozitia X este aceeasi pentru ambele puncte, deci o luam pe oricare dintre ele.
                    // Luam in calcul si grosimea path-ului, punctele din path reprezentand mijlocul acestuia.
                    // De aceea scadem thickness (este valabil pentru toate locurile unde avem '- thickness'
                    rectangle.X = Points[i].X - thickness;
                    // Luam cea mai mica pozitie Y, pentru ca reprezinta Y-ul coltului din stanga sus a dreptunghiului
                    rectangle.Y = Math.Min(Points[i - 1].Y, Points[i].Y) - thickness;
                    rectangle.Width = 2 * thickness;
                    // Calculam doar inaltimea, pentru ca valorile X sunt egale.
                    // Luam diferenta in modul pentru a sti lungimea dreptunghiului.
                    // Adaugam 2 * thickness pentru ca asta este valoarea lui Width,
                    // deci pentru a inconjuta punctele uniform in ambele directii
                    rectangle.Height = Math.Abs(Points[i - 1].Y - Points[i].Y) + 2 * thickness;
                }
                // Daca dreptunghiul este mai lung orizontal
                // (aceleasi explicatii sunt valabile, dar la X in loc de Y si invers)
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
