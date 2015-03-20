namespace Zoo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Test
    {
        public static void Main()
        {
            var animals = new List<Animal>();

            animals.Add(new Dog(4, "Sharo", Sex.M));
            animals.Add(new Dog(8, "Balkan", Sex.M));
            animals.Add(new Dog(5, "Jina", Sex.F));
            animals.Add(new Frog(2, "Zhaba", Sex.F));
            animals.Add(new Kitten(2, "Puhi"));
            animals.Add(new TomCat(5, "Tom"));

            foreach (var animal in animals)
            {
                animal.SayWahtYouCan();
            }

            Console.WriteLine("\nAverage age of all animals is: {0:F2} years", Animal.AverageAge(animals.ToArray()));
        }
    }
}
