namespace TripleRotationOfDigits
{
    using System;

    class TripleRotationOfDigits
    {
        static void Main()
        {   
            int K = int.Parse(Console.ReadLine());
            int digitCount = 5;
            int[] digit = new int[6];
            for (int i = 0; i < 6; i++)
            {
                if (K == 0)
                {
                    digitCount = i - 1;
                    break;
                }
                digit[i] = K % 10;
                K /= 10;
            }

            for (int i = 0; i < 3; i++)
            {
                if (digit[0] == 0)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        digit[j] = digit[j + 1];
                    }
                    digit[digitCount] = 0;
                    digitCount--;
                }
                else
                {
                    int buffer = digit[0];
                    for (int j = 0; j < 5; j++)
                    {
                        digit[j] = digit[j + 1];
                    }
                    digit[digitCount] = buffer;
                }
            }
            for (int i = (digitCount); i > -1; i--)
            {
                Console.Write(digit[i]);
            }
            Console.WriteLine();
        }
    }
}
