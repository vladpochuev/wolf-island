using System;
using System.Collections.Generic;
using WolfIsland.Environment;

namespace WolfIsland.Animals
{
    public class Rabbit : Animal
    {
        private double CHANCE_OF_BREEADING = 0.2;
        private List<Type> SUITABLE_BIOMES = new List<Type> { typeof(Plain) };

        public override void MakeMove(Island island)
        {

        }
    }
}