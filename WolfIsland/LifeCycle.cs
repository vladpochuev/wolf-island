using System;
using WolfIsland.Environment;

namespace WolfIsland
{
    public class LifeCycle
    {
        public int NumberOfMoves = 0;
        private IMap Map { get; set; }

        public LifeCycle(IMap map)
        {
            Map = map;
        }

        public void MakeNextMove()
        {
            Map.MakeAnimalsMove();
            NumberOfMoves++;
            Console.WriteLine("Move number " + NumberOfMoves + " was successfully completed");
        }
    }
}