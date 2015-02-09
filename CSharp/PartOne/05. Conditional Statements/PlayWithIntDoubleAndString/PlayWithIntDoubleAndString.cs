namespace PlayWithIntDoubleAndString
{
    using System;

    public class PlayWithIntDoubleAndString
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please choose a type:");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");

            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Console.Write("Please enter an int: ");
                    int userInteger = int.Parse(Console.ReadLine());
                    Console.WriteLine(userInteger);
                    break;
                case 2:
                    Console.Write("Please enter a double: ");
                    double userDouble = double.Parse(Console.ReadLine());
                    Console.WriteLine(userDouble);
                    break;
                case 3:
                    Console.Write("Please enter a string: ");
                    string userString = Console.ReadLine();
                    Console.WriteLine(userString);
                    break;
                default:
                    break;
            }
        }
    }
}