using System;

namespace super_bank
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            var account = new bankAccount("ali", +10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}. ");

            account.Makewithdrawal(120, DateTime.Now, "Hammock");
            
            account.Makewithdrawal(50, DateTime.Now, "Xbox Game");

            Console.WriteLine(account.GetAccountHistory());
            Console.WriteLine($"your    Balance is   :   {account.Balance}");

            //Test for a negative balance:
            try
            {
                account.Makewithdrawal(75000, DateTime.Now, "attempt to overdraw");

            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new bankAccount("invalid", -55);

            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine("Exception caught crerating account with negative balance");
                Console.WriteLine(e.ToString());
            }


        }
    }
}
