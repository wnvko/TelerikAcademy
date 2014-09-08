namespace Company.SampleDataGenerator
{
    using System.Collections.Generic;

    using Company.Data;

    internal class Program
    {
        static void Main(string[] args)
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, db, 100),
                new ProjectDataGenerator(random, db, 1000),
                new EmployeeDataGenerator(random, db, 5000),
                new ReportRandomGenerator(random, db, 250000),
                new EmployeesProjectsDataGenerator(random, db, 5000),
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}