namespace TimerWithEvent
{
    using System.Threading;

    public delegate void TickEventHandler(object sender, TimerEventArgs e);

    public class Timer
    {
        private int interval;

        public Timer(double interval)
        {
            this.interval = (int)(interval * 1000);
        }

        public event TickEventHandler Tick;

        public void OnTick(TimerEventArgs e)
        {
            if (this.Tick != null)
            {
                this.Tick(this, e);
            }
        }

        public void Start(int iterations)
        {
            while (iterations > 0)
            {
                TimerEventArgs arg = new TimerEventArgs(iterations);
                this.OnTick(arg);
                Thread.Sleep(this.interval);
                iterations--;
            }
        }
    }
}
