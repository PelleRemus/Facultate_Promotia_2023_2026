using System;

namespace ReversePolishNotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Verificam daca Stackk merge
            /*Stackk stack = new Stackk();

            stack.AddEnd(3);
            stack.AddEnd(2);
            stack.AddEnd(4);

            for (int i = 0; i < stack.Length; i++)
                Console.Write(stack.Values[i] + " ");

            Console.WriteLine();
            Console.WriteLine(stack.DeleteEnd());

            for (int i = 0; i < stack.Length; i++)
                Console.Write(stack.Values[i] + " ");*/

            Stackk stack = new Stackk();
            string reversePolishNotationEquation = Console.ReadLine();
            string[] elements = reversePolishNotationEquation.Split(' ');

            foreach (string element in elements)
            {
                if (int.TryParse(element, out int value))
                {
                    // Ce se intampla in spatele metodei TryParse(string s, out int result)
                    /*try
                    {
                        result = int.Parse(s);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }*/
                    stack.AddEnd(value);
                }
                else
                {
                    ApplyOperation(stack, element);
                }
            }

            if (stack.Length == 1)
                Console.WriteLine($"Rezultatul operatiei este {stack.DeleteEnd()}");
            else
                Console.WriteLine("Verificati input-ul, ecuatia nu este rezolvabila!");

            Console.ReadKey();
        }

        static void ApplyOperation(Stackk stack, string operation)
        {
            int value2 = stack.DeleteEnd();
            int value1 = stack.DeleteEnd();
            switch (operation)
            {
                case "+": stack.AddEnd(value1 + value2); break;
                case "-": stack.AddEnd(value1 - value2); break;
                case "*": stack.AddEnd(value1 * value2); break;
                case "/": stack.AddEnd(value1 / value2); break;
            }
        }
    }
}
