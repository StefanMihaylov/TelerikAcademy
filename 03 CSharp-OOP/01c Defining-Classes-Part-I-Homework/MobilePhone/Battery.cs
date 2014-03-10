namespace MobilePhone
{
    public class Battery
    {
        private string model;
        private BatteryType type;
        private uint? hoursIdle;
        private uint? hoursTalk;

        public Battery()
            : this(null, BatteryType.Unknown, null, null)
        {
        }

        public Battery(string batteryModel, BatteryType type, uint? batteryHoursIdle, uint? batteryHoursTalk)
        {
            this.Model = batteryModel;
            this.Type = type;
            this.HoursIdle = batteryHoursIdle;
            this.HoursTalk = batteryHoursTalk;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public BatteryType Type
        {
            get { return this.type; }
            set
            {
                if (!System.Enum.IsDefined(typeof(BatteryType), value))
                {
                    throw new System.ArgumentException("Invalid battery type " + value);
                }
                this.type = value;
            }
        }

        public uint? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value == null || value > 0)
                {
                    this.hoursIdle = value;
                }
                else
                {
                    throw new System.ArgumentException("Battery standby time shold be greather than zero");
                }
            }
        }

        public uint? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value == null || value > 0)
                {
                    this.hoursTalk = value;
                }
                else
                {
                    throw new System.ArgumentException("Battery talk time shold be greather than zero");
                }
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            result.AppendFormat("\n   Battery model: {0}\n", this.Model);
            result.AppendFormat("   Battery type: {0}\n", this.Type);
            result.AppendFormat("   Standby Time: {0}h\n", this.HoursIdle);
            result.AppendFormat("   Talk Time: {0}h", this.HoursTalk);
            return result.ToString();
        }

    }
}
