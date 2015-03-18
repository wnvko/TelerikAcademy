namespace LongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LongestString
    {
        private static Random random = new Random();
        private static int strings = 10;
        public static void Main(string[] args)

        {
            List<string> inputData = new List<string>();

            Console.WriteLine("Input strings:\n");
            for (int imdex = 0; imdex < strings; imdex++)
            {
                inputData.Add(GenerateRandomString());
                Console.WriteLine("{0} string is: {1,-22} length: {2}", imdex, inputData[imdex], inputData[imdex].Length);
            }

            Console.WriteLine();

            var longestStringLenght = inputData.Max(w => w.Length);

            Console.WriteLine("Longest string length is {0}", longestStringLenght);
        }

        public static string GenerateRandomString()
        {
            int stringLenght = random.Next(1, 21);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < stringLenght; i++)
            {
                result.Append((char)random.Next(65, 91));
            }

            return result.ToString();
        }
    }
}
