using System;

class Program
{
    static void Main()
    {
        long factorial = 1;
        Console.Write("Enter number ");
        int length = int.Parse(Console.ReadLine()); ;
        for (int i = 1; i <= length; i++)
        {
            factorial = factorial * i;
        }
        Console.WriteLine("Factorial of {0} = {1}", length, factorial);
        int zeros = 0;
        long divider = 10;
        for (int j = 1; j < factorial.ToString().Length; j++)
        {
            if (factorial % divider == 0)
            {
                divider = divider * 10;
                ++zeros;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine("Trailing 0's = {0}", zeros);

    }

    
}