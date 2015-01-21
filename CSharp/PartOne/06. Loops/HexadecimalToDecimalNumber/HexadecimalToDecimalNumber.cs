namespace HexadecimalToDecimalNumber
{
    using System;

    public class HexadecimalToDecimalNumber
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            string hexumber = Console.ReadLine();
            double decNumber = 0;

            for (int poss = hexumber.Length - 1; poss >= 0; poss--)
            {
                double curentPos = 0;
                switch (hexumber[poss])
                {
                    case 'A':
                        curentPos = 10;
                        break;
                    case 'B':
                        curentPos = 11;
                        break;
                    case 'C':
                        curentPos = 12;
                        break;
                    case 'D':
                        curentPos = 13;
                        break;
                    case 'E':
                        curentPos = 14;
                        break;
                    case 'F':
                        curentPos = 15;
                        break;
                    default:
                        curentPos = hexumber[poss] - '0';
                        break;
                }

                curentPos *= Math.Pow(16, hexumber.Length - poss - 1);

                decNumber += curentPos;
            }

            Console.WriteLine(decNumber);
        }
    }
}
