namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        public static void Main(string[] args)
        {
            Customer ivanIvanov = new IndividualCustomer("Ivan Ivanov");
            Customer petarStoyanov = new IndividualCustomer("Petar Stoyanov");
            Customer annaVasileva = new IndividualCustomer("Anna Vasileva");
            Customer mariaAtanasova = new IndividualCustomer("Maria Atanasova ");
            Customer cocaCola = new CompanyCustomer("CocaCola");
            Customer microsoft = new CompanyCustomer("Microsoft");
            Customer apple = new CompanyCustomer("Apple");
            Customer google = new CompanyCustomer("Google");

            DepositAccount depositIvanIvanov = new DepositAccount(ivanIvanov, 800m, 0.05m);
            DepositAccount depositCocaCola = new DepositAccount(cocaCola, 5000000m, 0.02m);
            LoanAccount loanAnnaVasilev = new LoanAccount(annaVasileva, -10000m, 0.12m);
            LoanAccount loanGoogle = new LoanAccount(google, -1000000m, 0.08m);
            MortageAccount mortagePetarStoyanov = new MortageAccount(petarStoyanov, -50000m, 0.07m);
            MortageAccount mortageMictosoft = new MortageAccount(microsoft, -5000000m, 0.06m);

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
                Console.WriteLine("{0} {1,14:F2}", account, account.InterestAmount(4));
            }

            depositIvanIvanov.Deposit(800m);
            loanAnnaVasilev.Deposit(600.12m);
            mortagePetarStoyanov.Deposit(1825.12m);
            Console.WriteLine("\nInterest for next 8 mounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine("{0} {1,14:F2}", account, account.InterestAmount(8));
            }

            Console.WriteLine("\nInterest for next 20 mounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine("{0} {1,14:F2}", account, account.InterestAmount(20));
            }
        }
    }
}
