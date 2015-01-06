namespace PrintLongSequence
{
    using System;

    public class PrintLongSequence
    {
        private static int start = 2;
        private static int end = 1002;
        private static int signChanger = -1;

        public static void Main(string[] args)
        {
            for (int number = start; number < end; number++)
            {
                Console.Write(string.Format("{0}, ", number * Math.Pow(signChanger, number)));
            }

            Console.WriteLine();
        }
    }
}
