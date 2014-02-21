namespace Bank
{
    using System;
    using System.Collections.Generic;
    class BankTest
    {
        static void Main()
        {
            Customer IvanIvanov = new IndividualCustomer("Ivan Ivanov");
            Customer PetarStoyanov = new IndividualCustomer("Petar Stoyanov");
            Customer AnnaVasileva = new IndividualCustomer("Anna Vasileva");
            Customer MariaAtanasova = new IndividualCustomer("Maria Atanasova ");
            Customer CocaCola = new CompanyCustomer("CocaCola");
            Customer Microsoft = new CompanyCustomer("Microsoft");
            Customer Apple = new CompanyCustomer("Apple");
            Customer Google = new CompanyCustomer("Google");

            DepositAccount depositIvanIvanov = new DepositAccount(IvanIvanov, 800m, 0.05m);
            DepositAccount depositCocaCola = new DepositAccount(CocaCola, 5000000m, 0.02m);
            LoanAccount loanAnnaVasilev= new LoanAccount(AnnaVasileva, -10000m, 0.12m);
            LoanAccount loanGoogle = new LoanAccount(Google, -1000000m, 0.08m);
            MortageAccount mortagePetarStoyanov = new MortageAccount(PetarStoyanov, -50000m, 0.07m);
            MortageAccount mortageMictosoft = new MortageAccount(Microsoft, -5000000m, 0.06m);

            IList<Account> accounts = new List<Account>();
            accounts.Add(depositIvanIvanov);
            accounts.Add(depositCocaCola);
            accounts.Add(loanAnnaVasilev);
            accounts.Add(loanGoogle);
            accounts.Add(mortagePetarStoyanov);
            accounts.Add(mortageMictosoft);

            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }

            depositIvanIvanov.WithDraw(258.15m);
            Console.WriteLine("\nInterest for next 4 mounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine(account +" "+ account.InterestAmount(4));
            }

            depositIvanIvanov.Deposit(800m);
            loanAnnaVasilev.Deposit(600.12m);
            mortagePetarStoyanov.Deposit(1825.12m);
            Console.WriteLine("\nInterest for next 8 mounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine(account + " " + account.InterestAmount(8));
            }

            Console.WriteLine("\nInterest for next 20 mounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine(account + " " + account.InterestAmount(20));
            }
        }
    }
}
