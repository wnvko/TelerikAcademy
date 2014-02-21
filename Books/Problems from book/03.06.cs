using System;

namespace ConsoleApplication1
{
    class Chapter03Problem06
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете широчината: ");
            string width = System.Console.ReadLine();
            double w = Convert.ToDouble(width);
            Console.WriteLine("Въведете височината: ");
            string height = System.Console.ReadLine();
            double h = Convert.ToDouble(height);
            double perimeter = 2 * w + 2 * h;            
            double area = w*h;
            Console.WriteLine("Площта е "+area+" квадратни нещо си");
            Console.WriteLine("Периметъра е " + perimeter + " нещо си");
        }
    }
}
