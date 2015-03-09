/*
 * Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
 *  - If an invalid number or non-number text is entered, the method should throw an exception.
 * Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
 */

using System;

public class EnterNumbers
{
    public static void Main()
    {
        Console.WriteLine("Enter ten integers between 0 and 100 in ascending order");
        try
        {
            int currentNumber = ReadNumber(0, 100);
            for (int counter = 1; counter < 10; counter++)
            {
                currentNumber = ReadNumber(currentNumber, 100);
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

    private static int ReadNumber(int start, int end)
    {
        if (start > end)
        {
            throw new ArgumentOutOfRangeException("The end number should be bigger than start number!");
        }

        int userInput = 0;
        Console.Write("Please enter an integer between {0} and {1}: ", start, end);
        try
        {
            userInput = int.Parse(Console.ReadLine());
            if (userInput < start || userInput > end)
            {
                throw new ArgumentOutOfRangeException(string.Format("The integer you have entered is not in the range ({0} is not between {1} - {2})", userInput, start, end));
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
}
