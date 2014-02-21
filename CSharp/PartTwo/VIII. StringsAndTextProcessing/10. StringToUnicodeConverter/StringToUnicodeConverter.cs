/*
 * Write a program that converts a string to a sequence of C# Unicode
 * character literals. Use format strings.
 * 
 * Sample input:
 * Hi!
 * 
 * Expected output:
 * \u0048\u0069\u0021
 */


namespace StringToUnicodeConverter
{
    using System;

    public class StringToUnicodeConverter
    {
        public static string TakeUserInput(string adviseString)
        {
            Console.WriteLine(adviseString);
            string userExpression = Console.ReadLine();
            return userExpression;
        }

        public static void Main()
        {
            string userInput = TakeUserInput("Enter a string to convert:");
            string output = string.Empty;

            foreach (char character in userInput)
            {
                string temp = "\\u" + Convert.ToInt32(character).ToString("X4");
                output = output + temp;
            }

            Console.WriteLine(output);
        }
    }
}