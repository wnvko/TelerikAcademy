/*
 * Write a program that prints to the console which day of the week is today. Use System.DateTime.
 */

using System;

public class DayOfWeek
{
    public static void Main(string[] args)
    {
        DateTime today = DateTime.Now;
        Console.WriteLine("Today is {0}", today.DayOfWeek);
    }
}
