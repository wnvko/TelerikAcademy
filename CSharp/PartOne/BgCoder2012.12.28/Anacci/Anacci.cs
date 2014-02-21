namespace Anacci
{
    using System;

    class Anacci
    {
        static void Main()
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            long sequenceNumber = int.Parse(Console.ReadLine());

            long allAnacci = sequenceNumber * 2 - 1;
            char[] Anacci = new char[allAnacci];
            long[] anacciAsNumbers = new long[allAnacci];

            //calculating Anaccis
            Anacci[0] = firstLetter;
            anacciAsNumbers[0] = AnacciToInt(Anacci[0]);

            if (sequenceNumber > 1)
            {
                Anacci[1] = secondLetter;
                anacciAsNumbers[1] = AnacciToInt(Anacci[1]);
            }
            for (int i = 2; i < allAnacci; i++)
            {
                anacciAsNumbers[i] = anacciAsNumbers[i - 2] + anacciAsNumbers[i - 1];
                Anacci[i] = IntToAnacci(anacciAsNumbers[i]);
            }

            //console output of result
            Console.WriteLine(Anacci[0]);
            for (int i = 1; i < sequenceNumber; i++)
            {
                int numberOfSpaces = 0;
                if (i > 1)
                {
                    numberOfSpaces = i;
                }
                string output = Convert.ToString(Anacci[i*2]);
                Console.Write(Anacci[i * 2 - 1]);
                Console.WriteLine(output.PadLeft(numberOfSpaces, ' '));
            }
        }

        //convert integer to Anacci
        static char IntToAnacci(long numberToConvert)
        {
            char result = ' ';
            numberToConvert = numberToConvert % 26;
            switch (numberToConvert)
            {
                case 1: result = 'A'; break;
                case 2: result = 'B'; break;
                case 3: result = 'C'; break;
                case 4: result = 'D'; break;
                case 5: result = 'E'; break;
                case 6: result = 'F'; break;
                case 7: result = 'G'; break;
                case 8: result = 'H'; break;
                case 9: result = 'I'; break;
                case 10: result = 'J'; break;
                case 11: result = 'K'; break;
                case 12: result = 'L'; break;
                case 13: result = 'M'; break;
                case 14: result = 'N'; break;
                case 15: result = 'O'; break;
                case 16: result = 'P'; break;
                case 17: result = 'Q'; break;
                case 18: result = 'R'; break;
                case 19: result = 'S'; break;
                case 20: result = 'T'; break;
                case 21: result = 'U'; break;
                case 22: result = 'V'; break;
                case 23: result = 'W'; break;
                case 24: result = 'X'; break;
                case 25: result = 'Y'; break;
                case 0: result = 'Z'; break;
            }
            return result;
        }

        //convert integer to Anacci
        static long AnacciToInt(char AnacciToConvert)
        {
            long result = 0;
            switch (AnacciToConvert)
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