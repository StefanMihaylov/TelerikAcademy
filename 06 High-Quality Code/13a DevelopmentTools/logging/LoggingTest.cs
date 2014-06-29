namespace logging
{
    using log4net;
    using log4net.Config;

    public class LoggingTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoggingTest));

        public static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            log.Info("Entering application.");

            log.Debug("Debug message");
            log.Error("Error message");

            log.Info("Exiting application.");
        }
    }
}

