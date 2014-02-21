namespace TimerWithEvents
{
    using System;

    public class Timer
    {
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(Timer myTimer, EventArgs e, int iterations);
        public void Start(int Iterations)
        {
            while (Iterations > 0)
            {
                if (Tick != null)
                {
                    Tick(this, e, Iterations);
                }
                System.Threading.Thread.Sleep(3000);
                Iterations--;
            }
        }
    }
}