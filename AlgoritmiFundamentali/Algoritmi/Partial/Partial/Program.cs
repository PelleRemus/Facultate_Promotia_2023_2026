using System;
using System.IO;
using System.Linq;

namespace Partial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Problema3();
            //Problema4();
        }

        // In fisierul data.in se dau pe mai multe linii numere intregi.
        // Afisati care numar prim apare de cele mai multe ori.
        static void Problema1()
        {
            // Metoda 1
            // TextReader reader = new StreamReader("../../data1.in");
            // string allText = reader.ReadToEnd();
            // allText.Replace(Environment.NewLine, " ");

            // Metoda 2
            string[] lines = File.ReadAllLines("../../data1.in");
            string allText = string.Join(" ", lines);
        }

        // Generati o matrice aleatoare de m, n elemente reale si determinati daca
        // matricea are suma elementelor din coltul din stanga sus egala cu
        // suma elementelor din coltul dreapta jos conform exemplului.
        static void Problema2()
        {

        }

        // Se da un vector de n numere intregi in fisierul data2.in,
        // pe prima linie este n, iar pe a doua linie cele n numere intregi.
        // Afisati in ordine descrescatoare toate numerele din fisier
        // care sunt puteri ale lui 3 sau ale lui 7.
        static void Problema3()
        {
            TextReader reader = new StreamReader("../../data2.in");
            int n = int.Parse(reader.ReadLine());
            string[] strings = reader.ReadLine().Split(' ');
            int[] array = strings.Select(s => int.Parse(s)).ToArray();

            int min = array[0], max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                    min = array[i];
                if (max < array[i])
                    max = array[i];
            }

            int[] frequency = new int[max - min + 1];
            for (int i = 0; i < array.Length; i++)
            {
                frequency[array[i] - min]++;
            }

            for (int i = max - 1; i >= min; i--)
            {
                if (frequency[i - min] != 0)
                {
                    int aux = i, aux2 = i;

                    while (aux > 1 && aux % 3 == 0)
                        aux = aux / 3;
                    while (aux2 > 1 && aux2 % 7 == 0)
                        aux2 = aux2 / 7;

                    if (aux == 1 || aux2 == 1)
                        while (frequency[i - min] != 0)
                        {
                            Console.Write(i + " ");
                            frequency[i - min]--;
                        }
                }
            }
            Console.ReadKey();
        }

        // Dintr-un cub de informatie booleana de dimensiune n, m, o,
        // stabiliti cate valori true sunt pe fetele laterale
        static void Problema4()
        {
            bool[,,] array = new bool[,,] // Asa se declara inline un array de 3 dimensiuni
            {
                {
                    { false, false, false, true },
                    { false, false, true, false },
                    { false, true, false, false },
                    { true, false, false, false },
                },
                {
                    { true, false, false, false },
                    { false, true, false, false },
                    { false, false, true, false },
                    { false, false, false, true },
                },
                {
                    { true, false, false, true },
                    { false, true, true, false },
                    { false, true, true, false },
                    { true, false, false, true },
                },
                {
                    { false, true, false, true },
                    { true, false, true, false },
                    { false, true, false, true },
                    { true, false, true, false },
                },
            };
            int o = array.GetLength(0);
            int n = array.GetLength(1);
            int m = array.GetLength(2);
            int count = 0; // pt array-ul 3D dat, rezultatul ar trebui sa fie 18

            // Pentru matrice patratica (2D)
            /*for (int i = 0; i < n - 1; i++)
            {
                if (array[i, 0]) // stanga
                    count++;
                if (array[0, i]) // sus
                    count++;
                if (array[i, n - 1]) // dreapta
                    count++;
                if (array[n - 1, i]) // jos
                    count++;
            }*/

            // Pentru cub (3D)
            // Avem nevoie de conditii mai lungi la unele if-uri penru a nu repeta valorile deja parcurse
            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (array[0, i, j]) // sus
                        count++;
                    if (array[n - 1, i, j]) // jos
                        count++;
                    // Pentru ca pentru primul indice luam deja toate valorile cand avem 0 si n-1,
                    // indexul i (care este primul dintre indici) nu mai poate lua valorile 0 si n-1.
                    if (array[i, 0, j] && i != 0 && i != n - 1) // spate
                        count++;
                    if (array[i, n - 1, j] && i != 0 && i != n - 1) // fata
                        count++;
                    // Iar aici, il restrictionam si pe j din aceleasi motive
                    if (array[i, j, 0] && i != 0 && i != n - 1 && j != 0 && j != n - 1) // stanga
                        count++;
                    if (array[i, j, n - 1] && i != 0 && i != n - 1 && j != 0 && j != n - 1) // dreapta
                        count++;
                }*/

            // Petru paralelipiped dreptunghic (3D)
            // Trebuie sa separam if-urile 2 cate 2 pe parcurgeri diferite pentru ca dimensiunile array-ului pot fi diferite
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (array[0, i, j]) // sus
                        count++;
                    if (array[n - 1, i, j]) // jos
                        count++;
                }
            // Nu mai avem if-uri lungi, in loc de conditiile de data trecuta, excludem valorile deja parcurse
            // restrictionand valorile de inceput si de final ale for-urilor pe cum este nevoie
            for (int k = 1; k < o - 1; k++)
                for (int j = 0; j < m; j++)
                {
                    if (array[k, 0, j]) // spate
                        count++;
                    if (array[k, n - 1, j]) // fata
                        count++;
                }
            for (int k = 1; k < o - 1; k++)
                for (int i = 1; i < n - 1; i++)
                {
                    if (array[k, i, 0]) // stanga
                        count++;
                    if (array[k, i, n - 1]) // dreapta
                        count++;
                }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
