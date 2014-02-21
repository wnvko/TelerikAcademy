using System;

namespace ConsoleApplication
{
    class Chapter06Problem15
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете шестнайсеточино число: ");
            string hex = Console.ReadLine();
            int power = 1;
            int N = 0;
            int lenght = hex.Length;
            for (int i = 1; i <= lenght; i++)
            {
                Console.WriteLine(hex.Substring((lenght - i), 1));
                Console.WriteLine(Convert.ToChar(hex.Substring((lenght - i), 1)));
                Console.WriteLine(Convert.ToInt32(Convert.ToChar(hex.Substring((lenght - i), 1))));
                switch(Convert.ToInt32(Convert.ToChar(hex.Substring((lenght - i), 1))))//checks the last uncheck hex digit, then convert to char and then convert ot int. char 1 = int 31; char A = int 41
                {
                    case 49: N = N + 1 * power; break;
                    case 50: N = N + 2 * power; break;
                    case 51: N = N + 3 * power; break;
                    case 52: N = N + 4 * power; break;
                    case 53: N = N + 5 * power; break;
                    case 54: N = N + 6 * power; break;
                    case 55: N = N + 7 * power; break;
                    case 56: N = N + 8 * power; break;
                    case 57: N = N + 9 * power; break;
                    case 65: N = N + 10 * power; break;
                    case 66: N = N + 11 * power; break;
                    case 67: N = N + 12 * power; break;
                    case 68: N = N + 13 * power; break;
                    case 69: N = N + 14 * power; break;
                    case 70: N = N + 15 * power; break;
                    default: N = N + 0 * power; break;
                }
                power *= 16;
            }
            Console.WriteLine("Шестнайсетично {0} = Десетично {1}", hex, N);
        }
    }
}