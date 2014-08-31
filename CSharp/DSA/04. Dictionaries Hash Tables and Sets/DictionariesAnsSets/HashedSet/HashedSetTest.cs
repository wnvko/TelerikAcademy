using System;

public class HashedSetTest
{
    static void Main()
    {
        HashedSet<string> mySet = new HashedSet<string>();

        mySet.Add("Gogo");
        mySet.Add("Mimi");
        mySet.Add("Tosho");
        mySet.Add("Pesho");
        mySet.Add("Vankata");

        HashedSet<string> otherSet = new HashedSet<string>();
        otherSet.Add("Tosho");
        otherSet.Add("Pesho");
        otherSet.Add("Moni");

        Console.WriteLine(mySet.Find("Gogo"));
        Console.WriteLine(mySet.Find("Gogo2"));

        mySet.Remove("Gogo");

        var union = mySet.Union(otherSet);
        var intersect = mySet.Intersect(otherSet);

        Console.WriteLine(mySet.Count());


        Console.WriteLine("\nMySet");
        foreach (var item in mySet)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("\nUnion");
        foreach (var item in union)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("\nIntersect");
        foreach (var item in intersect)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
