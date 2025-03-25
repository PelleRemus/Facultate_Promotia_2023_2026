using ProiectCuEntityFramework.Entities;
using System;
using System.Net;

namespace ProiectCuEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new LibraryContextFactory();
            Engine.dbContext = factory.Create();
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
                        MeniuAutori();
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
                        Console.WriteLine("Introduceti id-ul cartii pe care vreti sa o afisati:");
                        int index = int.Parse(Console.ReadLine());
                        Engine.AfisareOCarte(index);
                        break;
                    case 3:
                        Console.WriteLine("Introduceti id-ul cartii pe care vreti sa o editati:");
                        int id = int.Parse(Console.ReadLine());
                        Book newBook = new Book();
                        Console.WriteLine("Introduceti titlul noii carti:");
                        newBook.Title = Console.ReadLine();
                        Console.WriteLine("Introduceti descrierea noii carti:");
                        newBook.Description = Console.ReadLine();
                        Console.WriteLine("Introduceti editura noii carti:");
                        newBook.Publisher = Console.ReadLine();
                        Console.WriteLine("Introduceti id-ul autorului:");
                        newBook.AuthorId = int.Parse(Console.ReadLine());

                        Engine.EditareCarte(id, newBook);
                        break;
                    case 4:
                        Book book = new Book();
                        Console.WriteLine("Introduceti titlul noii carti:");
                        book.Title = Console.ReadLine();
                        Console.WriteLine("Introduceti descrierea noii carti:");
                        book.Description = Console.ReadLine();
                        Console.WriteLine("Introduceti editura noii carti:");
                        book.Publisher = Console.ReadLine();
                        Console.WriteLine("Introduceti id-ul autorului:");
                        book.AuthorId = int.Parse(Console.ReadLine());
                        Engine.AdaugareCarte(book);
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

        static void MeniuAutori()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Meniu Autori");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Selectati una din optiunile de mai jos:");
                Console.WriteLine("4. Adaugati un autor;");
                Console.WriteLine("0. Inapoi");
                Console.WriteLine();

                int option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 4:
                        Person person = new Person();
                        Console.WriteLine("Introduceti numele persoanei:");
                        person.Name = Console.ReadLine();
                        Engine.AdaugarePersoana(person);
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
