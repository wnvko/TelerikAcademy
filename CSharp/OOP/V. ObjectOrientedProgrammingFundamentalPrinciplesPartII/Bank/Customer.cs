namespace Bank
{
    using System;
    
    public abstract class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
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
                    throw new ArgumentException("Customer name cannot be null oe empty!");
                }

                this.name = value;
            }
        }
    }
}
