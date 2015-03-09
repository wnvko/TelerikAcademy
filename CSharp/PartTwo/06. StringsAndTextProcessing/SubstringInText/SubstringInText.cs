/*
 * Write a program that finds how many times a substring is contained in
 * a given text (perform case insensitive search).
 * Example: The target substring is "in".
 * The text is as follows:
 * We are living in an yellow submarine. We don't have anything else.
 * Inside the submarine is very tight. So we are drinking all the day.
 * We will move out of it in 5 days.
 * 
 * The result is: 9.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class SubstringInText
{
    public static void Main(string[] args)
    {
        string inputString = TakeUserInput("Enter a string to look in: ");
        string lookupString = TakeUserInput("Enter a lookup string: ");
        int repeatCounter = Regex.Matches(inputString, lookupString, RegexOptions.IgnoreCase).Count;
        Console.WriteLine("The string {0} repeats {1} times", lookupString, repeatCounter);
    }

    public static string TakeUserInput(string adviseString)
    {
        Console.Write(adviseString);
        string userExpression = Console.ReadLine();
        return userExpression;
    }
}