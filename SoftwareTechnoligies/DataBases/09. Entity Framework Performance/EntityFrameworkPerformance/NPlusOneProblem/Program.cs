using System;
using TelerikAcademy;

namespace NPlusOneProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities db = new TelerikAcademyEntities();

            //foreach (var employee in db.Employees.Include("Address.Town").Include("Department"))
            //{
            //    Console.WriteLine("{0} from {1} is in {2} department", employee.FirstName, employee.Address.Town, employee.Department);
            //}

            foreach (var employee in db.Employees)
            {
                Console.WriteLine("{0} from {1} is in {2} department", employee.FirstName, employee.Address.Town, employee.Department);
            }
        }
    }
}
