using System.Drawing;
using System.Windows.Forms;

namespace TowerDefence.TowerTypes
{
    public class DartMonkey : Tower
    {
        public static Button button;

        public DartMonkey(Point location)
            : base(location, Color.Brown, 50, 80, 200) // Long Range: 250
        { }

        public static void InitializeButton()
        {
            button = new Button();
            button.Parent = Form1.Instance.panel1;
            button.Location = new Point(5, 200);
            button.Size = new Size(65, 65);
            button.BackColor = Color.Brown;
            button.KeyDown += Form1.Instance.Control_KeyDown;
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
