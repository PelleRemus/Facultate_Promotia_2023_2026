using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Tile
    {
        public const int size = 50;
        public int Line { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsUncovered { get; set; }
        public Button Button { get; set; }

        public Tile(int i, int j)
        {
            Line = i;
            Column = j;
            Button = new Button();

            Button.Parent = Form1.Instance.panel1;
            Button.BackColor = Color.DarkGray;
            Button.Size = new Size(size, size);
            Button.Location = new Point(j * size, i * size);
            Button.Font = new Font("Arial", size / 2, FontStyle.Bold);
            Button.Margin = Padding.Empty;

            Button.Click += Button_Click;
        }

        public void ResetTile()
        {
            Value = 0;
            IsMine = false;
            IsUncovered = false;
            IsFlagged = false;
            Button.BackColor = Color.DarkGray;
            Button.Text = string.Empty;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Engine.DepthTraversal(Line, Column);
        }

        public void Traverse()
        {
            IsUncovered = true;
            Button.BackColor = Color.LightGray;

            if (Value != 0)
                Button.Text = Value.ToString();
            if (IsMine)
            {
                Button.ForeColor = Color.Crimson;
                Button.Text = "X";
            }
        }
    }
}
