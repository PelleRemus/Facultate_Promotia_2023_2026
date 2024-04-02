using System;

namespace The_2048_Game
{
    public static class Engine
    {
        public static int n = 4;                    // Jocul are dimensiunea 4x4
        public static Tile[,] tiles;                // Tile-urile afisate
        public static Random random = new Random(); // Genereaza valori la intamplare
        public static bool isInFreeplay = false;    // Determina daca ai castigat deja si vrei sa continui
        public static bool hasStarted = false;      // Pentru a verifica daca am apasat cel putin o data butonul de start

        public static void Initialize()
        {
            tiles = new Tile[n, n];
            Tile.size = (Form1.Instance.panel1.Width - 20) / n - 10; // Calculam size-ul picturebox-urilor. Scadem pixelii ce vor ramane spatiu liber intre tile-uri
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    tiles[i, j] = new Tile(Form1.Instance.panel1, Tile.size, i, j);
                }
        }

        public static void NewGame()
        {
            isInFreeplay = false; // In cazul in care eram deja in freeplay cand apasam butonul
            hasStarted = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    tiles[i, j].Value = 0; // Reinitializam toate valorile din matrice
                }
            GenerateNewTile();
            GenerateNewTile(); // Si generam doua tile-uri noi
            Render();
        }

        public static void GenerateNewTile()
        {
            int i, j;
            do
            {
                i = random.Next(n);
                j = random.Next(n);           // Luam valori la intamplare pt indicii din matrice 
            } while (tiles[i, j].Value != 0); // Si repetam atata timp cat suntem pe un tile care are deja valoare

            tiles[i, j].Value = 1;            // Pentru a nu suprascrie o valoare existenta
            // Vom pune in matricea de values puterea lui 2 a valorii care trebuie afisate
            // Adica pentru 2, avem 1, pentru 4 avem 2, pentru 8 avem 3...
        }

        public static void Render()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    tiles[i, j].Render();
                }
        }

        public static bool HasWon()
        {
            // Cautam in toata matricea valoarea 2048 (sau mai mare, just to be safe)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (tiles[i, j].Value > 10) // 2 la puterea 11 = 2048
                    {
                        return true;
                    }
            return false;
        }

        public static bool MoveLeft()
        {
            bool hasMoved = false;
            for (int i = 0; i < n; i++)
                for (int j = 1; j < n; j++)
                    if (tiles[i, j].Value != 0) // Nu are rost sa incercam sa mutam "tile-urile" goale
                    {
                        int index = j; // Incepem de la coloana curenta
                                       // Si, cat timp in stanga avem valoarea 0
                        while (index > 0 && tiles[i, index - 1].Value == 0)
                        {
                            tiles[i, index - 1].Value = tiles[i, index].Value; // Mutam valoarea curenta in stanga
                            tiles[i, index].Value = 0; // Si o stergem de pe coloana pe care a fost
                            index--;
                            hasMoved = true;
                        }
                    }
            return hasMoved;
        }
        public static bool CombineLeft()
        {
            bool hasCombined = false;
            for (int i = 0; i < n; i++)
                for (int j = 1; j < n; j++)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (tiles[i, j].Value != 0 && tiles[i, j].Value == tiles[i, j - 1].Value)
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        tiles[i, j - 1].Value++;
                        tiles[i, j].Value = 0;
                        hasCombined = true;
                    }
                }
            return hasCombined;
        }

        public static bool MoveRight()
        {
            bool hasMoved = false;
            for (int i = 0; i < n; i++)
                for (int j = n - 2; j >= 0; j--)
                    if (tiles[i, j].Value != 0) // Nu are rost sa incercam sa mutam "tile-urile" goale
                    {
                        int index = j; // Incepem de la coloana curenta
                                       // Si, cat timp in dreapta avem valoarea 0
                        while (index < n - 1 && tiles[i, index + 1].Value == 0)
                        {
                            tiles[i, index + 1].Value = tiles[i, index].Value; // Mutam valoarea curenta in dreapta
                            tiles[i, index].Value = 0; // Si o stergem de pe coloana pe care a fost
                            index++;
                            hasMoved = true;
                        }
                    }
            return hasMoved;
        }
        public static bool CombineRight()
        {
            bool hasCombined = false;
            for (int i = 0; i < n; i++)
                for (int j = n - 2; j >= 0; j--)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (tiles[i, j].Value != 0 && tiles[i, j].Value == tiles[i, j + 1].Value)
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        tiles[i, j + 1].Value++;
                        tiles[i, j].Value = 0;
                        hasCombined = true;
                    }
                }
            return hasCombined;
        }

        public static bool MoveUp()
        {
            bool hasMoved = false;
            for (int i = 1; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (tiles[i, j].Value != 0) // Nu are rost sa incercam sa mutam "tile-urile" goale
                    {
                        int index = i; // Incepem de la linia curenta
                                       // Si, cat timp in sus avem valoarea 0
                        while (index > 0 && tiles[index - 1, j].Value == 0)
                        {
                            tiles[index - 1, j].Value = tiles[index, j].Value; // Mutam valoarea curenta in sus
                            tiles[index, j].Value = 0; // Si o stergem de pe linia pe care a fost
                            index--;
                            hasMoved = true;
                        }
                    }
            return hasMoved;
        }
        public static bool CombineUp()
        {
            bool hasCombined = false;
            for (int i = 1; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (tiles[i, j].Value != 0 && tiles[i, j].Value == tiles[i - 1, j].Value)
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        tiles[i - 1, j].Value++;
                        tiles[i, j].Value = 0;
                        hasCombined = true;
                    }
                }
            return hasCombined;
        }

        public static bool MoveDown()
        {
            bool hasMoved = false;
            for (int i = n - 2; i >= 0; i--)
                for (int j = 0; j < n; j++)
                    if (tiles[i, j].Value != 0) // Nu are rost sa incercam sa mutam "tile-urile" goale
                    {
                        int index = i; // Incepem de la linia curenta
                                       // Si, cat timp in jos avem valoarea 0
                        while (index < n - 1 && tiles[index + 1, j].Value == 0)
                        {
                            tiles[index + 1, j].Value = tiles[index, j].Value; // Mutam valoarea curenta in jos
                            tiles[index, j].Value = 0; // Si o stergem de pe linia pe care a fost
                            index++;
                            hasMoved = true;
                        }
                    }
            return hasMoved;
        }
        public static bool CombineDown()
        {
            bool hasCombined = false;
            for (int i = n - 2; i >= 0; i--)
                for (int j = 0; j < n; j++)
                {
                    // Daca avem consecutiv doua valori egale (diferite de 0)
                    if (tiles[i, j].Value != 0 && tiles[i, j].Value == tiles[i + 1, j].Value)
                    {
                        // Le combinam, adica una din valori creste si cealalta devine 0
                        tiles[i + 1, j].Value++;
                        tiles[i, j].Value = 0;
                        hasCombined = true;
                    }
                }
            return hasCombined;
        }
    }
}
