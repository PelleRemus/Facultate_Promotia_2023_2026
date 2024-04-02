using System;
using System.Windows.Forms;

namespace The_2048_Game
{
    public partial class Form1 : Form
    {
        public static Form1 Instance; // Vom folosi o singura instanta a formularului, de aceea este statica
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Instance = this;
            Engine.Initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.NewGame();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Engine.hasStarted) // Daca nu am apasat inca pe New Game, nu facem nimic
                return;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                bool hasMoved = Engine.MoveLeft();
                if (Engine.CombineLeft() || hasMoved)
                {
                    Engine.MoveLeft();
                    Engine.GenerateNewTile();
                }
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                bool hasMoved = Engine.MoveRight();
                if (Engine.CombineRight() || hasMoved)
                {
                    Engine.MoveRight();
                    Engine.GenerateNewTile();
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                bool hasMoved = Engine.MoveUp();
                if (Engine.CombineUp() || hasMoved)
                {
                    Engine.MoveUp();
                    Engine.GenerateNewTile();
                }
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                bool hasMoved = Engine.MoveDown();
                if (Engine.CombineDown() || hasMoved)
                {
                    Engine.MoveDown();
                    Engine.GenerateNewTile();
                }
            }
            Engine.Render();

            if (!Engine.isInFreeplay && Engine.HasWon())
            {
                var result = MessageBox.Show("You reached 2048 and won the game!" + Environment.NewLine
                    + "Do you yant to start a new game? If not, you can continue in Freeplay mode",
                    "You won!", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    Engine.isInFreeplay = true;
                else
                    Engine.NewGame();
            }
        }
    }
}
