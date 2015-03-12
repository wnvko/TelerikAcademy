namespace MyList
{
    using System;
    using System.Collections.Generic;
    using Versions;

    [Version("1.0.0")]
    public class Test
    {
        public static void Main()
        {
            Type type = typeof(Test);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine("Version: {0}", attr.Version);
            }

            GenericList<string> stringList = new GenericList<string>();
            stringList.Add("Mimi");
            stringList.Add("Pepi");
            stringList.Add("Toni");

            Console.WriteLine(stringList);

            stringList.InsertAt("Gogo", 2);
            stringList.InsertAt("Ilio", 4);

            Console.WriteLine(stringList);

            // stringList.InsertAt("Mara", 6); // Argument out of range exception.
            stringList.Add("Anna");
            stringList.Add("Pepa");
            stringList.Add("Vera");
            stringList.Add("Maria");

            Console.WriteLine(stringList);
            Console.WriteLine();

            int indexOfPepa = stringList.FindIndexOf("Pepa");
            int indexOfSomeone = stringList.FindIndexOf("Someone");

            Console.WriteLine("Index of Pepa: {0}", indexOfPepa);
            Console.WriteLine("Index of Someone: {0}", indexOfSomeone);
            Console.WriteLine();

            Console.WriteLine("Min value is {0}", stringList.Min());
            Console.WriteLine("Max value is {0}", stringList.Max());
            Console.WriteLine();

            Console.WriteLine("At index 4 is {0}", stringList[4]);
            Console.WriteLine();

            stringList.RemoveAt(2);
            Console.WriteLine(stringList);

            stringList.ClearAll();
            Console.WriteLine(stringList);
        }
    }
}
