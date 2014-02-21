/*
 * Write a program to check if in a given expression the
 * brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)).
 */

namespace BraketChecker
{
    using System;

    public class BraketChecker
    {
        public static string TakeUserInput()
        {
            Console.Write("Enter an expression: ");
            string userExpression = Console.ReadLine();
            return userExpression;
        }

        public static bool CheckBrackets(string inputExpression)
        {
            bool isBracketsCorrect = true;
            int leftBracketsCount = 0;
            for (int counter = 0; counter < inputExpression.Length; counter++)
            {
                if (inputExpression[counter] == '(')
                {
                    leftBracketsCount++;
                }
                else if (inputExpression[counter] == ')')
                {
                    leftBracketsCount--;
                }

                if (leftBracketsCount<0)
                {
                    isBracketsCorrect = false;
                    return isBracketsCorrect;
                }
            }

            if (leftBracketsCount < 0)
            {
                isBracketsCorrect = false;
                return isBracketsCorrect;
            }

            return isBracketsCorrect;
        }
        public static void Main()
        {
            string userInput = TakeUserInput();
            bool corretExpression = CheckBrackets(userInput);
            if (corretExpression)
            {
                Console.WriteLine(userInput);
                Console.WriteLine("is with correct brackets.");
            }
            else
            {
                Console.WriteLine(userInput);
                Console.WriteLine("is with incorrect brackets.");
            }
        }
    }
}