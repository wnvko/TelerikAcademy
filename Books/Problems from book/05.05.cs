using System;

namespace BookHomeworks
{
    class Chapter05Problem05
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете цифра от 1 - 9: ");
            int numberToSay= int.Parse(Console.ReadLine());
            string sayNumber = "";
            bool errorValue = false;
            switch (numberToSay)
            {
                case 1: sayNumber = "Едно"; break;
                case 2: sayNumber = "Две"; break;
                case 3: sayNumber = "Три"; break;
                case 4: sayNumber = "Четири"; break;
                case 5: sayNumber = "Пет"; break;
                case 6: sayNumber = "Шест"; break;
                case 7: sayNumber = "Седем"; break;
                case 8: sayNumber = "Осем"; break;
                case 9: sayNumber = "Девет"; break;
                default: errorValue = true; break;
            }
            if (errorValue)
            {
                Console.WriteLine("Въведеното число не е в интервала от 1 - 9");
            }
            else
            {
                Console.WriteLine("Въведохте числото " + sayNumber);
            }
        }
    }
}