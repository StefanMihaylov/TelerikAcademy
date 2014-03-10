namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        private string model;
        private string manufacturer;
        private decimal? price;
        private string ownerName;
        private Battery battery;
        private Display display;

        private static GSM iPhone4S;

        private List<Call> calledPhoneNumbers;

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, new Battery(), new Display())
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.OwnerName = owner;
            this.Battery = battery;
            this.Display = display;
            this.CalledPhoneNumers = new List<Call>();
        }

        static GSM()
        {
            IPhone4S = new GSM("iPhone 4S", "Apple", 1000, "Ali Raza Tekin",
                        new Battery("1432 mAh", BatteryType.LiIon, 200, 14), new Display(960, 640, 16000000));
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new System.ArgumentException("Mobile phone model should not be empty");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new System.ArgumentException("Mobile phone manufacturer should not be empty");
                }
                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentException("Mobile phone price should be greather than zero");
                }
                this.price = value;
            }
        }

        public string OwnerName
        {
            get { return this.ownerName; }
            set { this.ownerName = value; }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
            set { iPhone4S = value; }
        }

        public List<Call> CalledPhoneNumers
        {
            get { return this.calledPhoneNumbers; }
            set { this.calledPhoneNumbers = value; }
        }

        public override string ToString()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            result.AppendLine("Mobile phone technical characteristics:");
            result.AppendFormat(" Model: {0}\n", this.Model);
            result.AppendFormat(" Manufacturer: {0}\n", this.Manufacturer);
            result.AppendFormat(" Price: {0:c}\n", this.Price);
            result.AppendFormat(" Owner: {0}\n", this.OwnerName);
            result.AppendFormat(" Battery: {0}\n", this.Battery);
            result.AppendFormat(" Display: {0}\n", this.Display);
            return result.ToString();
        }

        public void AddCall(string phoneNumber, int duration)
        {
            this.CalledPhoneNumers.Add(new Call(phoneNumber, duration));
        }

        public void DeleteCall(int index)
        {
            if (index >= 0 && index < this.CalledPhoneNumers.Count)
            {
                this.CalledPhoneNumers.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format(" Call #{0} do not exist", index + 1));
            }
        }

        public void ClearCalls()
        {
            this.CalledPhoneNumers.Clear();
        }

        public decimal CalculatePrice(decimal callPrice)
        {
            decimal sum = 0;
            foreach (var call in this.CalledPhoneNumers)
            {
                sum += call.Duration / 60m * callPrice;
            }
            return sum;
        }

    }
}
