namespace ToyStore.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToyStore.Data;

    internal class ToyDataGenerator : DataGenerator, IDataGenerator
    {
        public ToyDataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedOnjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedOnjects)
        {
        }

        public override void Generate()
        {
            var ageRangesIds = this.Database.AgeRanges.Select(a => a.Id).ToList();
            var manufacturersIds = this.Database.Manufacturers.Select(m => m.Id).ToList();
            var catrgoryIds = this.Database.Categories.Select(c => c.Id).ToList();

            Console.WriteLine("Adding toys...");
            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Type = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Price = this.Random.GetRandomNumber(10, 500),
                    Color = this.Random.GetRandomNumber(1, 5) == 5 ? null : this.Random.GetRandomStringWithRandomLength(5, 20),
                    ManufacturerId = manufacturersIds[this.Random.GetRandomNumber(0, manufacturersIds.Count - 1)],
                    AgeRangeId = ageRangesIds[this.Random.GetRandomNumber(0, ageRangesIds.Count - 1)],
                };

                if (catrgoryIds.Count > 0)
                {
                    var uniqueCategoryIds = new HashSet<int>();
                    var categoriesInToy = this.Random.GetRandomNumber(2, Math.Min(10, catrgoryIds.Count));

                    while (uniqueCategoryIds.Count != categoriesInToy)
                    {
                        uniqueCategoryIds.Add(catrgoryIds[this.Random.GetRandomNumber(0, catrgoryIds.Count - 1)]);
                    }

                    foreach (var uniqueCategoryId in uniqueCategoryIds)
                    {
                        toy.Categories.Add(this.Database.Categories.Find(uniqueCategoryId));
                    }
                }

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Toys.Add(toy);
            }

            Console.WriteLine("\nToys added");
        }
    }
}
