using System;
using WolfIsland.Interfaces;

namespace WolfIsland
{
    public class LifeCycle
    {
        public int NumberOfMoves { get; set; }
        private IMap Map { get; set; }

        public LifeCycle(IMap map)
        {
            Map = map;
        }

        public void MakeNextMove()
        {
            long start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Map.MakeAnimalsMove();
            NumberOfMoves++;
            Console.WriteLine("Move number " + NumberOfMoves + " was successfully completed");
            long diff = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - start;
            Console.WriteLine("Move took " + diff + " ms");
        }
    }
}