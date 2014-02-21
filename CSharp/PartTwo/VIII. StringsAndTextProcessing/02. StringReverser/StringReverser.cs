/*
 * Write a program that reads a string, reverses it and prints
 * the result at the console. Example: "sample"  "elpmas".
 */

namespace StringReverser
{
    using System;
    using System.Text;

    public class StringReverser
    {
        public static void Main()
        {
            Console.Write("Enter a string: ");
            string userInput = Console.ReadLine();
            StringBuilder reversetText = new StringBuilder();

            for (int counter = userInput.Length - 1; counter >= 0; counter--)
            {
                reversetText.Append(userInput[counter]);
            }

            Console.WriteLine("Your input is {0}", userInput);
            Console.WriteLine("Reversed text is {0}", reversetText.ToString());
        }
    }
}
