namespace TimerWithEvent
{
    using System;

    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(int ticks)
        {
            this.Ticks = ticks;
        }
        public int Ticks { get; set; }
    }
}
