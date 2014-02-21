namespace ExcelColumns
{
    using System;

    class ExcelColumns
    {
        static void Main()
        {
            //accept input data
            int numberOfLetters = int.Parse(Console.ReadLine());
            char [] columnLetters = new char[numberOfLetters];
            for (int i = 0; i < numberOfLetters; i++)
            {
                columnLetters[numberOfLetters - 1 - i] = char.Parse(Console.ReadLine());
            }

            double result = 0;

            //calculate the result
            for (int i = 0; i < numberOfLetters;i++ )
            {
                long buffer = LetterToInt(columnLetters[i]);
                result = result + buffer * Math.Pow(26.0, i);
            }

            Console.WriteLine(result);
        }

        //convert letter to long
        static long LetterToInt(char LetterToConvert)
        {
            long result = 0;
            switch (LetterToConvert)
            {
                case 'A': result = 1; break;
                case 'B': result = 2; break;
                case 'C': result = 3; break;
                case 'D': result = 4; break;
                case 'E': result = 5; break;
                case 'F': result = 6; break;
                case 'G': result = 7; break;
                case 'H': result = 8; break;
                case 'I': result = 9; break;
                case 'J': result = 10; break;
                case 'K': result = 11; break;
                case 'L': result = 12; break;
                case 'M': result = 13; break;
                case 'N': result = 14; break;
                case 'O': result = 15; break;
                case 'P': result = 16; break;
                case 'Q': result = 17; break;
                case 'R': result = 18; break;
                case 'S': result = 19; break;
                case 'T': result = 20; break;
                case 'U': result = 21; break;
                case 'V': result = 22; break;
                case 'W': result = 23; break;
                case 'X': result = 24; break;
                case 'Y': result = 25; break;
                case 'Z': result = 26; break;
            }
            return result;
        }
    }
}
