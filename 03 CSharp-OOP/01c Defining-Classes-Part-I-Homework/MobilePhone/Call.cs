
namespace MobilePhone
{
    using System;

    public class Call
    {
        private DateTime startCallDateAndTime;
        private string phoneNumber;
        private int duration;

        public Call()  : this(null, 0)
        {
        }

        public Call(string phoneNumber, int duration)
        {
            this.StartCallDateAndTime = DateTime.Now;
            this.PhoneNumber = phoneNumber;
            this.Duration = duration;
        }

        public DateTime StartCallDateAndTime
        {
            get { return this.startCallDateAndTime; }
            set { this.startCallDateAndTime = value; }            
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
            // TODO: Phone number can be cheched if it is correct: First symbol ("+" or digit), rest of symbols (only digits), total number of digits can be control too. I have no time to implement such a control now. It is too late, I have to sleep :(
        }

        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Call duration should be greather than zero");
                }
                this.duration = value;
            }
        }

        public override string ToString()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
            return string.Format("Date: {0}; Phone number: {1}; Duration: {2} s",
                this.StartCallDateAndTime, this.PhoneNumber, this.Duration);
        }
    }
}
