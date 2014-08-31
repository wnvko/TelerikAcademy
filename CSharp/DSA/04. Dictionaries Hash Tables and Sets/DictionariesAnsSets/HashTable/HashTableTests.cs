using System;
using System.Collections.Generic;

public class HashTableTests
{
    static void Main(string[] args)
    {
        int initialCapacity = 2;
        int wrongLoadFactor = 75;

        var myHashTable = new HashTable<string, int>(initialCapacity, wrongLoadFactor);

        myHashTable.Add("Gosho", 5);
        myHashTable.Add("Tosho", 7);
        myHashTable.Add("Mimi", 100);
        myHashTable.Add("Moro", 12);

        Console.WriteLine(myHashTable["Gosho"]);
        Console.WriteLine(myHashTable.ContainsValue(100));
        Console.WriteLine(myHashTable.ContainsValue(50));

        myHashTable["Gosho"] = 3;
        myHashTable["Momo"] = 15;

        myHashTable.Remove("Mimi");

        foreach (var pair in myHashTable)
        {
            System.Console.WriteLine(pair.Key + " --> " + pair.Value);
        }
    }
}