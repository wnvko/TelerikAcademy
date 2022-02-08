using System;
using System.Collections.Generic;

public class PriorityQueueTest
{
    public const int ElementsCount = 1000000;
    public static Random rnd = new Random();

    public static void Main(string[] args)
    {
        PriorityQueue<int, string> myPriorityQueue = new PriorityQueue<int, string>();
        PriorityQueue<int, string> otherPriorityQueue = new PriorityQueue<int, string>();

        FillQueue(myPriorityQueue);
        FillQueue(otherPriorityQueue);

        var merged = PriorityQueue<int, string>.MergeQueues(myPriorityQueue, otherPriorityQueue);
        PrintQueue(merged);

        PrintQueue(myPriorityQueue);

        PrintQueue(otherPriorityQueue);

    }

    private static void PrintQueue(PriorityQueue<int, string> myPriorityQueue)
    {
        Console.WriteLine();
        for (int pair = 0; pair < 20; pair++)
        {
            var currentPair = myPriorityQueue.Dequeue();
            Console.WriteLine("{0} --> {1}", currentPair.Key, currentPair.Value);
        }
    }

    private static void FillQueue(PriorityQueue<int, string> myPriorityQueue)
    {
        KeyValuePair<int, string> randomPair;

        for (int element = 0; element < ElementsCount; element++)
        {
            int randomInt = rnd.Next(0, ElementsCount);
            string randomString = GetRandomString();
            randomPair = new KeyValuePair<int, string>(randomInt, randomString);

            myPriorityQueue.Add(randomPair);
        }
    }

    private static string GetRandomString()
    {
        int stringLenght = rnd.Next(10, 15);
        char[] stringAsCharArray = new char[stringLenght];

        for (int letter = 0; letter < stringLenght; letter++)
        {
            stringAsCharArray[letter] = (char)(rnd.Next(25) + 'a');
        }

        string randomString = new string(stringAsCharArray);
        return randomString;
    }
}
