namespace Problem02
{
    using System;
    
    class Problem02
    {
        static void Main()
        {
            //enter first array
            Console.WriteLine("Please enter the first array:");
            string firstAsString = Console.ReadLine();
            char[] firstArray = firstAsString.ToCharArray();

            Console.WriteLine("Please enter the second array:");
            string secondAsString = Console.ReadLine();
            char[] secondArray = secondAsString.ToCharArray();
            
            //calculations
            int stringsToCheck = firstArray.Length;
            if (firstArray.Length > secondArray.Length)
            {
                stringsToCheck = secondArray.Length;
            }

            int smallerArray = 0;
            for (int i = 0; i < stringsToCheck; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    if (firstArray[i] > secondArray[i])
                    {
                        smallerArray = 2;
                        break;
                    }
                    else
                    {
                        smallerArray = 1;
                        break;
                    }
                }
                else
                {
                    if (firstAsString.Length - 1 == i && firstAsString.Length < secondAsString.Length)
                    {
                        smallerArray = 1;
                    }
                    if (secondAsString.Length -1 == i && secondAsString.Length < firstAsString.Length)
                    {
                        smallerArray = 2;
                    }
                }
            }

            //output
            switch (smallerArray)
            {
                case 0:
                    {
                        Console.WriteLine("These are same arrays!");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("The array:\n{0}\nis before:\n{1}", firstAsString, secondAsString);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("The array:\n{0}\nis before:\n{1}", secondAsString, firstAsString);
                        break;
                    }
            }
        }
    }
}