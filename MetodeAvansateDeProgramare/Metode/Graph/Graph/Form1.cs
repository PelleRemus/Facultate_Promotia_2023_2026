using System;
using System.Reflection;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graph.Initialize(this);
            Graph.ReadFromFile("../../Input.txt");
            Graph.DisplayGraph();
            Graph.ColorMap();
            Graph.ComponenteTareConexe();
            Graph.EsteEulerian();
            Graph.EsteHamiltonian();
            //Graph.DepthFirstSearch();
            //Graph.BreadthFirstSearch();

            Graph.DrawGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph.index++;
            if (Graph.index >= Graph.drumuriHamiltoniene.Count)
            {
                Graph.index = 0;
            }
            for (int i = 0; i < Graph.n; i++)
            {
                Graph.drumuriHamiltoniene[Graph.index][i].color = Graph.colors[i];
            }
            Graph.DrawGraph();
        }
    }
}
