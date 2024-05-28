using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WolfIsland.Animals;
using WolfIsland.Environment;

namespace WolfIsland
{
    public partial class Form1 : Form
    {
        private int FieldHeight { get; set; }
        private int FieldWidth { get; set; }
        private const int MarginHeight = 35;
        private int CellHeight { get; set; }
        private int CellWidth { get; set; }
        private Island Island { get; set; }
        private LifeCycle LifeCycle { get; set; }
        private List<Label> AnimalLabels { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeFields()
        {
            FieldHeight = Height - MarginHeight - 30;
            FieldWidth = FieldHeight;
            CellHeight = FieldHeight / 20;
            CellWidth = FieldWidth / 20;
            AnimalLabels = new List<Label>();
            Island = new Island();
            LifeCycle = new LifeCycle(Island);

            DrawBiomes();
            DrawAnimals();
        }

        private void DrawAnimals()
        {
            DrawCells();
        }

        private void DrawCells()
        {
            List<Animal>[,] animalsInCells = Island.AnimalsInCells;
            for (var i = 0; i < animalsInCells.GetLength(0); i++)
            {
                for (var j = 0; j < animalsInCells.GetLength(1); j++)
                {
                    DrawAnimalsInCell(animalsInCells[i, j]);
                }
            }
        }

        private void DrawAnimalsInCell(List<Animal> animalsInCell)
        {
            if (animalsInCell == null || animalsInCell.Count == 0) return;

            List<List<Animal>> typesOfAnimals = GroupAnimalsInCell(animalsInCell);
            DrawLabels(typesOfAnimals);
        }

        private List<List<Animal>> GroupAnimalsInCell(List<Animal> animalsInCell)
        {
            List<List<Animal>> typesOfAnimals = new List<List<Animal>>();
            List<Type> usedAnimals = new List<Type>();

            foreach (var a in animalsInCell)
            {
                int animalTypeId = usedAnimals.IndexOf(a.GetType());
                if (animalTypeId == -1)
                {
                    usedAnimals.Add(a.GetType());
                    typesOfAnimals.Add(new List<Animal>());
                    animalTypeId = typesOfAnimals.Count - 1;
                }

                typesOfAnimals[animalTypeId].Add(a);
            }

            return typesOfAnimals;
        }

        private void DrawLabels(List<List<Animal>> typesOfAnimals)
        {
            for (var i = 0; i < typesOfAnimals.Count; i++)
            {
                List<Animal> typesOfAnimal = typesOfAnimals[i];
                Animal animal = typesOfAnimal[0];
                Label label = new Label();
                AnimalLabels.Add(label);
                label.Text = typesOfAnimal.Count + Convert.ToString(animal.Symbol);
                label.ForeColor = animal.SymbolColor;
                label.BackColor = Island.Biomes[animal.X, animal.Y].Color;
                label.Font = new Font("Arial", CellHeight / 6, FontStyle.Bold);
                label.AutoSize = true;
                label.Location = new Point(animal.X * CellWidth, animal.Y * CellHeight + MarginHeight + i * (CellHeight / typesOfAnimals.Count));
                Controls.Add(label);
                label.BringToFront();
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

        private void RemoveAnimalsFromMap()
        {
            foreach (var label in AnimalLabels)
            {
                Controls.Remove(label);
            }

            AnimalLabels = new List<Label>();
        }

        private void toolStripNext_Click(object sender, EventArgs e)
        {
            RemoveAnimalsFromMap();
            LifeCycle.MakeNextMove();
            DrawAnimals();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeFields();
        }
    }
}