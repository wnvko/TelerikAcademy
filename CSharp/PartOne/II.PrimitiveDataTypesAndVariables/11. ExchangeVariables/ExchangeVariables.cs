namespace ExchangeVariables
{
    using System;

    class ExchangeVariables
    {
        static void Main()
        {
            /*
             * Declare two integer variables and assign them with
             * 5 and 10 and after that exchange their values.
            */
            
            int firstVariable = 5;
            int seconVariable = 10;
            Console.WriteLine("First variable value now is {0}", firstVariable);
            Console.WriteLine("Second variable value now is {0}",seconVariable);
            Console.WriteLine();
            
            int buffer = firstVariable; //safe the value of firstVariable
            firstVariable = seconVariable; //firstVariable value is now only in buffer
            seconVariable = buffer;
            
            Console.WriteLine("First variable value is already {0}", firstVariable);
            Console.WriteLine("Second variable value is already {0}", seconVariable);
        }
    }
}