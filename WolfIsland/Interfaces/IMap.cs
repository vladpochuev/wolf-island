using System;
using System.Collections.Generic;
using System.Drawing;
using WolfIsland.Animals;
using WolfIsland.Environment;

namespace WolfIsland.Interfaces
{
    public interface IMap
    {
        Biome[,] Biomes { get; }
        List<List<Animal>> TypesOfAnimal { get; }
        List<Type> AnimalsOrder { get; }

        void SetBiome(int x, int y, Biome biome);
        void MakeAnimalsMove();
        List<Animal> GetAnimalsInPoint(Point point);
        void CreateAnimal(Animal animal);
        void RemoveAnimal(Animal animal);
        void FillMapRandom();
    }
}