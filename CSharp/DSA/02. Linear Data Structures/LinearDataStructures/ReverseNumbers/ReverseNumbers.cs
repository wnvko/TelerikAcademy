namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    public class ReverseNumbers
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter numbers count N = ");
            int numbersCount = int.Parse(Console.ReadLine());

            Stack<int> inputData = new Stack<int>();
            for (int i = 0; i < numbersCount; i++)
            {
                inputData.Push(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < numbersCount; i++)
            {
                Console.WriteLine(inputData.Pop());
            }
        }
    }
}
