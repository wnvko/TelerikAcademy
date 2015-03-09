/*
 * Write a program that reads an integer number and calculates and prints its square root.
 *  - If the number is invalid or negative, print Invalid number.
 *  - In all cases finally print Good bye.
 * Use try-catch-finally block.
 */

using System;

public class SquareRoot
{
    public static void Main()
    {
        Console.Write("Enter an integer: ");

        try
        {
            int userInput = int.Parse(Console.ReadLine());
            if (userInput < 0)
            {
                throw new ArgumentOutOfRangeException("You have entered a negative number. Square root cannot by proceed!");
            }

            Console.Error.WriteLine("Square root of {0} is {1}.", userInput, Math.Sqrt(userInput));
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("You did not enter anything.");
        }
        catch (FormatException)
        {
            Console.Error.WriteLine("You did not enter a number.");
        }
        catch (OverflowException)
        {
            Console.Error.WriteLine("The number you entered was too big (bigger than {0})", int.MaxValue);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
