namespace IntDoubleString
{
    using System;

    class IntDoubleString
    {
        static void Main()
        {
            Console.WriteLine("Please choose:");
            Console.WriteLine("1. Integer");
            Console.WriteLine("2. Double");
            Console.WriteLine("3. String");
            int userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    {
                        /*
                         * Write a program that, depending on the user's choice inputs
                         * int, double or string variable. If the variable is integer or double,
                         * increases it with 1. If the variable is string, appends "*" at its end.
                         * The program must show the value of that variable as a console output. Use switch statement.
                         */
                        
                        Console.WriteLine("You choose 1. Integer");
                        Console.Write("Please enter an integer: ");
                        int userInteger = int.Parse(Console.ReadLine());
                        Console.WriteLine("Output {0}", (userInteger+1));
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You choose 2. Double");
                        Console.Write("Please enter a double: ");
                        double userDouble = double.Parse(Console.ReadLine());
                        Console.WriteLine("Output {0}", (userDouble + 1));
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("You choose 3. String");
                        Console.Write("Please enter a string: ");
                        string userString = Console.ReadLine();
                        Console.WriteLine("Output {0}", (userString + "*"));
                        break;
                    }
                default: 
                    break;
            }
        }
    }
}