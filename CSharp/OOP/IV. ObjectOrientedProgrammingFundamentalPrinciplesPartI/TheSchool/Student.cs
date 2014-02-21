namespace School
{
    using System;

    public class Student : Person
    {
        private string classID;

        public Student(string name) : base(name) { }

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
                if (String.IsNullOrEmpty(this.classID))
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Class ID must not be null or empty");
                    }

                    this.classID = value;
                }
                else
                {
                    throw new ArgumentException("The Class ID is already set and cannot be changed!");
                }
            }
        }
    }
}