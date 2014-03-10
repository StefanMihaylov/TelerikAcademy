namespace Bank
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Test
    {
        public static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var deposit1 = new Deposit(AccountCustomer.Personal, 100m, 0.03);
            var deposit2 = new Deposit(AccountCustomer.Bussiness, 50000, 0.05);
            var loan1 = new Loan(AccountCustomer.Personal, 500, 0.01);
            var loan2 = new Loan(AccountCustomer.Bussiness, 10000, 0.04);
            var mortgage1 = new Mortgage(AccountCustomer.Personal, 1000, 0.02);
            var mortgage2 = new Mortgage(AccountCustomer.Bussiness, 20000, 0.06);

            // initial states
            Console.WriteLine(new string('-', 40));
            Account[] bank = new Account[] { deposit1, deposit2, loan1, loan2, mortgage1, mortgage2, };
            foreach (var account in bank)
            {
                Console.WriteLine(account);
            }

            // check deposit and withdraw methods
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Account 1: {0}", deposit1);
            deposit1.Deposit(500m);
            Console.WriteLine(" Deposit: 500 => Balance: {0}", deposit1.Balance);
            deposit1.Withdraw(400m);
            Console.WriteLine("Withdraw: 400 => Balance: {0}", deposit1.Balance);

            // next codes throw exceptions
            // deposit1.Withdraw(400m);
            // Console.WriteLine("Withdraw: 400 => Balance: {0}", deposit1.Balance);
            // deposit1.Withdraw(-10m);
            // Console.WriteLine("Withdraw: -10 => Balance: {0}", deposit1.Balance);
            // deposit1.Deposit(-10m);
            // Console.WriteLine(" Deposit: -10 => Balance: {0}", deposit1.Balance);

            // calculate interest 
            Console.WriteLine(new string('-', 40));
            DateTime startDate = new DateTime(2014, 1, 1);
            // deposits
            int monthsDeposit = 3;
            Console.WriteLine("Deposit => {0} => \n\t Months: {1}, Interest: {2:c2}",
                deposit1, monthsDeposit, deposit1.CalculateInterest(startDate, startDate.AddMonths(monthsDeposit)));
            deposit1.Deposit(1000m);
            Console.WriteLine("Deposit => {0} => \n\t Months: {1}, Interest: {2:c2}",
                deposit1, monthsDeposit, deposit1.CalculateInterest(startDate, startDate.AddMonths(monthsDeposit)));

            // loan
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Loan => {0}", loan1);
            for (int months = 3; months < 5; months++)
            {
                Console.WriteLine("\t Months: {0}, Interest: {1:c2}",
                    months, loan1.CalculateInterest(startDate, startDate.AddMonths(months)));
            }
            Console.WriteLine("Loan => {0}", loan2);
            for (int months = 2; months < 4; months++)
            {
                Console.WriteLine("\t Months: {0}, Interest: {1:c2}", 
                    months, loan2.CalculateInterest(startDate, startDate.AddMonths(months)));
            }

            // mortgage
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Mortgage => {0}", mortgage1);
            for (int months = 4; months <= 10; months+=2)
            {
                Console.WriteLine("\t Months: {0}, Interest: {1:c2}", 
                    months, mortgage1.CalculateInterest(startDate, startDate.AddMonths(months)));
            }
            Console.WriteLine("Mortgage => {0}", mortgage2);
            for (int months = 6; months <= 18; months+=6)
            {
                Console.WriteLine("\t Months: {0}, Interest: {1:c2}", 
                    months, mortgage2.CalculateInterest(startDate, startDate.AddMonths(months)));
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
