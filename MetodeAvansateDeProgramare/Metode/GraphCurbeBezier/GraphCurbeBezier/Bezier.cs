using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCurbeBezier
{
    public class Bezier
    {
        public PointF A, B, C;
        public Segment AC, CB;
        public PointF[] points;
        public int k;

        public Bezier(PointF A, PointF B, PointF C, int k)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.k = k;
            points = new PointF[k + 1];
            CalcularePuncte();
        }

        public void CalcularePuncte()
        {
            AC = new Segment(A, C, k);
            CB = new Segment(C, B, k);

            for (int i = 0; i <= k; i++)
            {
                PointF P0 = AC.points[i];
                PointF P1 = CB.points[i];
                Segment P0_P1 = new Segment(P0, P1, k);
                points[i] = P0_P1.points[i];
            }
        }

        public void Draw()
        {
            Engine.graphics.DrawEllipse(new Pen(Color.Red, 7), A.X - 4, A.Y - 4, 9, 9);
            Engine.graphics.DrawEllipse(new Pen(Color.Red, 7), B.X - 4, B.Y - 4, 9, 9);
            //Engine.graphics.DrawEllipse(new Pen(Color.Red, 7), C.X - 4, C.Y - 4, 9, 9);
            for (int i = 0; i <= k; i++)
            {
                Engine.graphics.DrawEllipse(new Pen(Color.Green, 2),
                    points[i].X - 1, points[i].Y - 1, 3, 3);
            }
        }
    }
}
