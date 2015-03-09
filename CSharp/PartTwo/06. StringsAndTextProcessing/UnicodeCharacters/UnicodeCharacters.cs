/*
 * Write a program that converts a string to a sequence of C# Unicode character literals.
 * Use format strings.
 */

using System;
using System.Text;

public class UnicodeCharacters
{

    public static void Main()
    {
        string userInput = TakeUserInput("Enter a string to convert:");
        StringBuilder output = new StringBuilder();

        foreach (char character in userInput)
        {
            string temp = "\\u" + Convert.ToInt32(character).ToString("X4");
            output.Append(temp);
        }

        Console.WriteLine(output);
    }

    private static string TakeUserInput(string adviseString)
    {
        Console.WriteLine(adviseString);
        string input = Console.ReadLine();
        return input;
    }
}
