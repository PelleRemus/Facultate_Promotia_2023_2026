using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class RedBloon : Bloon
    {
        public RedBloon(int spawnTime) : base(Color.Red, 40, 3, spawnTime)
        { }
    }
}
