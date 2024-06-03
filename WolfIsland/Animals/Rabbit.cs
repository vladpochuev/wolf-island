using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Environment;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public class Rabbit : Animal
    {
        public override List<Type> SuitableBiomes { get; } = new List<Type> { typeof(Plain) };
        public override IMap Map { protected get; set; }

        public override string Symbol { get; set; } = "\ud83d\udc07";
        public override Color SymbolColor { get; set; } = Color.White;
        private const double ChanceOfBreeding = 0.2;

        public Rabbit(int x, int y, IMap map) : base(x, y, map)
        {
        }

        public Rabbit()
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
            if (randomInt < ChanceOfBreeding * 100)
            {
                Rabbit child = new Rabbit(X, Y, Map);
                Map.CreateAnimal(child);
                Console.WriteLine($"{child.GetType().Name + child.Id} was born by {GetType().Name + Id}");
            }
        }
    }
}