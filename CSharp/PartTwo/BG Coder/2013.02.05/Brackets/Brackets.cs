/*
 * Start 13:15
 * 0 pts @15:39
 * End
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{

    class Brackets
    {
        static string tab = string.Empty;
        static int tabsCount = 0;
        static StringBuilder result = new StringBuilder();
            
        public static string RemoveAdjacentSpaces(string input)
        {
            StringBuilder spaceless = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int spaceCounter = 1;
                if (input[i] == ' ')
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == ' ')
                        {
                            spaceCounter++;
                        }
                        else
                        {
                            i = j-1;
                            spaceless.Append(" ");
                            break;
                        }
                    }
                }
                else
                {
                    spaceless.Append(input[i]);
                }
            }
            return spaceless.ToString();
        }
        public static void ConvertOneLine(string input)
        {
            input = input.Trim();
            for (int letterCounter = 0; letterCounter < input.Length; letterCounter++ )
            {
                if (input[letterCounter] == '{')
                {
                    result.Append("\n");
                    for (int j = 0; j < tabsCount; j++)
                    {
                        result.Append(tab);
                    }

                    result.Append("{\n");
                    tabsCount++;
                    for (int j = 0; j < tabsCount; j++)
                    {
                        result.Append(tab);
                    }
                }
                else if (input[letterCounter] == '}')
                {
                    result.Append("\n");
                    tabsCount--;
                    for (int j = 0; j < tabsCount; j++)
                    {
                        result.Append(tab);
                    }

                    result.Append("}\n");
                    for (int j = 0; j < tabsCount; j++)
                    {
                        result.Append(tab);
                    }
                }
                else
                {
                    result.Append(input[letterCounter]);
                }
            }

            if (result.Length > 0 && !(result[result.Length-1] == '\n' || result[result.Length-1] == '.'))
            {
                result.Append("\n");
                for (int j = 0; j < tabsCount; j++)
                {
                    result.Append(tab);
                }
            }
        }

        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            tab = Console.ReadLine();
            string[] line = new string[numberOfLines];
            for (int i = 0; i < numberOfLines; i++)
            {
                line[i] = RemoveAdjacentSpaces(Console.ReadLine());
                if (line[i].CompareTo("\n") == 0)
                {
                    continue;
                }

                ConvertOneLine(line[i]);
            }
            string replace = string.Empty;
            replace = tab + " ";
            result.Replace(replace, tab);

            replace = tab + "\n";
            result.Replace(replace, string.Empty );

            Console.WriteLine(result);
        }
    }
}
