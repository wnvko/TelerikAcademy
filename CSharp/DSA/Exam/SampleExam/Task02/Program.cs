using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int variety = int.Parse(Console.ReadLine());

            int maxPleasant = input[0];
            int minPleasent = input[0];
            int minMust = 0;
            int maxMust = 0;

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] > maxPleasant)
                {
                    maxPleasant = input[i];
                    maxMust = i;
                }
                else if (input[i] < minPleasent)
                {
                    minPleasent = input[i];
                    minMust = i;
                }

                if (maxPleasant - minPleasent >= variety)
                {
                    break;
                }
            }

            int min = Math.Min(maxMust, minMust);
            int max = Math.Max(maxMust, minMust);
            int result = (min + 1) / 2;
            result += (max - min + 1) / 2;
            result++;

            if (maxPleasant - minPleasent < variety)
            {
                result = input.Count;
            }

            Console.WriteLine(result);
        }
    }
}