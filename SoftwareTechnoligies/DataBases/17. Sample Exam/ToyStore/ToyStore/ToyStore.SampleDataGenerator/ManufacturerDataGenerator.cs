namespace ToyStore.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using ToyStore.Data;

    internal class ManufacturerDataGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerDataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();

            while (manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(5, 20));
            }

            int index = 0;
            Console.WriteLine("Adding manufacturers...");

            try
            {
                foreach (var manufacturerName in manufacturersToBeAdded)
                {
                    var manufacturer = new Manufacturer
                    {
                        Name = manufacturerName,
                        Country = this.Random.GetRandomStringWithRandomLength(2, 30),
                    };

                    this.Database.Manufacturers.Add(manufacturer);
                    index++;

                    if (index % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }

                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            Console.WriteLine("\nManufacturers added");
        }
    }
}