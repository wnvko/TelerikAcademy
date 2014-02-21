namespace SayDigit
{
    using System;

    class SayDigit
    {
        static void Main()
        {
            /*
             * Write program that asks for a digit and depending on the input
             * shows the name of that digit (in English) using a switch statement.
             */
            
            Console.Write("Please enter a digit: ");
            byte digit = byte.Parse(Console.ReadLine());
            switch (digit)
            {
                case 0: Console.WriteLine("This is zero"); break;
                case 1: Console.WriteLine("This is one"); break;
                case 2: Console.WriteLine("This is two"); break;
                case 3: Console.WriteLine("This is three"); break;
                case 4: Console.WriteLine("This is four"); break;
                case 5: Console.WriteLine("This is five"); break;
                case 6: Console.WriteLine("This is six"); break;
                case 7: Console.WriteLine("This is seven"); break;
                case 8: Console.WriteLine("This is eight"); break;
                case 9: Console.WriteLine("This is nine"); break;
                default: Console.WriteLine("{0} is not digit", digit); break;
            }
        }
    }
}
