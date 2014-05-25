namespace Loop
{
    using System;

    public class LoopStatement
    {
        public const int MAX_LENGTH = 100;
        public static int lookupValue = 10;

        public bool IsArrayContainValue(int lookupValue, int[] lookupArray)
        {
            bool isArrayContainValue = false;

            for (int i = 0; i < MAX_LENGTH; i++)
            {
                Console.WriteLine(lookupArray[i]);

                if (lookupArray[i] == lookupValue && (i % 10 == 0))
                {
                    isArrayContainValue = true;
                    return isArrayContainValue;
                }
                else
                {
                    // do something ...
                }
            }

            return isArrayContainValue;
        }

        public void PrintResult(int[] array)
        {
            if (IsArrayContainValue(lookupValue, array))
            {
                Console.WriteLine("Value found");
            }
            else
            {
                // do something...
            }
        }
    }
}