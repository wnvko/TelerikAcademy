namespace Helper
{
    using System;
    using System.Collections.Generic;

    public class Arrays
    {
        private static Random random = new Random();

        public static List<T> GenerateRandomArray<T>(int elementsCount, int minValue = 1, int maxValue = 100)
        {
            List<T> list = new List<T>();
            for (int element = 0; element < elementsCount; element++)
            {
                int randomNumber = random.Next(minValue, maxValue);
                Type itemType = typeof(T);
                switch (itemType.FullName)
                {
                    case "System.Int32":
                    case "System.Double":
                        list.Add((T)(object)randomNumber);
                        break;
                    case "System.Char":
                        char randomChar = (char)randomNumber;
                        list.Add((T)(object)randomChar);
                        break;
                }
            }

            return list;
        }

        public static void PrintArray<T>(string name, List<T> array)
        {
            Console.WriteLine(name);
            for (int element = 0; element < array.Count; element++)
            {
                Console.Write(string.Format("{0}, ", array[element]));
            }

            Console.WriteLine();
        }
    }
}
