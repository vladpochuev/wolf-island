using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public class WolfM : Wolf, IBreedable
    {
        public override Color SymbolColor { get; set; } = Color.SkyBlue;
        public readonly Type BreadsWith = typeof(WolfF);

        public WolfM(int x, int y, IMap map) : base(x, y, map)
        {
        }

        public override void MakeMove()
        {
            if (!TryHunt() && !TryBreed())
            {
                Move();
            }

            Starve();
        }

        private bool TryBreed()
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                Point point = GetCoordinatesWithDirection(direction);
                point.X += X;
                point.Y += Y;

                if (X + point.X < 0 || X + point.X > 19 || Y + point.Y < 0 || Y + point.Y > 19) continue;

                List<Animal> animals = Map.GetAnimalsInPoint(point);
                foreach (var animal in animals)
                {
                    if (BreadsWith == animal.GetType())
                    {
                        Breed(animal, direction);
                        return true;
                    }
                }
            }

            return false;
        }

        public void Breed(Animal animal, Direction direction)
        {
            if (X == animal.X && Y == animal.Y)
            {
                Animal child;
                int randomInt = Random.Next(2);
                if (randomInt == 0)
                {
                    child = new WolfF(X, Y, Map);
                }
                else
                {
                    child = new WolfM(X, Y, Map);
                }

                Map.CreateAnimal(child);
                Console.WriteLine($"{child.GetType().Name + child.Id} was born by {GetType().Name + Id} and {animal.GetType().Name + animal.Id}");
                return;
            }

            ChangeLocation(direction);
        }
    }
}