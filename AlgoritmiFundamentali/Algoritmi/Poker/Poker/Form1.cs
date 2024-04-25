using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
            pictureBox1.BackgroundImage = Image.FromFile("../../Images/BackCard.png");
            Engine.Initiaize();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            await Engine.DealAllCards();

            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public PictureBox CreatePictureBoxForNewCard()
        {
            PictureBox card = new PictureBox();
            card.Parent = this;
            card.BackgroundImage = pictureBox1.BackgroundImage;
            card.Location = pictureBox1.Location;
            card.Size = pictureBox1.Size;
            card.BackgroundImageLayout = pictureBox1.BackgroundImageLayout;

            card.BringToFront();
            return card;
        }
    }
}
