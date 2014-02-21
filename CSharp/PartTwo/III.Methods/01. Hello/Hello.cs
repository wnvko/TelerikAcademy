/*Write a method that asks the user for his name and prints “Hello, <name>”
 * (for example, “Hello, Peter!”). Write a program to test this method.
 */

namespace Hello
{
    using System;
    class Hello
    {
        static void SayHello(string name)
        {
            Console.WriteLine("Hello {0}", name);
        }
        static void Main()
        {
            Console.Write("Enter a name: ");
            string name = Console.ReadLine();
            SayHello(name);
        }
    }
}
