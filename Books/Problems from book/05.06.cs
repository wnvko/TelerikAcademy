using System;

namespace BookHomeworks
{
    class Chapter05Problem06
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете коефициента а: ");
            double parameterA = int.Parse(Console.ReadLine());
            Console.Write("Въведете коефициента b: ");
            double parameterB = int.Parse(Console.ReadLine());
            Console.Write("Въведете коефициента c: ");
            double parameterC = int.Parse(Console.ReadLine());
            double determinant = parameterB * parameterB - 4 * parameterA * parameterC;
            if (determinant < 0)
            {
                Console.WriteLine("\nУравнението няма реално решение.");
            }
            else
            {
                if (determinant == 0)
                {
                    double xFirst = (-parameterB) / (2 * parameterA);
                    double xSecond = xFirst;
                    Console.WriteLine("\nУравнението има един двоен корен {0}", xFirst);
                }
                else
                {
                    double xFirst = (-parameterB + Math.Sqrt(determinant)) / (2 * parameterA);
                    double xSecond = (-parameterB - Math.Sqrt(determinant)) / (2 * parameterA);
                    Console.WriteLine("\nУравнението има два корена {0} и {1}", xFirst, xSecond);
                }
            }
        }
    }
}