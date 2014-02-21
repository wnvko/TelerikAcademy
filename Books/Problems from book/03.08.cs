using System;

namespace ConsoleApplication1
{
    class Chapter03Problem08
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете абциса на точката: ");
            string x = System.Console.ReadLine();
            double xDouble = Convert.ToDouble(x);
            Console.WriteLine("Въведете ордината на точката: ");
            string y = System.Console.ReadLine();
            double yDouble = Convert.ToDouble(y);            
            Console.WriteLine((xDouble*xDouble+yDouble*yDouble)<25 ? "Точката е в окръжността" : "Точката НЕ е в окръжността");            
        }
    }
}
