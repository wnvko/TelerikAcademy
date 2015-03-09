/*
 * Write a program that reverses the words in given sentence.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class ReverseSentence
{
    public static void Main()
    {
        string userInput = TakeUserInput("Enter a string: ");

        StringBuilder output = CreateReverseSentence(userInput);

        Console.WriteLine(output);
    }

    private static StringBuilder CreateReverseSentence(string userInput)
    {
        Stack<string> wordsStack = GetWords(userInput);
        Queue<string> symbols = GetSymbols(userInput);
        
        StringBuilder output = new StringBuilder();
        while (wordsStack.Count != 0 && symbols.Count != 0)
        {
            output.Append(wordsStack.Pop());
            output.Append(symbols.Dequeue());
        }
        
        return output;
    }

    private static Stack<string> GetWords(string userInput)
    {
        Stack<string> wordsStack = new Stack<string>();
        Regex words = new Regex(@"[\w#+]+");
        foreach (Match match in words.Matches(userInput))
        {
            wordsStack.Push(match.ToString());
        }

        return wordsStack;
    }

    private static Queue<string> GetSymbols(string userInput)
    {
        Queue<string> symbols = new Queue<string>();
        Regex symbol = new Regex(@"[^\w#+]+");
        foreach (Match match in symbol.Matches(userInput))
        {
            symbols.Enqueue(match.ToString());
        }

        return symbols;
    }

    private static string TakeUserInput(string adviseString)
    {
        Console.WriteLine(adviseString);
        string input = Console.ReadLine();
        return input;
    }
}
