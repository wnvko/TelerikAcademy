namespace SevenlandNumbers
{
    using System;

    class SevenlandNumbers
    {
        static void Main()
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int[] digitOfNumber = new int[4];
            
            //collect each digit of the input number
            for (int i = 0; i < 4; i++)
            {
                digitOfNumber[i] = inputNumber % 10;
                inputNumber /= 10;
            }

            //add one to the number
            digitOfNumber[0]++;
            for (int i = 0; i < 3; i++)
            {
                if (digitOfNumber[i] > 6)
                {
                    digitOfNumber[i] = 0;
                    digitOfNumber[i + 1]++;
                }
            }

            //convert digits to number
            string result = "" + digitOfNumber[3] + digitOfNumber[2] + digitOfNumber[1] + digitOfNumber[0];
            if (digitOfNumber[3] == 0)
            {
                result = "" + digitOfNumber[2] + digitOfNumber[1] + digitOfNumber[0];
            }

            if ((digitOfNumber[3] == 0) && (digitOfNumber[2] == 0))
            {
                result = "" + digitOfNumber[1] + digitOfNumber[0];
            }
            
            if ((digitOfNumber[3] == 0) && (digitOfNumber[2] == 0) && (digitOfNumber[1] == 0))
            {
                result = "" + digitOfNumber[0];
            }

            Console.WriteLine(result);
        }
    }
}
