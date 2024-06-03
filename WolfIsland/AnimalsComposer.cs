using System;
using System.Collections.Generic;
using WolfIsland.Animals;
using WolfIsland.Environment;

namespace WolfIsland
{
    public class AnimalsComposer
    {
        private Island Island { get; set; }
        private List<Animal>[,] AnimalsInCells { get; set; }

        public AnimalsComposer(int width, int height, Island island)
        {
            Island = island;
            AnimalsInCells = new List<Animal>[width, height];
        }

        public void Fill()
        {
            ClearCells();
            FillCells();
        }

        private void ClearCells()
        {
            for (var i = 0; i < AnimalsInCells.GetLength(0); i++)
            {
                for (var j = 0; j < AnimalsInCells.GetLength(1); j++)
                {
                    AnimalsInCells[i, j] = new List<Animal>();
                }
            }
        }

        private void FillCells()
        {
            foreach (var typeOfAnimal in Island.TypesOfAnimal.ToArray())
            {
                foreach (var animal in typeOfAnimal)
                {
                    AnimalsInCells[animal.X, animal.Y].Add(animal);
                }
            }
        }

        public List<List<Animal>> GetTypesOfAnimalsInCell(int x, int y)
        {
            List<Animal> animalsInCell = AnimalsInCells[x, y];
            if (animalsInCell == null || animalsInCell.Count == 0) return new List<List<Animal>>();

            return GroupAnimalsInCell(animalsInCell);
        }

        private List<List<Animal>> GroupAnimalsInCell(List<Animal> animalsInCell)
        {
            List<List<Animal>> typesOfAnimals = new List<List<Animal>>();
            List<Type> usedAnimals = new List<Type>();

            foreach (var animal in animalsInCell)
            {
                int animalTypeId = usedAnimals.IndexOf(animal.GetType());
                if (animalTypeId == -1)
                {
                    usedAnimals.Add(animal.GetType());
                    typesOfAnimals.Add(new List<Animal>());
                    animalTypeId = typesOfAnimals.Count - 1;
                }

                typesOfAnimals[animalTypeId].Add(animal);
            }

            return typesOfAnimals;
        }

        public void RemoveAnimalsFromCell(int x, int y)
        {
            foreach (var animal in AnimalsInCells[x, y].ToArray())
            {
                Island.RemoveAnimal(animal);
            }
        }
    }
}