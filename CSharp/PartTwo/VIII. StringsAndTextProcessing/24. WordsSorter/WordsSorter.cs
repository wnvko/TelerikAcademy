/*
 * Write a program that reads a list of words, separated
 * by spaces and prints the list in an alphabetical order.
 */

namespace WordsSorter
{
    using System;

    public class WordsSorter
    {
        public static void Main()
        {
            string textToCheck = "Write a program that reads a list of words separated by spaces and prints the list in an alphabetical order";
            Console.WriteLine(textToCheck);
            
            string[] checkedText = textToCheck.Split(' ');
            Array.Sort(checkedText);

            foreach (string word in checkedText)
            {
                Console.WriteLine(word);
            }
        }
    }
}
