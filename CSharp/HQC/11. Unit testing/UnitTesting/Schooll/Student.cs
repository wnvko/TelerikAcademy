using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Student
    {
        private Name foolName;
        private int uniqueNumber;
        private Schooll theSchooll;

        public Student(string firstName, string lastName)
        {
            this.FoolName = new Name(firstName, lastName);
        }

        public Name FoolName
        {
            get
            {
                return this.foolName;
            }

            private set
            {
                this.foolName = value;
            }
        }

        public Schooll 
    }
