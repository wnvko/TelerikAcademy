using System;

namespace ConsoleApplication1
{
    class Chapter03Problem04
    {
        static void Main(string[] args)
        {
            byte a = 10;
            byte b = 8;            
            bool c = a & b;
            Console.WriteLine( c ? "Третата цифра на числото е 1" : "Третата цифра на числото е 0");
        }
    }
}
