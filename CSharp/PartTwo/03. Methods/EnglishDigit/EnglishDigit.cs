/*
 * Write a method that returns the last digit of given integer as an English word.
 */

using System;
using System.Collections.Generic;

public class EnglishDigit
{
    public static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        var myClass = new EnglishDigit();
        myClass.SayLastDigit(number);
    }

    private void SayLastDigit(int input)
    {
        int lastDigit = input % 10;
        Console.WriteLine("\nThe last digit of {0} is \"{1}\"", input, this.SayDigit(lastDigit));
    }

    private string SayDigit(int input)
    {
        List<string> numberNames = new List<string>() { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", };
        if (0 <= input && input < 10)
        {
            string result = numberNames[input];
            return result;
        }
        else
        {
            return "Are you kidding me!";
        }
    }
}