namespace StringsAndObjects
{
    using System;

    public class StringsAndObjects
    {
        public static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";

            object helloWorld = hello + " " + world;

            string helloWorldAsString = (string)helloWorld;
            Console.WriteLine(helloWorldAsString);
        }
    }
}
