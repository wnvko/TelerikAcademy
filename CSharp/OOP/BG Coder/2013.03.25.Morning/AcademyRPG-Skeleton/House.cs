using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class House:StaticObject, ICollector
    {
        public House(Point position, int owner):base(position, owner)
        {
            this.HitPoints = 500;
        }
        public void Method()
        {
            throw new NotImplementedException();
        }
    }
}
