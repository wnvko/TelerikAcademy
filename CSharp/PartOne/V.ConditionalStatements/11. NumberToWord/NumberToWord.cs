namespace userNumberToWord
{
    using System;

    class userNumberToWord
    {
        static void Main()
        {
            /*
             * Write a program that converts a number in the range [0...999]
             * to a text corresponding to its English pronunciation.
             * Examples:
             * 0 -> "Zero"
             * 273 -> "Two hundred seventy three"
             * 400 -> "Four hundred"
             * 501 -> "Five hundred and one"
             * 711 -> "Seven hundred and eleven"
             */

            Console.Write("Please enter a userNumber [0..999]: ");
            int userNumber = int.Parse(Console.ReadLine());
            if (userNumber > 999 || userNumber < 0)
            {
                userNumber = -1; //will write an error in the output
            }
            int userNumber100 = userNumber / 100;
            int userNumber10 = (userNumber - 100 * userNumber100) / 10;
            int userNumber1 = userNumber - userNumber100 * 100 - userNumber10 * 10;
            string sayuserNumber100 ="";
            string sayuserNumber10 ="";
            string sayuserNumber1 ="";
            
            //set the hundreds of the number
            switch (userNumber100)
            {
                case 0: sayuserNumber100 = ""; break;
                case 1: sayuserNumber100 = "one hundred"; break;
                case 2: sayuserNumber100 = "two hundreds"; break;
                case 3: sayuserNumber100 = "three hundreds"; break;
                case 4: sayuserNumber100 = "four hundreds"; break;
                case 5: sayuserNumber100 = "five hundreds"; break;
                case 6: sayuserNumber100 = "six hundreds"; break;
                case 7: sayuserNumber100 = "seven hundreds"; break;
                case 8: sayuserNumber100 = "eight hundreds"; break;
                case 9: sayuserNumber100 = "nine hundreds"; break;
                default: break;
            }

            //set the tens of the number
            switch (userNumber10)
            {
                case 0: sayuserNumber10 = ""; break;
                case 1:
                    {
                        switch (userNumber1)
                        {
                            case 0: sayuserNumber10 = "ten"; break;
                            case 1: sayuserNumber10 = "eleven"; break;
                            case 2: sayuserNumber10 = "twelve"; break;
                            case 3: sayuserNumber10 = "thirteen"; break;
                            case 4: sayuserNumber10 = "fourteen"; break;
                            case 5: sayuserNumber10 = "fifteen"; break;
                            case 6: sayuserNumber10 = "sixteen"; break;
                            case 7: sayuserNumber10 = "seventeen"; break;
                            case 8: sayuserNumber10 = "eighteen"; break;
                            case 9: sayuserNumber10 = "nineteen"; break;
                            default: break;
                        }
                    } break;
                case 2: sayuserNumber10 = "twenty"; break;
                case 3: sayuserNumber10 = "thirty"; break;
                case 4: sayuserNumber10 = "fourty"; break;
                case 5: sayuserNumber10 = "fifty"; break;
                case 6: sayuserNumber10 = "sixty"; break;
                case 7: sayuserNumber10 = "seventy"; break;
                case 8: sayuserNumber10 = "eighty"; break;
                case 9: sayuserNumber10 = "ninety"; break;
                default: break;
            }

            //set the ones of the number
             switch (userNumber1)
            {
                case 0: sayuserNumber1 = "zero"; break;
                case 1: sayuserNumber1 = "one"; break;
                case 2: sayuserNumber1 = "two"; break;
                case 3: sayuserNumber1 = "three"; break;
                case 4: sayuserNumber1 = "four"; break;
                case 5: sayuserNumber1 = "five"; break;
                case 6: sayuserNumber1 = "six"; break;
                case 7: sayuserNumber1 = "seven"; break;
                case 8: sayuserNumber1 = "eight"; break;
                case 9: sayuserNumber1 = "nine"; break;
                default: break;
            }
            //check if tens are from 10 to 19
            if (userNumber10 == 1)
             {
                 userNumber1 = 0;
             }

            if (userNumber100 > 0)
            {
                if (userNumber10 > 0)
                {
                    if (userNumber1 > 0)
                    {
                        Console.WriteLine("Say: " + sayuserNumber100 + " and " + sayuserNumber10 + "-" + sayuserNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Say: " + " " + sayuserNumber100 + " and " + sayuserNumber10);
                    }
                }
                else
                {
                    if (userNumber1 > 0)
                    {
                        Console.WriteLine("Say: " + sayuserNumber100 + " and " + sayuserNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Say: " + sayuserNumber100);
                    }
                }
            }
            else
            {
                if (userNumber10 > 0)
                {
                    if (userNumber1 > 0)
                    {
                        Console.WriteLine("Say: " + sayuserNumber10 + "-" + sayuserNumber1);
                    }
                    else
                    {
                        Console.WriteLine("Say: " + sayuserNumber10);
                    }
                }
                else
                {
                    if (userNumber1 >= 0)
                    {
                        Console.WriteLine("Say: " + sayuserNumber1);
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