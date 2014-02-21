namespace MaxLenghtString
{
    using System;
    using System.Linq;
    using System.Text;

    class MaxLenghtString
    {
        static Random rnd = new Random();
        public static string GenerateRandomString()
        {
            int stringLenght = rnd.Next(1, 21);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < stringLenght; i++)
            {
                result.Append((char)rnd.Next(65, 91));
            }

            return result.ToString();
        }
        static void Main()
        {
            string[] inputData = new string[10];
            Console.WriteLine("Input strings:\n");
            for (int i = 0; i < inputData.Length; i++)
            {
                inputData[i] = GenerateRandomString();
                Console.WriteLine("{0} string is: {1,-22} lenght: {2}", i, inputData[i], inputData[i].Length);
            }

            Console.WriteLine();

            var longestStringLenght = inputData.Max(w => w.Length);

            Console.WriteLine("Longets string lenght is {0}", longestStringLenght);
        }
    }
}
