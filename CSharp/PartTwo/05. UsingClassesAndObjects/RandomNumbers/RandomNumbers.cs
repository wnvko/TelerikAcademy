/*
 * Write a program that generates and prints to the console 10 random values in the range [100, 200].
 */

using System;

public class RandomNumbers
{
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        int randomNumber = new int();
        for (int index = 0; index < 10; index++)
        {
            randomNumber = random.Next(100, 201);
            Console.WriteLine(randomNumber);
        }
    }
}
