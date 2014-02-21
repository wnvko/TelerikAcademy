using System;

namespace ConsoleApplication
{
    class Chapter06Problem14
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете N: ");
            int N = int.Parse(Console.ReadLine());
            string decToHex = "";
            Console.Write("Десетично {0} = Двоично ", N);
            int ostatak = 0;
            while (N > 0)
            {
                ostatak = N % 16;
                switch (ostatak)
                {
                    case 1: decToHex = 1 + decToHex; break;
                    case 2: decToHex = 2 + decToHex; break;
                    case 3: decToHex = 3 + decToHex; break;
                    case 4: decToHex = 4 + decToHex; break;
                    case 5: decToHex = 5 + decToHex; break;
                    case 6: decToHex = 6 + decToHex; break;
                    case 7: decToHex = 7 + decToHex; break;
                    case 8: decToHex = 8 + decToHex; break;
                    case 9: decToHex = 9 + decToHex; break;
                    case 10: decToHex = "A" + decToHex; break;
                    case 11: decToHex = "B" + decToHex; break;
                    case 12: decToHex = "C" + decToHex; break;
                    case 13: decToHex = "D" + decToHex; break;
                    case 14: decToHex = "E" + decToHex; break;
                    case 15: decToHex = "F" + decToHex; break;
                    default: decToHex = 0 + decToHex; break; 
                }
                
                N = N / 16;
            }
            Console.WriteLine(decToHex);
        }
    }
}