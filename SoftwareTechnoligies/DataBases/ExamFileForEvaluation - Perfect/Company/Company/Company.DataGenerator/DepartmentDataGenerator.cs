namespace Company.DataGenerator
{
    using System.Collections.Generic;

    using Company.Data;
    using Contracts;

    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator random, CompanyEntities companyEntities, int numberOfItemsToBeGenerated, ILogger logger)
            : base(random, companyEntities, numberOfItemsToBeGenerated, logger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogLine("Generating departments...");
            this.Logger.Log("0%");

            var uniqueNames = new HashSet<string>();
            while (uniqueNames.Count != this.Count)
            {
                uniqueNames.Add(this.Random.GetRandomString(10, 50));
            }

            var index = 0;
            foreach (var name in uniqueNames)
            {
                var department = new Department()
                {
                    Name = name
                };

                this.Database.Departments.Add(department);

                if (index % 100 == 0)
                {
                    this.Database.SaveChanges();

                    this.Logger.Log(string.Format("\r{0}%", index * 100 / this.Count));
                }

                index++;
            }

            this.Logger.LogLine("\r100%");
            this.Logger.LogLine("Departments generated successfully!");
        }
    }
}