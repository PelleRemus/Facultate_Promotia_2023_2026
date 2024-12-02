using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmulLuiPrim
{
    internal class Program
    {
        static int n;
        static int[,] adiacenta;
        static bool[] vizitate;

        static void Main(string[] args)
        {
            n = 7;
            adiacenta = new int[,]
            {
                { 0, 7, 0, 5, 0, 0, 0 },
                { 7, 0, 8, 9, 7, 0, 0 },
                { 0, 8, 0, 0, 5, 0, 0 },
                { 5, 9, 0, 0, 15, 6, 0 },
                { 0, 7, 5, 15, 0, 8, 9 },
                { 0, 0, 0, 6, 8, 0, 11 },
                { 0, 0, 0, 0, 9, 11, 0 },
            };
            Afisare(Prim(3));
            Console.ReadKey();
        }

        static int[,] Prim(int startNode)
        {
            int[,] arboreMinim = new int[n, n];
            List<int> solutie = new List<int> { startNode };
            HashSet<int> vecini = Vecini(startNode).ToHashSet();
            vizitate = new bool[n];
            vizitate[startNode] = true;

            while (solutie.Count < n)
            {
                int min = Int32.MaxValue, minVecin = vecini.First(), nodSolutie = startNode;
                foreach (int vecin in vecini)
                {
                    foreach (int nod in solutie)
                        if (VerificaMinimNou(nod, vecin, min))
                        {
                            min = adiacenta[nod, vecin];
                            minVecin = vecin;
                            nodSolutie = nod;
                        }
                }

                solutie.Add(minVecin);
                vizitate[minVecin] = true;
                var temp = Vecini(minVecin);
                foreach (int vecin in temp)
                    if (!solutie.Contains(vecin))
                        vecini.Add(vecin);

                arboreMinim[nodSolutie, minVecin] = min;
                arboreMinim[minVecin, nodSolutie] = min;
            }
            return arboreMinim;
        }

        static List<int> Vecini(int nod)
        {
            List<int> vecini = new List<int>();
            for (int j = 0; j < n; j++)
                if (adiacenta[nod, j] != 0)
                    vecini.Add(j);
            return vecini;
        }

        static bool VerificaMinimNou(int nod, int vecin, int min)
        {
            return adiacenta[nod, vecin] != 0 // verificam daca exista muchie intre nod si vecin
                && adiacenta[nod, vecin] < min // verificam daca muchia gasita are cost mai mic decat minimul curent
                && !vizitate[vecin]; // verificam sa nu eiste deja vecinul gasit in solutia curenta
        }

        static void Afisare(int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
