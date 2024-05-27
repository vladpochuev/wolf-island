using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public abstract class Predator : Animal
    {
        public abstract List<Type> Hunts { get; set; }
        protected abstract double Score { get; set; }
        protected abstract double ScoreReducing { get; set; }

        protected Predator(int x, int y, IMap map) : base(x, y, map)
        {
        }

        protected bool TryHunt()
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                Point point = GetCoordinatesWithDirection(direction);
                point.X += X;
                point.Y += Y;

                List<Animal> animals = Map.GetAnimalsInPoint(point);
                foreach (var animal in animals)
                {
                    if (Hunts.Contains(animal.GetType()))
                    {
                        Hunt(animal, direction);
                        return true;
                    }
                }
            }

            return false;
        }

        private void Hunt(Animal animal, Direction direction)
        {
            if (X == animal.X && Y == animal.Y)
            {
                Eat(animal);
                return;
            }

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