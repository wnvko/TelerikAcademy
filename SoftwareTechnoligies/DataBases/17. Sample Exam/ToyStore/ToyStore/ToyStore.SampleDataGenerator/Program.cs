namespace ToyStore.SampleDataGenerator
{
    using System.Collections.Generic;
    using ToyStore.Data;

    internal class Program
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new ToyStoreEntities();
            db.Configuration.AutoDetectChangesEnabled = false;


            var listOfGenerators = new List<IDataGenerator>
            {
                new CategoryDataGenerator(random, db, 100),
                new ManufacturerDataGenerator(random, db, 50),
                new AgeRangeDataGenerator(random, db, 100),
                new ToyDataGenerator(random, db, 20000),
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
