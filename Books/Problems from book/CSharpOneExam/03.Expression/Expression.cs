namespace Expression
{
    using System;
    using System.Globalization;
    using System.Threading;

    class Expression
    {
        static string CalculateExpression(string inputString)
        {
            string number = "";
            double CEpreviousNum = 0.0;
            double CEnextNum = 0.0;
            double CEoutput = 0;
            for (int counter = 0; counter < inputString.Length; counter++)
            {
                string buffer = "";
                int checkForDigit = inputString[counter] - '0';
                while (counter < inputString.Length &&
                    inputString[counter] == '.' ||
                    (checkForDigit > -1 && checkForDigit < 10))
                {
                    buffer = buffer + inputString[counter];
                    counter++;
                    checkForDigit = inputString[counter] - '0';
                    CEpreviousNum = double.Parse(buffer);
                }
                buffer = "";
                if (inputString[counter] == '.' || (checkForDigit < 0 || checkForDigit > 9))
                {
                    switch (inputString[counter])
                    {
                        case '+':
                            {
                                counter++;
                                checkForDigit = inputString[counter] - '0';
                                while (counter < inputString.Length &&
                                    inputString[counter] == '.' ||
                                    (checkForDigit > -1 && checkForDigit < 10))
                                {
                                    buffer = buffer + inputString[counter];
                                    counter++;
                                    if (counter == inputString.Length)
                                    {
                                        break;
                                    }
                                    checkForDigit = inputString[counter] - '0';
                                }
                                CEnextNum = double.Parse(buffer);
                                CEoutput = CEpreviousNum + CEnextNum;
                                CEpreviousNum = CEoutput;
                                counter--;
                                break;
                            }
                        case '-':
                            {
                                counter++;
                                checkForDigit = inputString[counter] - '0';
                                while (counter < inputString.Length &&
                                    inputString[counter] == '.' ||
                                    (checkForDigit > -1 && checkForDigit < 10))
                                {
                                    buffer = buffer + inputString[counter];
                                    counter++;
                                    if (counter == inputString.Length)
                                    {
                                        break;
                                    }
                                    checkForDigit = inputString[counter] - '0';
                                }
                                CEnextNum = double.Parse(buffer);
                                CEoutput = CEpreviousNum - CEnextNum;
                                CEpreviousNum = CEoutput;
                                counter--;
                                break;
                            }
                        case '*':
                            {
                                counter++;
                                checkForDigit = inputString[counter] - '0';
                                while (counter < inputString.Length &&
                                    inputString[counter] == '.' ||
                                    (checkForDigit > -1 && checkForDigit < 10))
                                {
                                    buffer = buffer + inputString[counter];
                                    counter++;
                                    if (counter == inputString.Length)
                                    {
                                        break;
                                    }
                                    checkForDigit = inputString[counter] - '0';
                                }
                                CEnextNum = double.Parse(buffer);
                                CEoutput = CEpreviousNum * CEnextNum;
                                CEpreviousNum = CEoutput;
                                counter--;
                                break;
                            }
                        case '/':
                            {
                                counter++;
                                checkForDigit = inputString[counter] - '0';
                                while (counter < inputString.Length &&
                                    inputString[counter] == '.' ||
                                    (checkForDigit > -1 && checkForDigit < 10))
                                {
                                    buffer = buffer + inputString[counter];
                                    counter++;
                                    if (counter == inputString.Length)
                                    {
                                        break;
                                    }
                                    checkForDigit = inputString[counter] - '0';
                                }
                                CEnextNum = double.Parse(buffer);
                                CEoutput = CEpreviousNum / CEnextNum;
                                CEpreviousNum = CEoutput;
                                counter--;
                                break;
                            }
                    } //end switch
                }//end if
            }//end for
            return Convert.ToString(CEoutput);
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //input
            string inputAsString = Console.ReadLine();
            string inputLessBrackets = "";

            //calculations
            for (int counter = 0; counter < inputAsString.Length; counter++)
            {

                if (inputAsString[counter] == '(')
                {
                    string inBracketsString = "";
                    counter++;
                    while (inputAsString[counter] != ')')
                    {
                        inBracketsString = inBracketsString + inputAsString[counter];
                        counter++;
                    }
                    inputLessBrackets = inputLessBrackets + CalculateExpression(inBracketsString);
                }
                else
                {
                    inputLessBrackets = inputLessBrackets + inputAsString[counter];
                }
            }

            double finalOutput = double.Parse(CalculateExpression(inputLessBrackets));

            //ouptut
            Console.WriteLine("{0:F2}", finalOutput);
        }
    }
}