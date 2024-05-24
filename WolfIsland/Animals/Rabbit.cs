using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Environment;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public class Rabbit : Animal
    {
        private double CHANCE_OF_BREEADING = 0.2;
        public override List<Type> SuitableBiomes { get; } = new List<Type> { typeof(Plain) };
        public override string Symbol { get; set; } = "\ud83d\udc07";
        public override Color SymbolColor { get; set; } = Color.White;
        protected override IMap Map { get; set; }

        public Rabbit(int x, int y, IMap map) : base(x, y, map)
        {
        }

        public override void MakeMove()
        {
            Move();
            Breed();
        }

        private void Breed()
        {
            int randomInt = Random.Next(99);
            if (randomInt < CHANCE_OF_BREEADING * 100)
            {
                Map.CreateAnimal(new Rabbit(X, Y, Map));
            }
        }
    }
}