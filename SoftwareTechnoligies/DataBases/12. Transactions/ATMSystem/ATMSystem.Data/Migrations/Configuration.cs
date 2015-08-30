namespace ATMSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;

    using ATMSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ATMSystem.Data.ATMSystemContext>
    {
        private Random rnd = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ATMSystem.Data.ATMSystemContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating duplicate seed data. E.g.
            string[] cardNumbers = new string[10];
            string[] cardPINs = new string[10];
            decimal[] cardCash = new decimal[10];

            for (int card = 0; card < cardPINs.Length; card++)
            {
                CardAccount currentCard = new CardAccount();

                cardNumbers[card] = CreateRandomString(10);
                cardPINs[card] = CreateRandomString(4);
                cardCash[card] = rnd.Next(500, 10000);

                currentCard.CardNumber = cardNumbers[card];
                currentCard.CardPIN = cardPINs[card];
                currentCard.CardCash = cardCash[card];

                context.CardAccounts.AddOrUpdate(currentCard);
            }
        }

        private string CreateRandomString(int stringLenght)
        {
            string randomString = string.Empty;
            for (int leter = 0; leter < stringLenght; leter++)
            {
                randomString += (char)rnd.Next(65, 91);
            }

            return randomString;
        }
    }
}
