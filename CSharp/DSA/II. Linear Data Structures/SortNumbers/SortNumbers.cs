namespace SortNumbers
{
    using System;
    using System.Collections.Generic;

    public class SortNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Please enter some numbers");
            Console.WriteLine("Enter empty line to finish");

            List<int> inputData = new List<int>();

            while (true)
            {
                string currentInput = Console.ReadLine();
                if (currentInput == string.Empty)
                {
                    break;
                }

                inputData.Add(int.Parse(currentInput));
            }

            inputData.Sort();

            for (int i = 0; i < inputData.Count; i++)
            {
                Console.WriteLine(inputData[i]);
            }
        }
    }
}
