/*
 * Write a method that calculates the number of workdays between today and given date, passed as
 * parameter. Consider that workdays are all days from Monday to Friday except a fixed list of
 * public holidays specified preliminary as array.
 */

using System;
using System.Collections.Generic;

public class Workdays
{
    public static void Main(string[] args)
    {
        List<DateTime> listOfHolidays = new List<DateTime>();
        AddHolidayToList(listOfHolidays, "01 / 01 / 2015");
        AddHolidayToList(listOfHolidays, "03 / 03 / 2015");
        AddHolidayToList(listOfHolidays, "18 / 04 / 2015");
        AddHolidayToList(listOfHolidays, "19 / 04 / 2015");
        AddHolidayToList(listOfHolidays, "20 / 04 / 2015");
        AddHolidayToList(listOfHolidays, "01 / 05 / 2015");
        AddHolidayToList(listOfHolidays, "06 / 05 / 2015");
        AddHolidayToList(listOfHolidays, "24 / 05 / 2015");
        AddHolidayToList(listOfHolidays, "06 / 09 / 2015");
        AddHolidayToList(listOfHolidays, "22 / 09 / 2015");
        AddHolidayToList(listOfHolidays, "24 / 12 / 2015");
        AddHolidayToList(listOfHolidays, "25 / 12 / 2015");
        AddHolidayToList(listOfHolidays, "26 / 12 / 2015");
        AddHolidayToList(listOfHolidays, "31 / 12 / 2015");

        Console.Write("Enter start date (dd/mm/yyyy): ");
        string startDateAsText = Console.ReadLine();
        Console.Write("Enter end date (dd/mm/yyyy): ");
        string endDateAsText = Console.ReadLine();

        DateTime startDate = GetDateFromString(startDateAsText);
        DateTime endDate = GetDateFromString(endDateAsText);

        int workingDays = CalculateWorkingDays(startDate, endDate, listOfHolidays);
        Console.WriteLine("\n There are {0} working days between {1:dd.MM.yyy} and {2:dd.MM.yyy}", workingDays, startDate, endDate);
    }

    public static int CalculateWorkingDays(DateTime startDay, DateTime endDay, List<DateTime> holidays)
    {
        int workingDays = 0;

        foreach (var day in holidays)
        {
            if (day >= startDay && day <= endDay)
            {
                if (IsWorkingDay(day))
                {
                    workingDays--;
                }
            }
        }

        while (endDay > startDay)
        {
            if (IsWorkingDay(startDay))
            {
                workingDays++;
            }

            startDay = startDay.AddDays(1);
        }

        return workingDays;
    }

    public static bool IsWorkingDay(DateTime dayToCheck)
    {
        bool workingDay = true;
        if (dayToCheck.DayOfWeek == DayOfWeek.Saturday || dayToCheck.DayOfWeek == DayOfWeek.Sunday)
        {
            workingDay = false;
        }

        return workingDay;
    }

    public static List<DateTime> AddHolidayToList(List<DateTime> holidays, string holidayAsText)
    {
        DateTime dateToAdd = GetDateFromString(holidayAsText);
        holidays.Add(dateToAdd);
        return holidays;
    }

    private static DateTime GetDateFromString(string holidayAsText)
    {
        string[] date = holidayAsText.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        DateTime dateToAdd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

        return dateToAdd;
    }
}
