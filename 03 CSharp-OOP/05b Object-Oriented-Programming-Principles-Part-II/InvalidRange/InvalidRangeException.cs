namespace InvalidRange
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : IEquatable<T>
    {
        public T StartRange { get; private set; }
        public T EndRange { get; private set; }

        public InvalidRangeException(string msg, T start, T end)
            : this(msg, start, end, null)
        {

        }

        public InvalidRangeException(string msg, T start, T end, Exception innerEx)
            : base(msg, innerEx)
        {
            this.StartRange = start;
            this.EndRange = end;
        }

        public override string Message
        {
            get
            {
                if (StartRange.Equals(EndRange))
                {
                    return base.Message;
                }
                else
                {
                    return string.Format("{0}, Range:[{1}...{2}]", base.Message, this.StartRange, this.EndRange);
                }
            }
        }
    }
}
