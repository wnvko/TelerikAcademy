namespace Company.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;

    using Company.Data;

    internal class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding projects...");
            int index = 0;
            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50),
                };

                this.Database.Projects.Add(project);
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

