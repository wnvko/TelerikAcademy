using System;
using System.Collections.Generic;
public class KnapsackProblem
{
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        // represents items in weight/price manner
        int itemsCount = 8;
        Item[] items = new Item[itemsCount];
        GetRandomItems(items);
        Array.Sort(items);

        // rucksack parameters
        int maxVolume = 20;
        int maxItems = (int)(itemsCount / 1.2);
        int[,] rucksackArray = new int[maxItems, maxVolume];
        
        // Dynamic programming
        CalculateMaxweightAndPrice(items, maxVolume, maxItems, rucksackArray);
        
        // Print the result
        PrintItems(items);
        PrintRuckSack(maxVolume, maxItems, rucksackArray);
        Console.WriteLine("\nMax price {0} ", rucksackArray[maxItems - 1, maxVolume - 1]);
    }

    private static void GetRandomItems(Item[] items)
    {
        for (int i = 1; i < 8; i++)
        {
            items[i] = new Item(random.Next(1, 15), random.Next(1, 20));
        }

        items[0] = new Item(0, 0);
    }

    private static void CalculateMaxweightAndPrice(Item[] items, int maxVolume, int maxItems, int[,] rucksackArray)
    {
        for (int i = 1; i < maxItems; i++)
        {
            for (int j = 0; j < maxVolume; j++)
            {
                if (j >= items[i].Weight && rucksackArray[i - 1, j] < rucksackArray[i - 1, j - items[i].Weight] + items[i].Price)
                {
                    rucksackArray[i, j] = rucksackArray[i - 1, j - items[i].Weight] + items[i].Price;
                }
                else
                {
                    rucksackArray[i, j] = rucksackArray[i - 1, j];
                }
            }
        }
    }

    private static void PrintItems(Item[] items)
    {
        int index = 0;
        foreach (var item in items)
        {
            index++;
            Console.WriteLine("Item {0} Weight: {1}, Price: {2}", index, item.Weight, item.Price);
        }

        Console.WriteLine();
    }

    private static void PrintRuckSack(int maxVolume, int maxItems, int[,] rucksackArray)
    {
        for (int i = 0; i < maxItems; i++)
        {
            for (int j = 0; j < maxVolume; j++)
            {
                Console.Write("{0,2}, ", rucksackArray[i, j]);
            }

            Console.WriteLine();
        }
    }

}
