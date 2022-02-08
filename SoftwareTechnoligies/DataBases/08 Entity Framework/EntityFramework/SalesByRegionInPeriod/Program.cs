﻿using System;
using System.Linq;
using NorthWind;

namespace SalesByRegionInPeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter region: ");
            string region = Console.ReadLine();
            Console.Write("Enter start date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter end date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            NorthwindEntities db = new NorthwindEntities();
            var sales = from o in db.Orders
                        where o.ShipRegion == region
                        where o.ShippedDate > startDate
                        where o.ShippedDate < endDate
                        select new
                        {
                            Country = o.ShipCountry,
                            Shiped = o.ShippedDate
                        };

            foreach (var sale in sales)
            {
                Console.WriteLine(sale);
            }
        }
    }
}
