/*
 * Write a program that extracts from a given text all sentences containing given word.
 * Example: The word is "in". The text is:
 * We are living in a yellow submarine. We don't have anything else. Inside the
 * submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
 * 
 * The expected result is:
 * We are living in a yellow submarine.
 * We will move out of it in 5 days.
 * 
 * Consider that the sentences are separated by "." and the words – by non-letter symbols.
 */

namespace SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static string TakeUserInput(string inputString)
        {
            Console.WriteLine(inputString);
            string userExpression = Console.ReadLine();
            return userExpression;
        }

        public static void Main(string[] args)
        {
            string userInput = TakeUserInput("Enter a string:");
            string lookupString = TakeUserInput("Enter lookup value:");
            lookupString = @"[\w\s]+\b" + lookupString + @"\b[\s\w]+\.";
            Regex result = new Regex(lookupString);

            foreach (Match match in result.Matches(userInput))
            {
                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}