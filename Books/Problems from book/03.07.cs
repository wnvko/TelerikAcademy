using System;

namespace ConsoleApplication1
{
    class Chapter03Problem07
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете вашата маса: ");
            string mass = System.Console.ReadLine();
            double massDouble = Convert.ToDouble(mass);
            double weightOnEarth = massDouble * 9.81;
            double weightOnMoon = massDouble * 9.81 * 0.18;
            Console.WriteLine("Вашето тегло на Земята е "+weightOnEarth+" N");
            Console.WriteLine("Вашето тегло на Луната е " + weightOnMoon+ " N");
        }
    }
}
