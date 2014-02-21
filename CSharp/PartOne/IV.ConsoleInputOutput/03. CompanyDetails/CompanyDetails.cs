namespace CompanyDetails
{
    using System;

    class CompanyDetails
    {
        static void Main()
        {
            /*
             * A company has name, address, phone number, fax number, web site and manager.
             * The manager has first name, last name, age and a phone number.
             * Write a program that reads the information about a company and its manager and prints them on the console.
             */

            Console.WriteLine("Please enter information about your company");
            Console.Write("Company name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Address:");
            Console.Write("City: ");
            string companyAddressCity = Console.ReadLine();
            Console.Write("Postal Code: ");
            string companyAddressPostalCode = Console.ReadLine();
            Console.Write("Street: ");
            string companyAddressStreet = Console.ReadLine();
            Console.WriteLine("Contact information:");
            Console.Write("Phone number : ");
            int companyPhoneNumber = int.Parse(Console.ReadLine());
            Console.Write("Faxnumber : ");
            int companyFaxNumber = int.Parse(Console.ReadLine());
            Console.Write("Web site address: ");
            string companyWebSite = Console.ReadLine();
            Console.WriteLine("Please enter information about thethe manager");
            Console.Write("First name: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Last name: ");
            string managerLastName = Console.ReadLine();
            Console.Write("Age: ");
            int managerAge = int.Parse(Console.ReadLine());
            Console.Write("Phone number : ");
            int managerPhoneNumber = int.Parse(Console.ReadLine());

            //print all the information
            Console.Clear();
            Console.WriteLine("Here is your company details");
            Console.WriteLine(companyName);
            Console.WriteLine("Address:");
            Console.WriteLine(companyAddressCity.PadLeft(20));
            Console.WriteLine(companyAddressPostalCode.PadLeft(20));
            Console.WriteLine(companyAddressStreet.PadLeft(20));
            Console.WriteLine("Contact information:");
            Console.WriteLine("{0,20:(0)2 ### ###0}",companyPhoneNumber);
            Console.WriteLine("{0,20:(0)2 ### ###0}", companyFaxNumber);
            Console.WriteLine(companyWebSite.PadLeft(20));
            Console.WriteLine("General manager:");
            Console.WriteLine("{0,20} {1}", managerFirstName, managerLastName);
            Console.WriteLine("{0,20} years", managerAge);
            Console.WriteLine("{0,20:(0)2 ### ###0}", managerPhoneNumber);
        }
    }
}
