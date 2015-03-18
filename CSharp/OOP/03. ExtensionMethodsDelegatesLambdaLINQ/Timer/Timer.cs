using System.Threading;

namespace Timer
{
    public delegate void TimerDelegate(int repeatance);
    
    public class Timer
    {
        private int ticksCount;
        private int interval;
        private TimerDelegate callDelegate;

        public Timer(int ticksCount, int interval, TimerDelegate callDelegate)
        {
            this.ticksCount = ticksCount;
            this.interval = interval;
            this.callDelegate = callDelegate;
        }

        public int TicksCount
        {
            get { return this.ticksCount; }
        }

        public int Interval
        {
            get { return this.interval; }
        }

        public void Run()
        {
            int ticks = this.TicksCount;
            while (ticks > 0)
            {
                Thread.Sleep(this.interval);
                ticks--;
                this.callDelegate(ticks);
            }
        }
    }
}
