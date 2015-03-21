namespace BankAccounts
{
    using System;

    public class MortageAccount : Account
    {
        public MortageAccount(Customer accountOwner, decimal balance, decimal interestRate)
            : base(accountOwner, balance, interestRate)
        {
        }

        public override decimal InterestAmount(int periodInMounts)
        {
            if (this.AccountOwner.Customertype == CustomerType.Company)
            {
                if (periodInMounts < 6)
                {
                    return 0;
                }
                else
                {
                    return this.InterestRate * (periodInMounts - 6) * this.Balance;
                }
            }
            else if (this.AccountOwner.Customertype == CustomerType.Individual)
            {
                if (periodInMounts < 12)
                {
                    return this.InterestRate * periodInMounts * this.Balance / 2;
                }
                else
                {
                    return this.InterestRate * (periodInMounts - 6) * this.Balance;
                }
            }
            else
            {
                throw new ArgumentException("Unknown customer type!");
            }
        }
    }
}
