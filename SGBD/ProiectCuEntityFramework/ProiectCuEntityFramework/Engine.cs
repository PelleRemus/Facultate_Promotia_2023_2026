using ProiectCuEntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCuEntityFramework
{
    public static class Engine
    {
        public static List<string> carti = new List<string>
        {
            "Capra cu 3 iezi",
            "Ultima noapte de dragoste, intaia noapte de razboi",
            "Maitreyi",
            "Ion",
        };
        public static List<string> autori = new List<string>
        {
            "Ion Creanga",
            "Camil Petrescu",
            "Mircea Eliade",
            "Liviu Rebreanu",
        };

        public static LibraryContext dbContext;

        public static void AfisareCarti()
        {
            var carti = dbContext.Books.ToList();
            for (int i = 0; i < carti.Count; i++)
            {
                Console.WriteLine(carti[i]);
            }
        }

        public static void AfisareOCarte(int id)
        {
            var book = dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                Console.WriteLine("Cartea nu exista!");
                return;
            }
            Console.WriteLine(book);
        }

        public static void EditareCarte(int id, Book newBook)
        {
            Console.WriteLine($"Actualiarea cartii cu id-ul {id}...");
            Book dbBook = dbContext.Books.FirstOrDefault(b => b.Id == id);

            dbBook.Title = newBook.Title;
            dbBook.Description = newBook.Description;
            dbBook.AuthorId = newBook.AuthorId;
            dbBook.Publisher = newBook.Publisher;

            dbContext.SaveChanges();
            Console.WriteLine("Actualizare cu succes!");
        }

        public static void AdaugareCarte(Book book)
        {
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
            Console.WriteLine("Adaugare cu succes!");
        }

        public static void StergereCarte(int index)
        {
            Console.WriteLine("Se sterge cartea:");
            AfisareOCarte(index);
            carti.RemoveAt(index);
            Console.WriteLine("Stergere cu succes!");
        }

        public static void AdaugarePersoana(Person person)
        {
            dbContext.People.Add(person);
            dbContext.SaveChanges();
            Console.WriteLine("Adaugare cu succes!");
        }
    }
}
