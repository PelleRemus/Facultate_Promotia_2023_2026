using System;

namespace Backtracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 6, p = 3;
            int[] solution = new int[n];
            bool[] existing = new bool[n];
            Combinari(n, p, 1, solution, existing);
            Console.ReadKey();
        }

        static void ProdusCartezian(int n, int index, int[] solution)
        {
            if (index >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(solution[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    solution[index] = i + 1;
                    ProdusCartezian(n, index + 1, solution);
                }
            }
        }

        static void Permutari(int n, int index, int[] solution, bool[] existing)
        {
            if (index >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(solution[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!existing[i])
                    {
                        existing[i] = true;
                        solution[index] = i + 1;
                        Permutari(n, index + 1, solution, existing);
                        existing[i] = false;
                    }
                }
            }
        }

        static void Aranjamente(int n, int length, int index, int[] solution, bool[] existing)
        {
            if (index >= length)
            {
                for (int i = 0; i < length; i++)
                    Console.Write(solution[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!existing[i])
                    {
                        existing[i] = true;
                        solution[index] = i + 1;
                        Aranjamente(n, length, index + 1, solution, existing);
                        existing[i] = false;
                    }
                }
            }
        }

        static void Combinari(int n, int length, int index, int[] solution, bool[] existing)
        {
            if (index > length)
            {
                for (int i = 1; i <= length; i++)
                    Console.Write(solution[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = solution[index - 1] + 1; i < n; i++)
                {
                    if (!existing[i])
                    {
                        existing[i] = true;
                        solution[index] = i;
                        Combinari(n, length, index + 1, solution, existing);
                        existing[i] = false;
                    }
                }
            }
        }
    }
}
