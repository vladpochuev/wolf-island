using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public abstract class Predator : Animal
    {
        public abstract HashSet<Type> Hunts { get; }
        protected abstract double Score { get; set; }
        protected abstract double ScoreReducing { get; set; }

        protected Predator(int x, int y, IMap map) : base(x, y, map)
        {
        }

        protected Predator()
        {
        }

        protected void Hunt(Animal animal)
        {
            if (!Hunts.Contains(animal.GetType())) return;

            if (X == animal.X && Y == animal.Y)
            {
                Eat(animal);
                return;
            }

            Direction direction = GetWayToOtherAnimal(animal);
            ChangeLocation(direction);
        }

        private void Eat(Animal animal)
        {
            Score++;
            Map.RemoveAnimal(animal);
            Console.WriteLine($"{animal.GetType().Name + animal.Id} was killed by {GetType().Name + Id}");
        }

        protected void Starve()
        {
            Score -= ScoreReducing;
            if (Score <= 0)
            {
                StarveToDeath();
            }
        }

        private void StarveToDeath()
        {
            Map.RemoveAnimal(this);
            Console.WriteLine($"Animal {GetType().Name + Id} starved to death");
        }
    }
}