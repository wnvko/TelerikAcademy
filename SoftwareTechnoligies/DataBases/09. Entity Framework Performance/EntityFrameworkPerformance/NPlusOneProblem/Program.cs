namespace NPlusOneProblem
{
    using System;
    using TelerikAcademy;

    public class Program
    {
        public static void Main(string[] args)
        {
            TelerikAcademyEntities db = new TelerikAcademyEntities();
            using (db)
            {

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
}
