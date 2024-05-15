using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class WhiteBloon : Bloon
    {
        static readonly Image image = Image.FromFile("../../Images/WhiteBloon.png");
        public WhiteBloon(int spawnTime) : base(image, 45, 7, spawnTime)
        { }
    }
}
