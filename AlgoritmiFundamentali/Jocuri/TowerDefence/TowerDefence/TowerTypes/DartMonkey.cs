using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class DartMonkey : Tower
    {
        static readonly Image image = Image.FromFile("../../Images/DartMonkey.png");
        public static Button button;

        public DartMonkey(Point location)
            : base(location, image, 70, 95, 250)
        { }

        public static void InitializeButton()
        {
            button = new Button();
            Form1.InitializeButton(button, image, new Point(5, 200));
            button.Click += Button_Click;
        }

        // Cand apasam pe butonul tower-ului, se creaza un nou tower,
        // care este si cel selectat in momentul de fata (pentru a se misca dupa mouse)
        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new DartMonkey(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
