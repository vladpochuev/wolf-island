using WolfIsland.Environment;

namespace WolfIsland
{
    public interface IMap
    {
        Biome[,] Map { get; set; }

        void SetBiome(int x, int y, Biome biome);

        void MakeAnimalsMove();
    }
}