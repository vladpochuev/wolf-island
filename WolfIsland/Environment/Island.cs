using System;
using System.Collections.Generic;
using WolfIsland.Animals;

namespace WolfIsland.Environment
{
    public class Island : IMap
    {
        public Biome[,] Map { get; set; }
        private List<Animal> Animals { get; set; }
        private Random Random { get; set; }

        public Island()
        {
            Map = new Biome[20, 20];
            Animals = new List<Animal>();
            Random = new Random();
            FillMap();
        }

        public void MakeAnimalsMove()
        {
            foreach (var animal in Animals)
            {
                animal.MakeMove(this);
            }
        }

        public void SetBiome(int x, int y, Biome biome)
        {
            Map[x, y] = biome;
        }

        public void CreateAnimal(Animal animal)
        {

        }

        public void RemoveAnimal(Animal animal)
        {

        }

        private void FillMap()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Random.Next(2) == 0)
                    {
                        Map[i, j] = new Plain();
                    }
                    else
                    {
                        Map[i, j] = new Ocean();
                    }
                }
            }
        }
    }
}