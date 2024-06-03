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
        private const int CellQuantityWidth = 20;
        private const int CellQuantityHeight = 20;
        private const int MarginHeight = 35;
        private int CellHeight { get; set; }
        private int CellWidth { get; set; }
        private Island Island { get; set; }
        private AnimalsComposer AnimalsComposer { get; set; }
        private LifeCycle LifeCycle { get; set; }
        private PictureBox[,] PictureBoxes { get; set; }
        private List<ToolStripButton> ControlButtons { get; set; }
        private FormButtonState ButtonState { get; set; } = FormButtonState.None;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeFields()
        {
            FieldHeight = Height - MarginHeight - 30;
            FieldWidth = FieldHeight;
            CellHeight = FieldHeight / CellQuantityHeight;
            CellWidth = FieldWidth / CellQuantityWidth;
            PictureBoxes = new PictureBox[CellQuantityWidth, CellQuantityHeight];
            Island = new Island(CellQuantityWidth, CellQuantityHeight);
            AnimalsComposer = new AnimalsComposer(CellQuantityWidth, CellQuantityHeight, Island);
            LifeCycle = new LifeCycle(Island);

            AddCreateButtons();
            AnimalsComposer.Fill();
            DrawBiomes();
            DrawAnimals();
        }

        private void MakeNextMove(object sender, EventArgs e)
        {
            RemoveLabels();
            LifeCycle.MakeNextMove();
            DrawAnimals();
        }

        private void DrawAnimals()
        {
            AnimalsComposer.Fill();

            for (var i = 0; i < CellQuantityHeight; i++)
            {
                for (var j = 0; j < CellQuantityHeight; j++)
                {
                    DrawAnimalsInCell(i, j);
                }
            }
        }

        private void DrawAnimalsInCell(int x, int y)
        {
            RemoveLabelsFromCell(x, y);
            List<List<Animal>> typesOfAnimals = AnimalsComposer.GetTypesOfAnimalsInCell(x, y);
            DrawLabelsInCell(typesOfAnimals);
        }

        private void RemoveLabelsFromCell(int x, int y)
        {
            PictureBoxes[x, y].Controls.Clear();
        }

        private void DrawLabelsInCell(List<List<Animal>> typesOfAnimals)
        {
            for (var i = 0; i < typesOfAnimals.Count; i++)
            {
                List<Animal> typesOfAnimal = typesOfAnimals[i];
                Animal animal = typesOfAnimal[0];
                Label label = new Label();
                label.Text = typesOfAnimal.Count + Convert.ToString(animal.Symbol);
                label.ForeColor = animal.SymbolColor;
                label.BackColor = Color.Transparent;
                label.Font = new Font("Arial", CellHeight / 6, FontStyle.Bold);
                label.AutoSize = true;
                label.Location = new Point(0, i * (CellHeight / typesOfAnimals.Count));
                PictureBoxes[animal.X, animal.Y].Controls.Add(label);
                label.Click += RedirectLabelClick;
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
            pictureBox.Click += ChangePictureBoxContent;
            PictureBoxes[x, y] = pictureBox;
            Controls.Add(pictureBox);
        }

        private void RemoveBiomes()
        {
            Biome[,] biomes = Island.Biomes;
            for (int i = 0; i < biomes.GetLength(0); i++)
            {
                for (int j = 0; j < biomes.GetLength(1); j++)
                {
                    RemoveBiome(i, j);
                }
            }
        }

        private void RemoveBiome(int x, int y)
        {
            Controls.Remove(PictureBoxes[x, y]);
            AnimalsComposer.RemoveAnimalsFromCell(x, y);
        }

        private void UpdateBiomes()
        {
            RemoveBiomes();
            DrawBiomes();
        }

        private void UpdateBiome(int x, int y)
        {
            RemoveBiome(x, y);
            DrawBiome(x, y, Island.Biomes[x, y].Color);
        }

        private void ChangePictureBoxContent(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int x = pictureBox.Location.X / CellWidth;
            int y = (pictureBox.Location.Y - MarginHeight) / CellHeight;

            Object obj = ButtonStateFactory.GetObject(ButtonState);

            if (obj is Biome biome)
            {
                ChangeBiome(x, y, biome);
            }

            if (obj is Animal animal)
            {
                animal.X = x;
                animal.Y = y;
                animal.Map = Island;
                AddAnimal(x, y, animal);
            }
        }

        private void ChangeBiome(int x, int y, Biome biome)
        {
            Island.Biomes[x, y] = biome;
            UpdateBiome(x, y);
        }

        private void AddAnimal(int x, int y, Animal animal)
        {

            if (!animal.SuitableBiomes.Contains(Island.Biomes[x, y].GetType()))
            {
                Console.WriteLine(
                    $"Biome {Island.Biomes[x, y].GetType().Name} is not suitable for an animal {animal.GetType().Name}");
                return;
            }

            Island.CreateAnimal(animal);
            RemoveLabelsFromCell(x, y);
            AnimalsComposer.Fill();
            DrawAnimalsInCell(x, y);
        }

        private void RemoveLabels()
        {
            for (int i = 0; i < PictureBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < PictureBoxes.GetLength(1); j++)
                {
                    RemoveLabelsFromCell(i, j);
                }
            }
        }

        private void AddCreateButtons()
        {
            ControlButtons = new List<ToolStripButton> { plainBtn, oceanBtn, rabbitBtn, wolfMBtn, wolfFBtn };
        }

        private void RedirectLabelClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            ChangePictureBoxContent(label.Parent, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeFields();
        }

        private void plainBtn_Click(object sender, EventArgs e)
        {
            ButtonState = FormButtonState.Plain;
            UncheckAllCreateButtons();
            plainBtn.Checked = true;
        }

        private void oceanBtn_Click(object sender, EventArgs e)
        {
            ButtonState = FormButtonState.Ocean;
            UncheckAllCreateButtons();
            oceanBtn.Checked = true;
        }

        private void rabbitBtn_Click(object sender, EventArgs e)
        {
            ButtonState = FormButtonState.Rabbit;
            UncheckAllCreateButtons();
            rabbitBtn.Checked = true;
        }

        private void wolfMBtn_Click(object sender, EventArgs e)
        {
            ButtonState = FormButtonState.WolfM;
            UncheckAllCreateButtons();
            wolfMBtn.Checked = true;
        }

        private void wolfFBtn_Click(object sender, EventArgs e)
        {
            ButtonState = FormButtonState.WolfF;
            UncheckAllCreateButtons();
            wolfFBtn.Checked = true;
        }

        private void UncheckAllCreateButtons()
        {
            foreach (var button in ControlButtons)
            {
                button.Checked = false;
            }
        }

        private void randomBtn_Click(object sender, EventArgs e)
        {
            Island.FillMapRandom();
            UpdateBiomes();
        }
    }
}