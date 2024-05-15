using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class RedBloon : Bloon
    {
        static readonly Image image = Image.FromFile("../../Images/RedBloon.png");
        public RedBloon(int spawnTime) : base(image, 65, 5, spawnTime)
        { }
    }
}
