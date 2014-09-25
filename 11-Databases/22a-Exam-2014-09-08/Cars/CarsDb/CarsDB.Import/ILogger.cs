namespace CarsDB.Import
{
    public interface ILogger
    {
        void Log(string message, params object[] args);

        void LogLine(string message, params object[] args);
    }
}
