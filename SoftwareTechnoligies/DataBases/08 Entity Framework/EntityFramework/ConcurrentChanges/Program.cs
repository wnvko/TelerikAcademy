using System;
using System.Linq;
using NorthWind;

namespace ConcurrentChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities dbOne = new NorthwindEntities();
            NorthwindEntities dbTwo = new NorthwindEntities();

            var customerOne = (Customer)dbOne.Customers.Where(c => c.ContactName.Contains("no")).FirstOrDefault();
            var customerTwo = (Customer)dbTwo.Customers.Where(c => c.ContactName.Contains("no")).FirstOrDefault();
            Console.WriteLine("Customer initial name:");
            Console.WriteLine("One {0}", customerOne.ContactName);
            Console.WriteLine("Two {0}", customerTwo.ContactName);
            Console.WriteLine();

            customerOne.ContactName = "Pesho";
            customerTwo.ContactName = "Ne e Pesho";
            Console.WriteLine("Customer changed name:");
            Console.WriteLine("One {0}", customerOne.ContactName);
            Console.WriteLine("Two {0}", customerTwo.ContactName);
            Console.WriteLine();

            dbOne.SaveChanges();
            dbTwo.SaveChanges();

            customerOne = (Customer)dbOne.Customers.Where(c => c.ContactName.Contains("Pesho")).FirstOrDefault();
            customerTwo = (Customer)dbTwo.Customers.Where(c => c.ContactName.Contains("Pesho")).FirstOrDefault();

            Console.WriteLine("Customer database saved name:");
            Console.WriteLine("One {0}", customerOne.ContactName);
            Console.WriteLine("Two {0}", customerTwo.ContactName);
        }
    }
}
