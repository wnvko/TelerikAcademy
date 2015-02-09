namespace BonusScore
{
    using System;

    public class BonusScore
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a number [1..9]: ");
            string userString = Console.ReadLine();

            int userNumber;

            switch (userString)
            {
                case "1":
                case "2":
                case "3":
                    userNumber = 10 * int.Parse(userString);
                    break;
                case "4":
                case "5":
                case "6":
                    userNumber = 100 * int.Parse(userString);
                    break;
                case "7":
                case "8":
                case "9":
                    userNumber = 1000 * int.Parse(userString);
                    break;
                default:
                    userNumber = -1;
                    break;
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
