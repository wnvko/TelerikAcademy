using System;
using System.Collections.Generic;

public class StrangeSequence
{
    public static void Main()
    {
        Console.Write("Please enter N: ");
        int startNumber = int.Parse(Console.ReadLine());
        Queue<int> theSequrnce = new Queue<int>();
        theSequrnce.Enqueue(startNumber);

        for (int i = 0; i < 50; i++)
        {
            int currentValue = theSequrnce.Dequeue();
            Console.WriteLine("Value on possition {0} -> {1}", i + 1, currentValue);
            theSequrnce.Enqueue(currentValue + 1);
            theSequrnce.Enqueue(2 * currentValue + 1);
            theSequrnce.Enqueue(currentValue + 2);
        }
    }
}