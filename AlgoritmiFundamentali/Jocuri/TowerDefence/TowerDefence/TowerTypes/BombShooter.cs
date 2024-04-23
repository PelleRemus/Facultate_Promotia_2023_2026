using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class BombShooter : Tower
    {
        public static Button button;

        public BombShooter(Point location)
            : base(location, Color.Black, 50, 90, 240) // Extra Range: 280
        { }

        public static void InitializeButton()
        {
            button = new Button();
            button.Parent = Form1.Instance.panel1;
            button.Location = new Point(200, 200);
            button.Size = new Size(65, 65);
            button.BackColor = Color.Black;
            button.KeyDown += Form1.Instance.Control_KeyDown;
            button.Click += Button_Click;
        }

        private static void Button_Click(object sender, System.EventArgs e)
        {
            Engine.selectedTower = new BombShooter(Form1.Instance.MouseLocation);
            Engine.towers.Add(Engine.selectedTower);
        }
    }
}
