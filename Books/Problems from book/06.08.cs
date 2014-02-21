using System;

namespace ConsoleApplication
{
    class Chapter06Problem08
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете N: ");
            int N = int.Parse(Console.ReadLine());
            long nFaktoriel = 1;
            long nPlusOneFaktoriel= 1;
            long double_n_KaFaktoriel = 1;
            for (int i = 1; i <= 2*N; i++)
            {
                double_n_KaFaktoriel= double_n_KaFaktoriel* i;
                if (N >= i)
                {
                    nFaktoriel= nFaktoriel* i;
                }
                if (N +1 >= i)
                {
                    nPlusOneFaktoriel= nPlusOneFaktoriel* i;
                }
            }
            Console.WriteLine("{0}-тото число на Каталан е: {1}", N, ((double_n_KaFaktoriel)/(nPlusOneFaktoriel*nFaktoriel)));
        }
    }
}