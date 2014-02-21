
namespace School
{
    using System;
    using System.Collections.Generic;
    public class Teacher : Person
    {
        private IList<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            disciplines = new List<Discipline>();
        }

        public Teacher(string name, IList<Discipline> disciplines)
            : this(name)
        {

        }
        public IList<Discipline> Discipline
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }
    }
}