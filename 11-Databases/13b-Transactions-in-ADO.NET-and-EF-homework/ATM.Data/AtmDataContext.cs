namespace ATM.Data
{
    using System.Data.Entity;

     using ATM.Model;

    public class AtmDataContext : DbContext
    {
        public AtmDataContext()
            : base("AtmDB")
        {
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionsHistory> LogRecords { get; set; }
    }
}
