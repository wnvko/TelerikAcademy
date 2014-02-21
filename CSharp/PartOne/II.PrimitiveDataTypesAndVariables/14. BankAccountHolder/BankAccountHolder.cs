namespace BankAccountHolder
{
    using System;

    class BankAccountHolder
    {
        static void Main()
        {
            /*
             * A bank account has a holder name (first name,
             * middle name and last name), available amount of
             * money (balance), bank name, IBAN, BIC code and
             * 3 credit card numbers associated with the account.
             * Declare the variables needed to keep the information
             * for a single bank account using the appropriate
             * data types and descriptive names.
            */
            string firstName;
            string middleName;
            string lastName;
            decimal accountBalance;
            string bankName;
            string IBAN; //usually include letters and numbers
            string bankInformationCode;
            int[] creditCardNumber = new int[3]; //initialize an array of three integers
        }
    }
}
