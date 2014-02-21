using System;

namespace ConsoleApplication1
{
    class Chapter02Problem08
    {
        static void Main(string[] args)
        {
            string firstPart = "Hello";
            string secondPart = "World";
            object result = firstPart + " " + secondPart;
            string resultAsSting = Convert.ToString(result);
            Console.WriteLine(resultAsSting);
        }
    }
}
