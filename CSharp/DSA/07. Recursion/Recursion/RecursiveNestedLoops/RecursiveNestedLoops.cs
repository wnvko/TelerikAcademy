using System;

class RecursiveNestedLoops
{
    private static int[] arr;
    private static int loops;

    static void Main()
    {
        loops = GetInput();
        arr = new int[loops];
        PrintLoops(0);
    }

    private static void PrintLoops(int n)
    {
        if (n >= loops)
        {
            PrintResult(arr);
        }
        else
        {
            for (int i = 0; i < loops; i++)
            {
                arr[n] = i + 1;
                PrintLoops(n + 1);
            }
        }

        return;
    }

    private static void PrintResult(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    private static int GetInput()
    {
        Console.Write("Please enter number of loops (>10 is not ok): ");
        int numberOfLoops = int.Parse(Console.ReadLine());
        return Math.Min(10, numberOfLoops);
    }
}
