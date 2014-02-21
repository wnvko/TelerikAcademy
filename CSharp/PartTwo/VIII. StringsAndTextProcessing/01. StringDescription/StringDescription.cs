/*
 * Describe the strings in C#. What is typical for the string
 * data type? Describe the most important methods of the String class.
 */

namespace StringDescription
{
    using System;

    public class StringDescription
    {
        public static void Main()
        {
            Console.WriteLine("Stringf represents text as a series of Unicode characters.");
            Console.WriteLine("The String type exposes the following members (not full list):");
            Console.WriteLine("{0,-20}{1}", "String(Char, Int32)", "Initializes a new instance of the String class to the value indicated by a specified Unicode character repeated a specified number of times.");
            Console.WriteLine("{0,-20}{1}", "Length)", "Gets the number of characters in the current String object.");
            Console.WriteLine("{0,-20}{1}", "Compare(String, String)", "Compares two specified String objects and returns an integer that indicates their relative position in the sort order.");
            Console.WriteLine("{0,-20}{1}", "Concat(String, String)", "Concatenates two specified instances of String.");
            Console.WriteLine("{0,-20}{1}", "Contains", "Returns a value indicating whether a specified substring occurs within this string.");
            Console.WriteLine("{0,-20}{1}", "Equals(String, String)", "Determines whether two specified String objects have the same value.");
            Console.WriteLine("{0,-20}{1}", "IndexOf", "Reports the zero-based index of the first occurrence of the specified value");
            Console.WriteLine("{0,-20}{1}", "Join", "Concatenates the elements of an object array, using the specified separator between each element.");
            Console.WriteLine("{0,-20}{1}", "Split(Char[])", "Returns a string array that contains the substrings in this instance that are delimited by elements of a specified Unicode character array.");
            Console.WriteLine("{0,-20}{1}", "ToCharArray()", "Copies the characters in this instance to a Unicode character array.");
            Console.WriteLine();
        }
    }
}
