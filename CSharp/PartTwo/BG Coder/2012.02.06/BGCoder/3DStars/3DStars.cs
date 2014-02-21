/*
 * start @23:30
 * end @00:20 80 pts.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DStars
{
    class Program
    {
        public static bool CheckStar(char[, ,] color, int i, int j, int k)
        {
            bool isStar = false;
            char match = color[i, j, k];

            if (match == color[i + 1, j, k] &&
                match == color[i - 1, j, k] &&
                match == color[i, j + 1, k] &&
                match == color[i, j - 1, k] &&
                match == color[i, j, k + 1] &&
                match == color[i, j, k - 1])
            {
                isStar = true;
            }

            return isStar;
        }
        static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            string[] dimension = dimensions.Split(' ');
            int W = int.Parse(dimension[0]);
            int H = int.Parse(dimension[1]);
            int D = int.Parse(dimension[2]);

            char[, ,] color = new char[H, D, W];

            for (int i = 0; i < H; i++)
            {
                string plate = Console.ReadLine();
                string[] row = plate.Split(' ');
                for (int j = 0; j < D; j++)
                {
                    char[] colors = row[j].ToCharArray();
                    for (int k = 0; k < W; k++)
                    {
                        color[i, j, k] = colors[k];
                    }
                }
            }

            SortedDictionary<char, int> found = new SortedDictionary<char, int>();

            for (int i = 1; i < H - 1; i++)
            {
                for (int j = 1; j < D - 1; j++)
                {
                    for (int k = 1; k < W - 1; k++)
                    {
                        bool isStar = CheckStar(color, i, j, k);
                        if (isStar)
                        {
                            if (found.ContainsKey(color[i, j, k]))
                            {
                                found[color[i, j, k]] = found[color[i, j, k]] + 1;
                            }
                            else
                            {
                                found.Add(color[i, j, k], 1);
                            }
                        }

                    }
                }
            }
            StringBuilder resultString = new StringBuilder();
            int result = 0;
            foreach (KeyValuePair<char,int> pair in found)
            {
                resultString.Append(pair.Key);
                resultString.Append(" ");
                resultString.Append(pair.Value);
                resultString.Append("\n");
                result += pair.Value;
            }

            Console.WriteLine(result);
            Console.WriteLine(resultString.ToString().Trim());
        }
    }
}
