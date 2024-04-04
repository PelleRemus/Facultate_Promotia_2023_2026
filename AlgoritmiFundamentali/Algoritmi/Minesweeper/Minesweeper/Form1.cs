using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Instance = this;
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
