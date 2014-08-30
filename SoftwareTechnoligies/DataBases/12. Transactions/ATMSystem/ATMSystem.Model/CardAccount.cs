namespace ATMSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CardAccount
    {
        private ICollection<TransactionsHistory> transactionsHistoryId;

        public CardAccount()
        {
            this.transactionsHistoryId = new HashSet<TransactionsHistory>();
        }

        [Key]
        public int CardAccountId { get; set; }

        [StringLength(10)]
        public string CardNumber { get; set; }

        [StringLength(4)]
        public string CardPIN { get; set; }

        public decimal CardCash { get; set; }

        public virtual ICollection<TransactionsHistory> TransactionsHistoryId
        {
            get { return this.transactionsHistoryId; }
            set { this.transactionsHistoryId = value; }
        }
    }
}