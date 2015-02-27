/*
 * Write a method that asks the user for his name and prints “Hello, <name>”. Write a program to
 * test this method.
 */

using System;

public static class SayHello
{
    public static void Main()
    {
        Console.Write("Enter a name: ");
        string name = Console.ReadLine();
        PrintHello(name);
    }

    private static void PrintHello(string name)
    {
        Console.WriteLine("Hello {0}", name);
    }
}
