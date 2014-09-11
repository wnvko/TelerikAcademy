// download problem from here http://downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%202.zip

using System;

public class BinaryPasswords
{
    public static void Main()
    {
        string input = Console.ReadLine();
        ulong result = 1;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '*')
            {
                result <<= 1;
            }
        }

        Console.WriteLine(result);
    }
}
