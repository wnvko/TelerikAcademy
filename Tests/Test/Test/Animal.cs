using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Animal : IAnimal
    {
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return "I am animal";
        }

        public virtual string Talk()
        {
            return "Wow";
        }
    }
}
