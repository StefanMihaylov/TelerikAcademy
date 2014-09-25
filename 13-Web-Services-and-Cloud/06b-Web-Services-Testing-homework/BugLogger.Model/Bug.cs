namespace BugLogger.Model
{
    using System;

    public class Bug
    {
        public int BugId { get; set; }

        public Status Status { get; set; }

        public string Text { get; set; }

        public DateTime LogDate { get; set; }
    }
}
