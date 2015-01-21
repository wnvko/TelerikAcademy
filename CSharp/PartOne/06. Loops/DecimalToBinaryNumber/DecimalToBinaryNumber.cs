namespace DecimalToBinaryNumber
{
    using System;

    public class DecimalToBinaryNumber
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int decNumber = int.Parse(Console.ReadLine());
            string binNumber = string.Empty;

            while (decNumber != 0)
            {
                int reminder = decNumber % 2;
                binNumber = reminder + binNumber;
                decNumber /= 2;
            }

            Console.WriteLine(binNumber);
        }
    }
}
