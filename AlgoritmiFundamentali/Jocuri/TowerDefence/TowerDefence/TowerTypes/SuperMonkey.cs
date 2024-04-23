using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class SuperMonkey : Tower
    {
        public static Button button;

        public SuperMonkey(Point location)
            : base(location, Color.Blue, 50, 100, 280) // Epic Range: 480
        { }

        public static void InitializeButton()
        {
            button = new Button();
            button.Parent = Form1.Instance.panel1;
            button.Location = new Point(265, 200);
            button.Size = new Size(65, 65);
            button.BackColor = Color.Blue;
            button.KeyDown += Form1.Instance.Control_KeyDown;
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new SuperMonkey(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
