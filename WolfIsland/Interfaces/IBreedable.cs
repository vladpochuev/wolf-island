using WolfIsland.Animals;

namespace WolfIsland.Interfaces
{
    public interface IBreedable : IMovable
    {
        void Breed(Animal animal, Direction direction);
    }
}