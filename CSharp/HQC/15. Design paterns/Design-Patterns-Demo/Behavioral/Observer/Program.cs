namespace Observer
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            // Create IBM stock and attach investors
            var ibm = new IBM("IBM", 120.00);

            var sorros = new Investor("Sorros");
            ibm.Attach(sorros);
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;

            ibm.Detach(sorros);

            ibm.Price = 120.50;

            ibm.Attach(sorros);
            ibm.Price = 120.75;
        }
    }
}
