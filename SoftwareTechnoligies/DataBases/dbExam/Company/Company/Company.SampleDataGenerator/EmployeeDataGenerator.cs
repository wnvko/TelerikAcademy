namespace Company.SampleDataGenerator
{
    using System;
    using System.Linq;

    using Company.Data;
    using System.Data.Entity.SqlServer;

    internal class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {
            var departmentIds = this.Database.Departments.Select(d => d.Id).ToList();
            var projectIds = this.Database.Projects.Select(p => p.Id).ToList();

            // generate top level managers
            Console.WriteLine("Adding employee's top managers...");
            int index = 0;

            for (int i = 0; i < this.Count * 0.05; i++)
            {
                var managerEmployee = GenerateRandomEmployee(departmentIds);

                this.Database.Employees.Add(managerEmployee);

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            // generet the rest of employees - not top managers
            Console.WriteLine("Adding employees not top managers...");
            index = 0;

            for (int i = 0; i < this.Count * 0.95; i++)
            {
                var employee = GenerateRandomEmployee(departmentIds);
                var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();

                while (true)
                {
                    var randomId = employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count - 1)];
                    var manager = this.Database.Employees.Where(m => m.Id == randomId).FirstOrDefault();

                    if (manager != null)
                    {
                        var myManager = new Employee();
                        myManager = manager;
                        bool isNotInCycle = CheckCycles(employee, manager);
                        if (isNotInCycle)
                        {
                            employee.ManagerId = myManager.Id;
                            break;
                        }
                    }
                }

                this.Database.Employees.Add(employee);

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nEmployees added...");
        }

        private bool CheckCycles(Employee employee, Employee manager)
        {
            while (manager.ManagerId != null)
            {
                if (employee.Id == manager.Id)
                {
                    return false;
                }

                manager = this.Database.Employees.Where(m => m.Id == manager.ManagerId).FirstOrDefault();
                CheckCycles(employee, manager);
            }

            return true;
        }

        private Employee GenerateRandomEmployee(System.Collections.Generic.List<int> departmentIds)
        {
            var employee = new Employee
            {
                FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                YearSalary = this.Random.GetRandomNumber(50000, 200000),
                DepartmentId = departmentIds[this.Random.GetRandomNumber(0, departmentIds.Count - 1)],
            };

            return employee;
        }
    }
}
