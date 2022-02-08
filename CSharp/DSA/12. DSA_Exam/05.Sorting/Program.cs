using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] numbers = new int[N];
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            int K = int.Parse(Console.ReadLine());
            int tried = 0;

            while (!Check(numbers))
            {
                List<int> possToChange = new List<int>();

                for (int i = 0; i <= numbers.Length - K; i++)
                {
                    possToChange.Add(i);
                    for (int j = i + 1; j < i + K; j++)
                    {
                        if (numbers[i] > numbers[j])
                        {
                            possToChange.Add(j);
                        }

                        if (possToChange.Count == K)
                        {
                            break;
                        }
                    }

                    if (possToChange.Count == K)
                    {
                        break;
                    }

                    possToChange.Clear();
                }

                if (possToChange.Count == 0)
                {
                    possToChange.Clear();

                    for (int i = 0; i <= numbers.Length - K; i++)
                    {
                        possToChange.Add(i);
                        for (int j = i + 1; j < i + K; j++)
                        {
                            if (numbers[i] < numbers[j])
                            {
                                possToChange.Add(j);
                            }

                            if (possToChange.Count == K)
                            {
                                break;
                            }
                        }

                        if (possToChange.Count == K)
                        {
                            break;
                        }

                        possToChange.Clear();
                    }

                    possToChange.Clear();

                    if (possToChange.Count == 0)
                    {
                        tried = -1;
                        break;

                    }

                }

                int[] toSort = new int[possToChange.Count];
                int index = 0;
                foreach (var item in possToChange)
                {
                    toSort[index] = numbers[item];
                    index++;
                }

                Array.Reverse(toSort);

                index = 0;
                foreach (var item in possToChange)
                {
                    numbers[item] = toSort[index];
                    index++;
                }

                tried++;
            }

            Console.WriteLine(tried);

        }

        private static bool Check(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
