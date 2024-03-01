using System.Drawing;
using System.Windows.Forms;

namespace X_si_O
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        string player = "X";

        public Form1()
        {
            InitializeComponent();

            int size = panel1.Width / 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Parent = panel1;
                    button.Size = new Size(size, size);
                    button.Location = new Point(j * size, i * size);
                    button.Font = new Font("Arial", size / 3);
                    button.Click += Button_Click;
                    buttons[i, j] = button;
                }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ResetAllButtons();
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            button.Text = player;
            button.Enabled = false;

            if (IsGameWon())
            {
                DisableAllButtons();
                MessageBox.Show($"Player {player} has won!", "You Won!");
            }
            else if (IsDraw())
            {
                MessageBox.Show($"No player has won this time!", "It's a Draw!");
            }

            if (player == "X")
                player = "O";
            else
                player = "X";
        }

        bool IsGameWon()
        {
            // verificare pe linii
            bool hasWon = buttons[0, 0].Text == player && buttons[0, 1].Text == player && buttons[0, 2].Text == player;
            hasWon = hasWon || buttons[1, 0].Text == player && buttons[1, 1].Text == player && buttons[1, 2].Text == player;
            hasWon = hasWon || buttons[2, 0].Text == player && buttons[2, 1].Text == player && buttons[2, 2].Text == player;

            // verificare pe coloane
            hasWon = hasWon || buttons[0, 0].Text == player && buttons[1, 0].Text == player && buttons[2, 0].Text == player;
            hasWon = hasWon || buttons[0, 1].Text == player && buttons[1, 1].Text == player && buttons[2, 1].Text == player;
            hasWon = hasWon || buttons[0, 2].Text == player && buttons[1, 2].Text == player && buttons[2, 2].Text == player;

            // verificare pe diagonale
            hasWon = hasWon || buttons[0, 0].Text == player && buttons[1, 1].Text == player && buttons[2, 2].Text == player;
            hasWon = hasWon || buttons[0, 2].Text == player && buttons[1, 1].Text == player && buttons[2, 0].Text == player;

            return hasWon;
        }

        bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Text == "")
                        return false;
                }
            return true;
        }

        void DisableAllButtons()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    buttons[i, j].Enabled = false;
        }

        void ResetAllButtons()
        {
            player = "X";
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Enabled = true;
                    buttons[i, j].Text = "";
                }
        }
    }
}
