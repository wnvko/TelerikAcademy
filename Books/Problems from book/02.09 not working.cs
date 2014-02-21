using System;

namespace ConsoleApplication1
{
    class Chapter02Problem09
    {
        static void Main(string[] args)
        {
            string quotedString = @"The "use" of quotations causes difficulties.";
            string unquotedString = "The \"use\" of quotations causes difficulties.";                        
            Console.WriteLine(quotedString);
            Console.WriteLine(unquotedString);
        }
    }
}
