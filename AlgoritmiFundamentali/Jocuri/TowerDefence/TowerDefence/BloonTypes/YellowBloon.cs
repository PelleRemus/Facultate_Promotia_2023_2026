using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class YellowBloon : Bloon
    {
        static readonly Image image = Image.FromFile("../../Images/YellowBloon.png");
        public YellowBloon(int spawnTime) : base(image, 90, 9, spawnTime)
        { }
    }
}
