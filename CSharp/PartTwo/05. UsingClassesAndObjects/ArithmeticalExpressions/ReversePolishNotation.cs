using System;
using System.Collections;
using System.Text.RegularExpressions;

public class ReversePolishNotation
{
    private Queue output;
    private Stack ops;

    private string stringOriginalExpression;
    private string stringTransitionExpression;
    private string stringPostfixExpression;

    public ReversePolishNotation()
    {
        this.stringOriginalExpression = string.Empty;
        this.stringTransitionExpression = string.Empty;
        this.stringPostfixExpression = string.Empty;
    }

    public enum TokenType
    {
        None,
        Number,
        Constant,
        Plus,
        Minus,
        Multiply,
        Divide,
        NaturalLogarithm,
        Power,
        SquareRoot,
        LeftParenthesis,
        RightParenthesis,
        UnaryMinus,
        Coma
    }

    public string OriginalExpression
    {
        get { return this.stringOriginalExpression; }
    }

    public string TransitionExpression
    {
        get { return this.stringTransitionExpression; }
    }

    public string PostfixExpression
    {
        get { return this.stringPostfixExpression; }
    }

    public void Parse(string expression)
    {
        this.output = new Queue();
        this.ops = new Stack();

        this.stringOriginalExpression = expression;

        string stringBuffer = expression.ToLower();

        // captures numbers. Anything like 11 or 22.34 is captured
        stringBuffer = Regex.Replace(stringBuffer, @"(?<number>\d+(\.\d+)?)", " ${number} ");

        // captures these symbols: + - * / ( ) ,
        stringBuffer = Regex.Replace(stringBuffer, @"(?<ops>[+\-*/(),])", " ${ops} ");

        // captures alphabets. Currently captures the two math constants PI and E,
        // and the natural logarithm, power and square root
        stringBuffer = Regex.Replace(stringBuffer, "(?<alpha>(pi|e|ln|sqrt|pow))", " ${alpha} ");

        // trims up consecutive spaces and replace it with just one space
        stringBuffer = Regex.Replace(stringBuffer, @"\s+", " ").Trim();

        // The following chunk captures unary minus operations.
        // 1) We replace every minus sign with the string "MINUS".
        // 2) Then if we find a "MINUS" with a number or constant in front,
        //    then it's a normal minus operation.
        // 3) If we find "MINUS" with a right bracket in front,
        //    then it's a normal minus operation.
        // 4) Otherwise, it's a unary minus operation.

        // Step 1.
        stringBuffer = Regex.Replace(stringBuffer, "-", "MINUS");

        // Step 2. Looking for pi or e or generic number \d+(\.\d+)?
        stringBuffer = Regex.Replace(stringBuffer, @"(?<number>(pi|e|(\d+(\.\d+)?)))\s+MINUS", "${number} -");

        // Step 3. Looking for )
        stringBuffer = Regex.Replace(stringBuffer, @"(?<number>[)])\s+MINUS", "${number} -");

        // Step 4. Use the tilde ~ as the unary minus operator
        stringBuffer = Regex.Replace(stringBuffer, "MINUS", "~");

        this.stringTransitionExpression = stringBuffer;

        // tokenize it!
        string[] stringParsed = stringBuffer.Split(" ".ToCharArray());
        int i = 0;
        double tokenValue;
        bool number = false;
        ReversePolishNotationToken token;
        ReversePolishNotationToken opstoken;
        for (i = 0; i < stringParsed.Length; ++i)
        {
            token = new ReversePolishNotationToken();
            token.TokenValue = stringParsed[i];
            token.TokenValueType = TokenType.None;
            number = double.TryParse(stringParsed[i], out tokenValue);
            if (number)
            {
                token.TokenValueType = TokenType.Number;

                // If the token is a number, then add it to the output queue.
                this.output.Enqueue(token);
            }
            else
            {
                switch (stringParsed[i])
                {
                    case "+":
                        {
                            token.TokenValueType = TokenType.Plus;
                            if (this.ops.Count > 0)
                            {
                                opstoken = (ReversePolishNotationToken)this.ops.Peek();

                                // while there is an operator, o2, at the top of the stack
                                while (this.IsOperatorToken(opstoken.TokenValueType))
                                {
                                    // pop o2 off the stack, onto the output queue;
                                    this.output.Enqueue(this.ops.Pop());
                                    if (this.ops.Count > 0)
                                    {
                                        opstoken = (ReversePolishNotationToken)this.ops.Peek();
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            // push o1 onto the operator stack.
                            this.ops.Push(token);
                            break;
                        }

                    case "-":
                        {
                            token.TokenValueType = TokenType.Minus;
                            if (this.ops.Count > 0)
                            {
                                opstoken = (ReversePolishNotationToken)this.ops.Peek();

                                // while there is an operator, o2, at the top of the stack
                                while (this.IsOperatorToken(opstoken.TokenValueType))
                                {
                                    // pop o2 off the stack, onto the output queue;
                                    this.output.Enqueue(this.ops.Pop());
                                    if (this.ops.Count > 0)
                                    {
                                        opstoken = (ReversePolishNotationToken)this.ops.Peek();
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            // push o1 onto the operator stack.
                            this.ops.Push(token);
                            break;
                        }

                    case "*":
                        {
                            token.TokenValueType = TokenType.Multiply;
                            if (this.ops.Count > 0)
                            {
                                opstoken = (ReversePolishNotationToken)this.ops.Peek();

                                // while there is an operator, o2, at the top of the stack
                                while (this.IsOperatorToken(opstoken.TokenValueType))
                                {
                                    if (opstoken.TokenValueType == TokenType.Plus || opstoken.TokenValueType == TokenType.Minus)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        // Once we're in here, the following algorithm condition is satisfied.
                                        // o1 is associative or left-associative and its precedence is less than (lower precedence) or equal to that of o2, or
                                        // o1 is right-associative and its precedence is less than (lower precedence) that of o2,

                                        // pop o2 off the stack, onto the output queue;
                                        this.output.Enqueue(this.ops.Pop());
                                        if (this.ops.Count > 0)
                                        {
                                            opstoken = (ReversePolishNotationToken)this.ops.Peek();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }

                            // push o1 onto the operator stack.
                            this.ops.Push(token);
                            break;
                        }

                    case "/":
                        {
                            token.TokenValueType = TokenType.Divide;
                            if (this.ops.Count > 0)
                            {
                                opstoken = (ReversePolishNotationToken)this.ops.Peek();

                                // while there is an operator, o2, at the top of the stack
                                while (this.IsOperatorToken(opstoken.TokenValueType))
                                {
                                    if (opstoken.TokenValueType == TokenType.Plus || opstoken.TokenValueType == TokenType.Minus)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        // Once we're in here, the following algorithm condition is satisfied.
                                        // o1 is associative or left-associative and its precedence is less than (lower precedence) or equal to that of o2, or
                                        // o1 is right-associative and its precedence is less than (lower precedence) that of o2,

                                        // pop o2 off the stack, onto the output queue;
                                        this.output.Enqueue(this.ops.Pop());
                                        if (this.ops.Count > 0)
                                        {
                                            opstoken = (ReversePolishNotationToken)this.ops.Peek();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }

                            // push o1 onto the operator stack.
                            this.ops.Push(token);
                            break;
                        }

                    case "~":
                        {
                            token.TokenValueType = TokenType.UnaryMinus;

                            // push o1 onto the operator stack.
                            this.ops.Push(token);
                            break;
                        }

                    case ",":
                        {
                            token.TokenValueType = TokenType.Coma;

                            // Until the topmost element of the stack is a left parenthesis,
                            // pop the element onto the output queue.
                            if (this.ops.Count > 0)
                            {
                                opstoken = (ReversePolishNotationToken)this.ops.Peek();

                                // Until the token at the top of the stack is a left parenthesis
                                while (opstoken.TokenValueType != TokenType.LeftParenthesis)
                                {
                                    // pop operators off the stack onto the output queue
                                    this.output.Enqueue(this.ops.Pop());
                                    if (this.ops.Count > 0)
                                    {
                                        opstoken = (ReversePolishNotationToken)this.ops.Peek();
                                    }
                                    else
                                    {
                                        // If the stack runs out without finding a left parenthesis,
                                        // then there are mismatched parentheses.
                                        throw new Exception("Unbalanced parenthesis!");
                                    }
                                }
                            }

                            break;
                        }

                    case "(":
                        {
                            token.TokenValueType = TokenType.LeftParenthesis;

                            // If the token is a left parenthesis, then push it onto the stack.
                            this.ops.Push(token);
                            break;
                        }

                    case ")":
                        {
                            token.TokenValueType = TokenType.RightParenthesis;
                            if (this.ops.Count > 0)
                            {
                                opstoken = (ReversePolishNotationToken)this.ops.Peek();

                                // Until the token at the top of the stack is a left parenthesis
                                while (opstoken.TokenValueType != TokenType.LeftParenthesis)
                                {
                                    // pop operators off the stack onto the output queue
                                    this.output.Enqueue(this.ops.Pop());
                                    if (this.ops.Count > 0)
                                    {
                                        opstoken = (ReversePolishNotationToken)this.ops.Peek();
                                    }
                                    else
                                    {
                                        // If the stack runs out without finding a left parenthesis,
                                        // then there are mismatched parentheses.
                                        throw new Exception("Unbalanced parenthesis!");
                                    }
                                }

                                // Pop the left parenthesis from the stack, but not onto the output queue.
                                this.ops.Pop();
                            }

                            if (this.ops.Count > 0)
                            {
                                opstoken = (ReversePolishNotationToken)this.ops.Peek();

                                // If the token at the top of the stack is a function token
                                if (this.IsFunctionToken(opstoken.TokenValueType))
                                {
                                    // pop it and onto the output queue.
                                    this.output.Enqueue(this.ops.Pop());
                                }
                            }

                            break;
                        }

                    case "pi":
                        {
                            token.TokenValueType = TokenType.Constant;

                            // If the token is a number, then add it to the output queue.
                            this.output.Enqueue(token);
                            break;
                        }

                    case "e":
                        {
                            token.TokenValueType = TokenType.Constant;

                            // If the token is a number, then add it to the output queue.
                            this.output.Enqueue(token);
                            break;
                        }

                    case "ln":
                        {
                            token.TokenValueType = TokenType.NaturalLogarithm;

                            // If the token is a function token, then push it onto the stack.
                            this.ops.Push(token);
                            break;
                        }

                    case "sqrt":
                        {
                            token.TokenValueType = TokenType.SquareRoot;

                            // If the token is a function token, then push it onto the stack.
                            this.ops.Push(token);
                            break;
                        }

                    case "pow":
                        {
                            token.TokenValueType = TokenType.Power;

                            // push o1 onto the operator stack.
                            this.ops.Push(token);
                            break;
                        }
                }
            }
        }

        // When there are no more tokens to read:

        // While there are still operator tokens in the stack:
        while (this.ops.Count != 0)
        {
            opstoken = (ReversePolishNotationToken)this.ops.Pop();

            // If the operator token on the top of the stack is a parenthesis
            if (opstoken.TokenValueType == TokenType.LeftParenthesis)
            {
                // then there are mismatched parenthesis.
                throw new Exception("Unbalanced parenthesis!");
            }
            else
            {
                // Pop the operator onto the output queue.
                this.output.Enqueue(opstoken);
            }
        }

        this.stringPostfixExpression = string.Empty;
        foreach (object obj in this.output)
        {
            opstoken = (ReversePolishNotationToken)obj;
            this.stringPostfixExpression += string.Format("{0} ", opstoken.TokenValue);
        }
    }

    public double Evaluate()
    {
        Stack result = new Stack();
        double oper1 = 0.0;
        double oper2 = 0.0;
        ReversePolishNotationToken token = new ReversePolishNotationToken();

        // While there are input tokens left
        foreach (object obj in this.output)
        {
            // Read the next token from input.
            token = (ReversePolishNotationToken)obj;
            switch (token.TokenValueType)
            {
                case TokenType.Number:
                    // If the token is a value
                    // Push it onto the stack.
                    {
                        result.Push(double.Parse(token.TokenValue));
                        break;
                    }

                case TokenType.Constant:
                    // If the token is a value
                    // Push it onto the stack.
                    {
                        result.Push(this.EvaluateConstant(token.TokenValue));
                        break;
                    }

                case TokenType.Plus:
                    // NOTE: n is 2 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 2)
                        {
                            // So, pop the top n values from the stack.
                            oper2 = (double)result.Pop();
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(oper1 + oper2);
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }

                case TokenType.Minus:
                    // NOTE: n is 2 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 2)
                        {
                            // So, pop the top n values from the stack.
                            oper2 = (double)result.Pop();
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(oper1 - oper2);
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }

                case TokenType.Multiply:
                    // NOTE: n is 2 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 2)
                        {
                            // So, pop the top n values from the stack.
                            oper2 = (double)result.Pop();
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(oper1 * oper2);
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }

                case TokenType.Divide:
                    // NOTE: n is 2 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 2)
                        {
                            // So, pop the top n values from the stack.
                            oper2 = (double)result.Pop();
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(oper1 / oper2);
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }

                case TokenType.Power:
                    // NOTE: n is 2 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 2)
                        {
                            // So, pop the top n values from the stack.
                            oper2 = (double)result.Pop();
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(Math.Pow(oper1, oper2));
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }

                case TokenType.UnaryMinus:
                    // NOTE: n is 1 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 1)
                        {
                            // So, pop the top n values from the stack.
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(-oper1);
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }

                case TokenType.NaturalLogarithm:
                    // NOTE: n is 1 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 1)
                        {
                            // So, pop the top n values from the stack.
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(Math.Log(oper1));
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }

                case TokenType.SquareRoot:
                    // NOTE: n is 1 in this case
                    // If there are fewer than n values on the stack
                    {
                        if (result.Count >= 1)
                        {
                            // So, pop the top n values from the stack.
                            oper1 = (double)result.Pop();

                            // Evaluate the function, with the values as arguments.
                            // Push the returned results, if any, back onto the stack.
                            result.Push(Math.Sqrt(oper1));
                        }
                        else
                        {
                            // (Error) The user has not input sufficient values in the expression.
                            throw new Exception("Evaluation error!");
                        }

                        break;
                    }
            }
        }

        // If there is only one value in the stack
        if (result.Count == 1)
        {
            // That value is the result of the calculation.
            return (double)result.Pop();
        }
        else
        {
            // If there are more values in the stack
            // (Error) The user input too many values.
            throw new Exception("Evaluation error!");
        }
    }

    private bool IsOperatorToken(TokenType t)
    {
        bool result = false;
        switch (t)
        {
            case TokenType.Plus:
            case TokenType.Minus:
            case TokenType.Multiply:
            case TokenType.Divide:
            case TokenType.UnaryMinus:
                {
                    result = true;
                    break;
                }

            default:
                {
                    result = false;
                    break;
                }
        }

        return result;
    }

    private bool IsFunctionToken(TokenType t)
    {
        bool result = false;
        switch (t)
        {
            case TokenType.NaturalLogarithm:
            case TokenType.SquareRoot:
            case TokenType.Power:
                result = true;
                break;
            default:
                result = false;
                break;
        }

        return result;
    }

    private double EvaluateConstant(string tokenValue)
    {
        double result = 0.0;
        switch (tokenValue)
        {
            case "pi":
                result = Math.PI;
                break;
            case "e":
                result = Math.E;
                break;
        }

        return result;
    }

    public struct ReversePolishNotationToken
    {
        public string TokenValue;
        public TokenType TokenValueType;
    }
}
