namespace ExtractThirdBit
{
    using System;

    public class ExtractThirdBit
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int v = int.Parse(Console.ReadLine());
            int p = 3;
            int mask = 1;
            mask <<= p;
            int vWithMask = v & mask;
            int result = vWithMask > 0 ? 1 : 0;
            Console.WriteLine("The {0} bit of {1} = {2}", p, v, result);
        }
    }
}
