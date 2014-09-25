namespace RandomDataGenetaror
{
    public interface ILogger
    {
        void Log(string message, params object[] args);

        void LogLine(string message, params object[] args);
    }
}
