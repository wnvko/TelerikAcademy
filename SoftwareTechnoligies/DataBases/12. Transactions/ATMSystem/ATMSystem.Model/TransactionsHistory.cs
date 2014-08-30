namespace ATMSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TransactionsHistory
    {
        [Key]
        public int TransactionsHistoryId { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Ammount { get; set; }

        public int CardAccountId { get; set; }
    }
}