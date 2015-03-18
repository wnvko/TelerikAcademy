namespace TimerWithEvent
{
    using System;

    public class TestTimer
    {
        private static double waitSeconds = 0.7;
        private static int repeate = 10;

        public static void Main(string[] args)
        {
            Timer timer = new Timer(waitSeconds);
            
            Listener first = new Listener("First");
            first.Subscribe(timer);
            
            Listener second = new Listener("Second");
            second.Subscribe(timer);
            
            timer.Start(repeate);
            
            Console.WriteLine("Enough!");
        }
    }
}
