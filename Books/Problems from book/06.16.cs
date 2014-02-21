using System;

namespace ConsoleApplication
{
    class Chapter06Problem16
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете броя на числата: ");
            int count = int.Parse(Console.ReadLine());
            int[] numbers = new int[count];
            int i, bufer, random1, random2;
            Random rand = new Random();
            for (i = 0; i < count; i++)
            {
                numbers[i] = i + 1;
                Console.WriteLine(numbers[i]);
            }
            i = 0;
            while (i < count * count)
            {
                random1 = rand.Next(count);
                random2 = rand.Next(count);
                bufer = numbers[random1];
                numbers[random1] = numbers[random2];
                numbers[random2] = bufer;
                i++;
            }
            for (i = 0; i < count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}