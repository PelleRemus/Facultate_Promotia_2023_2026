using System;
using System.Linq;
using System.Windows.Forms;

namespace TowerDefence
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
            panel1.Height = Height - 100;

            Engine.Initialize();
            Engine.Draw();
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        // Timer este o componenta a formularelor care apeleaza metoda la un interval fix.
        // Intervalul are valoarea initiala 100 (milisecunde), dar am setat-o la 10 pentru a executa codul mai des
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Pentru fiecare balon, il miscam mai departe in path,
            // dar doar daca este timpul sa fie spawned
            foreach (Bloon bloon in Engine.bloons.ToList())
                if (bloon.SpawnTime <= Engine.time)
                    bloon.Move();
            // De fiecare data cand facem modificari, vrem sa le afisam
            Engine.Draw();
            Engine.time++;
        }
    }
}
