using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class BlackBloon : Bloon
    {
        static readonly Image image = Image.FromFile("../../Images/BlackBloon.png");
        public BlackBloon(int spawnTime) : base(image, 45, 6, spawnTime)
        { }
    }
}
