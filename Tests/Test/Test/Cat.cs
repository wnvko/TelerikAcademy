using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Cat : Animal
    {
        public Cat(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return "I am a Cat";
        }

        public override string Talk()
        {
            return "Mew";
        }
    }
}
