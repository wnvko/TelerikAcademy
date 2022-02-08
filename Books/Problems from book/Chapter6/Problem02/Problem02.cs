namespace Problem02
{
    using System;

    class Problem02
    {
        static void Main()
        {
            Console.Write("Enter the numbers of elements in first array: ");
            int firstArrayLenght = int.Parse(Console.ReadLine());
            Console.Write("Enter the numbers of elements in second array: ");
            int secondArrayLenght = int.Parse(Console.ReadLine());

            if (firstArrayLenght != secondArrayLenght)
            {
                Console.WriteLine("The two arrays are diferent");
                return;
            }

            int[] firstArray = new int[firstArrayLenght];
            int[] secondArray = new int[secondArrayLenght];

            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write("First array {0}: ", (i + 1));
                firstArray[i] = int.Parse(Console.ReadLine());
                Console.Write("Second array {0}: ", (i + 1));
                secondArray[i] = int.Parse(Console.ReadLine());
                if (firstArray[i] != secondArray[i])
                {
                    Console.WriteLine("The two arrays are diferent");
                    return;
                }
            }
            Console.WriteLine("Two arrays are equal!");
        }
    }
}
