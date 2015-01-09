namespace IsoscelesTriangle
{
    using System;
    using System.Text;

    public class IsoscelesTriangle
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            char copyright = '\u00A9';
            Console.WriteLine("   {0}", copyright);
            Console.WriteLine();
            Console.WriteLine("  {0} {0}", copyright);
            Console.WriteLine();
            Console.WriteLine(" {0} {0} {0}", copyright);
            Console.WriteLine();
            Console.WriteLine("{0} {0} {0} {0}", copyright);
        }
    }
}
