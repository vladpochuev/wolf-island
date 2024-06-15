using System;
using System.Collections.Generic;
using WolfIsland.Environment;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public abstract class Wolf : Predator
    {
        public override List<Type> SuitableBiomes { get; } = new List<Type> { typeof(Plain) };
        public override string Symbol { get; } = "\ud83d\udc3a";
        public override IMap Map { protected get; set; }
        public override HashSet<Type> Hunts { get; } = new HashSet<Type> { typeof(Rabbit) };
        protected override double Score { get; set; } = 1;
        protected override double ScoreReducing { get; set; } = 0.1;

        public Wolf(int x, int y, IMap map) : base(x, y, map)
        {
        }

        protected Wolf()
        {
        }
    }
}