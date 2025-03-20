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

        public static LibraryContext dbContext = new LibraryContext("Server=localhost;Database=biblioteca;Trusted_Connection=True;TrustServerCertificate=true;");

        public static void AfisareCarti()
        {
            for (int i = 0; i < carti.Count; i++)
            {
                AfisareOCarte(i);
            }
        }

        public static void AfisareOCarte(int index)
        {
            Console.WriteLine(index + ". " + carti[index]);
        }

        public static void EditareCarte(int index, string titluNou)
        {
            Console.WriteLine($"Actualiarea cartii '{carti[index]}'...");
            carti[index] = titluNou;
            Console.WriteLine("Actualizare cu succes! noua carte:");
            AfisareOCarte(index);
        }

        public static void AdaugareCarte(string titlu)
        {
            carti.Add(titlu);
            Console.WriteLine("Adaugare cu succes! Noua carte:");
            AfisareOCarte(carti.Count() - 1);
        }

        public static void StergereCarte(int index)
        {
            Console.WriteLine("Se sterge cartea:");
            AfisareOCarte(index);
            carti.RemoveAt(index);
            Console.WriteLine("Stergere cu succes!");
        }
    }
}
