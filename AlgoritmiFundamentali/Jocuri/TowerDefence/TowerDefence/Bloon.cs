using System;
using System.Drawing;

namespace TowerDefence
{
    public abstract class Bloon
    {
        public Point Location { get; set; }
        public Point Destination { get; set; }
        public int DestinationIndex { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        public int Speed { get; set; }
        public int SpawnTime { get; set; }

        public Bloon(Color color, int size, int speed, int spawnTime)
        {
            Color = color;
            Size = size;
            Speed = speed;
            SpawnTime = spawnTime;
            Location = new Point(Engine.path.Points[0].X - size, Engine.path.Points[0].Y - size / 2);
            DestinationIndex = 1;
            Destination = new Point(Engine.path.Points[1].X - Size / 2, Engine.path.Points[1].Y - Size / 2);
        }

        public void Move()
        {
            if(Math.Abs(Location.X - Destination.X) < Speed && Math.Abs(Location.Y - Destination.Y) < Speed)
            {
                Location = Destination;
                DestinationIndex++;
                Destination = new Point(Engine.path.Points[DestinationIndex].X - Size / 2,
                                        Engine.path.Points[DestinationIndex].Y - Size / 2);
            }

            if(Location.Y == Destination.Y)
            {
                if(Location.X < Destination.X)
                    Location = new Point(Location.X + Speed, Location.Y);
                else
                    Location = new Point(Location.X - Speed, Location.Y);
            }
            else if(Location.X == Destination.X)
            {
                if (Location.Y < Destination.Y)
                    Location = new Point(Location.X, Location.Y + Speed);
                else
                    Location = new Point(Location.X, Location.Y - Speed);
            }
        }
    }
}
