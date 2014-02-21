namespace Bank
{
    using System;

    class LoanAccount : Account
    {
        public LoanAccount(Customer accountOwner, decimal balance, decimal interestRate)
            : base(accountOwner, balance, interestRate)
        {
        }

        public override decimal InterestAmount(int periodInMounts)
        {
            if (this.AccountOwner.GetType().Name.CompareTo("IndividualCustomer") == 0)
            {
                periodInMounts -= 3;
                return this.InterestRate * periodInMounts;
            }
            else if (this.AccountOwner.GetType().Name.CompareTo("CompanyCustomer") == 0)
            {
                periodInMounts -= 2;
                return this.InterestRate * periodInMounts;
            }
            else
            {
                throw new ArgumentException("Unknown customer type!");
            }
        }
    }
}