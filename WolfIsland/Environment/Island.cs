using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Animals;
using WolfIsland.Interfaces;

namespace WolfIsland.Environment
{
    public class Island : IMap
    {
        public Biome[,] Biomes { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Animal>[,] AnimalsInCells { get; set; }
        private Random Random { get; set; }

        public Island()
        {
            Biomes = new Biome[20, 20];
            Animals = new List<Animal>();
            for (int i = 0; i < 10; i++)
            {
                Animals.Add(new Rabbit(5, 5, this));
                Animals.Add(new WolfF(5, 5, this));
                Animals.Add(new WolfM(5, 5, this));
            }
            AnimalsInCells = new List<Animal>[20, 20];
            Random = new Random();
            FillCellsWithAnimals();
            FillMapRandom();
        }

        private void FillCellsWithAnimals()
        {
            for (var i = 0; i < AnimalsInCells.GetLength(0); i++)
            {
                for (var j = 0; j < AnimalsInCells.GetLength(1); j++)
                {
                    AnimalsInCells[i, j] = new List<Animal>();
                }
            }

            foreach (var animal in Animals)
            {
                AnimalsInCells[animal.X, animal.Y].Add(animal);
            }
        }

        public void MakeAnimalsMove()
        {
            foreach (var animal in Animals.ToArray())
            {
                if (RemoveAnimal(animal))
                {
                    animal.MakeMove();
                    CreateAnimal(animal);
                }
            }
        }

        public void SetBiome(int x, int y, Biome biome)
        {
            Biomes[x, y] = biome;
        }

        public List<Animal> GetAnimalsInPoint(Point point)
        {
            return AnimalsInCells[point.X, point.Y];
        }

        public void CreateAnimal(Animal animal)
        {
            Animals.Add(animal);
            AnimalsInCells[animal.X, animal.Y].Add(animal);
        }

        public bool RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
            return AnimalsInCells[animal.X, animal.Y].Remove(animal);
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

            Biomes[5, 5] = new Plain();
        }
    }
}