using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class BombShooter : Tower
    {
        static readonly Image image = Image.FromFile("../../Images/BombShooter.png");
        public static Button button;

        public BombShooter(Point location)
            : base(location, image, 70, 95, 300)
        { }

        public static void InitializeButton()
        {
            button = new Button();
            Form1.InitializeButton(button, image, new Point(200, 200));
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new BombShooter(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
