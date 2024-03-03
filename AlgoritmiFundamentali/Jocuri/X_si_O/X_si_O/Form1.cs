using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace X_si_O
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        string player = "X";
        // "State" este o denumire conventionala, care aici reprezinta starea actuala a jocurilor castigate
        State state = new State();
        string statePath = "../../State.json";

        public Form1()
        {
            InitializeComponent();

            int size = panel1.Width / 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    // Daca nu punem parent, butonul va exista in cod, dar nu va fi afisat
                    button.Parent = panel1;
                    button.Size = new Size(size, size);
                    // Incepem cu j la location, pentru ca prima valoare reprezinta Width
                    // Care creste pe "coloanele" de pixeli a ecranului
                    button.Location = new Point(j * size, i * size);
                    button.Font = new Font("Arial", size / 3);
                    // "Click" este un eveniment. La eveniment, se adauga metode care trebuie apelate.
                    // Aceste metode nu sunt apelate, adica nu punem parantezele deschise si inchise
                    button.Click += Button_Click;
                    buttons[i, j] = button;
                }

            // Citim si afisam state-ul salvat in trecut
            ReadState();
            UpdateListBoxWithCurrentState();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ResetGame();
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            button.Text = player;
            button.Enabled = false; // Pentru a nu putea fi apasat de doua ori acelais buton

            if (IsGameWon())
            {
                DisableAllButtons(); // Pentru a nu putea continua sa jucam dupa ce am castigat
                if (player == "X")
                    state.gamesWonByX++;
                else
                    state.gamesWonByO++;

                SaveState();
                UpdateListBoxWithCurrentState();
                MessageBox.Show($"Player {player} has won!", "You Won!");
            }
            else if (IsDraw()) // Trebuie "else if" pt a nu spune ca e remiza daca se castiga la ultimul pas
            {
                MessageBox.Show($"No player has won this time!", "It's a Draw!");
            }

            // Alternam intre player X si player O
            if (player == "X")
                player = "O";
            else
                player = "X";
        }

        bool IsGameWon()
        {
            // Verificare pe linii
            bool hasWon = buttons[0, 0].Text == player && buttons[0, 1].Text == player && buttons[0, 2].Text == player;
            hasWon = hasWon || buttons[1, 0].Text == player && buttons[1, 1].Text == player && buttons[1, 2].Text == player;
            hasWon = hasWon || buttons[2, 0].Text == player && buttons[2, 1].Text == player && buttons[2, 2].Text == player;

            // Verificare pe coloane
            hasWon = hasWon || buttons[0, 0].Text == player && buttons[1, 0].Text == player && buttons[2, 0].Text == player;
            hasWon = hasWon || buttons[0, 1].Text == player && buttons[1, 1].Text == player && buttons[2, 1].Text == player;
            hasWon = hasWon || buttons[0, 2].Text == player && buttons[1, 2].Text == player && buttons[2, 2].Text == player;

            // Verificare pe diagonale
            hasWon = hasWon || buttons[0, 0].Text == player && buttons[1, 1].Text == player && buttons[2, 2].Text == player;
            hasWon = hasWon || buttons[0, 2].Text == player && buttons[1, 1].Text == player && buttons[2, 0].Text == player;

            return hasWon;
        }

        bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    // Daca exista vreun spatiu fara valoare de X sau O atribuita, inca putem continua jocul
                    if (buttons[i, j].Text == "")
                        return false;
                }
            return true;
        }

        void ReadState()
        {
            TextReader reader = new StreamReader(statePath);
            string json = reader.ReadToEnd(); // Citim tot textul
            // Si apoi convertim textul la obiectul state
            state = JsonConvert.DeserializeObject<State>(json);
            // Trebuie sa inchidem fisierul pentru a putea fi folosit de Writer in viitor
            reader.Close();
        }
        void SaveState()
        {
            TextWriter writer = new StreamWriter(statePath);
            writer.Write(JsonConvert.SerializeObject(state, Formatting.Indented));
            // Trebuie sa inchidem fisierul, pentru a se salva ce am scris in el
            writer.Close();
        }

        void UpdateListBoxWithCurrentState()
        {
            // Intai stergem ce avem deja in listbox
            listBox1.Items.Clear();
            // Si apoi adaugam valorile noi
            listBox1.Items.Add($"Player X has won {state.gamesWonByX} times.");
            listBox1.Items.Add($"Player O has won {state.gamesWonByO} times.");
        }

        void DisableAllButtons()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Enabled = false;
                }
        }

        void ResetGame()
        {
            player = "X"; // Jocurile incep cu jucatorul X
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    // La inceput, toate butoanele sunt enabled si textul din ele este gol
                    buttons[i, j].Enabled = true;
                    buttons[i, j].Text = "";
                }
        }
    }
}
