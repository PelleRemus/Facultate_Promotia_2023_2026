using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TowerDefence.TowerTypes;

namespace TowerDefence
{
    public partial class Form1 : Form
    {
        public Point MouseLocation { get; set; }
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

            DartMonkey.InitializeButton();
            TackShooter.InitializeButton();
            IceTower.InitializeButton();
            BombShooter.InitializeButton();
            SuperMonkey.InitializeButton();
        }

        public void Control_KeyDown(object sender, KeyEventArgs e)
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

        // Detectam locatia mouse-ului in momentul in care acesta se misca peste ecran.
        // Aceasta va reprezenta pozitia tower-ului care nu a fost plasat inca, actualizata in timp real
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
            if (Engine.selectedTower != null)
                Engine.selectedTower.Location = MouseLocation;
        }
    }
}
