namespace Company.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;

    using Company.Data;

    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {
            var departmentstoBeAdded = new HashSet<string>();
            while (departmentstoBeAdded.Count != this.Count)
            {
                departmentstoBeAdded.Add(this.Random.GetRandomStringWithRandomLength(10, 50));
            }

            Console.WriteLine("Adding departments...");
            int index = 0;

            foreach (var departmentName in departmentstoBeAdded)
            {
                var department = new Department
                {
                    Name = departmentName,
                };

                this.Database.Departments.Add(department);
                index++;

                if (index % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }
            }

            Console.WriteLine("\nDepartments added");
        }
    }
}
