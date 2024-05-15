using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class BlueBloon : Bloon
    {
        static readonly Image image = Image.FromFile("../../Images/BlueBloon.png");
        public BlueBloon(int spawnTime) : base(image, 72, 6, spawnTime)
        { }
    }
}
