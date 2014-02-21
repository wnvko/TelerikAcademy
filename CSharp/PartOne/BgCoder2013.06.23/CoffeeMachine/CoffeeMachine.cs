using System;

class CoffeeMachine
{
    static void Main()
    {
        int[] N = new int[5];
        N[0] = int.Parse(Console.ReadLine());
        double CashInMachine = N[0] * 0.05;
        N[1] = int.Parse(Console.ReadLine());
        CashInMachine += N[1] * 0.10;
        N[2] = int.Parse(Console.ReadLine());
        CashInMachine += N[2] * 0.20;
        N[3] = int.Parse(Console.ReadLine());
        CashInMachine += N[3] * 0.50;
        N[4] = int.Parse(Console.ReadLine());
        CashInMachine += N[4];
        double A = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());
        if (A >= P)
        {
            if ((A - P) <= CashInMachine)
            {
                Console.WriteLine("Yes {0:0.00}", (CashInMachine - (A - P)));
            }
            else
            {
                Console.WriteLine("No {0:0.00}", ((A - P) - CashInMachine));
            }
        }
        else
        {
            Console.WriteLine("More {0:0.00}", (P - A));
        }
    }
}