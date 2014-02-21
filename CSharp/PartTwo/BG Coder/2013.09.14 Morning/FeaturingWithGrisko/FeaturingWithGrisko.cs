namespace Permutations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class Permutations
    {
        static void Main()
        {
            string inputWord = Console.ReadLine();
            char[] letters = inputWord.ToCharArray();
            StringBuilder permutation = new StringBuilder();
            int options = 0;
            int numberOfPermutations = inputWord.Length;

            int mobileNumber = numberOfPermutations;
            char[] directions = new char[numberOfPermutations];
            int[] numbers = new int[numberOfPermutations];
            for (int index = 0; index < numberOfPermutations; index++)
            {
                directions[index] = 'L';
                numbers[index] = index + 1;
            }

            while (mobileNumber > 1)
            {
                int mobileNumberPosition = 0;
                while (true)
                {
                    if (numbers[mobileNumberPosition] == mobileNumber)
                    {
                        break;
                    }
                    mobileNumberPosition++;
                }

                if ((mobileNumberPosition == 0 && directions[mobileNumberPosition] == 'L') ||
                    (mobileNumberPosition == (numberOfPermutations - 1) && directions[numberOfPermutations - 1] == 'R'))
                {
                    mobileNumber--;
                    continue;
                }
                else if (directions[mobileNumberPosition] == 'L' &&
                    numbers[mobileNumberPosition] > numbers[mobileNumberPosition - 1])
                {
                    int numberBuffer = numbers[mobileNumberPosition];
                    numbers[mobileNumberPosition] = numbers[mobileNumberPosition - 1];
                    numbers[mobileNumberPosition - 1] = numberBuffer;

                    char directionBuffer = directions[mobileNumberPosition];
                    directions[mobileNumberPosition] = directions[mobileNumberPosition - 1];
                    directions[mobileNumberPosition - 1] = directionBuffer;
                }
                else if (directions[mobileNumberPosition] == 'R' &&
                    numbers[mobileNumberPosition] > numbers[mobileNumberPosition + 1])
                {
                    int buffer = numbers[mobileNumberPosition];
                    numbers[mobileNumberPosition] = numbers[mobileNumberPosition + 1];
                    numbers[mobileNumberPosition + 1] = buffer;

                    char directionBuffer = directions[mobileNumberPosition];
                    directions[mobileNumberPosition] = directions[mobileNumberPosition + 1];
                    directions[mobileNumberPosition + 1] = directionBuffer;
                }
                else
                {
                    mobileNumber--;
                    continue;
                }

                for (int index = 0; index < numberOfPermutations; index++)
                {
                    if (numbers[index] > mobileNumber)
                    {
                        if (directions[index] == 'L')
                        {
                            directions[index] = 'R';
                        }
                        else
                        {
                            directions[index] = 'L';
                        }
                    }
                }

                for (int index = 0; index < numberOfPermutations; index++)
                {
                    permutation.Append(letters[numbers[index]-1]);
                }
                char test = inputWord[0];
                bool res = true;
                for (int i = 1; i < inputWord.Length; i++)
                {
                    if (test == inputWord[i])
                    {
                        res = false;
                        break;
                    }
                    test = inputWord[i];
                }

                if (res)
                {
                    options++;
                }
                permutation.Clear();
                mobileNumber = numberOfPermutations;
            }
          char test2 = inputWord[0];
          bool res2 = true;
          for (int i = 1; i < inputWord.Length; i++)
          {
            if (test2 == inputWord[i])
              {
              	res2 = false;
                break;
              }
            test2 = inputWord[i];
          }
          
          if(res2)
          {
              options++;
          }
            Console.WriteLine(options);
        }
    }
}