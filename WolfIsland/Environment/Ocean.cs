using System.Drawing;

namespace WolfIsland.Environment
{
    public class Ocean : Biome
    {
        public override Color Color { get; set; }
        public Ocean()
        {
            Color = Color.Blue;
        }
    }
}