using System;
using System.Xml.Schema;

namespace WolfIsland.Environment
{
    public class Island
    {
        private Biome[,] Map { get; set; }
        private Random Random { get; set; }

        public Island()
        {
            Map = new Biome[20,20];
            Random = new Random();
            FillMap();
        }

        public void CreateAnimal()
        {

        }

        public void RemoveAnimal()
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

        public void DrawMap()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(Map[i, j].GetType() == typeof(Plain) ? 'p' : 'o');
                }

                Console.WriteLine();
            }
        }
    }
}