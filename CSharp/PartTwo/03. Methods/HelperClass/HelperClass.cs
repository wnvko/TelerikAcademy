using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HelperClass
{
    private Random random = new Random();

    public T[] GenerateRandomArray<T>(int numberOfItems, int maxNumber = 0)
    {
        if (maxNumber == 0)
        {
            maxNumber = numberOfItems / 3;
        }

        T[] randomArray = new T[numberOfItems];
        for (int counter = 0; counter < numberOfItems; counter++)
        {
            switch (typeof(T).Name)
            {
                case "Int32":
                    object randomNumber = (object)this.random.Next(maxNumber);
                    randomArray[counter] = (T)(randomNumber);
                    break;
                case "Decimal":
                    randomNumber = (object)((decimal)this.random.Next(maxNumber));
                    randomArray[counter] = (T)(randomNumber);
                    break;
                case "Double":
                    randomNumber = (object)((double)this.random.Next(maxNumber));
                    randomArray[counter] = (T)(randomNumber);
                    break;
                case "Single":
                    randomNumber = (object)((float)this.random.Next(maxNumber));
                    randomArray[counter] = (T)(randomNumber);
                    break;
                default:
                    break;
            }

        }

        return randomArray;
    }

    public void PrintArray<T>(T[] inputArray)
    {
        for (int counter = 0; counter < inputArray.Length; counter++)
        {
            Console.Write("{0} ", inputArray[counter]);
        }
    }
}
