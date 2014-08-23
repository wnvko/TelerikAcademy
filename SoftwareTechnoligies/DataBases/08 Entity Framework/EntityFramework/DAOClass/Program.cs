using System;
using System.Linq;
using NorthWind;

namespace DAOClass
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities dbAdd = new NorthwindEntities();

            Customer customerToAdd = new Customer();
            customerToAdd.CustomerID = "WTFTW";
            customerToAdd.CompanyName = "Pesho & Partners Ltd.";
            customerToAdd.ContactName = "Pesho";
            Console.WriteLine(customerToAdd.ContactName);
            OperateCustomer.AddCustomer(customerToAdd, dbAdd);

            NorthwindEntities dbAlter = new NorthwindEntities();
            Customer customerToChange = (Customer)dbAlter.Customers.Where(c => c.CustomerID == "WTFTW").FirstOrDefault();
            customerToChange.ContactName = "Veche sam Gosho";
            Console.WriteLine(customerToChange.ContactName);
            OperateCustomer.ModifyCustomer(customerToChange, dbAlter);

            NorthwindEntities dbRemove = new NorthwindEntities();
            Customer customerToDelete = (Customer)dbRemove.Customers.Where(c => c.CustomerID == "WTFTW").FirstOrDefault();
            Console.WriteLine(customerToDelete.ContactName);
            OperateCustomer.DeleteCustomer(customerToDelete, dbRemove);
        }
    }
}
