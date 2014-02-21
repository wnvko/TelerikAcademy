namespace Bank
{
    public abstract class Account : IDepositAble
    {
        private Customer accountOwner;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer accountOwner, decimal balance, decimal interestRate)
        {
            this.AccountOwner = accountOwner;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer AccountOwner
        {
            get
            {
                return this.accountOwner;
            }

            private set
            {
                this.accountOwner = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }

            protected set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }

            private set { this.interestRate = value; }
        }

        public void Deposit(decimal amountToDeposit)
        {
            this.Balance += amountToDeposit;
        }

        public abstract decimal InterestAmount(int periodInMounts);

        public override string ToString()
        {
            return string.Format("{0,-20}{1,15:F2}{2,8:P1}",this.AccountOwner.Name,this.Balance,this.InterestRate);
        }
    }
}
