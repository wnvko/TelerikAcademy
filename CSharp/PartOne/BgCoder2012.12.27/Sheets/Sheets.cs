namespace Sheets
{
    using System;

    class Sheets
    {
        static void Main()
        {
            int numberOfA10Sheets = int.Parse(Console.ReadLine());
            int mask = 1;
            for (int i = 0; i < 11; i++)
            {
                int maskToAply = mask << i;
                if ((numberOfA10Sheets & maskToAply) == 0)
                {
                    Console.WriteLine("A{0}", 10 - i);
                }
            }
        }
    }
}