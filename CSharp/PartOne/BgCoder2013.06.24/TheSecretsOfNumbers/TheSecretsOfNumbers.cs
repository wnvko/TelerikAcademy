namespace TheSecretsOfNumbers
{
    using System;

    class TheSecretsOfNumbers
    {
        static void Main()
        {
            string inputNumber = Console.ReadLine();
            string unsignedInputNumber = inputNumber.Replace("-", "");//removes minus sign if exist
            int numberLenght = unsignedInputNumber.Length;
            char[] numberDigitAsChar = unsignedInputNumber.ToCharArray();
            int[] numberDigit = new int[numberLenght];
            int specilaSum = 0;

            //convert input number to array of numbers and calculate special sum
            for (int i = 0; i < numberLenght; i++)
            {
                numberDigit[i] = numberDigitAsChar[numberLenght - i - 1] - '0';
                if ((i + 1) % 2 != 0)
                {
                    specilaSum = specilaSum + numberDigit[i] * (i + 1) * (i + 1);
                }
                else
                {
                    specilaSum = specilaSum + numberDigit[i] * numberDigit[i] * (i + 1);
                }   
            }
            int firstLetter = (specilaSum % 26) + 1;
            
            //SAS stands for secret alpha-sequence
            string outputString = "";
            char SAS = 'A';
            int SASLenght = specilaSum % 10;
            for (int i = 0; i < SASLenght; i++)
            {
                if (firstLetter + i > 26)
                {
                    firstLetter -= 26;
                }
                SAS = (char)(firstLetter + i + 64);
                outputString = outputString + SAS;
            }
            if (specilaSum % 10 == 0)
            {
                Console.WriteLine(specilaSum);
                Console.WriteLine(inputNumber + " has no secret alpha-sequence");
            }
            else
            {
                Console.WriteLine(specilaSum);
                Console.WriteLine(outputString);
            }
            
        }
    }
}
