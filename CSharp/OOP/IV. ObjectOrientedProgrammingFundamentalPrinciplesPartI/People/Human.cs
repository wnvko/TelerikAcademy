namespace People
{
    using System;
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name lenght cannot be less than two letters!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name lenght cannot be less than two letters!");
                }

                this.lastName = value;
            }
        }
    }
}