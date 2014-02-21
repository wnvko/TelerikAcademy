namespace Bank
{
    using System;

    class DepositAccount : Account, IWithDrawAble
    {
        public DepositAccount(Customer accountOwner, decimal balance, decimal interestRate)
            : base(accountOwner, balance, interestRate)
        {
        }
        public override decimal InterestAmount(int periodInMounts)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return periodInMounts * this.InterestRate;
            }
        }

        public void WithDraw(decimal amountToWithDraw)
        {
            // if it is not allowed to withdraw more than available balance uncomment next three rows
            //if (amountToWithDraw > this.Balance)
            //{
            //    throw new ArgumentException("Account balance is less than withdraw amount!");
            //}

            this.Balance -= amountToWithDraw;
        }
    }
}
