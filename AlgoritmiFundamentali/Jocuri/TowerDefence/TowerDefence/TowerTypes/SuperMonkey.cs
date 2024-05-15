using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class SuperMonkey : Tower
    {
        static readonly Image image = Image.FromFile("../../Images/SuperMonkey.png");
        public static Button button;

        public SuperMonkey(Point location)
            : base(location, image, 70, 110, 350)
        { }

        public static void InitializeButton()
        {
            button = new Button();
            Form1.InitializeButton(button, image, new Point(265, 200));
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new SuperMonkey(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
