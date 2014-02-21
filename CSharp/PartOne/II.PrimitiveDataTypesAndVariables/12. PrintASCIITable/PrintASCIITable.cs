namespace PrintASCIITable
{
    using System;

    class PrintASCIITable
    {
        static void Main()
        {
            /*
             * Find online more information about ASCII (American
             * Standard Code for Information Interchange) and write
             * a program that prints the entire ASCII table of characters on the console.
            */
            char currentSymbol;
            for (int i = 0; i < 128; i++)
            {
                currentSymbol = (char)i;
                Console.WriteLine("ASCII symbol No{0} is {1}", i, currentSymbol);
                if ((i != 0) && (i % 20 == 0)) //stop output after each 20 lines
                {
                    Console.ReadLine();
                }
            }
        }
    }
}