namespace BankAccounts
{
    using System;

    public abstract class Customer
    {
        protected int loanAccountPeriod;
        protected CustomerType customerType;

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
                    throw new ArgumentException("Customer name cannot be null be empty!");
                }

                this.name = value;
            }
        }

        public int LoanAcountPeriod
        {
            get { return this.loanAccountPeriod; }
        }

        public CustomerType Customertype
        {
            get { return this.customerType; }
        }
    }
}
