using System;

namespace ConsoleApplication
{
    class Chapter06Problem13
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете N: ");
            string binary = Console.ReadLine();
            int power = 1;
            int N = 0;
            int lenght = binary.Length;
            for (int i = 1; i <= lenght; i++)
            {
                N = N + power * Convert.ToInt32(binary.Substring((lenght - i), 1));
                power *= 2;
            }
            int binToDec = 0;
            power = 1;
            Console.Write("Двоично {0} = Десетично ", binary);
            while (N > 0)
            {
                binToDec = binToDec + (N & 1) * power;
                N = N >> 1;
                power *= 2;
            }
            Console.WriteLine(binToDec);
        }
    }
}