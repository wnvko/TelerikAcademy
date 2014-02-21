/*
 * start @20:30
 * 100 pts @23:18 - 30 min dinner :)
 */

namespace ConsoleJustification
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleJustification
    {
        public static int WriteFitedLine(List<string> words, int start, int width)
        {
            int lettersCount = 0;
            int count = start;
            int finish = 0;

            while (lettersCount <= width + 1)
            {
                if (count == words.Count)
                {
                    count++;
                    finish = int.MaxValue;
                    break;
                }
                lettersCount += words[count].Length;
                lettersCount++;
                count++;
                finish = count - 1;
            }

            count--;
            lettersCount = 0;
            for (int i = start; i < count; i++)
            {
                lettersCount += words[i].Length;
            }

            int allSpaces = width - lettersCount;
            int spacesCount = count - start - 1;
            int[] spaces = new int[0];
            if (spacesCount > 0)
            {
                spaces = new int[spacesCount];
                for (int i = spacesCount - 1; i >= 0; i--)
                {
                    spaces[i] = allSpaces / spacesCount;
                    allSpaces -= spaces[i];
                    spacesCount--;
                }
            }

            for (int i = start, j = 0; i < count - 1; i++, j++)
            {
                Console.Write(words[i]);
                Console.Write(new string(' ', spaces[j]));
            }
            Console.Write(words[count - 1]);
            Console.WriteLine();

            return finish;
        }
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            string[] lines = new string[linesCount];
            StringBuilder words = new StringBuilder();
            char[] separators = new char[] { ' ' };

            for (int i = 0; i < linesCount; i++)
            {
                lines[i] = Console.ReadLine();
                string[] temp = lines[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                words.Append(string.Join(" ", temp));
                words.Append(" ");
            }

            List<string> wordList = new List<string>();
            wordList.AddRange(words.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries));

            int start = 0;
            while (start <= wordList.Count)
            {
                start = WriteFitedLine(wordList, start, width);
            }

        }
    }
}
