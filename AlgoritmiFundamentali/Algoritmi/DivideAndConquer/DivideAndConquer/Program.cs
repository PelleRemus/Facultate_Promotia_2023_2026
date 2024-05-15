using System;

namespace DivideAndConquer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine(BinarySearch(array, 0, array.Length, n));
            string[] array = { "apa", "banana", "carte", "mijloc", "zebra" };
            string word = Console.ReadLine();
            Console.WriteLine(SearchInDictionary(array, 0, array.Length, word));
            Console.ReadKey();
        }

        // Se da o lista de numere ordonate.
        // Sa se afle daca un numar n este inclus in aceasta lista
        static bool BinarySearch(int[] array, int left, int right, int n)
        {
            if (left > right)
                return false;

            int middle = (left + right) / 2;
            if (array[middle] == n)
                return true;

            if (array[middle] < n)
                return BinarySearch(array, middle + 1, right, n);
            else
                return BinarySearch(array, left, middle - 1, n);
        }

        // Cum ati cauta un cuvant intr-un dictionar?
        static bool SearchInDictionary(string[] array, int left, int right, string word)
        {
            if (left > right)
                return false;

            int middle = (left + right) / 2;
            if (array[middle].CompareTo(word) == 0)
                return true;

            if (array[middle].CompareTo(word) < 0)
                return SearchInDictionary(array, middle + 1, right, word);
            else
                return SearchInDictionary(array, left, middle - 1, word);
        }
    }
}
