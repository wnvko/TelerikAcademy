using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Dog : Animal
    {
        public Dog(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return "I am a Dog";
        }

        public override string Talk()
        {
            return "Bau";
        }
    }
}
