namespace PrintQoutationMarks
{
    using System;

    class PrintQoutationMarks
    {
        static void Main()
        {
            /*
             * Declare two string variables and assign them with following value:
             * The "use" of quotations causes difficulties.
             * Do the above in two different ways: with and without using quoted strings.
            */
            string escapingQuotes = "The \"use\" of quotations causes difficulties.";
            string citingQuotes = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(escapingQuotes);
            Console.WriteLine();
            Console.WriteLine(citingQuotes);
        }
    }
}
