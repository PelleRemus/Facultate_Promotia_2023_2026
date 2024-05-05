using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class IceTower : Tower
    {
        public static Button button;

        public IceTower(Point location)
            : base(location, Color.SkyBlue, 50, 58, 120) // Wide Freeze: 150
        { }

        public static void InitializeButton()
        {
            button = new Button();
            button.Parent = Form1.Instance.panel1;
            button.Location = new Point(135, 200);
            button.Size = new Size(65, 65);
            button.BackColor = Color.SkyBlue;
            button.KeyDown += Form1.Instance.Control_KeyDown;
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new IceTower(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
