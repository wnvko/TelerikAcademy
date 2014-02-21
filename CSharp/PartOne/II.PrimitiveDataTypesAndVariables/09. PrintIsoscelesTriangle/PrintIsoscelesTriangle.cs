namespace PrintIsoscelesTriangle
{
    using System;
    using System.Text;

    class PrintIsoscelesTriangle
    {
        static void Main()
        {
            /*
             * Write a program that prints an isosceles triangle of 9
             * copyright symbols ©. Use Windows Character Map to find
             * the Unicode code of the © symbol.
             * Note: the © symbol may be displayed incorrectly.
             */
                        
            // next row forces the console to use Unicode (UTF8) encoding
            // System.Text library have to be added before
            Console.OutputEncoding = Encoding.UTF8; 
            
            char copyright = '\u00A9';
            Console.WriteLine("{0}",copyright);
            Console.WriteLine("{0}{0}", copyright);
            Console.WriteLine("{0} {0}", copyright);
            Console.WriteLine("{0}{0}{0}{0}", copyright);
        }
    }
}
