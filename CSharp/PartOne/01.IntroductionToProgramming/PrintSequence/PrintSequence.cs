namespace PrintSequence
{
    using System;

    public class PrintSequence
    {
        private static int start = 2;
        private static int end = 12;
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
