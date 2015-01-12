namespace FormattingNumbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter three numbers.");
            Console.Write("(int)a = ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("(double)b = ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("(double)c = ");
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine("{0,10:X} | {1,10:0000000000} | {2,10:N2} | {3,-10:N2}", a, Convert.ToString(a, 2), b, c);
        }
    }
}
