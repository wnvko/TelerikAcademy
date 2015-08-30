namespace ToListProblem
{
    using System;
    using System.Linq;
    using TelerikAcademy;

    public class Program
    {
        public static void Main(string[] args)
        {
            TelerikAcademyEntities db = new TelerikAcademyEntities();
            using (db)
            {
                //List<Town> badWay = db.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Where(t => t.Name == "Sofia").ToList();
                //foreach (var town in badWay)
                //{
                //    Console.WriteLine(town);
                //}

                IQueryable goodWay = db.Employees.Select(e => e.Address).Select(a => a.Town).Where(t => t.Name == "Sofia");
                foreach (var town in goodWay)
                {
                    Console.WriteLine(town);
                }

                Console.WriteLine("Please check screenshots in the archive!");
            }
        }
    }
}