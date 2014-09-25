namespace ATM.ConsoleClient
{
    using System;
    using System.Data.SqlClient;
    using System.Data.Entity;
    using System.Linq;
    using System.Transactions;

    using ATM.Data;
    using ATM.Data.Migrations;
    using ATM.Model;


    public class Program
    {
        /* 1. Suppose you are creating a simple engine for an ATM machine. Create a new database "ATM" in SQL Server to hold the accounts of the card holders and the balance (money) for each account. Add a new table CardAccounts with the following fields: Id (int), CardNumber (char(10)), CardPIN (char(4)), CardCash (money). Add a few sample records in the table.
         
           2. Using transactions write a method which retrieves some money (for example $200) from certain account. The retrieval is successful when the following sequence of sub-operations is completed successfully:
             - A query checks if the given CardPIN and CardNumber are valid.
             - The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
             - The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).
            Why does the isolation level need to be set to “repeatable read”?
         
           3. Extend the project from the previous exercise and add a new table TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount) containing information about all money retrievals on all accounts.
             Modify the program logic so that it saves historical information (logs) in the new table after each successful money withdrawal.
             What should the isolation level be for the transaction? */

        private const string ConnectionString = "Data Source = .; Initial Catalog = AtmDb; Integrated Security = True";

        public static void Main()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<AtmDataContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDataContext, Configuration>());

            var db = new AtmDataContext();

            int records = db.CardAccounts.Count();
            if (records == 0)
            {
                db.CardAccounts.Add(new CardAccount() { CardNumber = "1234567890", CardPIN = "1234", CardMoney = 2000m });
                db.CardAccounts.Add(new CardAccount() { CardNumber = "9876543210", CardPIN = "9876", CardMoney = 5000m });
                db.CardAccounts.Add(new CardAccount() { CardNumber = "7418529630", CardPIN = "7410", CardMoney = 1000m });
                db.SaveChanges();
            }

            Console.WriteLine("\t Initial data:");
            Print();

            Console.WriteLine("\n\t Invalid sender card number:");
            TransferMoney(db, "9876543211", "9876", "7418529630", 200m);

            Console.WriteLine("\n\t Invalid sender card pin:");
            TransferMoney(db, "9876543210", "98761", "7418529630", 200m);

            Console.WriteLine("\n\t Invalid receeiver card number:");
            TransferMoney(db, "9876543210", "9876", "7418529631", 200m);

            Console.WriteLine("\n\t Success operation:");
            TransferMoney(db, "9876543210", "9876", "7418529630", 200m);
            Print();

            Console.WriteLine("\n\t Log Records:");
            PrintLog(db);

            Console.WriteLine("\n\t Second Success operation:");
            TransferMoney(db, "9876543210", "9876", "1234567890", 300m);
            Print();

            Console.WriteLine("\n\t Log Records:");
            PrintLog(db);
        }

        private static void TransferMoney(AtmDataContext dbcontext, string sendingAccount, string sendingPin, string receivingAccount, decimal amount)
        {
            var dbConnection = new SqlConnection(ConnectionString);
            dbConnection.Open();

            try
            {
                using (dbConnection)
                {
                    var tranOptions = new TransactionOptions();
                    tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;

                    using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                    {
                        CardAccount sender = GetAccountData(dbConnection, sendingAccount);

                        if (sender == null)
                        {
                            Console.WriteLine("Invalid sender card number");
                            tran.Dispose();
                        }
                        else if (sender.CardPIN != sendingPin)
                        {
                            Console.WriteLine("Invalid sender Pin");
                            tran.Dispose();
                        }
                        else if (sender.CardMoney < amount)
                        {
                            Console.WriteLine("Insufficient amount in the sender account");
                            tran.Dispose();
                        }
                        else
                        {
                            sender.CardMoney -= amount;

                            UpdateReceiverAccont(dbConnection, receivingAccount, amount);

                            UpdateAmount(dbConnection, sender.CardAccountId, sender.CardMoney);

                            Log(dbcontext, sender.CardNumber, receivingAccount, amount);

                            tran.Complete();
                        }
                    }
                }
            }
            catch (TransactionAbortedException ex)
            {
                Console.WriteLine("Transaction aborted. Message: {0}", ex.Message);
            }

        }

        private static CardAccount GetAccountData(SqlConnection dbConnection, string cardNumber)
        {
            // SQL injection is possible! I have no time to write parametric query
            string query = string.Format("SELECT * FROM CardAccounts WHERE CardNumber = {0}", cardNumber);
            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    int id = (int)reader["CardAccountId"];
                    string accountNumber = (string)reader["CardNumber"];
                    string cardPin = (string)reader["CardPIN"];
                    decimal cardAmount = (decimal)reader["CardMoney"];

                    return new CardAccount()
                    {
                        CardAccountId = id,
                        CardNumber = accountNumber,
                        CardPIN = cardPin,
                        CardMoney = cardAmount
                    };
                }
            }

            return null;
        }

        private static void UpdateReceiverAccont(SqlConnection dbConnection, string cardNumber, decimal amount)
        {
            var tranOptions = new TransactionOptions();
            tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;

            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, tranOptions))
            {
                CardAccount receiver = GetAccountData(dbConnection, cardNumber);
                if (receiver == null)
                {
                    Console.WriteLine("Invalid Receiver Card number");
                    //tran.Dispose();
                }
                else
                {
                    receiver.CardMoney += amount;

                    UpdateAmount(dbConnection, receiver.CardAccountId, receiver.CardMoney);

                    tran.Complete();
                }
            }
        }

        private static void UpdateAmount(SqlConnection dbConnection, int cardId, decimal amount)
        {
            var tranOptions = new TransactionOptions();
            tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;

            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, tranOptions))
            {
                string query = string.Format("UPDATE CardAccounts SET CardMoney = {1} WHERE CardAccountId = {0}", cardId, amount);
                SqlCommand receiveMoneyCommand = new SqlCommand(query, dbConnection);
                receiveMoneyCommand.ExecuteNonQuery();

                tran.Complete();
            }
        }

        private static void Print()
        {
            var dbConnection = new SqlConnection(ConnectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                var tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;

                using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                {
                    string query = string.Format("SELECT * FROM CardAccounts");
                    SqlCommand command = new SqlCommand(query, dbConnection);
                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["CardAccountId"];
                            string accountNumber = (string)reader["CardNumber"];
                            string cardPin = (string)reader["CardPIN"];
                            decimal cardAmount = (decimal)reader["CardMoney"];

                            Console.WriteLine("\t Card \"{0}\" : {1:c0}", accountNumber, cardAmount);
                        }
                    }

                    Console.WriteLine(new string('-', 60));
                }
            }
        }

        private static void Log(AtmDataContext dbContext, string senderCardNumber, string receiverCardNumber, decimal amount)
        {
            var tranOptions = new TransactionOptions();
            tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;

            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, tranOptions))
            {
                dbContext.LogRecords.Add(new TransactionsHistory()
                {
                    TransactionDate = DateTime.Now,
                    SenderCardNumber = senderCardNumber,
                    ReceiverCardNumber = receiverCardNumber,
                    Amount = amount
                });

                dbContext.SaveChanges();

                tran.Complete();
            }
        }

        private static void PrintLog(AtmDataContext dbContext)
        {
            foreach (var record in dbContext.LogRecords)
            {
                Console.WriteLine("\t From \"{0}\" to \"{1}\" => {2:c0}", record.SenderCardNumber, record.ReceiverCardNumber, record.Amount);
            }
        }
    }
}
