namespace ToyStore.SampleDataGenerator
{
    using System;
    using ToyStore.Data;

    internal class CategoryDataGenerator : DataGenerator, IDataGenerator
    {
        public CategoryDataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding categories...");
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20)
                };

                this.Database.Categories.Add(category);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nCategories added");
        }
    }
}
