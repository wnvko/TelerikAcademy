namespace IsThirdDigitSeven
{
    using System;

    public class IsThirdDigitSeven
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());

            string result = number.ToString()[number.ToString().Length - 3] == '7' ? "Yes" : "No";
            Console.WriteLine("The third digit of {0} is 7: {1}", number, result);
        }
    }
}
