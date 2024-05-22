using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfIsland.Environment;

namespace WolfIsland
{
    public partial class Form1 : Form
    {
        private int FieldHeight { get; set; } = 800;
        private int FieldWidth { get; set; } = 800;
        private Island Island { get; set; }
        private LifeCycle LifeCycle { get; set; }

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Island = new Island();
            LifeCycle = new LifeCycle(Island);

            DrawBiomes();
        }

        private void DrawBiomes()
        {
            Biome[,] biomes = Island.Map;
            for (int i = 0; i < biomes.GetLength(0); i++)
            {
                for (int j = 0; j < biomes.GetLength(1); j++)
                {
                    DrawBiome(i, j, biomes[i, j].Color);
                }
            }
        }

        private void DrawBiome(int x, int y, Color color)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = color;
            pictureBox.Location = new Point(x * FieldWidth / 20, y * FieldHeight / 20);
            pictureBox.Size = new Size(FieldWidth / 20, FieldHeight / 20);
            Controls.Add(pictureBox);
        }

        private void toolStripNext_Click(object sender, EventArgs e)
        {
            LifeCycle.MakeNextMove();
        }
    }
}