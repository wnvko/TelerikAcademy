/*
 * start @21:10
 * end @22:53 60 pts
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace PHPVariables
{
    class PHPVariables
    {
        public static void ParsePHP(StringBuilder inputPHP)
        {
            List<string> variableName = new List<string>();
            StringBuilder variable = new StringBuilder();
            bool text = false;
            char textStarter = ' ';

            for (int i = 0; i < inputPHP.Length; i++)
            {
                // check comments like //
                if (inputPHP[i] == '/' && !text)
                {
                    if (i + 1 < inputPHP.Length && inputPHP[i + 1] == '/')
                    {
                        i++;
                        while (inputPHP[i] != '\n')
                        {
                            i++;
                            char temp = inputPHP[i];
                        }
                    }
                    // check comments like /*
                    else if (i + 1 < inputPHP.Length && inputPHP[i + 1] == '*')
                    {
                        i += 2;
                        while (i + 1 < inputPHP.Length && inputPHP[i] != '*' && inputPHP[i + 1] != '/')
                        {
                            i++;
                            char temp = inputPHP[i];
                        }
                    }
                }
                // check comments like #
                else if (inputPHP[i] == '#' && !text)
                {
                    while (inputPHP[i] != '\n')
                    {
                        i++;
                        char temp = inputPHP[i];
                    }
                }
                // check text starting with '
                else if (inputPHP[i] == '\'')
                {
                    if (text && textStarter == '\'')
                    {
                        textStarter = ' ';
                        text = false;
                    }
                    else if (!text)
                    {
                        text = true;
                        textStarter = '\'';
                    }
                }
                // check text starting with "
                else if (inputPHP[i] == '\"')
                {
                    if (text && textStarter == '\"')
                    {
                        textStarter = ' ';
                        text = false;
                    }
                    else if (!text)
                    {
                        text = true;
                        textStarter = '\"';
                    }
                }
                else if (inputPHP[i] == '$')
                {
                    if (text && i - 1 >= 0 && inputPHP[i - 1] == '\\')
                    {
                        continue;

                    }

                    i++;
                    while (char.IsLetterOrDigit(inputPHP[i]) || inputPHP[i] == '_')
                    {
                        variable.Append(inputPHP[i]);
                        i++;
                    }

                    if (!variableName.Contains(variable.ToString()))
                    {
                        variableName.Add(variable.ToString().Trim());
                    }
                    variable.Clear();
                    i--;
                }
            }

            Console.WriteLine(variableName.Count);
            variableName.Sort();
            foreach (var found in variableName)
            {
                Console.WriteLine(found);
            }
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            StringBuilder inputPHP = new StringBuilder();
            while (true)
            {
                string temp = Console.ReadLine();
                if (temp == "?>")
                {
                    break;
                }
                inputPHP.Append(temp);
                inputPHP.Append("\n");
            }

            ParsePHP(inputPHP);
        }
    }
}
