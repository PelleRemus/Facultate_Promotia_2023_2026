using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public static class Engine
    {
        public static int n, m;
        public static int nrOfMines;
        public static Tile[,] tiles;
        public static Random random;

        public static void Initialise(int lines, int columns)
        {
            n = lines; m = columns;
            nrOfMines = n * m / 7;
            tiles = new Tile[n, m];
            random = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    tiles[i, j] = new Tile(i, j);
                }
        }

        public static void StartNewGame()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    tiles[i, j].ResetTile();
                }

            for (int i = 0; i < nrOfMines; i++)
            {
                GenerateNewMine();
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    for (int k = i - 1; k <= i + 1; k++)
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            if (k >= 0 && l >= 0 && k < n && l < m && tiles[k, l].IsMine)
                                tiles[i, j].Value++;
                        }
                }
        }

        public static void GenerateNewMine()
        {
            int i, j;
            do
            {
                i = random.Next(n);
                j = random.Next(m);
            } while (tiles[i, j].IsMine);

            tiles[i, j].IsMine = true;
        }

        public static void DepthTraversal(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < m && !tiles[i, j].IsUncovered)
            {
                tiles[i, j].Traverse();
                if (tiles[i, j].Value == 0)
                {
                    DepthTraversal(i - 1, j); // In sus
                    DepthTraversal(i, j + 1); // In dreapta
                    DepthTraversal(i + 1, j); // In jos
                    DepthTraversal(i, j - 1); // In stanga
                }
            }
        }
    }
}
