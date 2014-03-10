namespace BankAccountExample
{
    using System;

    class BankAccount
    {
        static void Main()
        {
            /* A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names. */

            string firstName = "Pesho";
            string middleName = "Petrov";
            string lastName = "Peshov";
            string fullName = firstName + " " + middleName + " " + lastName;
            decimal balance;
            string bankName;
            string iban;
            string bicCode;
            ulong creditCard1;
            ulong creditCard2;
            ulong creditCard3;
        }
    }
}
