/*
 * Write a method that checks if the element at given position in given array of integers is larger
 * than its two neighbors (when such exist).
 */

using System;

public class LargerThanNeighbours
{
    public enum Neighbor
    {
        None = 0,
        One = 1,
        Two = 2,
    }

    public static void Main(string[] args)
    {
        var myClass = new LargerThanNeighbours();
        var myClassHelper = new HelperClass();

        Console.Write("Enter the number of elements in the array: ");
        int elementsCount = int.Parse(Console.ReadLine());
        int[] array = myClassHelper.GenerateRandomArray<int>(elementsCount);

        Console.WriteLine("Random array: ");
        myClassHelper.PrintArray(array);
        Console.WriteLine();

        Console.Write("Enter lookup position: ");
        int lookupPosition = int.Parse(Console.ReadLine());

        bool bigger = myClass.CheckNeighbors(lookupPosition, array);
        if (bigger)
        {
            Console.WriteLine("Element at position {0} ({1}) is bigger than it's neighbors ({2} and {3})", lookupPosition, array[lookupPosition], array[lookupPosition - 1], array[lookupPosition + 1]);
        }
        else
        {
            switch (myClass.NeighborsCount(lookupPosition, array))
            {
                case Neighbor.None:
                    Console.WriteLine("This position is outside array!");
                    break;
                case Neighbor.One:
                    Console.WriteLine("This element has only one neighbor!");
                    break;
                case Neighbor.Two:
                    Console.WriteLine("Element at position {0} ({1}) is not bigger than it's neighbors ({2} and {3})", lookupPosition, array[lookupPosition], array[lookupPosition - 1], array[lookupPosition + 1]);
                    break;
                default:
                    break;
            }
        }
    }

    public bool CheckNeighbors(int position, int[] inputArray)
    {
        Neighbor neighbors = this.NeighborsCount(position, inputArray);

        if (neighbors == Neighbor.None || neighbors == Neighbor.One)
        {
            return false;
        }
        else
        {
            if (inputArray[position-1] < inputArray[position] && inputArray[position] > inputArray[position+1])
            {
                return true;
            }

            return false;
        }
    }

    private Neighbor NeighborsCount(int position, int[] inputArray)
    {
        if (position < 0 || position >= inputArray.Length)
        {
            return Neighbor.None;
        }

        if (position == 0 || position == inputArray.Length - 1)
        {
            return Neighbor.One;
        }

        return Neighbor.Two;
    }

    public int position { get; set; }
}
