namespace Bank
{
    using System;

    public abstract class Account : IDepositable
    {
        protected const int NumberOfDaysInMonth = 30; // every month has 30 day, one year has 360 days

        // fields         
        private decimal balance;
        private double interestRate;

        // constructor
        public Account(AccountCustomer customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        // properties
        public AccountCustomer Customer { get; private set; }
        // also a customer details have to be added, but this is not part of this exercise

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance should not be negative");
                }
                this.balance = value;
            }
        }

        public double InterestRate
        {
            get { return this.interestRate; }
            protected set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("interest rate should be in range 0.0...1.0 (0...100%)");
                }
                this.interestRate = value;
            }
        }

        // methods
        public abstract decimal CalculateInterest(DateTime startDate, DateTime endDate);

        public void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("Deposit money should be bigger than zero");
            }
            this.Balance += money;
        }

        protected static int Months(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End date should be later than start date");
            }

            int days = (endDate - startDate).Days;
            return days / NumberOfDaysInMonth;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Balance: {1:c2}, Interest rate: {2:p2}", 
                this.Customer,this.Balance, this.InterestRate );
        }
    }
}
