using WolfIsland.Animals;
using WolfIsland.Environment;

namespace WolfIsland
{
    public interface IMap
    {
        Biome[,] Biomes { get; set; }

        void SetBiome(int x, int y, Biome biome);
        void MakeAnimalsMove();
        void CreateAnimal(Animal animal);
        void RemoveAnimal(Animal animal);
    }
}