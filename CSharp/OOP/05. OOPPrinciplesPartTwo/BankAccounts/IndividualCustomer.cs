namespace BankAccounts
{
    public class IndividualCustomer : Customer
    {
        public IndividualCustomer(string name)
            : base(name)
        {
            this.loanAccountPeriod = 3;
            this.customerType = CustomerType.Individual;
        }
    }
}
