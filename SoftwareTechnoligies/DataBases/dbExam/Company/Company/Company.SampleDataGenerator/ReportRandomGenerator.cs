namespace Company.SampleDataGenerator
{
    using System;
    using System.Linq;

    using Company.Data;

    internal class ReportRandomGenerator : DataGenerator, IDataGenerator
    {
        public ReportRandomGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {
            var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();

            Console.WriteLine("Adding reports...");
            int index = 0;
            for (int i = 0; i < this.Count; i++)
            {
                var report = new Report
                {
                    Time = DateTime.Now.AddDays(this.Random.GetRandomNumber(-10000,1000)),
                    EmployeeId = employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count-1)],
                };
                
                this.Database.Reports.Add(report);
                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nProjects added");
        }
    }
}
