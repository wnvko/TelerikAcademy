using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivisibleBysevenAndThree
{
    public class Test
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            AddRandomNumbers(numbers, 15);

            Console.WriteLine("Initial numbers:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Special numbers:");
            var specialNumbers = numbers.Where(number => (number % 7 == 0 || number % 3 == 0));
            foreach (var number in specialNumbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        public static void AddRandomNumbers(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(1, 101));
            }
        }
    }
}
