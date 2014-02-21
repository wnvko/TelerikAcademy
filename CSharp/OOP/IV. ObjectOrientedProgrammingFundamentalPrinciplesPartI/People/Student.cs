namespace People
{
    using System;
    class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Student grade have to be between 1 and 12!");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-10} of {2} grade.", FirstName, LastName, Grade);
        }
    }
}