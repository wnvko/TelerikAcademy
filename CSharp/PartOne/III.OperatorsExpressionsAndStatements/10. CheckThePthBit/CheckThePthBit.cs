namespace CheckThePthBit
{
    using System;

    class CheckThePthBit
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int v = int.Parse(Console.ReadLine());
            Console.Write("Enter a possition to check: ");
            
            int p = int.Parse(Console.ReadLine());
            int mask = 1;
            mask <<= p;
            int vWithMask = v & mask;
            int result = (vWithMask > 0 ? 1 : 0);
            Console.WriteLine("The {0} bit of {1} = {2}", p, v, result);
        }
    }
}