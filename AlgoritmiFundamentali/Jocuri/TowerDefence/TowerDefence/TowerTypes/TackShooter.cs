using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class TackShooter : Tower
    {
        public static Button button;

        public TackShooter(Point location)
            : base(location, Color.Pink, 50, 80, 140) // Extra Range: 160
        { }

        public static void InitializeButton()
        {
            button = new Button();
            button.Parent = Form1.Instance.panel1;
            button.Location = new Point(70, 200);
            button.Size = new Size(65, 65);
            button.BackColor = Color.Pink;
            button.KeyDown += Form1.Instance.Control_KeyDown;
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new TackShooter(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
