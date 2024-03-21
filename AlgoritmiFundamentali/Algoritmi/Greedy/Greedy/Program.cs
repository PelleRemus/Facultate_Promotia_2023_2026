using System;

namespace Greedy
{
    internal class Program
    {
        // Problema cu suma de bani
        // Avand o suma de bani, si valorile bancnotelor,
        // trebuie sa ajungem la acea suma folosind cat mai putine bancnote posibil.
        // Afisati numarul de bancnote obtinute
        static int[] bancnote = new int[] { 500, 200, 100, 50, 10, 5, 1 };
        static int suma = 3467;
        static void Main(string[] args)
        {
            /*int count = 0;
            for (int i = 0; i < bancnote.Length; i++)
            {
                int currentCount = suma / bancnote[i];
                count += currentCount;
                suma -= currentCount * bancnote[i];
            }
            Console.WriteLine(count);
            */

            // Subiecte bac 2009, varianta 70, S3, ex. 3
            int maxValue = 0, maxCount = 0, readValue, currValue, currCount = 0;
            readValue = int.Parse(Console.ReadLine());
            currValue = readValue;
            do
            {
                if (currValue == readValue)
                    currCount++;
                else
                {
                    if (currCount > maxCount)
                    {
                        maxCount = currCount;
                        maxValue = currValue;
                    }
                    currCount = 1;
                }
                currValue = readValue;
                readValue = int.Parse(Console.ReadLine());
            } while (readValue != 0);

            Console.WriteLine($"{maxValue} {maxCount}");
            Console.ReadKey();
        }
    }
}
