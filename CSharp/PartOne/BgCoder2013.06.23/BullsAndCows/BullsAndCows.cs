namespace BullsAndCows
{
    using System;
    using System.Linq;

    class BullsAndCows
    {
        static void Main()
        {
            int secretNumber = int.Parse(Console.ReadLine());
            int bullsCount = int.Parse(Console.ReadLine());
            int cowsCount = int.Parse(Console.ReadLine());

            if ((cowsCount + bullsCount) >= 4)
            {
                Console.WriteLine("No");
                return;
            }
            string output = "";

            //SN stands for Secret Number
            int[] SNPosition = new int[4];

            //GN stands for Gues Number
            int[] GNPosition = new int[4];

            //find and print right numbers
            for (int i = 0; i < 10000; i++)
            {
                int bullsFound = 0;
                int cowsFound = 0;
                int zerosCount = 0;
                bool[] bullOnPosition = new bool[4];

                for (int j = 0; j < 4; j++)
                {
                    GNPosition[j] = ReturnNthDigit(i, j);
                    SNPosition[j] = ReturnNthDigit(secretNumber, j);

                    //omit zeros
                    if (GNPosition[j] == 0)
                    {
                        zerosCount++;
                        break;
                    }
                }

                if (zerosCount > 0)
                {
                    continue;
                }

                //find bulls
                for (int j = 0; j < 4; j++)
                {
                    if (SNPosition[j] == GNPosition[j])
                    {
                        bullsFound++;
                        bullOnPosition[j] = true;
                        SNPosition[j] = 0;
                    }
                }
                if (bullsFound > bullsCount)
                {
                    continue; //this number will not print and will not check cows
                }

                //find cows
                for (int j = 0; j < 4; j++)
                {
                    if (bullOnPosition[j])
                    {
                        continue;
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        if (GNPosition[j] == SNPosition[k])
                        {
                            cowsFound++;
                            SNPosition[k] = 0;
                            break;
                        }
                    }
                }

                //print the neccesary numbers
                if ((bullsCount == bullsFound) && (cowsCount == cowsFound))
                {
                    output = output + GNPosition[3] + GNPosition[2] + GNPosition[1] + GNPosition[0] + " ";
                }
            }
            Console.WriteLine(output);
        }

        //retutn the n-th digit of an integer
        static int ReturnNthDigit(int inputNumber, int digitPosition)
        {
            int divider = 1;
            for (int i = 0; i < digitPosition; i++)
            {
                divider *= 10;
            }

            inputNumber /= divider;
            inputNumber %= 10;
            return inputNumber;
        }
    }
}