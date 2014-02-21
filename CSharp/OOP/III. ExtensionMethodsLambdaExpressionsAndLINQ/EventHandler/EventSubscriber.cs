namespace TimerWithEvents
{
    using System;

    public class Listener
    {
        public void Subscribe(Timer myTimer)
        {
            myTimer.Tick += new Timer.TickHandler(HeardIt);
        }
        private void HeardIt(Timer myTimer, EventArgs e, int iterations)
        {
            System.Console.WriteLine("Just {0} more times", iterations);
        }

    }
}