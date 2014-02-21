using System;

namespace ConsoleApplication
{
    class Chapter06Problem07
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете N: ");
            int eN = int.Parse(Console.ReadLine());
            Console.Write("Въведете K < {0}: ", eN);
            int kA = int.Parse(Console.ReadLine());
            long enFaktoriel = 1;
            long kaFaktoriel = 1;
            long enMinusKaFaktoriel = 1;
            for (int i = 1; i <= eN; i++)
            {
                enFaktoriel = enFaktoriel * i;
                if (kA >= i)
                {
                    kaFaktoriel = kaFaktoriel * i;
                }
                if (eN - kA >= i)
                {
                    enMinusKaFaktoriel = enMinusKaFaktoriel * i;
                }
            }
            Console.WriteLine("{0}!*{1}!/({0}-{1})! = {2}", eN, kA, ((enFaktoriel * kaFaktoriel) / (enMinusKaFaktoriel)));
        }
    }
}
