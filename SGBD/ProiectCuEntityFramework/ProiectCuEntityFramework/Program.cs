using System;

namespace ProiectCuEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Meniu Principal");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Selectati una din optiunile de mai jos:");
                Console.WriteLine("1. Du-te la meniul cu carti;");
                Console.WriteLine("2. Du-te la meniul cu autori;");
                Console.WriteLine("0. Iesire");
                Console.WriteLine();

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        MeniuCarti();
                        break;
                    case 2:

                        break;
                    case 0:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Optiunea introdusa nu exista!");
                        Console.WriteLine("Apasati orice tasta pentru a reveni la meniul anterior!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MeniuCarti()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Meniu Carti");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Selectati una din optiunile de mai jos:");
                Console.WriteLine("1. Afisati toate cartile din biblioteca;");
                Console.WriteLine("2. Afisati o carte in functie de indice;");
                Console.WriteLine("3. Actualizati titlul unei carti;");
                Console.WriteLine("4. Adaugati o carte;");
                Console.WriteLine("5. Stergeti o carte;");
                Console.WriteLine("0. Inapoi");
                Console.WriteLine();

                int option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Engine.AfisareCarti();
                        break;
                    case 2:
                        Console.WriteLine("Introduceti indexul cartii pe care vreti sa o afisati:");
                        int index = int.Parse(Console.ReadLine());
                        Engine.AfisareOCarte(index);
                        break;
                    case 3:
                        Console.WriteLine("Introduceti indexul cartii pe care vreti sa o editati:");
                        index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Introduceti noul titlu al cartii:");
                        string titlu = Console.ReadLine();
                        Engine.EditareCarte(index, titlu);
                        break;
                    case 4:
                        Console.WriteLine("Introduceti titlul noii carti:");
                        titlu = Console.ReadLine();
                        Engine.AdaugareCarte(titlu);
                        break;
                    case 5:
                        Console.WriteLine("Introduceti indexul cartii pe care vreti sa o stergeti:");
                        index = int.Parse(Console.ReadLine());
                        Engine.StergereCarte(index);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Optiunea introdusa nu exista!");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Apasati orice tasta pentru a reveni la meniul anterior");
                Console.ReadKey();
            }
        }
    }
}
