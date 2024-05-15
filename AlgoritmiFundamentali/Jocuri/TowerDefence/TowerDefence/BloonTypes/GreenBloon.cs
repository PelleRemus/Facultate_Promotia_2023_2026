using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class GreenBloon : Bloon
    {
        static readonly Image image = Image.FromFile("../../Images/GreenBloon.png");
        public GreenBloon(int spawnTime) : base(image, 82, 7, spawnTime)
        { }
    }
}
