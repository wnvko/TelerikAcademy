namespace CheckABitAtGivenPosition
{
    using System;

    public class CheckABitAtGivenPosition
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter a position to check (0 - 31): ");
            int position = int.Parse(Console.ReadLine());

            int mask = 1;
            mask <<= position;
            int vWithMask = number & mask;
            bool isBitAtPoasitionIsOne = vWithMask > 0;
            Console.WriteLine("The {0}th position of {1} is 1 - {2}", position, number, isBitAtPoasitionIsOne);
        }
    }
}
