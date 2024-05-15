using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class TackShooter : Tower
    {
        static readonly Image image = Image.FromFile("../../Images/TackShooter.png");
        public static Button button;

        public TackShooter(Point location)
            : base(location, image, 70, 80, 175)
        { }

        public static void InitializeButton()
        {
            button = new Button();
            Form1.InitializeButton(button, image, new Point(70, 200));
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new TackShooter(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
