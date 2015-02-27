/*
 * Write a program that calculates the value of given arithmetical expression. The expression can
 * contain the following elements only:
 *    - Real numbers, e.g. 5, 18.33, 3.14159, 12.6
 *    - Arithmetic operators: +, -, *, / (standard priorities)
 *    - Mathematical functions: ln(x), sqrt(x), pow(x,y)
 *    - Brackets (for changing the default priorities): (, )
 *  
 * Examples:
 *                      input                           |	output
 * (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)              |	~10.6
 * pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)   |	~21.22
 */

/*
 * Original source for the code below
 * http://www.dreamincode.net/forums/topic/35320-reverse-polish-notation-in-c%23/
 * I just replaced some functions and fix two bugs:
 *  1) On row 142 check if the '-' sign is after closing (right) bracket
 *  2) On row 302 check and manipulate if there is coma in expression
  */

using System;
using System.Globalization;
using System.Threading;

public class ArithmeticalExpressions
{
    public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double result = 0.0;
        ReversePolishNotation rpn = new ReversePolishNotation();

        // rpn.Parse("pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)");
        rpn.Parse("(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)");
        result = rpn.Evaluate();
        Console.WriteLine("orig:   {0}", rpn.OriginalExpression);
        Console.WriteLine("tran:   {0}", rpn.TransitionExpression);
        Console.WriteLine("post:   {0}", rpn.PostfixExpression);
        Console.WriteLine("result: {0}", result);
    }
}
