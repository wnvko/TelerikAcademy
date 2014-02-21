/*
 * start: 20:30
 * 33 points@21:30
 * stil 33 points@22:10 :(
 */

namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MagicWords
    {
        public static void Reorder(List<string> inputList)
        {
            int len = 0;
            int n = inputList.Count;
            int pos = 0;
            string temp = string.Empty;

            for (int i = 0; i < n; i++)
            {
                len = inputList[i].Length;
                pos = len % (n + 1);
                temp = inputList[i];
                if (pos == n)
                {
                    for (int j = i; j < pos - 1; j++)
                    {
                        inputList[j] = inputList[j + 1];
                    }

                    inputList[pos - 1] = temp;
                    continue;
                }
                else if (pos > i)
                {
                    for (int j = i; j < pos; j++)
                    {
                        inputList[j] = inputList[j + 1];
                    }
                }
                else if (pos < i)
                {
                    for (int j = i; j > pos; j--)
                    {
                        inputList[j] = inputList[j - 1];
                    }
                }

                inputList[pos] = temp;
            }
        }

        public static void Print(List<string> inputList)
        {
            int maxLenght = int.MinValue;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i].Length > maxLenght)
                {
                    maxLenght = inputList[i].Length;
                }
            }

            for (int i = 0; i < maxLenght; i++)
            {
                for (int j = 0; j < inputList.Count; j++)
                {
                    if (i < inputList[j].Length && inputList[j] != null)
                    {
                        result.Append(inputList[j][i]);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }

        public static void Main()
        {
            int wordsCount = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();
            for (int i = 0; i < wordsCount; i++)
            {
                words.Add(Console.ReadLine());
            }

            //words.Clear();
            //Random rnd = new Random();
            //for (int i = 0; i < 1000; i++)
            //{
            //    string tempString = string.Empty;
            //    for (int j = 0; j < 1000; j++)
            //    {
            //        char temp = (char)rnd.Next(255);
            //         tempString += temp.ToString();
            //    }
            //    words.Add(tempString);
            //}

            try
            {
                Reorder(words);
                Print(words);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}