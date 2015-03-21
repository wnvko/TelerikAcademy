namespace BankAccounts
{
    public class CompanyCustomer : Customer
    {
        public CompanyCustomer(string name)
            : base(name)
        {
            this.loanAccountPeriod = 2;
            this.customerType = CustomerType.Company;
        }
    }
}
