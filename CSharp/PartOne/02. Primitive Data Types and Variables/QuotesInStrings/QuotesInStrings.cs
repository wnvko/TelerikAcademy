namespace QuotesInStrings
{
    using System;

    public class QuotesInStrings
    {
        public static void Main(string[] args)
        {
            string escapingQuotes = "The \"use\" of quotations causes difficulties.";
            string citingQuotes = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(escapingQuotes);
            Console.WriteLine();
            Console.WriteLine(citingQuotes);
        }
    }
}
