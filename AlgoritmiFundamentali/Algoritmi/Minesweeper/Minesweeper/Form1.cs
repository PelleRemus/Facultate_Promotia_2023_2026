using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        // Modul prin care vom accesa obiectul de Form1 creat din exteriorul clasei
        // (In interiorul clasei, putem face deja asta folosind cuvantul cheie "this")
        public static Form1 Instance;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Instance = this;
            // Calculam numarul de linii si de coloane in functie de dimensiunile panoului
            // Si in functie de dimensiunea pe care o dorim pentru tile-uri, salvata in constanta size
            int n = panel1.Height / Tile.size;
            int m = panel1.Width / Tile.size;
            Engine.Initialise(n, m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.StartNewGame();
        }
    }
}
