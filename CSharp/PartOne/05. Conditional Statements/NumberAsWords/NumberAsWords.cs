namespace NumberAsWords
{
    using System;

    public class NumberAsWords
    {
        private static string[] ones = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] tens = new string[] { string.Empty, string.Empty, "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        public static void Main(string[] args)
        {
            Console.Write("Please enter a userNumber [0..999]: ");
            int userNumber = int.Parse(Console.ReadLine());
            if (userNumber > 999 || userNumber < 0)
            {
                userNumber = -1;
            }

            int userNumber100 = userNumber / 100;
            int userNumber10 = (userNumber - (100 * userNumber100)) / 10;
            int userNumber1 = userNumber - (userNumber100 * 100) - (userNumber10 * 10);

            string sayUserNumber100 = ones[userNumber100] + " hundred";
            if (userNumber100 == 0)
            {
                sayUserNumber100 = string.Empty;
            }

            string sayUserNumber10 = tens[userNumber10];

            string sayUserNumber1 = ones[userNumber1];
            if (userNumber10 == 1)
            {
                sayUserNumber10 = string.Empty;
                sayUserNumber1 = ones[userNumber10 + userNumber1];
            }

            if (userNumber100 > 0)
            {
                if (userNumber10 > 0)
                {
                    if (userNumber1 > 0)
                    {
                        Console.WriteLine("Say: " + sayUserNumber100 + " and " + sayUserNumber10 + "-" + sayUserNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Say: " + sayUserNumber100 + " and " + sayUserNumber10);
                    }
                }
                else
                {
                    if (userNumber1 > 0)
                    {
                        Console.WriteLine("Say: " + sayUserNumber100 + " and " + sayUserNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Say: " + sayUserNumber100);
                    }
                }
            }
            else
            {
                if (userNumber10 > 0)
                {
                    if (userNumber1 > 0)
                    {
                        Console.WriteLine("Say: " + sayUserNumber10 + "-" + sayUserNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Say: " + sayUserNumber10);
                    }
                }
                else
                {
                    if (userNumber1 >= 0)
                    {
                        Console.WriteLine("Say: " + sayUserNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Your number is not from 0 to 999");
                    }
                }
            }
        }
    }
}
