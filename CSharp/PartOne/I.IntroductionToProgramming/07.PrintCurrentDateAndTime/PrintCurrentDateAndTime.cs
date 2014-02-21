using System;

class PrintCurrentDateAndTime
{
    static void Main()
    {
        //Create a console application that prints the current date and time.

        Console.Write("Today is: ");
        Console.WriteLine(DateTime.Now.Date.ToString(@"dd.MMM.yyyy"));
        //display only the date part of DateTime.Now converted in string in dd.MMM.yyyy format
        Console.Write("Now it is: ");
        Console.Write(DateTime.Now.TimeOfDay.ToString(@"hh\:mm"));
        //display only the hour part of DateTime.Now
        Console.WriteLine(" o'clock");
    }
}