namespace ATMSystem.Data
{
    using System.Data.Entity;
    using ATMSystem.Models;

    public class ATMSystemContext : DbContext
    {
        public ATMSystemContext()
            : base("name=ATMSystemDb")
        {
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionsHistory> TransactionsHistories { get; set; }
    }
}