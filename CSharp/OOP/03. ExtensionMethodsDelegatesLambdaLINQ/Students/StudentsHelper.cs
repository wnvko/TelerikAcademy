namespace Students
{
    using System;
    using System.Text;

    public class Student
    {
        private string firstName;
        private string secondName;
        private int age;

        public Student(string firstName, string secondName, int age)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string SecondName
        {
            get { return this.secondName; }
            set { this.secondName = value; }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be >0");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("{0,-15}{1,-15}{2}", this.FirstName, this.SecondName, this.Age));
            return output.ToString();
        }
    }
}
