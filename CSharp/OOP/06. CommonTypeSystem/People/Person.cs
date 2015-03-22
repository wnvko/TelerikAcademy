namespace People
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int? age;
        
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            
            set
            {
                if (this.age < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder overridedResult = new StringBuilder();
        
            overridedResult.Append(this.Name);
            if (this.Age == null)
            {
                overridedResult.AppendLine(" is of unknown age!");
            }
            else
            {
                overridedResult.Append(" is age of ");
                overridedResult.AppendLine(this.Age.ToString());
            }

            return overridedResult.ToString();
        }
    }
}