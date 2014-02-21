/*
 * Read in MSDN about the keyword event in C# and how to publish events. Re-implement the
 * above using .NET events and following the best practices.
 */

namespace TimerWithEvents
{
    using System;

    class Test
    {
        static void Main()
        {
            Timer myTimer = new Timer();
            Listener myListener = new Listener();
            myListener.Subscribe(myTimer);
            myTimer.Start(3);

            Console.WriteLine("Enough!");
        }
    }
}