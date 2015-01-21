namespace MatrixOfNumbers
{
    using System;

    public
        class MatrixOfNumbers
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputNumber; i++)
            {
                for (int j = i; j < (inputNumber + i); j++)
                {
                    Console.Write("{0,3}", j);
                }

                Console.WriteLine();
            }
        }
    }
}
