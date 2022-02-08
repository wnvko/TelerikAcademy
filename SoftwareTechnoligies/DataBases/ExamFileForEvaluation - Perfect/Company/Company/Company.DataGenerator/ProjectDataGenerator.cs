namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Contracts;

    internal class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectDataGenerator(IRandomDataGenerator random, CompanyEntities companyEntities, int numberOfItemsToBeGenerated, ILogger logger)
            : base(random, companyEntities, numberOfItemsToBeGenerated, logger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogLine("Generating projects...");
            this.Logger.Log("0%");

            var employeesIds = this.Database.Employees.Select(e => e.Id).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var numberOfEmployees = 0;

                if (this.Random.GetChance(90))
                {
                    numberOfEmployees = this.Random.GetRandomNumber(4, 6);
                }
                else
                {
                    numberOfEmployees = this.Random.GetRandomNumber(2, 20);
                }

                var currentEmployees = new HashSet<int>();
                while (currentEmployees.Count != numberOfEmployees)
                {
                    currentEmployees.Add(employeesIds[this.Random.GetRandomNumber(0, employeesIds.Count - 1)]);
                }

                var project = new Project()
                {
                    Name = this.Random.GetRandomString(5, 50)
                };

                foreach (var id in currentEmployees)
                {
                    var startDate = this.Random.GetRandomDate(new DateTime(1900, 1, 1, 0, 0, 0), new DateTime(2000, 1, 1, 0, 0, 0));
                    var endDate = this.Random.GetRandomDate(startDate, new DateTime(2100, 1, 1, 0, 0, 0));

                    project.EmployeesProjects.Add(new EmployeesProject()
                        {
                            EmployeeId = id,
                            ProjectId = project.Id,
                            StartDate = startDate,
                            EndDate = endDate
                        });
                }

                this.Database.Projects.Add(project);

                if (i % 100 == 0)
                {
                    this.Database.SaveChanges();

                    this.Logger.Log(string.Format("\r{0}%", i * 100 / this.Count));
                }
            }

            this.Logger.LogLine("\r100%");
            this.Logger.LogLine("Projects generated successfully!");
        }
    }
}