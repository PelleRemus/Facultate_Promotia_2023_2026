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
            // Scadem 'size' din valoarea X-ului pentru a scoate balonul afara din ecran.
            // Astfel, ascundem baloanele daca inca nu s-a ajuns la spawnTime, si arata mai bine cand incepe jocul
            // Scadem 'size / 2' pentru a centra baloanele pe Path
            Location = new Point(Engine.path.Points[0].X - size, Engine.path.Points[0].Y - size / 2);
            DestinationIndex = 1;
            Destination = new Point(Engine.path.Points[1].X - size / 2, Engine.path.Points[1].Y - size / 2);
        }

        public void Move()
        {
            // Daca balonul a ajuns suficient de aproape de destinatie
            if (Math.Abs(Location.X - Destination.X) < Speed && Math.Abs(Location.Y - Destination.Y) < Speed)
            {
                // Intai ne asiguram ca balonul va fi pozitionat cu X-ul si cu Y-ul bine fata de urmatorul punct
                Location = Destination;
                DestinationIndex++; // Ne ducem la urmatorul punct destinatie
                // Daca am ajuns la ultimul punct din path
                if (DestinationIndex == Engine.path.Points.Count)
                {
                    // Balonul a ajuns la sfarsit si nu il mai afisam
                    Engine.bloons.Remove(this);
                    return;
                }
                // Alegem noul punct destinatie (trebuie modificat la coltul din stanga sus al balonului)
                Destination = new Point(Engine.path.Points[DestinationIndex].X - Size / 2,
                                        Engine.path.Points[DestinationIndex].Y - Size / 2);
            }

            // Atunci cand trebuie sa ne miscam orizontal
            if (Location.Y == Destination.Y)
            {
                // Verificam daca trebuie sa ne miscam in dreapta sau in stanga
                if (Location.X < Destination.X)
                    Location = new Point(Location.X + Speed, Location.Y);
                else
                    Location = new Point(Location.X - Speed, Location.Y);
            }
            // Atunci cand trebuie sa ne miscam vertical
            else if (Location.X == Destination.X)
            {
                // Verificam daca trebuie sa ne miscam in jos sau in sus
                if (Location.Y < Destination.Y)
                    Location = new Point(Location.X, Location.Y + Speed);
                else
                    Location = new Point(Location.X, Location.Y - Speed);
            }
        }
    }
}
