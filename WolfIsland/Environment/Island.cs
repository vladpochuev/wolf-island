using System;
using System.Collections.Generic;
using WolfIsland.Animals;

namespace WolfIsland.Environment
{
    public class Island : IMap
    {
        public Biome[,] Biomes { get; set; }
        public List<Animal> Animals { get; set; }
        private Random Random { get; set; }

        public Island()
        {
            Biomes = new Biome[20, 20];
            Animals = new List<Animal> {new Rabbit(5, 5, this)};
            Random = new Random();
            FillMapRandom();
        }

        public void MakeAnimalsMove()
        {
            foreach (var animal in Animals.ToArray())
            {
                animal.MakeMove();
            }
        }

        public void SetBiome(int x, int y, Biome biome)
        {
            Biomes[x, y] = biome;
        }

        public void CreateAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }

        private void FillMapRandom()
        {
            for (int i = 0; i < Biomes.GetLength(0); i++)
            {
                for (int j = 0; j < Biomes.GetLength(1); j++)
                {
                    if (Random.Next(2) == 0)
                    {
                        Biomes[i, j] = new Ocean();
                    }
                    else
                    {
                        Biomes[i, j] = new Plain();
                    }
                }
            }
        }
    }
}