using System;

namespace Minesweeper
{
    // Clasa Engine reprezinta "motorul" aplicatiei, unde se intampla toate actiunile aplicatiei
    // Este statica deoarece nu avem nevoie decat de unul, si pentru a fi mai simplu
    // (Sa nu ne incurcam cu instantiatul clasei si pentru a ne asigura ca avem aceleasi valori la proprietati in intreaga solutie)
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
            // Ne asiguram ca toate valorile din matrice sunt ca la inceputul rularii aplicatiei
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    tiles[i, j].ResetTile();
                }

            // Intai generam minele
            for (int i = 0; i < nrOfMines; i++)
            {
                GenerateNewMine();
            }

            // dupa care calculam valorile fiecarui tile, in functie de cate mine este inconjurat
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    // Ne uitam la tile-urile inconjuratoare, pe o arie de 3x3 cu tile-ul curent in mijloc
                    for (int k = i - 1; k <= i + 1; k++)
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            // Ne asiguram ca nu iesim cu indicii din matrice, si verificam daca avem mina pe indicele respectiv
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
            } while (tiles[i, j].IsMine); // Asa, ne asiguram ca nu punem o mina pe o pozitie deja luata

            tiles[i, j].IsMine = true;
        }

        public static void DepthTraversal(int i, int j)
        {
            // Verificam sa nu fi ajuns i sau j la o valoare invalida ca si indice,
            // Si ne asiguram ca nu am descoperit deja valoarea tile-ului curent (pentru a evita infinite loops)
            if (i >= 0 && j >= 0 && i < n && j < m && !tiles[i, j].IsUncovered)
            {
                tiles[i, j].Traverse();
                // Dupa traversare, doar daca tile-ul curent este "gol" (0) putem traversa mai departe
                if (tiles[i, j].Value == 0)
                {
                    DepthTraversal(i - 1, j); // Traversam in sus
                    DepthTraversal(i, j + 1); // Traversam in dreapta
                    DepthTraversal(i + 1, j); // Traversam in jos
                    DepthTraversal(i, j - 1); // Traversam in stanga
                }
            }
        }
    }
}
