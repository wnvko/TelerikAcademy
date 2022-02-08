namespace Company.DataGenerator
{
    using System;
    using System.Linq;

    using Company.Data;
    using Contracts;

    internal class ReportDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportDataGenerator(IRandomDataGenerator random, CompanyEntities companyEntities, int numberOfItemsToBeGenerated, ILogger logger)
            : base(random, companyEntities, numberOfItemsToBeGenerated, logger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogLine("Generating reports...");
            this.Logger.Log("0%");

            var employeesIds = this.Database.Employees.Select(e => e.Id).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var report = new Report()
                {
                    EmployeeId = employeesIds[this.Random.GetRandomNumber(0, employeesIds.Count - 1)],
                    TimeOfReporting = this.Random.GetRandomDate(new DateTime(1900, 1, 1, 0, 0, 0), new DateTime(2015, 1, 1, 0, 0, 0))
                };

                this.Database.Reports.Add(report);

                if (i % 100 == 0)
                {
                    this.Database.SaveChanges();

                    this.Logger.Log(string.Format("\r{0}%", i * 100 / this.Count));
                }
            }

            this.Logger.LogLine("\r100%");
            this.Logger.LogLine("Reports generated successfully!");
        }
    }
}