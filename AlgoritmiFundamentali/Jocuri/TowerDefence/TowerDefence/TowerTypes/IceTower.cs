using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class IceTower : Tower
    {
        static readonly Image image = Image.FromFile("../../Images/IceTower.png");
        public static Button button;

        public IceTower(Point location)
            : base(location, image, 70, 70, 150)
        { }

        public static void InitializeButton()
        {
            button = new Button();
            Form1.InitializeButton(button, image, new Point(135, 200));
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new IceTower(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
