using System.Drawing;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public class WolfF : Wolf
    {
        public override Color SymbolColor { get; set; } = Color.HotPink;

        public WolfF(int x, int y, IMap map) : base(x, y, map)
        {
        }

        public WolfF()
        {
        }

        public override void MakeMove()
        {
            if (!TryHunt())
            {
                Move();
            }
            Starve();
        }
    }
}