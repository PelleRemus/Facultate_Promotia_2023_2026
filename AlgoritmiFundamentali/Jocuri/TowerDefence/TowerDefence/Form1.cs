using System;
using System.Drawing;
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

        Bitmap bitmap;
        Graphics graphics;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Bloon bloon in Engine.bloons)
                if(bloon.SpawnTime <= Engine.time)
                    bloon.Move();
            Engine.Draw();
            Engine.time++;
        }
    }
}
