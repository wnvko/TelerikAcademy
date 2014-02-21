/*
 * start @23:00
 * end @23:30 40pts
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes
{
    class Tubes
    {
        static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());
            long M = long.Parse(Console.ReadLine());
            long totalLenght = 0;
            long[] tubes = new long[N];
            for (int i = 0; i < N; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
                totalLenght += tubes[i];
            }

            long start = totalLenght / M;

            for (long i = start; i > 0; i--)
            {
                long totalTubes = 0;
                for (int j = 0; j < N; j++)
                {
                    totalTubes += tubes[j] / i;
                }

                if (totalTubes >= M)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
