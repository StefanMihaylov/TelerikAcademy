namespace TimerClass
{
    using System.Threading;

    public delegate void TimerDelegate(int ticksCount); // delagate declaration

    class Timer
    {
        public int StartTick { get; set; }
        public int Interval { get; set; }
        private TimerDelegate callback;

        public Timer(int tickCounter, int interval, TimerDelegate callback)
        {
            this.StartTick = tickCounter;
            this.Interval = interval;
            this.callback = callback;
        }

        public void Run()
        {
            int ticks = this.StartTick;
            while (ticks > 0)
            {
                Thread.Sleep(this.Interval);
                ticks--;
                this.callback(ticks);               
            }            
        }
    }
}
