namespace FightersCon
{
    using System;

    public class InvalidPowerValueException : ApplicationException
    {
        public InvalidPowerValueException(string msg)
            : base(msg)
        {
        }

        public InvalidPowerValueException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }

    }
}

