/*
 * start 23:50
 * end 1:58 @ 100
 */

namespace DecodeAndDecrypt
{
    using System;
    using System.Text;

    class DecodeAndDecrypt
    {
        public static int CypherLenght(string input)
        {
            int returnValue = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int tempNum = 0;
                bool res = int.TryParse(input[input.Length - i - 1].ToString(), out tempNum);
                if (res)
                {
                    returnValue += (int)Math.Pow(10, i) * tempNum;
                }
                else
                {
                    break;
                }
            }

            return returnValue;
        }

        public static string Encrypt(string input)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                bool res = false;
                int repeat = 0;
                do
                {
                    int tempNum = 0;
                    res = int.TryParse(input[i].ToString(), out tempNum);
                    if (res)
                    {
                        repeat = repeat * 10 + tempNum;
                        i++;
                    }
                } while (res);

                if (repeat > 0)
                {
                    result.Append(input[i], repeat);
                }
                else
                {
                    result.Append(input[i]);
                }
            }


            return result.ToString();
        }

        public static int ReturnLetterCode(char input)
        {
            int code = 0;
            switch (input)
            {
                case 'A': code = 0; break;
                case 'B': code = 1; break;
                case 'C': code = 2; break;
                case 'D': code = 3; break;
                case 'E': code = 4; break;
                case 'F': code = 5; break;
                case 'G': code = 6; break;
                case 'H': code = 7; break;
                case 'I': code = 8; break;
                case 'J': code = 9; break;
                case 'K': code = 10; break;
                case 'L': code = 11; break;
                case 'M': code = 12; break;
                case 'N': code = 13; break;
                case 'O': code = 14; break;
                case 'P': code = 15; break;
                case 'Q': code = 16; break;
                case 'R': code = 17; break;
                case 'S': code = 18; break;
                case 'T': code = 19; break;
                case 'U': code = 20; break;
                case 'V': code = 21; break;
                case 'W': code = 22; break;
                case 'X': code = 23; break;
                case 'Y': code = 24; break;
                case 'Z': code = 25; break;
            }

            return code;
        }

        public static char ReturnLetter(int code)
        {
            char original = ' ';
            switch (code)
            {
                case 0: original = 'A'; break;
                case 1: original = 'B'; break;
                case 2: original = 'C'; break;
                case 3: original = 'D'; break;
                case 4: original = 'E'; break;
                case 5: original = 'F'; break;
                case 6: original = 'G'; break;
                case 7: original = 'H'; break;
                case 8: original = 'I'; break;
                case 9: original = 'J'; break;
                case 10: original = 'K'; break;
                case 11: original = 'L'; break;
                case 12: original = 'M'; break;
                case 13: original = 'N'; break;
                case 14: original = 'O'; break;
                case 15: original = 'P'; break;
                case 16: original = 'Q'; break;
                case 17: original = 'R'; break;
                case 18: original = 'S'; break;
                case 19: original = 'T'; break;
                case 20: original = 'U'; break;
                case 21: original = 'V'; break;
                case 22: original = 'W'; break;
                case 23: original = 'X'; break;
                case 24: original = 'Y'; break;
                case 25: original = 'Z'; break;
            }

            return original;
        }

        public static string Decode(string input, string coder)
        {
            StringBuilder original = new StringBuilder();
            string result = string.Empty;
            char[] temp = input.ToCharArray();

            if (input.Length >= coder.Length)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < coder.Length; j++)
                    {
                        int pos = i * coder.Length + j;
                        if (pos >= input.Length)
                        {
                            break;
                        }

                        int tempMes = input[pos] - 'A';
                        int tempCoder = ReturnLetterCode(coder[j]);
                        original.Append(ReturnLetter(tempMes ^ tempCoder));
                    }
                }

                result = original.ToString();
            }
            else
            {
                for (int i = 0; i < coder.Length; i++)
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        int pos = i * input.Length + j;
                        if (pos >= coder.Length)
                        {
                            break;
                        }

                        int tempMes = temp[j] - 'A';
                        int tempCoder = ReturnLetterCode(coder[pos]);
                        temp[j] = (ReturnLetter(tempMes ^ tempCoder));
                    }
                }

                result = new string(temp);
            }

            return result;
        }

        static void Main()
        {
            string inputMes = Console.ReadLine();
            int lengthOfCypher = CypherLenght(inputMes);

            string encrypted = inputMes.Remove(inputMes.Length - lengthOfCypher.ToString().Length);
            string encodedWithCypher = Encrypt(encrypted);
            string cypher = encodedWithCypher.Substring(encodedWithCypher.Length - lengthOfCypher);
            string encoded = encodedWithCypher.Remove(encodedWithCypher.Length - lengthOfCypher);
            Console.WriteLine(Decode(encoded, cypher));


        }
    }
}
