using WolfIsland.Environment;

namespace WolfIsland.Animals
{
    public abstract class Animal : IPlaceable, IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void MakeMove(Island island);
    }
}