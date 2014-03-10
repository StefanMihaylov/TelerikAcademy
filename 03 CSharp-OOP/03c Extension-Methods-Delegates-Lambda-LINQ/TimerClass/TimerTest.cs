namespace TimerClass
{
    using System;
    using System.Threading;

    public class TimerTest
    {
        // 7. Using delegates write a class Timer that has can execute certain method at each t seconds.

        static void Main()
        {
            Console.WriteLine("Wait...");
            TimerDelegate timerElapsedDelegate = new TimerDelegate(PrintMessage);

            Timer testTimer = new Timer(5, 1000, timerElapsedDelegate); // 5 ticks, 1 sec wait time.
            testTimer.Run();
        }

        public static void PrintMessage(int ticks)
        {
            Console.WriteLine(" Ticks left: {0}", ticks);
        }
    }
}
