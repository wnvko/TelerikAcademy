/*
 * Write a method ReadNumber(int start, int end) that enters an
 * integer number in given range [start…end]. If an invalid number
 * or non-number text is entered, the method should throw an
 * exception. Using this method write a program that enters 10 numbers:
 * a1, a2, … a10, such that 1 < a1 < … < a10 < 100
 */

namespace LimitedNumberReader
{
    using System;

    public class LimitedNumberReader
    {
        /// <summary>
        /// Checks if the number user entered is in range between between
        ///  lower and upper limit and if it is actually an integer
        /// </summary>
        /// <param name="lowerLimit">The lower limit of the range</param>
        /// <param name="upperLimit">The upper limit ot he range</param>
        /// <returns></returns>
        public static int CheckNumberToLimits(int lowerLimit, int upperLimit)
        {
            if (lowerLimit > upperLimit)
            {
                throw new ArgumentOutOfRangeException("The upper limit should be bigger than lower limit!");
            }

            int userInput = 0;
            Console.Write("Please enter an integer between {0} and {1}: ", lowerLimit, upperLimit);
            try
            {
                userInput = int.Parse(Console.ReadLine());
                if (userInput <= lowerLimit || userInput >= upperLimit)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The integer you have entered is not in the range" +
                                                                        "({0} is not between {1} - {2})", userInput, lowerLimit, upperLimit));
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("You did not enter anything.");
            }
            catch (FormatException)
            {
                throw new FormatException("You did not enter a number.");
            }
            catch (OverflowException)
            {
                throw new OverflowException(string.Format("The number you entered was too big (bigger than {0})", int.MaxValue));
            }

            return userInput;
        }

        public static void Main()
        {
            Console.WriteLine("Enter ten integers between 0 and 100 in ascending order");
            try
            {
                int currentNumber = CheckNumberToLimits(0, 100);
                for (int counter = 1; counter < 10; counter++)
                {
                    currentNumber = CheckNumberToLimits(currentNumber, 100);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}