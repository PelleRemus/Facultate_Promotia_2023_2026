using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Partial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exercitiul 3
            int m = int.Parse(Console.ReadLine());

            // facem un lant de la primul nod pana la nodul m
            // (pentru a fi tare cone cu numar minim de muchii)
            // 1 -> 2, 2 -> 3, ... m-1 -> m
            for (int i = 0; i < m - 1; i++)
            {
                Console.WriteLine($"{i + 1} -> {i + 2}");
            }
            // facem inca o muchie intre antepenultimul si ultimul nod
            // (pentru a 3-a culoare)
            Console.WriteLine($"{m - 2} -> {m}");
            Console.ReadKey();
        }

        // Exercitiul 4
        public static void Arbore(int[,] adiacenta)
        {
            int n = adiacenta.GetLength(0);
            bool[] vizitate = new bool[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (adiacenta[i, j] != 0)
                    {
                        if (vizitate[i] && vizitate[j])
                        {
                            Console.WriteLine($"{i + 1} -> {j + 1}");
                        }
                        vizitate[i] = true;
                        vizitate[j] = true;
                    }
                }
            }
        }
    }
}
