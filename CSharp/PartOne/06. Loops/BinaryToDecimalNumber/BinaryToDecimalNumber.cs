namespace BinaryToDecimalNumber
{
    using System;

    public class BinaryToDecimalNumber
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string binNumber = Console.ReadLine();
            double decNumber = 0;

            for (int possition = binNumber.Length - 1; possition >= 0; possition--)
            {
                decNumber += (binNumber[possition] - '0') * Math.Pow(2, binNumber.Length - possition - 1);
            }

            Console.WriteLine(decNumber);
        }
    }
}
