using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public abstract class Predator : Animal
    {
        public abstract List<Type> Hunts {get; set;}
        protected abstract double Score { get; set; }
        protected abstract double ScoreReducing { get; set; }

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
                        Hunt(direction, animal);
                        return true;
                    }
                }
            }

            return false;
        }

        protected void Hunt(Direction direction, Animal animal)
        {
            if (X == animal.X && Y == animal.Y)
            {
                Eat(animal);
                return;
            }
            ChangeLocation(direction);
        }

        protected void Eat(Animal animal)
        {
            Score++;
            Map.RemoveAnimal(animal);
        }

        protected void Starve()
        {
            Score -= ScoreReducing;
            if (Score <= 0)
            {
                StarveToDeath();
            }
        }

        protected void StarveToDeath()
        {
            Map.RemoveAnimal(this);
        }

        protected Predator(int x, int y, IMap map) : base(x, y, map)
        {
        }
    }
}