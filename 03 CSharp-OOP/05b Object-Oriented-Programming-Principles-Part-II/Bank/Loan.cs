namespace Bank
{
    using System;

    public class Loan : Account
    {
        public Loan(AccountCustomer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(DateTime startDate, DateTime endDate)
        {            
            decimal months = Account.Months(startDate, endDate);
            decimal rejectedMonths = 0;

            if (this.Customer == AccountCustomer.Personal)
            {
                rejectedMonths = 3;
            }
            else if (this.Customer == AccountCustomer.Bussiness)
            {
                rejectedMonths = 2;
            }

            if (months <= rejectedMonths)
            {
                return 0.0m;
            }
            else
            {
                return this.Balance * (decimal)this.InterestRate * (months - rejectedMonths);
            }
        }
    }
}