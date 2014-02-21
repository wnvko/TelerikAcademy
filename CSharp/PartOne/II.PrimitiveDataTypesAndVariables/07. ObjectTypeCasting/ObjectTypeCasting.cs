namespace ObjectTypeCasting
{
    using System;

    class ObjectTypeCasting
    {
        static void Main()
        {
            /*
             * Declare two string variables and assign them with
             * “Hello” and “World”. Declare an object variable and
             * assign it with the concatenation of the first two
             * variables (mind adding an interval).
             * Declare a third string variable and initialize it with
             * the value of the object variable (you should perform type casting).
             */
            string firstString = "Hello";
            string secondString = "World";
            object concatenationResult = string.Concat(firstString, " ", secondString);
            string objectToString = (string)concatenationResult;
            Console.WriteLine(objectToString);
        }
    }
}
