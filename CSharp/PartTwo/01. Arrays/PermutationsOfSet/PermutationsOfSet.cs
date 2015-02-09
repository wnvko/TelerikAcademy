/*
 * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
 */

using System;

public class PermutationsOfSet
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of permutations: ");
        int numberOfPermutations = int.Parse(Console.ReadLine());

        // Based on the Johnson-Trotter algorithm. More here: http://www.cut-the-knot.org/Curriculum/Combinatorics/JohnsonTrotter.shtml
        int mobileNumber = numberOfPermutations;
        char[] directions = new char[numberOfPermutations];
        int[] numbers = new int[numberOfPermutations];
        
        for (int index = 0; index < numberOfPermutations; index++)
        {
            directions[index] = 'L';
            numbers[index] = index + 1;
            Console.Write("{0}\t", numbers[index]);
        }

        Console.WriteLine();
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
                Console.Write("{0}\t", numbers[index]);
            }

            Console.WriteLine();
            mobileNumber = numberOfPermutations;
        }
    }
}
