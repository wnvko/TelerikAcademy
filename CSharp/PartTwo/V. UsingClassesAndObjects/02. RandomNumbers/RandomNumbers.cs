/*
 * Write a program that generates and prints to the
 * console 10 random values in the range [100, 200].
 */

namespace RandomNumbers
{
    using System;

    public class RandomNumbers
    {
        private static Random rnd = new Random();
        
        public static void Main()
        {
            int randomNumber = new int();
            for (int index = 0; index < 10; index++)
            {
                randomNumber = rnd.Next(100, 200);
                Console.WriteLine(randomNumber);
            }
        }
    }
}