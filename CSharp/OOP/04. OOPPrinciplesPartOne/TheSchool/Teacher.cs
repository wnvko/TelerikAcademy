namespace TheSchool
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person
    {
        private IList<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.disciplines = new List<Discipline>();
        }

        public Teacher(string name, IList<Discipline> disciplines)
            : this(name)
        {
            this.disciplines = disciplines;
        }

        public IList<Discipline> Discipline
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }
    }
}