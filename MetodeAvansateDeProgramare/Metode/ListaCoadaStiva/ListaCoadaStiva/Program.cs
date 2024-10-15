using System;

namespace ListaCoadaStiva
{
    class Program
    {
        static void Main(string[] args)
        {
            Coada coada = new Coada();
            coada.AdaugareFinal(1);
            coada.AdaugareFinal(2);
            coada.AdaugareFinal(3);
            coada.AdaugareFinal(4);

            Console.WriteLine(coada.StergereInceput());
            Console.WriteLine(coada.ToString());
            Console.WriteLine();

            Stiva stiva = new Stiva();
            stiva.AdaugareFinal(1);
            stiva.AdaugareFinal(2);
            stiva.AdaugareFinal(3);
            stiva.AdaugareFinal(4);

            Console.WriteLine(stiva.StergereFinal());
            Console.WriteLine(stiva.StergereFinal());
            Console.WriteLine(stiva.ToString());
            Console.WriteLine();

            Lista lista = new Lista();
            lista.AdaugareOrdonata(2);
            lista.AdaugareOrdonata(1);
            lista.AdaugareOrdonata(5);
            lista.AdaugareOrdonata(6);
            lista.AdaugareOrdonata(4);
            lista.AdaugareOrdonata(3);
            Console.WriteLine(lista.ToString());
            Console.ReadKey();
        }
    }
}
