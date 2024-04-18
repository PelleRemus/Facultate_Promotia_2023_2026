namespace BacktrackingVizual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n;
        int[] solution;
        bool[] existing;
        bool canContinue = false;

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out n))
            {
                solution = new int[n];
                existing = new bool[n];
                await Permutari(n, 0, solution, existing);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canContinue = true;
        }

        private async Task Permutari(int n, int index, int[] solution, bool[] existing)
        {
            indexLabel.Text = "index: " + index;
            if (index >= n)
            {
                string s = GenerateSolutionString();
                listBox1.Items.Add(s);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    iLabel.Text = "i: " + i;
                    if (!existing[i])
                    {
                        existing[i] = true;
                        existingTextBox.Text = GenerateExistingString();
                        solution[index] = i + 1;
                        solutionTextBox.Text = GenerateSolutionString();

                        while (!canContinue)
                            await Task.Delay(1000);
                        canContinue = false;

                        await Permutari(n, index + 1, solution, existing);
                        indexLabel.Text = "index: " + index;
                        existing[i] = false;
                        existingTextBox.Text = GenerateExistingString();
                    }
                }
            }
        }

        private string GenerateSolutionString()
        {
            string s = "";
            for (int i = 0; i < n; i++)
                s += solution[i] + " ";
            return s;
        }

        private string GenerateExistingString()
        {
            string s = "";
            for (int i = 0; i < n; i++)
                s += existing[i].ToString()[0] + " ";
            return s;
        }
    }
}
