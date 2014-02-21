/*
 * Write a program that reverses the words in given sentence.
 * Example:
 * "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!".
 */

namespace SentenceReverser
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SentenceReverser
    {
        public static string TakeUserInput(string adviseString)
        {
            Console.WriteLine(adviseString);
            string userExpression = Console.ReadLine();
            return userExpression;
        }

        public static void Main()
        {
            string userInput = TakeUserInput("Enter a string: ");
            Stack<string> wordsStack = new Stack<string>();
            Queue<string> symbols = new Queue<string>();

            Regex words = new Regex(@"[\w#+]+");
            foreach (Match match in words.Matches(userInput))
            {
                wordsStack.Push(match.ToString());
            }

            Regex symbol = new Regex(@"[^\w#+]+");
            foreach (Match match in symbol.Matches(userInput))
            {
                symbols.Enqueue(match.ToString());
            }

            StringBuilder output = new StringBuilder();
            while (wordsStack.Count != 0 && symbols.Count != 0)
            {
                output.Append(wordsStack.Pop());
                output.Append(symbols.Dequeue());
            }
            
            Console.WriteLine(output);
        }
    }
}