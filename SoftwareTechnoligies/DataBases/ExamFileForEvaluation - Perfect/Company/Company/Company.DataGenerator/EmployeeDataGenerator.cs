namespace Company.DataGenerator
{
    using System.Linq;

    using Company.Data;
    using Contracts;

    internal class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator random, CompanyEntities companyEntities, int numberOfItemsToBeGenerated, ILogger logger)
            : base(random, companyEntities, numberOfItemsToBeGenerated, logger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogLine("Generating employees...");
            this.Logger.Log("0%");

            var departmentsIds = this.Database.Departments.Select(d => d.Id).ToList();
            var managersIds = this.Database.Employees.Select(e => e.Id).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var employee = new Employee()
                {
                    FirstName = this.Random.GetRandomString(5, 20),
                    LastName = this.Random.GetRandomString(5, 20),
                    YearSalary = this.Random.GetRandomNumber(50000, 200000),
                    DepartmentId = departmentsIds[this.Random.GetRandomNumber(0, departmentsIds.Count - 1)]
                };

                if (managersIds.Count == 0 && i > this.Count * 5 / 100)
                {
                    managersIds = this.Database.Employees.Select(e => e.Id).ToList();
                }

                if (managersIds.Count > 0)
                {
                    var managerId = managersIds[this.Random.GetRandomNumber(0, managersIds.Count - 1)];
                    var manager = this.Database.Employees.Find(managerId);

                    // Check for cycle in the management tree
                    while (manager.ManagerId != null)
                    {
                        if (manager.ManagerId == employee.Id)
                        {
                            managerId = managersIds[this.Random.GetRandomNumber(0, managersIds.Count - 1)];
                            manager = this.Database.Employees.Find(managerId);
                        }
                    }

                    employee.ManagerId = managerId;
                }

                this.Database.Employees.Add(employee);

                if (i % 100 == 0)
                {
                    this.Database.SaveChanges();

                    this.Logger.Log(string.Format("\r{0}%", i * 100 / this.Count));
                }
            }

            this.Logger.LogLine("\r100%");
            this.Logger.LogLine("Employees generated successfully!");
        }
    }
}