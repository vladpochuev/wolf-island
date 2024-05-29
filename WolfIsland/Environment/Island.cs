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
        public List<List<Animal>> TypesOfAnimal { get; set; }
        public List<Type> AnimalsOrder { get; set; } = new List<Type> { typeof(WolfM), typeof(WolfF), typeof(Rabbit)};
        public List<Animal>[,] AnimalsInCells { get; set; }
        private Random Random { get; set; }

        public Island()
        {
            Biomes = new Biome[20, 20];
            TypesOfAnimal = new List<List<Animal>>();
            for (int i = 0; i < 1; i++)
            {
                TypesOfAnimal.Add(new List<Animal> { new WolfM(5, 5, this) });
                TypesOfAnimal.Add(new List<Animal> {new WolfF(5, 5, this)});
                TypesOfAnimal.Add(new List<Animal> { new Rabbit(4, 5, this) });
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

            foreach (var typeOfAnimal in TypesOfAnimal.ToArray())
            {
                foreach (var animal in typeOfAnimal)
                {
                    AnimalsInCells[animal.X, animal.Y].Add(animal);
                }
            }
        }

        public void MakeAnimalsMove()
        {
            foreach (var typeOfAnimal in TypesOfAnimal.ToArray())
            {
                foreach (var animal in typeOfAnimal.ToArray())
                {
                    if (RemoveAnimal(animal))
                    {
                        animal.MakeMove();
                        CreateAnimal(animal);
                    }
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
            for (var i = 0; i < AnimalsOrder.Count; i++)
            {
                if (animal.GetType() == AnimalsOrder[i])
                {
                    TypesOfAnimal[i].Add(animal);
                    AnimalsInCells[animal.X, animal.Y].Add(animal);
                }
            }
        }

        public bool RemoveAnimal(Animal animal)
        {
            for (var i = 0; i < AnimalsOrder.Count; i++)
            {
                if (animal.GetType() == AnimalsOrder[i])
                {
                    TypesOfAnimal[i].Remove(animal);
                    return AnimalsInCells[animal.X, animal.Y].Remove(animal);
                }
            }

            return false;
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