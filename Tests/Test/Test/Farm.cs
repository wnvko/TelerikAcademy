using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Farm
    {
        public Farm(string name)
        {
            this.Name = name;
            Animals = new List<IAnimal>();
        }
        public string Name { get; set; }
        public List<IAnimal> Animals { get; set; }

        public void AddAnimal(IAnimal animal)
        {
            Animals.Add(animal);
        }

        public override string ToString()
        {
            StringBuilder allAnimals = new StringBuilder();
            allAnimals.AppendLine(this.Name);

            foreach (var animal in Animals)
            {
                allAnimals.Append(animal.Talk());
                allAnimals.AppendLine(animal.Name);
            }

            return allAnimals.ToString();
        }
    }
}
