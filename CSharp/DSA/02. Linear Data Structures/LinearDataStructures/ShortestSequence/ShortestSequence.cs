using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Struct containing value of current item, unique ID of it's parent and it's unique ID
/// </summary>
struct VPU
{
    public int value;
    public int parent;
    public int uniqueID;

    public VPU(int value, int parent, int uniqueID)
    {
        this.value = value;
        this.parent = parent;
        this.uniqueID = uniqueID;
    }
}

public class ShortestSequence
{
    public static void Main()
    {
        Console.Write("Please enter N: ");
        int startNumber = int.Parse(Console.ReadLine());
        Console.Write("Please enter M: ");
        int targetNumber = int.Parse(Console.ReadLine());

        List<VPU> allSteps = new List<VPU>();
        Queue<VPU> allValues = new Queue<VPU>();
        int counterID = 0;
        allValues.Enqueue(new VPU(startNumber, 0, counterID));

        while (true)
        {
            VPU currentValue = allValues.Dequeue();
            allSteps.Add(currentValue);

            if (currentValue.value + 1 == targetNumber)
            {
                allSteps.Add(new VPU(currentValue.value + 1, currentValue.uniqueID, ++counterID));
                break;
            }
            else
            {
                allValues.Enqueue(new VPU(currentValue.value + 1, currentValue.uniqueID, ++counterID));
            }

            if (currentValue.value + 2 == targetNumber)
            {
                allSteps.Add(new VPU(currentValue.value + 2, currentValue.uniqueID, ++counterID));
                break;
            }
            else
            {
                allValues.Enqueue(new VPU(currentValue.value + 2, currentValue.uniqueID, ++counterID));
            }

            if (currentValue.value * 2 == targetNumber)
            {
                allSteps.Add(new VPU(currentValue.value * 2, currentValue.uniqueID, ++counterID));
                break;
            }
            else
            {
                allValues.Enqueue(new VPU(currentValue.value * 2, currentValue.uniqueID, ++counterID));
            }
        }

        Stack<VPU> showTheWay = new Stack<VPU>();
        showTheWay.Push(allSteps[allSteps.Count - 1]);

        for (int i = allSteps.Count; i >= 0; i--)
        {
            if (showTheWay.Peek().parent == i)
            {
                showTheWay.Push(allSteps[i]);
            }
        }

        foreach (var item in showTheWay)
        {
            Console.Write(item.value);
            if (item.value != targetNumber)
            {
                Console.Write(" -> ");
            }
        }

        Console.WriteLine();
    }
}