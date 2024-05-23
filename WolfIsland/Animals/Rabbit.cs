using System;
using System.Collections.Generic;
using WolfIsland.Environment;

namespace WolfIsland.Animals
{
    public class Rabbit : Animal
    {
        private double CHANCE_OF_BREEADING = 0.2;
        public override List<Type> SuitableBiomes { get; } = new List<Type> { typeof(Plain) };
        public override string Symbol { get; set; } = "\ud83d\udc07";
        protected override IMap Map { get; set; }
        private Random Random { get; }

        public Rabbit(int x, int y, IMap map) : base(x, y, map)
        {
            Random = new Random();
        }

        public override void MakeMove()
        {
            Move();
            Breed();
        }

        private void Move()
        {
            bool isBiomeValid;
            do
            {
                int randomInt = Random.Next(8);
                Direction direction = (Direction)randomInt;
                isBiomeValid = ChangeLocation(direction);
            } while (!isBiomeValid);
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