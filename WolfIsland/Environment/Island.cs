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
        public List<Type> AnimalsOrder { get; set; } = new List<Type> { typeof(WolfM), typeof(WolfF), typeof(Rabbit) };
        private Random Random { get; set; }

        public Island(int width, int height)
        {
            Biomes = new Biome[width, height];
            TypesOfAnimal = new List<List<Animal>>();
            for (int i = 0; i < 1; i++)
            {
                TypesOfAnimal.Add(new List<Animal>()); // WolfM
                TypesOfAnimal.Add(new List<Animal>()); // WolfF
                TypesOfAnimal.Add(new List<Animal>()); // Rabbit
            }

            Random = new Random();
            FillMapRandom();
        }

        public void MakeAnimalsMove()
        {
            foreach (var typeOfAnimal in TypesOfAnimal.ToArray())
            {
                foreach (var animal in typeOfAnimal.ToArray())
                {
                    animal.MakeMove();
                }
            }
        }

        public List<Animal> GetAnimalsInPoint(Point point)
        {
            List<Animal> animals = new List<Animal>();
            foreach (var typeOfAnimals in TypesOfAnimal)
            {
                foreach (var animal in typeOfAnimals)
                {
                    if (point.X == animal.X && point.Y == animal.Y)
                    {
                        animals.Add(animal);
                    }
                }
            }

            return animals;
        }

        public void SetBiome(int x, int y, Biome biome)
        {
            Biomes[x, y] = biome;
        }

        public void CreateAnimal(Animal animal)
        {
            for (var i = 0; i < AnimalsOrder.Count; i++)
            {
                if (animal.GetType() == AnimalsOrder[i])
                {
                    TypesOfAnimal[i].Add(animal);
                }
            }
        }

        public void RemoveAnimal(Animal animal)
        {
            for (var i = 0; i < AnimalsOrder.Count; i++)
            {
                if (animal.GetType() == AnimalsOrder[i])
                {
                    TypesOfAnimal[i].Remove(animal);
                }
            }
        }

        public void FillMapRandom()
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