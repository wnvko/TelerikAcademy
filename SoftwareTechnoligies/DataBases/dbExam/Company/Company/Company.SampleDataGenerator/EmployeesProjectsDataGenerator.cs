namespace Company.SampleDataGenerator
{
    using System;
    using System.Linq;

    using Company.Data;

    internal class EmployeesProjectsDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeesProjectsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {

            var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();
            var projectIds = this.Database.Projects.Select(p => p.Id).ToList();

            Console.WriteLine("Adding projects to employees...");
            int index = 0;

            while (index <= this.Count)
            {
                foreach (var projectid in projectIds)
                {
                    var randomNumberofemployees = this.Random.GetRandomNumber(2, 20);

                    for (int i = 0; i < randomNumberofemployees; i++)
                    {
                        var employeeid = employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count - 1)];
                        var isExist = this.Database.EmployeesProjects.Any(ep => ep.ProjectId == projectid && ep.EmployeeId == employeeid);

                        if (isExist)
                        {
                            continue;
                        }

                        var startDate = DateTime.Now.AddDays(this.Random.GetRandomNumber(-10000, 0));
                        var endDate = startDate.AddDays(this.Random.GetRandomNumber(0, 1000));

                        var employeesProjects = new EmployeesProject
                        {
                            EmployeeId = employeeid,
                            ProjectId = projectid,
                            StartDate = startDate,
                            EndDate = endDate,
                        };


                        this.Database.EmployeesProjects.Add(employeesProjects);
                        index++;

                        if (index % 100 == 0)
                        {
                            Console.Write(".");
                             this.Database.SaveChanges();
                        }
                    }
                }
            }

            Console.WriteLine("\nProjects to employees added...");

        }
    }
}
