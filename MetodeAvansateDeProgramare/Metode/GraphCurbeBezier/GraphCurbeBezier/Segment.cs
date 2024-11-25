using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCurbeBezier
{
    public class Segment
    {
        public PointF P0, P1;
        public PointF[] points;
        public int k; // numarul de puncte din segment

        public Segment(PointF P0, PointF P1, int k)
        {
            this.P0 = P0;
            this.P1 = P1;
            this.k = k;
            points = new PointF[k + 1];
            CalcularePuncteIntermediare();
        }

        public void CalcularePuncteIntermediare()
        {
            for (int i = 0; i <= k; i++)
            {
                float x = ((k - i) * P0.X + i * P1.X) / k;
                float y = ((k - i) * P0.Y + i * P1.Y) / k;
                points[i] = new PointF(x, y);
            }
        }

        public void Draw()
        {
            Engine.graphics.DrawEllipse(new Pen(Color.Red, 7), P0.X - 4, P0.Y - 4, 9, 9);
            Engine.graphics.DrawEllipse(new Pen(Color.Red, 7), P1.X - 4, P1.Y - 4, 9, 9);
            for (int i = 0; i <= k; i++)
            {
                Engine.graphics.DrawEllipse(new Pen(Color.Blue, 2),
                    points[i].X - 1, points[i].Y - 1, 3, 3);
            }
        }
    }
}
