using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace ProblemFour
{
    class Program
    {
        public static int[] CompareParagrafs(StringBuilder[] inputText, string toFind)
        {
            int[] order = new int[inputText.Length];
            toFind = toFind.ToUpper();
            char[] splitChar = new char[] { ' ' };

            for (int i = 0; i < inputText.Length; i++)
            {
                StringBuilder currentLine = new StringBuilder();
                for (int j = 0; j < inputText[i].Length; j++)
                {
                    if (inputText[i][j] != ',' &&
                        inputText[i][j] != '.' &&
                        inputText[i][j] != '(' &&
                        inputText[i][j] != ')' &&
                        inputText[i][j] != ';' &&
                        inputText[i][j] != '-' &&
                        inputText[i][j] != '!' &&
                        inputText[i][j] != '?')
                    {
                        currentLine.Append((inputText[i][j]));
                    }
                    else
                    {
                        currentLine.Append(" ");
                    }
                }

                string[] currentWords = currentLine.ToString().Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
                currentLine.Clear();

                for (int j = 0; j < currentWords.Length; j++)
                {
                    if (string.Compare(currentWords[j].ToUpper(), toFind) == 0)
                    {
                        currentWords[j] = toFind.ToUpper();
                        order[i]++;
                    }
                    currentLine.Append(currentWords[j]);
                    if (j < currentWords.Length - 1)
                    {
                        currentLine.Append(" ");
                    }
                }

                inputText[i] = currentLine;
            }

            return order;
        }
        static void Main(string[] args)
        {

            string textToFind = string.Empty;
            int lines = 0;
            List<StringBuilder> text = new List<StringBuilder>();

            textToFind = Console.ReadLine();
            lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                text.Add(new StringBuilder(Console.ReadLine()));
            }

            StringBuilder[] textLines = text.ToArray();

            //string textToFind = Console.ReadLine();
            //int lines = int.Parse(Console.ReadLine());
            //StringBuilder[] textLines = new StringBuilder[lines];


            //for (int i = 0; i < lines; i++)
            //{
            //    textLines[i] = new StringBuilder(Console.ReadLine());
            //}

            int[] order = CompareParagrafs(textLines, textToFind);

            for (int i = 0; i < order.Length; i++)
            {
                for (int j = i + 1; j < order.Length; j++)
                {
                    if (order[i] <= order[j])
                    {
                        int buffer = order[i];
                        order[i] = order[j];
                        order[j] = buffer;

                        StringBuilder stringBuffer = textLines[i];
                        textLines[i] = textLines[j];
                        textLines[j] = stringBuffer;
                    }
                }
            }

            for (int i = 0; i < textLines.Length; i++)
            {
                Console.WriteLine(textLines[i]);
            }
        }
    }
}