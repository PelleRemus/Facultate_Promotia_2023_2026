using System;
using System.Collections.Generic;

namespace Partial
{
    // Eercitiul 1
    public static class Parcurgeri
    {
        public static int n;
        public static int[,] adiacenta;
        public static bool[] vizitate;
        public static void ParcurgereAdancime(int[,] adiacenta)
        {
            Parcurgeri.adiacenta = adiacenta;
            n = adiacenta.GetLength(0);
            vizitate = new bool[n];
            ParcurgereAdancimeRecursiv(6); // nodul al 7-lea are indicele 6
        }

        // Explicatia pe cod:
        // Parcurgerea in adancime este un procedeu recursiv care ajunge sa parcurga
        // toate nodurile inlantuite cu nodul sursa. pentru fiecare nod cu care se apeleaza
        // metoda, punem vectorul boolean de vizitate pe true pe pozitia respectiva.
        // Pentru a vedea rezultatele (ordinea in care s-au parcurs nodurile), afisam nodul curent.
        // Facem un for pana la n (numarul de noduri al grafului), in care, pentru fiecare i,
        // verificam in primul rand, ca nodul i sa nu fi fost parcurs / vizitat pana acum
        // (pentru a evita ciclurile infinite), iar in al doilea rand, verificam daca exista muchie
        // intre nodul curent si nodul i (folosind matricea de adiacenta, pe pozitia nodului curent
        // si i) (valoarea trebuie sa fie diferita de 0), caz in care apelam din nou
        // metoda pentru parcurdere in adancime, de data aceasta, cu nodul i.
        //
        // Explicatia efectului parcurgerii:
        // Parcurgerea in adancime parcurge intai primul vecin al fiecarui nod cu care este
        // apelata metoda, pana cand nu mai este niciun vecin nevizitat, dupa care revine la 
        // nodurile deja vizitate si trece mai departe la urmatorii vecini, pana cand
        // am parcurs intreaga componenta conexa din care face parte nodul sursa.
        public static void ParcurgereAdancimeRecursiv(int nodSursa)
        {
            vizitate[nodSursa] = true;
            Console.WriteLine(nodSursa + 1);
            for (int i = 0; i < n; i++)
            {
                if (!vizitate[i] && adiacenta[nodSursa, i] != 0)
                {
                    ParcurgereAdancimeRecursiv(i);
                }
            }
        }

        // Explicatia pe cod:
        // Ne cream o coada in care adaugam nodul sursa. In acelasi timp, punem vectorul
        // boolean de vizitate pe true pe pozitia nodului sursa. Cat timp avem noduri introduse
        // in coada, luam urmatorul element din coada, il afisam, si parcurgem folosind un for
        // toate valorile pana la n (numarul de noduri al grafului), iar pentru fiecare i,
        // verificam daca nodul i nu a mai fost vizitat pana acum (folosind vectorul boolean)
        // si daca avem legatura in matricea de adiacenta cu nodul curent. Daca sunt indeplinite
        // conditiile, adaugam nodul i in coada si punem vectorul boolean de vizitate pe true
        // pe poitia nodului i. (daca nu punem pe true aici, e posibil sa fie adaugat in coada de mai multe ori)
        //
        // Explicatia efectului parcurgerii:
        // Deoarece adaugam toti vecinii nodului curent in coada inainte sa trecem la urmatorul
        // pas (extragerea urmatorului nod din coada), intai se vor parcurge toate nodurile vecine cu
        // nodul curent inainte sa se treaca la cevinii acestora.
        public static void ParcurgereLatime(int[,] adiacenta)
        {
            Parcurgeri.adiacenta = adiacenta;
            n = adiacenta.GetLength(0);
            vizitate = new bool[n];

            Queue<int> coada = new Queue<int>();
            coada.Enqueue(6); // nodul al 7-lea are indicele 6
            vizitate[6] = true;

            while (coada.Count > 0)
            {
                int nodCurent = coada.Dequeue();
                Console.WriteLine(nodCurent + 1);
                for (int i = 0; i < n; i++)
                {
                    if (!vizitate[i] && adiacenta[nodCurent, i] != 0)
                    {
                        coada.Enqueue(i);
                        vizitate[i] = true;
                    }
                }
            }
        }
    }
}
