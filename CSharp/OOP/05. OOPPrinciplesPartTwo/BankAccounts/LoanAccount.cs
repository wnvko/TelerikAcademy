namespace BankAccounts
{
    using System;

    public class LoanAccount : Account
    {
        public LoanAccount(Customer accountOwner, decimal balance, decimal interestRate)
            : base(accountOwner, balance, interestRate)
        {
        }

        public override decimal InterestAmount(int periodInMounts)
        {
            periodInMounts -= this.AccountOwner.LoanAcountPeriod;
            return this.InterestRate * periodInMounts * this.Balance;
        }
    }
}
