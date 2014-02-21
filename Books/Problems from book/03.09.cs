using System;

namespace ConsoleApplication1
{
    class Chapter03Problem09
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете абциса на точката: ");
            string x = System.Console.ReadLine();
            double xDouble = Convert.ToDouble(x);
            Console.WriteLine("Въведете ордината на точката: ");
            string y = System.Console.ReadLine();
            double yDouble = Convert.ToDouble(y);            
            Console.WriteLine((xDouble*xDouble+yDouble*yDouble)<25 && (xDouble<-1 || xDouble>5) && (yDouble<1 || yDouble>5) ? "Точката е в окръжността и извън правоъгълника" : "Точката НЕ е в окръжността или е в правоъгълника");            
        }
    }
}
