using System.Collections.Generic;

namespace Graph
{
    public static partial class Graph
    {
        public static void Kruskal()
        {
            // Step 1: Sort edges by cost
            edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));

            // Step 2: Initialize disjoint sets (Union-Find)
            int[] parent = new int[vertices.Count];
            int[] rank = new int[vertices.Count];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i; // Each vertex is its own parent initially
                rank[i] = 0;   // Rank is initially 0 for all vertices
            }

            List<Edge> mstEdges = new List<Edge>();

            // Step 3: Process edges in ascending order of cost
            foreach (Edge edge in edges)
            {
                int root1 = Find(parent, edge.start.value - 1);
                int root2 = Find(parent, edge.end.value - 1);

                // If roots are different, adding this edge doesn't form a cycle
                if (root1 != root2)
                {
                    mstEdges.Add(edge);
                    Union(parent, rank, root1, root2);
                }

                // Stop if we've already got n-1 edges in MST
                if (mstEdges.Count == vertices.Count - 1)
                    break;
            }

            // Update the graph with the MST edges
            edges = mstEdges;
        }

        // Helper function for Union-Find: Find with path compression
        private static int Find(int[] parent, int vertex)
        {
            if (parent[vertex] != vertex)
                parent[vertex] = Find(parent, parent[vertex]);
            return parent[vertex];
        }

        // Helper function for Union-Find: Union by rank
        private static void Union(int[] parent, int[] rank, int root1, int root2)
        {
            if (rank[root1] > rank[root2])
            {
                parent[root2] = root1;
            }
            else if (rank[root1] < rank[root2])
            {
                parent[root1] = root2;
            }
            else
            {
                parent[root2] = root1;
                rank[root1]++;
            }
        }
    }
}
