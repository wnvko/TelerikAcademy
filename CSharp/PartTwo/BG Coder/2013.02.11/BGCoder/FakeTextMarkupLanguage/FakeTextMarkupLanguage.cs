/*
 * start @ 21:10
 * end @ 22:24 70 pts
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTextMarkupLanguage
{
    class FakeTextMarkupLanguage
    {
        public static string ParseFTMLLine(string input)
        {
            List<StringBuilder> temp = new List<StringBuilder>();
            StringBuilder output = new StringBuilder();
            Stack<string> tag = new Stack<string>();
            int depth = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '<')
                {
                    if (depth >= 0)
                    {
                        temp[depth].Append(input[i]);
                    }
                    else
                    {
                        output.Append(input[i]);
                    }
                }
                else
                {
                    switch (input[i + 1])
                    {
                        case 'u':
                            {
                                tag.Push("u");
                                i += 6;
                                depth++;
                                temp.Add(new StringBuilder());
                                break;
                            }
                        case 'l':
                            {
                                tag.Push("l");
                                i += 6;
                                depth++;
                                temp.Add(new StringBuilder());
                                break;
                            }
                        case 't':
                            {
                                tag.Push("t");
                                i += 7;
                                depth++;
                                temp.Add(new StringBuilder());
                                break;
                            }
                        case 'd':
                            {
                                tag.Push("d");
                                i += 4;
                                depth++;
                                temp.Add(new StringBuilder());
                                break;
                            }
                        case 'r':
                            {
                                tag.Push("r");
                                i += 4;
                                depth++;
                                temp.Add(new StringBuilder());
                                break;
                            }
                        case '/':
                            {
                                string tagToProceed = tag.Pop();
                                if (tagToProceed == "u")
                                {
                                    i += 7;
                                    string converted = temp[depth].ToString().ToUpper();
                                    temp.RemoveAt(depth);
                                    depth--;
                                    if (depth >= 0)
                                    {
                                        temp[depth].Append(converted);
                                    }
                                    else
                                    {
                                        output.Append(converted);
                                    }
                                }
                                else if (tagToProceed == "l")
                                {
                                    i += 7;
                                    string converted = temp[depth].ToString().ToLower();
                                    temp.RemoveAt(depth);
                                    depth--;
                                    if (depth >= 0)
                                    {
                                        temp[depth].Append(converted);
                                    }
                                    else
                                    {
                                        output.Append(converted);
                                    }
                                }
                                else if (tagToProceed == "t")
                                {
                                    i += 8;
                                    string converted = temp[depth].ToString();
                                    string toggled = string.Empty;
                                    char[] inputArray = converted.ToCharArray();

                                    foreach (char c in inputArray)
                                    {
                                        if (char.IsLower(c))
                                        {
                                            toggled += c.ToString().ToUpper();
                                        }
                                        else if (char.IsUpper(c))
                                        {
                                            toggled += c.ToString().ToLower();
                                        }
                                        else
                                        {
                                            toggled += c.ToString();
                                        }
                                    }

                                    temp.RemoveAt(depth);
                                    depth--;
                                    if (depth >= 0)
                                    {
                                        temp[depth].Append(toggled);
                                    }
                                    else
                                    {
                                        output.Append(toggled);
                                    }
                                }
                                else if (tagToProceed == "d")
                                {
                                    i += 5;
                                    temp.RemoveAt(depth);
                                    depth--;
                                }
                                else if (tagToProceed == "r")
                                {
                                    i += 5;
                                    string converted = temp[depth].ToString();
                                    char[] reversed = converted.ToCharArray();
                                    Array.Reverse(reversed);
                                    temp.RemoveAt(depth);
                                    depth--;
                                    if (depth >= 0)
                                    {
                                        temp[depth].Append(reversed);
                                    }
                                    else
                                    {
                                        output.Append(reversed);
                                    }
                                }
                                break;
                            }
                    }
                }
            }

            return output.ToString();
        }
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            string[] input = new string[linesCount];

            for (int i = 0; i < linesCount; i++)
            {
                input[i] = Console.ReadLine();
            }

            for (int i = 0; i < linesCount; i++)
            {
                Console.WriteLine(ParseFTMLLine(input[i]));
            }
        }
    }
}