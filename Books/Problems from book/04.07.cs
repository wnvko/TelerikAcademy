using System;

namespace BookHomeworks
{
    class Chapter04Problem07
    {
        static void Main(string[] args)
        {
            int [] number = new int[6];
            for (int i = 1; i <= 5; i++)
            {
                bool isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Въведете число №{0}", i);
                    string userInput = Console.ReadLine();
                    isNumber = Int32.TryParse(userInput, out number[i]);
                }
            }
            Console.WriteLine("Сумата на числата е " + (number[1] + number[2] + number[3] + number[4] + number[5]));
        }
    }
}
