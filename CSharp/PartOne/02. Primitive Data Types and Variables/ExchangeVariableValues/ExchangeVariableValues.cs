namespace ExchangeVariableValues
{
    using System;

    public class ExchangeVariableValues
    {
        public static void Main(string[] args)
        {
            int firstVariable = 5;
            int seconVariable = 10;
            Console.WriteLine("First variable value now is {0}", firstVariable);
            Console.WriteLine("Second variable value now is {0}", seconVariable);
            Console.WriteLine();

            int buffer = firstVariable;
            firstVariable = seconVariable;
            seconVariable = buffer;

            Console.WriteLine("First variable value is already {0}", firstVariable);
            Console.WriteLine("Second variable value is already {0}", seconVariable);
        }
    }
}
