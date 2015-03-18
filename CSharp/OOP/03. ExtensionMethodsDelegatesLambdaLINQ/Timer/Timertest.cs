namespace Timer
{
    using System;
    using System.Threading;

    public class Timertest
    {
        public const int ticksCount = 10;
        public const int interval = 2000;

        public static void Main()
        {
            TimerDelegate timerDelegate = new TimerDelegate(Print);

            Timer timer = new Timer(ticksCount, interval, timerDelegate);
            Thread separateProcess = new Thread(new ThreadStart(timer.Run));
            separateProcess.Start();
        }

        public static void Print(int ticks)
        {
            Console.WriteLine("Hello (will print another {0} times)!", ticks);
        }
    }
}
