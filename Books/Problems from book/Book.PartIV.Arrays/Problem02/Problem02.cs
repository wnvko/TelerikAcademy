namespace Problem02
{
    using System;
    using System.Linq;

    class Problem02
    {
        static void Main()
        {
            //enter first array
            Console.WriteLine("Please enter the first array (enter end for finish):");
            int firstArrayCount = 0;
            int[] firstArray = new int[0];
            string input = "";
            bool endOfInput = false;
            while (input != "end")
            {
                int[] bufferArray = new int[1];
                input = Console.ReadLine();
                endOfInput = int.TryParse(input, out bufferArray[0]);
                if (endOfInput)
                {
                    firstArray = firstArray.Concat(bufferArray).ToArray();
                }
                firstArrayCount++;
            }

            //enter second array
            Console.WriteLine("Please enter the second array (enter end for finish):");
            int secondArrayCount = 0;
            int[] secondArray = new int[0];
            input = "";
            endOfInput = false;
            while (input != "end")
            {
                int[] bufferArray = new int[1];
                input = Console.ReadLine();
                endOfInput = int.TryParse(input, out bufferArray[0]);
                if (endOfInput)
                {
                    secondArray = secondArray.Concat(bufferArray).ToArray();
                }
                secondArrayCount++;
            }

            //check arrays
            bool equalArrays = false;
            if (firstArray.Length == secondArray.Length)
            {
                equalArrays = true;
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        equalArrays = false;
                        break;
                    }
                }
            }

            //output
            Console.WriteLine("These are two equal arrays: {0}", equalArrays);
        }
    }
}