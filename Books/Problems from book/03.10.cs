using System;

namespace ConsoleApplication1
{
    class Chapter03Problem10
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете четирицифрено число: ");
            string absdString = System.Console.ReadLine();
            int abcd = Convert.ToInt16(absdString);
            int d = abcd % 10;
            int c = (abcd / 10) % 10;
            int b = (abcd / 100) % 10;
            int a = (abcd / 1000) % 10;
            int sum = a + b + c + d;
            string dcbaString = Convert.ToString(d) + c + b + a;
            string dabcString = Convert.ToString(d) + a + b + c;
            string acbdString = Convert.ToString(a) + c + b + d;
            Console.WriteLine("Сумата от цифрите е "+sum);
            Console.WriteLine("Числото dcba е "+dcbaString);
            Console.WriteLine("Числото dabc е " + dabcString);
            Console.WriteLine("Числото acbd е " + acbdString);
        }
    }
}
