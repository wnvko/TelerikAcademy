namespace ATM.Client
{
    using ATMSystem.Data;
    using ATMSystem.Data.Migrations;
    using ATMSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    public class ATMClient
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer<ATMSystemContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMSystemContext, Configuration>());
            var db = new ATMSystemContext();

            Console.Write("Enter the Card ID to withdraw from: ");
            int cardId = int.Parse(Console.ReadLine());

            Console.Write("Enter the amount: ");
            decimal amount = int.Parse(Console.ReadLine());

            // not working - see description bellow
            //string trigger = CreateTriggerString();
            //db.Database.ExecuteSqlCommand(trigger);

            // RepeatableRead isolation level will lock all the fields that have been read during transaction
            // this will asure data consistency after transaction is commited
            using (DbContextTransaction dbTransaction = db.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                try
                {

                    var card = db.CardAccounts.FirstOrDefault(c => c.CardAccountId == cardId);
                    var cardInitialAmount = card.CardCash;
                    TransactionsHistory transactionLog = new TransactionsHistory();
                    transactionLog.Ammount = amount;
                    transactionLog.TransactionDate = DateTime.Now;
                    transactionLog.CardAccountId = card.CardAccountId;

                    Console.WriteLine("Before transaction");
                    PrintCardDetails(card);

                    bool cardExist = card != null;
                    bool cardHasEnoughMoney = cardInitialAmount >= amount;

                    if (cardHasEnoughMoney)
                    {
                        card.CardCash -= amount;
                        db.TransactionsHistories.Add(transactionLog);
                        db.SaveChanges();
                        dbTransaction.Commit();
                    }
                    else
                    {
                        Console.WriteLine("No enough money in account. No transaction implemented!");
                    }

                    Console.WriteLine("\nAfter transaction");
                    PrintCardDetails(card);
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong account number! Unsuccesful trnsaction!");
                    dbTransaction.Rollback();
                }
            }
        }

        private static void PrintCardDetails(CardAccount card)
        {
            Console.WriteLine("Card ID/Card N - {0}/{1} - amount: {2}", card.CardAccountId, card.CardNumber, card.CardCash);
        }

        private static string CreateTriggerString()
        {
            // this method is not working at all.
            // if you can show me a working way toinsert trigger
            // runtime it will be great :)
            string trigger = @"IF EXISTS (SELECT * 
                                          FROM sys.objects 
                                          WHERE [type] = 'TR' 
                                          AND [name] = 'tr_AccountAmountChange') 
                               BEGIN 
                                   DROP TRIGGER dbo.tr_AccountAmountChange
                               END 
                               GO 
                                    CREATE TRIGGER dbo.tr_AccountAmountChange ON dbo.CardAccounts AFTER UPDATE 
                                    AS 
                                    SET NOCOUNT ON 
                                    DECLARE @InsertDate DATETIME = GETDATE() 
                                    DECLARE @Amount DECIMAL(18, 2) 
                                    DECLARE @CardAccountId INT
                                    SET @Amount = ( 
                                        SELECT (i.CardCash - d.CardCash) 
                                        FROM deleted AS d 
                                        JOIN inserted AS i 
                                        ON i.CardAccountId = d.CardAccountId) 
                                    SET @CardAccountId = (
                                        SELECT d.CardAccountId
                                        FROM deleted AS d 
                                        JOIN inserted AS i 
                                        ON i.CardAccountId = d.CardAccountId) 
                                    INSERT INTO TransactionsHistories(TransactionDate, Ammount, CardAccountId) 
                                    VALUES (@InsertDate, @Amount, @CardAccountId) 
                               GO
                               ";

            return trigger;
        }
    }
}