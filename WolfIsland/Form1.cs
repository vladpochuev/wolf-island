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
using WolfIsland.Animals;
using WolfIsland.Environment;

namespace WolfIsland
{
    public partial class Form1 : Form
    {
        private const int FieldHeight = 800;
        private const int FieldWidth = 800;
        private const int MarginHeight = 50;
        private int CellHeight { get; set; }
        private int CellWidth { get; set; }
        private Island Island { get; set; }
        private LifeCycle LifeCycle { get; set; }
        private List<Label> AnimalSymbols { get; set; }

        public Form1()
        {
            CellHeight = FieldHeight / 20;
            CellWidth = FieldWidth / 20;

            InitializeComponent();
            Init();
        }

        private void Init()
        {
            AnimalSymbols = new List<Label>();
            Island = new Island();
            LifeCycle = new LifeCycle(Island);

            DrawBiomes();
            DrawAnimals();
        }

        private void DrawAnimals()
        {
            List<Animal> animals = Island.Animals;

            foreach (var animal in animals)
            {
                DrawAnimal(animal.X, animal.Y, animal.Symbol);
            }
        }

        private void DrawAnimal(int x, int y, string symbol)
        {
            Label label = new Label();
            AnimalSymbols.Add(label);
            label.Text = Convert.ToString(symbol);
            label.ForeColor = Color.White;
            label.BackColor = Island.Biomes[x, y].Color;
            label.Font = new Font("Arial", 15, FontStyle.Bold);
            label.AutoSize = true;
            label.Location = new Point((int)(x * CellWidth + 0.15 * CellWidth), (int)(y * CellHeight + 0.15 * CellHeight + MarginHeight));
            Controls.Add(label);
            label.BringToFront();
        }

        private void RemoveAnimalsFromMap()
        {
            foreach (var label in AnimalSymbols)
            {
                Controls.Remove(label);
            }
        }

        private void DrawBiomes()
        {
            Biome[,] biomes = Island.Biomes;
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
            pictureBox.Location = new Point(x * CellWidth, y * CellHeight + MarginHeight);
            pictureBox.Size = new Size(CellWidth, CellHeight);
            Controls.Add(pictureBox);
        }

        private void toolStripNext_Click(object sender, EventArgs e)
        {
            RemoveAnimalsFromMap();
            LifeCycle.MakeNextMove();
            DrawAnimals();
        }
    }
}