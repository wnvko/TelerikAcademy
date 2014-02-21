/*
 * Write a program that reads a year from the console and
 * checks whether it is a leap. Use DateTime.
 */

namespace LeapYear
{
    using System;
    using System.Collections.Generic;
    
    public class LeapYear
    {
        public static void Main()
        {
            Console.Write("Enter year to check: ");
            int userYear = int.Parse(Console.ReadLine());
            bool isLeap = DateTime.IsLeapYear(userYear);
            if (isLeap)
            {
                Console.WriteLine("\n{0} is leap year!", userYear);
            }
            else
            {
                Console.WriteLine("\n{0} is not leap year!", userYear);
            }
        }
    }
}
