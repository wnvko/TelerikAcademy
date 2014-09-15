using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Girls
{
    class Program
    {
        private static SortedSet<string> combinationsK = new SortedSet<string>();
        private static SortedSet<string> combinationsL = new SortedSet<string>();

        private static int shirts_K;
        private static char[] skirts_L_chars;
        private static int skirts_L;
        private static int girls_N;
        private static string[] currentComb;

        private static bool[] used;

        static void Main(string[] args)
        {
            shirts_K = int.Parse(Console.ReadLine());
            skirts_L_chars = Console.ReadLine().ToCharArray();
            Array.Sort(skirts_L_chars);
            skirts_L = skirts_L_chars.Length;
            girls_N = int.Parse(Console.ReadLine());
            currentComb = new string[girls_N];
            CombineK(0, 0);

            currentComb = new string[girls_N];
            used = new bool[skirts_L];
            CombineL(0);

            SortedSet<string> result = new SortedSet<string>();

            foreach (var combK in combinationsK)
            {
                foreach (var combL in combinationsL)
                {
                    string current = string.Empty;

                    for (int n = 0; n < girls_N; n++)
                    {
                        current =current+ combK[n].ToString() + skirts_L_chars[int.Parse(combL[n].ToString())];
                        if (n < girls_N - 1)
                        {
                            current = current + '-';
                        }
                    }

                    result.Add(current);
                }
            }

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void CombineL(int index)
        {
            if (index >= girls_N)
            {
                string cur = GetString(currentComb);
                combinationsL.Add(cur);
            }
            else
            {
                for (int i = 0; i < skirts_L; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentComb[index] = i.ToString();
                        CombineL(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void CombineK(int index, int start)
        {
            if (index >= girls_N)
            {
                string cur = GetString(currentComb);
                combinationsK.Add(cur);
            }
            else
            {
                for (int i = start; i < shirts_K; i++)
                {
                    currentComb[index] = i.ToString();
                    CombineK(index + 1, i + 1);
                }
            }
        }

        private static string GetString(string[] currentComb)
        {
            string result = string.Empty;
            for (int i = 0; i < currentComb.Length; i++)
            {
                result = result + currentComb[i];
            }

            return result;
        }
    }
}
