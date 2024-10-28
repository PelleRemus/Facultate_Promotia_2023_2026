﻿using System;
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
            Graph.DepthFirstSearch();
            Graph.BreadthFirstSearch();
        }
    }
}
