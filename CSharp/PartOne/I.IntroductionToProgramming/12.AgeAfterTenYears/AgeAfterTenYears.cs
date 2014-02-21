using System;


class AgeAfterTenYears
{
    static void Main(string[] args)
    {
        //* Write a program to read your age from the
        //console and print how old you will be after 10 years
        
        Console.Write("Input how old are you now: ");
        int CurrentAge = int.Parse(Console.ReadLine());
        Console.WriteLine("You will be {0} years old after 10 years", CurrentAge + 10);
    }
}