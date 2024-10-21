using System;

namespace Recursivitate_Backtracking
{
    internal class Program
    {
        static int[] solution;
        static bool[] taken;

        static void Main(string[] args)
        {
            int n = 5;
            /*long factorial = 1;
            for (int i = n; i > 0; i--)
                factorial *= i;

            Console.WriteLine(factorial);*/
            // Console.WriteLine(Factorial(n));

            // Console.WriteLine(Fibonacci(45));
            /*long[] fibonacci = new long[n];
            fibonacci[0] = 1;
            fibonacci[1] = 1;
            for(int i = 2; i < n; i++)
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            Console.WriteLine(fibonacci[n-1]);*/

            // Recursiv(5);

            // Produs cartezian intre n multimi de la 1 la n
            // Pentru n=3:
            // 111, 112, 113, 121, 122, 123, ..., 331, 332, 333
            /*for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                    for (int k = 1; k <= n; k++)
                        Console.WriteLine($"{i}{j}{k}");*/
            /*solution = new int[n];
            ProdusCartezian(n, 0);*/

            // Toate permutarile de dimensiune n
            // Pentru n=3:
            // 123 132 213 231 312 321
            /*for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                    for (int k = 1; k <= n; k++)
                        if (i != j && i != k && j != k)
                        {
                            Console.WriteLine($"{i}{j}{k}");
                        }*/
            /*solution = new int[n];
            taken = new bool[n];
            Permutari(n, 0);*/

            // Toate aranjamentele de dimensiune n luate cate p
            // Pentru n=5 si p=3:
            // 123 124 125 132 134 135 ... 541 542 543
            /*int p = 3;
            solution = new int[p];
            taken = new bool[n];
            Aranjamente(n, 0, p);*/


            // Toate combinarile de dimensiune n luate cate p
            // Pentru n=5 si p=3:
            // 123 124 125 134 135 145 234 235 345
            int p = 3;
            solution = new int[p + 1];
            taken = new bool[n];
            Combinari(n, 1, p);
            Console.ReadKey();
        }

        static long Factorial(int n)
        {
            // Conditia de oprire
            if (n == 0 || n == 1)
                return 1;

            // Pasul recursiv in sine
            long factorial = Factorial(n - 1);
            return n * factorial;
        }

        static long Fibonacci(int n)
        {
            // Conditia de oprire
            if (n == 1 || n == 2)
                return 1;

            // Pasii recursivi in sine
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /*1
         *121
         *1213121
         *121312141213121
         *1213121412131215121312141213121
         */
        static void Recursiv(int n)
        {
            // Conditia de oprire
            if (n == 0)
                return;

            // Pasii recursivi in sine
            Recursiv(n - 1);
            Console.Write(n);
            Recursiv(n - 1);
        }

        static void ProdusCartezian(int n, int k)
        {
            // Conditie de oprire (si afisare)
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(solution[i]);
                Console.WriteLine();
                return;
            }

            // Pasul recursiv
            for (int i = 1; i <= n; i++)
            {
                solution[k] = i;
                ProdusCartezian(n, k + 1);
            }
        }

        static void Permutari(int n, int k)
        {
            // Conditie de oprire (si afisare)
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(solution[i]);
                Console.WriteLine();
                return;
            }

            // Pasul recursiv
            for (int i = 0; i < n; i++)
            {
                if (!taken[i])
                {
                    taken[i] = true;
                    solution[k] = i + 1;
                    Permutari(n, k + 1);
                    taken[i] = false;
                }
            }
        }

        static void Aranjamente(int n, int k, int p)
        {
            // Conditie de oprire (si afisare)
            if (k >= p)
            {
                for (int i = 0; i < p; i++)
                    Console.Write(solution[i]);
                Console.WriteLine();
                return;
            }

            // Pasul recursiv
            for (int i = 0; i < n; i++)
            {
                if (!taken[i])
                {
                    taken[i] = true;
                    solution[k] = i + 1;
                    Aranjamente(n, k + 1, p);
                    taken[i] = false;
                }
            }
        }

        static void Combinari(int n, int k, int p)
        {
            // Conditie de oprire (si afisare)
            if (k > p)
            {
                for (int i = 1; i <= p; i++)
                    Console.Write(solution[i]);
                Console.WriteLine();
                return;
            }

            // Pasul recursiv
            for (int i = solution[k - 1]; i < n; i++)
            {
                if (!taken[i])
                {
                    taken[i] = true;
                    solution[k] = i + 1;
                    Combinari(n, k + 1, p);
                    taken[i] = false;
                }
            }
        }
    }
}
