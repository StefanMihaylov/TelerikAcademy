namespace RandomDataGenetaror
{    
    using System;

    public class ConsoleLogger: ILogger
    {
        public void Log(string message, params object[] args)
        {
            Console.Write(message, args);
        }

        public void LogLine(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
