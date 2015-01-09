namespace PrintTheASCIITable
{
    using System;

    public class PrintTheASCIITable
    {
        public static void Main(string[] args)
        {
            for (int code = 0; code < 256; code++)
            {
                char symbol = (char)code;
                Console.WriteLine("Code {0} -> {1}", code, symbol);
            }
        }
    }
}
