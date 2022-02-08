namespace Company.DataGenerator
{
    using System.Collections.Generic;

    using Company.Data;
    using Company.DataGenerator.Contracts;

    internal class EntryPoint
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            var logger = new ConsoleLogger();

            var generators = new List<IDataGenerator>()
            {
                new DepartmentDataGenerator(random, db, 100, logger),
                new EmployeeDataGenerator(random, db, 5000, logger),
                new ProjectDataGenerator(random, db, 1000, logger),
                new ReportDataGenerator(random, db, 250000, logger)
            };

            db.Configuration.AutoDetectChangesEnabled = false;

            foreach (var generator in generators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}