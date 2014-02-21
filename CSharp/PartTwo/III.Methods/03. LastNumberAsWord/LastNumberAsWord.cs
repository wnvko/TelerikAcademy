/*Write a method that returns the last digit of given integer as
 * an English word.
 * Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".
 */

namespace LastNumberAsWord
{
    using System;
    class LastNumberAsWord
    {
        static string SayDigit(int input)
        {
            string result = "";
            switch (input)
            {
                case 1: result = "One"; break;
                case 2: result = "Two"; break;
                case 3: result = "Three"; break;
                case 4: result = "Four"; break;
                case 5: result = "Five"; break;
                case 6: result = "Six"; break;
                case 7: result = "Seven"; break;
                case 8: result = "Eight"; break;
                case 9: result = "Nine"; break;
                case 0: result = "Zero"; break;
                default: break;
            }
            return result;
        }

        static void SayLastDigit(int input)
        {
            int lastDigit = input % 10;
            Console.WriteLine("\nThe last digit of {0} is \"{1}\"", input, SayDigit(lastDigit));
        }
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());

            SayLastDigit(number);
        }
    }
}