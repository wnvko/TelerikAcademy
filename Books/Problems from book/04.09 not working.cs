using System;

namespace BookHomeworks
{
    class Chapter04Problem09
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int c;
            int det;
            bool aIsNumber = false;
            while (!aIsNumber)
                {
                    Console.WriteLine("Въведете параметъра а: ");
                    string userInput = Console.ReadLine();
                    aIsNumber = Int32.TryParse(userInput, out a);
                }
            bool bIsNumber = false;
            while (!bIsNumber)
                {
                    Console.WriteLine("Въведете параметъра b: ");
                    string userInput = Console.ReadLine();
                    bIsNumber = Int32.TryParse(userInput, out b);
                }
            bool cIsNumber = false;    
            while (!cIsNumber)
                {
                    Console.WriteLine("Въведете параметъра c: ");
                    string userInput = Console.ReadLine();
                    cIsNumber = Int32.TryParse(userInput, out c);
                }
            det = b * b - 4 * a * c;
            if (det < 0)
            {
                Console.WriteLine("Детерминантата е по-малка от 0. Уравнението няма реални корени");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(Convert.ToDouble(det))) / (2 * a);
                double x2 = (-b - Math.Sqrt(Convert.ToDouble(det))) / (2 * a);
                Console.WriteLine("Корените на уравнението са:");
                Console.WriteLine("х1: {0}", x1);
                Console.WriteLine("х2: {0}", x1);
            }
        }
    }
}
