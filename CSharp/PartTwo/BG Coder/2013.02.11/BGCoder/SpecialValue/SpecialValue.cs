/*
 * start @ 23:05
 * end @23:14 0 pts
 * start @ 18:00 next day
 * end @19:20 70pts. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialValue
{
    class SpecialValue
    {
        public static void FindSpecialValue(List<int>[] input, List<bool>[] isVisited)
        {
            int maxSpecialValue = 0;
            int currentValue = 0;

            for (int col = 0; col < input[0].Count; col++)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Count; j++)
                    {
                        isVisited[i][j] = false;
                    }
                }

                int row = 0;
                int colNow = col;
                int specialValue = 0;
                while (true)
                {
                    currentValue = input[row][colNow];
                    if (isVisited[row][colNow])
                    {
                        specialValue = int.MinValue;
                        break;
                    }
                    specialValue++;
                    if (currentValue < 0)
                    {
                        specialValue += Math.Abs(currentValue);
                        break;
                    }
                    else
                    {
                        isVisited[row][colNow] = true;
                        row++;
                        if (row >= input.Length)
                        {
                            row = 0;
                        }

                        colNow = currentValue;
                    }
                }

                if (specialValue > maxSpecialValue)
                {
                    maxSpecialValue = specialValue;
                }
            }

            Console.WriteLine(maxSpecialValue);
        }
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[] inputStrings = new string[rows];
            List<int>[] numbers = new List<int>[rows];
            List<bool>[] isVisited = new List<bool>[rows];

            for (int i = 0; i < rows; i++)
            {
                inputStrings[i] = Console.ReadLine();
                string[] temp = inputStrings[i].Split((new char[2] { ',', ' ' }), StringSplitOptions.RemoveEmptyEntries);
                numbers[i] = new List<int>();
                isVisited[i] = new List<bool>();
                foreach (var number in temp)
                {
                    numbers[i].Add(int.Parse(number));
                    isVisited[i].Add(false);
                }
            }

            FindSpecialValue(numbers, isVisited);
        }
    }
}
