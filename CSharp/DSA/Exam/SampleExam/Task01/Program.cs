using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    class Program
    {
        static SortedDictionary<char, string> letters = new SortedDictionary<char, string>();
        static SortedSet<string> result = new SortedSet<string>();
        static String message;

        public static void TakeInput()
        {
            message = Console.ReadLine();
            string cipher = Console.ReadLine();
            char currentLetter = cipher[0];
            StringBuilder code = new StringBuilder();

            for (int i = 1; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    letters.Add(currentLetter, code.ToString());
                    code.Clear();
                    currentLetter = cipher[i];
                }
                else
                {
                    code.Append(cipher[i]);
                }
            }

            letters.Add(currentLetter, code.ToString());
        }

        public static string Decoder(string word)
        {
            foreach (var pair in letters)
            {
                //currentWord.Append(pair.Key);
                //foreach (var letter in currentWord)
                //{

                //}
            }

            return string.Empty;
        }
        static void Main()
        {
            TakeInput();
            Decoder(string.Empty);
        }
    }
}
