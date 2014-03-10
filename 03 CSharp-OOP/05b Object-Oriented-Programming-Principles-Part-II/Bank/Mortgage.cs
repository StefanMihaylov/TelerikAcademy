namespace Bank
{
    using System;

    class Mortgage : Account
    {
        public Mortgage(AccountCustomer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(DateTime startDate, DateTime endDate)
        {
            decimal interestPerMonth = this.Balance * (decimal)this.InterestRate;
            decimal months = Account.Months(startDate, endDate);

            decimal rejectedMonths = 0.0m;
            decimal reducedInterestRate = 0.0m;

            if (this.Customer == AccountCustomer.Personal)
            {
                rejectedMonths = 6.0m;
                reducedInterestRate = 0.0m;
            }
            else if (this.Customer == AccountCustomer.Bussiness)
            {
                rejectedMonths = 12m;
                reducedInterestRate = 0.5m;
            }
                        
            if (months <= rejectedMonths)
            {
                return interestPerMonth * reducedInterestRate * months;
            }
            else
            {
                decimal result = interestPerMonth * reducedInterestRate * rejectedMonths;
                result += interestPerMonth * (months - rejectedMonths);
                return result;
            }
        }
    }
}
