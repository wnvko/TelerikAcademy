using System;
using NorthWind;

namespace DAOClass
{
    public class OperateCustomer
    {
        public static void AddCustomer(Customer customer, NorthwindEntities db)
        {
            if (customer != null && db != null)
            {
                using (db)
                {
                    try
                    {
                        db.Customers.Add(customer);
                        db.SaveChanges();
                        Console.WriteLine("{0} is added", customer.ContactName.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not added.", customer.ContactName.ToString());
                        HandleException(e);
                    }
                }
            }
        }

        public static void DeleteCustomer(Customer customer, NorthwindEntities db)
        {
            if (customer != null)
            {
                using (db)
                {
                    try
                    {
                        db.Customers.Remove(customer);
                        db.SaveChanges();
                        Console.WriteLine("{0} is deleted", customer.ContactName.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not deleted.", customer.ContactName.ToString());
                        HandleException(e);
                    }
                }
            }
        }

        public static void ModifyCustomer(Customer customer, NorthwindEntities db)
        {
            if (customer != null)
            {
                using (db)
                {
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("{0} is changed", customer.ContactName.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not modified.", customer.ContactName.ToString());
                        HandleException(e);
                    }
                }
            }
        }

        private static void HandleException(Exception e)
        {
            int exceptionLevel = 0;
            while (true)
            {
                Console.WriteLine(" Exception level {0} - {1}", exceptionLevel, e.Message);
                if (e.InnerException == null)
                {
                    break;
                }

                e = e.InnerException;
                exceptionLevel++;
            }
        }
    }
}
