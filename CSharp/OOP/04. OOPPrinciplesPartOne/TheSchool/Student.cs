namespace TheSchool
{
    using System;

    public class Student : Person
    {
        private string classID;

        public Student(string name)
            : base(name)
        {
        }

        public Student(string name, string classID)
            : this(name)
        {
            this.ClassID = classID;
        }

        public string ClassID
        {
            get
            {
                return this.classID;
            }

            set
            {
                if (this.classID != null)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Class ID must not be null or empty");
                    }

                    this.classID = value;
                }
            }
        }
    }
}