namespace School
{
    using System;
    public class Person : Comment
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Person name cannot be null or empty!");
                }

                this.name = value;
            }
        }
    }
}
