namespace Bank
{
    using System;

    class MortageAccount : Account
    {
        public MortageAccount(Customer accountOwner, decimal balance, decimal interestRate)
            : base(accountOwner, balance, interestRate)
        {
        }

        public override decimal InterestAmount(int periodInMounts)
        {
            if (this.AccountOwner.GetType().Name.CompareTo("IndividualCustomer") == 0)
            {
                if (periodInMounts < 6)
                {
                    return 0;
                }
                else
                {
                    return this.InterestRate * (periodInMounts - 6);
                }
            }
            else if (this.AccountOwner.GetType().Name.CompareTo("CompanyCustomer") == 0)
            {
                if (periodInMounts < 12)
                {
                    return this.InterestRate * periodInMounts / 2;
                }
                else
                {
                    return this.InterestRate * (periodInMounts - 6);
                }
            }
            else
            {
                throw new ArgumentException("Unknown customer type!");
            }
        }
    }
}
