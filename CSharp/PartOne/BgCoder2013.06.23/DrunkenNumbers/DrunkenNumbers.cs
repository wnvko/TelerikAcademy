using System;

class DrunkenNumbers
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] drunkenNumber = new int[N];
        int mitkoBeers = 0;
        int vladkoBeers = 0;
        for (int i = 0; i < N; i++)
        {
            drunkenNumber[i] = int.Parse(Console.ReadLine());
            if (drunkenNumber[i] < 0)
            {
                drunkenNumber[i] *= -1;
            }
            int sizeOfTheDN = 0;
            int[] drunkenNumberDigit = new int[9];
            for (int j = 0; j < 9; j++)
            {
                drunkenNumberDigit[j] = drunkenNumber[i] % 10;
                drunkenNumber[i] /= 10;
                if (drunkenNumberDigit[j] == 0 && drunkenNumber[i] == 0)
                {
                    break;
                }
                else
                {
                    sizeOfTheDN++;
                }
            }
            switch (sizeOfTheDN)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[0];
                        break;
                    }
                case 2:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[1];
                        break;
                    }
                case 3:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0] + drunkenNumberDigit[1];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[1] + drunkenNumberDigit[2];
                        break;
                    }
                case 4:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0] + drunkenNumberDigit[1];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[2] + drunkenNumberDigit[3];
                        break;
                    }
                case 5:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0] + drunkenNumberDigit[1] + drunkenNumberDigit[2];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[2] + drunkenNumberDigit[3] + drunkenNumberDigit[4];
                        break;
                    }
                case 6:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0] + drunkenNumberDigit[1] + drunkenNumberDigit[2];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[3] + drunkenNumberDigit[4] + drunkenNumberDigit[5];
                        break;
                    }
                case 7:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0] + drunkenNumberDigit[1] + drunkenNumberDigit[2] + drunkenNumberDigit[3];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[3] + drunkenNumberDigit[4] + drunkenNumberDigit[5] + drunkenNumberDigit[6];
                        break;
                    }
                case 8:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0] + drunkenNumberDigit[1] + drunkenNumberDigit[2] + drunkenNumberDigit[3];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[4] + drunkenNumberDigit[5] + drunkenNumberDigit[6] + drunkenNumberDigit[7];
                        break;
                    }
                case 9:
                    {
                        vladkoBeers = vladkoBeers + drunkenNumberDigit[0] + drunkenNumberDigit[1] + drunkenNumberDigit[2] + drunkenNumberDigit[3] + drunkenNumberDigit[4];
                        mitkoBeers = mitkoBeers + drunkenNumberDigit[4] + drunkenNumberDigit[5] + drunkenNumberDigit[6] + drunkenNumberDigit[7] + drunkenNumberDigit[8];
                        break;
                    }
            }
        }
        if (mitkoBeers > vladkoBeers)
        {
            Console.WriteLine("M {0}", (mitkoBeers - vladkoBeers));
        }
        else
        {
            if (mitkoBeers == vladkoBeers)
            {
                Console.WriteLine("No {0}", (mitkoBeers + vladkoBeers));
            }
            else
            {
                Console.WriteLine("V {0}", (vladkoBeers - mitkoBeers));
            }
        }
    }
}