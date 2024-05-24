using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public class WolfF : Wolf
    {
        public override List<Type> Hunts { get; set; } = new List<Type> { typeof(Rabbit) };
        public override Color SymbolColor { get; set; } = Color.HotPink;

        public override void MakeMove()
        {
            if (!TryHunt())
            {
                Move();
            }
            Starve();
        }

        public WolfF(int x, int y, IMap map) : base(x, y, map)
        {
        }
    }
}