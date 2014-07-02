using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main()
        {
            Animal some = new Cat("Tommy");
            Animal doggy = new Dog("Doggy");
            Animal animal = new Animal("Who are you?!?");

            Farm oldOne = new Farm("Old One");
            oldOne.AddAnimal(some);
            oldOne.AddAnimal(doggy);
            oldOne.AddAnimal(animal);

            Console.WriteLine(oldOne);
        }
    }
}
