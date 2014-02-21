namespace CheckIfSumIsZero
{
    using System;

    class CheckIfSumIsZero
    {
        static void Main()
        {
            /*
             * We are given 5 integer numbers. Write a program that checks
             * if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 -> 1+1-2=0.
             */

            int[] numbers = new int [5];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Please enter Number[{0}]: ", (i + 1));
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    Console.WriteLine("Sum of {0} = 0", numbers[i]);
                }
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if ((numbers[i] + numbers[j]) == 0)
                    {
                        Console.WriteLine("Sum of {0} + {1} = 0", numbers[i], numbers[j]);
                    }
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        if ((numbers[i] + numbers[j] + numbers[k]) == 0)
                        {
                            Console.WriteLine("Sum of {0} + {1} + {2} = 0", numbers[i], numbers[j], numbers[k]);
                        }
                        for (int l = k + 1; l < numbers.Length; l++)
                        {
                            if ((numbers[i] + numbers[j] + numbers[k] + numbers[l]) == 0)
                            {
                                Console.WriteLine("Sum of {0} + {1} + {2} + {3} = 0", numbers[i], numbers[j], numbers[k], numbers[l]);
                            }
                        }
                    }
                }
            }
            if ((numbers[0]+numbers[1]+numbers[2]+numbers[3]+numbers[4]) == 0)
            {
                Console.WriteLine("Sum of {0} + {1} + {2} + {3} + {4} = 0",numbers[0], numbers[1], numbers[2],numbers[3], numbers[4]);
            }
        }
    }
}