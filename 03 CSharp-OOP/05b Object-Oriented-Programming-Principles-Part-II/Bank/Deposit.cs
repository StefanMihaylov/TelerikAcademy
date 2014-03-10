namespace Bank
{
    using System;

    public class Deposit : Account, IWithdrawable
    {
        public Deposit(AccountCustomer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(DateTime startDate, DateTime endDate)
        {
            if (this.Balance < 1000m) // & this.Balance > 0) // if "balance" < 0???
            {
                return 0.0m;
            }
            else
            {
                return this.Balance * (decimal)this.InterestRate * Account.Months(startDate, endDate);
            }
        }

        public void Withdraw(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("Withdraw money should be bigger than zero");
            }

            if (money > this.Balance)
            {
                throw new ArgumentException("There is not enough money in the account");
            }

            this.Balance -= money;
        }
    }
}
