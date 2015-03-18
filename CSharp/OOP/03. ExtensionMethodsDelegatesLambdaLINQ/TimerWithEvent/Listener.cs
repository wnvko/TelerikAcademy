namespace TimerWithEvent
{
    using System;

    public class Listener
    {
        private string name;

        public Listener(string name)
        {
            this.name = name;
        }

        public void Subscribe(Timer timer)
        {
            timer.Tick += this.Timer_Tick;
        }

        private void Timer_Tick(object sender, TimerEventArgs e)
        {
            Console.WriteLine("{0} said: \"Just {1} more times\"", this.name, e.Ticks);
        }
    }
}
