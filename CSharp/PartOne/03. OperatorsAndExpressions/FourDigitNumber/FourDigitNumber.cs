namespace FourDigitNumber
{
    using System;
    using System.Linq;

    public class FourDigitNumber
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a four digit integer: ");
            int number = int.Parse(Console.ReadLine());
            int sumOfDigits = number.ToString().Sum(c => c - '0');
            Console.WriteLine("Sum of digits {0}", sumOfDigits);

            int reversed = int.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()));
            Console.WriteLine("Reversed {0}", reversed);
            int lastDigitInFront = int.Parse(number.ToString()[3].ToString() + number.ToString()[0] + number.ToString()[1] + number.ToString()[2]);
            Console.WriteLine("Last digit in front {0}", lastDigitInFront);

            int secondAndThirdDigitsExchanged = int.Parse(number.ToString()[0].ToString() + number.ToString()[2] + number.ToString()[1] + number.ToString()[3]);
            Console.WriteLine("Second and third digit exchanged {0}", secondAndThirdDigitsExchanged);
        }
    }
}
