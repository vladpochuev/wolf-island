using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Interfaces;

namespace WolfIsland.Animals
{
    public abstract class Animal : IPlaceable, IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract string Symbol { get; set; }
        public abstract Color SymbolColor { get; set; }
        public abstract List<Type> SuitableBiomes { get; }
        protected abstract IMap Map { get; set; }
        protected static Random Random { get; set; }

        protected Animal(int x, int y, IMap map)
        {
            X = x;
            Y = y;
            Map = map;
            Random = new Random();
        }

        public abstract void MakeMove();

        protected void Move()
        {
            bool isBiomeValid;
            do
            {
                int randomInt = Random.Next(9);
                Direction direction = (Direction)randomInt;
                isBiomeValid = ChangeLocation(direction);
            } while (!isBiomeValid);
        }

        protected bool ChangeLocation(Direction direction)
        {
            Point point = GetCoordinatesWithDirection(direction);

            if (X + point.X < 0 || X + point.X > 19 || Y + point.Y < 0 || Y + point.Y > 19) return false;
            if (SuitableBiomes.Contains(Map.Biomes[X + point.X, Y + point.Y].GetType()))
            {
                X += point.X;
                Y += point.Y;
                return true;
            }

            return false;
        }

        protected Point GetCoordinatesWithDirection(Direction direction)
        {
            Dictionary<Direction, Point> dictionary = new Dictionary<Direction, Point>
            {
                { Direction.Top, new Point(0, 1) },
                { Direction.RightTop, new Point(1, 1) },
                { Direction.Right, new Point(1, 0) },
                { Direction.RightBottom, new Point(1, -1) },
                { Direction.Bottom, new Point(0, -1) },
                { Direction.LeftBottom, new Point(-1, -1) },
                { Direction.Left, new Point(-1, 0) },
                { Direction.LeftTop, new Point(-1, 1) },
                { Direction.Center, new Point(0, 0) }
            };

            return dictionary[direction];
        }
    }
}