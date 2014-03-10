namespace StudentAndWorker
{
    public class Worker : Human
    {
        public const decimal Workdaysperweek = 5.0m;

        // fields
        private decimal weekSalary;
        private int workHoursPerDay;

        // costructor
        public Worker(string firstName, string lastName, decimal salary, int workHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHours;
        }

        // properties
        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentException("Salary should be bigger than zero");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentException("Work hours should be bigger than zero");
                }
                this.workHoursPerDay = value;
            }
        }

        // methods
        public override string ToString()
        {
            return string.Format("{0} - Week Salary: {1}, Work Hours: {2}, Hour salary: {3:c2}", 
                base.ToString(), this.WeekSalary, this.WorkHoursPerDay,MoneyPerHour());
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / Workdaysperweek / this.WorkHoursPerDay;
        }
    }
}
