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
        private PictureBox[,] PictureBoxes { get; set; }
        private List<ToolStripButton> CreateButtons { get; set; }
        private FormButtonState ButtonState { get; set; } = FormButtonState.None;

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
            PictureBoxes = new PictureBox[20, 20];
            Island = new Island();
            LifeCycle = new LifeCycle(Island);

            AddCreateButtons();
            DrawBiomes();
            DrawAnimals();
        }

        private void AddCreateButtons()
        {
            CreateButtons = new List<ToolStripButton>{plainBtn, oceanBtn, rabbitBtn, wolfMBtn, wolfFBtn};
        }

        private void UncheckAllCreateButtons()
        {
            foreach (var button in CreateButtons)
            {
                button.Checked = false;
            }
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

            foreach (var animal in animalsInCell)
            {
                int animalTypeId = usedAnimals.IndexOf(animal.GetType());
                if (animalTypeId == -1)
                {
                    usedAnimals.Add(animal.GetType());
                    typesOfAnimals.Add(new List<Animal>());
                    animalTypeId = typesOfAnimals.Count - 1;
                }

                typesOfAnimals[animalTypeId].Add(animal);
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

        private void RedirectLabelClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            ChangePictureBoxContent(label.Parent, e);
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

        private void RemoveBiomes()
        {
            Biome[,] biomes = Island.Biomes;
            for (int i = 0; i < biomes.GetLength(0); i++)
            {
                for (int j = 0; j < biomes.GetLength(1); j++)
                {
                    RemoveBiome(PictureBoxes[i, j], i, j);
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

        private void ChangePictureBoxContent(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int x = pictureBox.Location.X / CellWidth;
            int y = (pictureBox.Location.Y - MarginHeight) / CellHeight;

            if (ButtonState == FormButtonState.Ocean
                || ButtonState == FormButtonState.Plain)
            {
                ChangeBiome(pictureBox, x, y);
            }
            else if (ButtonState == FormButtonState.Rabbit
                     || ButtonState == FormButtonState.WolfM
                     || ButtonState == FormButtonState.WolfF)
            {
                AddAnimal(x, y);
            }
        }

        private void ChangeBiome(PictureBox pictureBox, int x, int y)
        {
            if (ButtonState == FormButtonState.Ocean)
            {
                Island.Biomes[x, y] = new Ocean();
            }
            else if (ButtonState == FormButtonState.Plain)
            {
                Island.Biomes[x, y] = new Plain();
            }

            UpdateBiome(pictureBox, x, y);
        }

        private void UpdateBiomes()
        {
            RemoveBiomes();
            DrawBiomes();
        }

        private void UpdateBiome(PictureBox pictureBox, int x, int y)
        {
            RemoveBiome(pictureBox, x, y);
            DrawBiome(x, y, Island.Biomes[x, y].Color);
        }

        private void RemoveBiome(PictureBox pictureBox, int x, int y)
        {
            Controls.Remove(pictureBox);
            foreach (var animal in Island.AnimalsInCells[x, y].ToArray())
            {
                Island.RemoveAnimal(animal);
            }
        }

        private void AddAnimal(int x, int y)
        {
            Animal animal = null;

            if (ButtonState == FormButtonState.Rabbit)
            {
                animal = new Rabbit(x, y, Island);
            }
            else if (ButtonState == FormButtonState.WolfM)
            {
                animal = new WolfM(x, y, Island);
            }
            else if (ButtonState == FormButtonState.WolfF)
            {
                animal = new WolfF(x, y, Island);
            }

            if (!animal.SuitableBiomes.Contains(Island.Biomes[x, y].GetType()))
            {
                Console.WriteLine(
                    $"Biome {Island.Biomes[x, y].GetType().Name} is not suitable for an animal {animal.GetType().Name}");
                return;
            }

            Island.CreateAnimal(animal);
            PictureBoxes[x, y].Controls.Clear();
            DrawAnimalsInCell(Island.AnimalsInCells[x, y]);
        }

        private void RemoveAnimalsFromMap()
        {
            for (int i = 0; i < PictureBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < PictureBoxes.GetLength(1); j++)
                {
                    PictureBoxes[i, j].Controls.Clear();
                }
            }
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

        private void randomBtn_Click(object sender, EventArgs e)
        {
            Island.FillMapRandom();
            UpdateBiomes();
        }
    }
}