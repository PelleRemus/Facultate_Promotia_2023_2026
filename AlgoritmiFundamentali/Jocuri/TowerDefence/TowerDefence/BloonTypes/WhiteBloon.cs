using System.Drawing;

namespace TowerDefence.BloonTypes
{
    public class WhiteBloon : Bloon
    {
        public WhiteBloon(int spawnTime) : base(Color.White, 25, 4, spawnTime)
        { }
    }
}
