using System;

namespace BookHomeworks
{
    class Chapter04Problem03
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете името на фирмата");
            string companyName = Console.ReadLine();
            Console.WriteLine("Въведете адреса на фирмата");
            string companyAdress = Console.ReadLine();
            Console.WriteLine("Въведете телефнния номер на фирмата");
            int companyPhoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете номера на факса на фирмата");
            int companyFaxNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете уеб адреса на фирмата");
            string companyWebAdress = Console.ReadLine();
            Console.WriteLine("Въведете информация за мениджъра на фирмата:");
            Console.Write("Име: ");
            string managerName = Console.ReadLine();
            Console.Write("Фамилия: ");
            string managerSirname = Console.ReadLine();
            Console.Write("Телефонен номер: ");
            int managerPhoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Фирма {0}", companyName);
            Console.WriteLine("Адрес: {0}", companyAdress);
            Console.WriteLine("Телефон: {0:(0#) ### ####}", companyPhoneNumber);
            Console.WriteLine("Факс: {0:(0#) ### ####}", companyFaxNumber);
            Console.WriteLine("Уеб адрес: {0}", companyWebAdress);
            Console.WriteLine("Управител");
            Console.WriteLine(managerName + " " + managerSirname);
            Console.WriteLine("Телефон: {0:(0#) ### ####}", managerPhoneNumber);
        }
    }
}
