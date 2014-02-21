namespace CalculateBonus
{
    using System;

    class CalculateBonus
    {
        static void Main()
        {
            /*
             * Write a program that applies bonus scores to given scores in the range [1..9].
             * The program reads a digit as an input. If the digit is between 1 and 3,
             * the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100;
             * if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value
             * is not a digit, the program must report an error.
             * Use a switch statement and at the end print the calculated new value in the console.
             */

            Console.Write("Please enter a number [1..9]: ");
            string userString = Console.ReadLine();
            int userNumber;
            switch (userString)
            {
                case "1":
                case "2":
                case "3": userNumber = 10*int.Parse(userString); break;
                case "4":
                case "5":
                case "6": userNumber = 100 * int.Parse(userString); break;
                case "7":
                case "8":
                case "9": userNumber = 1000 * int.Parse(userString); break;
                default: userNumber = -1; break;
            }
            if (userNumber > 0)
            {
                Console.WriteLine("Your bonus is {0}", userNumber);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
