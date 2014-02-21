using System;

namespace BookHomeworks
{
    class Chapter04Problem08
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
            int maxNumber = 0;
            maxNumber = number[1];
            maxNumber = (maxNumber > number[2] ? maxNumber : number[2]);
            maxNumber = (maxNumber > number[3] ? maxNumber : number[3]);
            maxNumber = (maxNumber > number[4] ? maxNumber : number[4]);
            maxNumber = (maxNumber > number[5] ? maxNumber : number[5]);
            Console.WriteLine("Най-голямото от числата е {0}", maxNumber);
        }
    }
}
