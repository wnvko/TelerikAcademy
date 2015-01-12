namespace PrintCompanyInformation
{
    using System;

    public class PrintCompanyInformation
    {
        public static void Main(string[] args)
        {
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
            Console.Write("Fax number : ");
            int companyFaxNumber = int.Parse(Console.ReadLine());
            Console.Write("Web site address: ");
            string companyWebSite = Console.ReadLine();
            Console.WriteLine("Please enter information about the manager");
            Console.Write("First name: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Last name: ");
            string managerLastName = Console.ReadLine();
            Console.Write("Age: ");
            int managerAge = int.Parse(Console.ReadLine());
            Console.Write("Phone number : ");
            int managerPhoneNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Here is your company details");
            Console.WriteLine(companyName);
            Console.WriteLine("Address:");
            Console.WriteLine(companyAddressCity.PadLeft(20));
            Console.WriteLine(companyAddressPostalCode.PadLeft(20));
            Console.WriteLine(companyAddressStreet.PadLeft(20));
            Console.WriteLine("Contact information:");
            Console.WriteLine("{0,20:(0)2 ### ###0}", companyPhoneNumber);
            Console.WriteLine("{0,20:(0)2 ### ###0}", companyFaxNumber);
            Console.WriteLine(companyWebSite.PadLeft(20));
            Console.WriteLine("General manager:");
            Console.WriteLine("{0,20} {1}", managerFirstName, managerLastName);
            Console.WriteLine("{0,20} years", managerAge);
            Console.WriteLine("{0,20:(0)2 ### ###0}", managerPhoneNumber);
        }
    }
}
