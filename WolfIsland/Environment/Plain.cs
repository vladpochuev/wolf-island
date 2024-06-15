using System.Drawing;

namespace WolfIsland.Environment
{
    public class Plain : Biome
    {
        public override Color Color { get; set; }
        public Plain()
        {
            Color = Color.Green;
        }
    }
}