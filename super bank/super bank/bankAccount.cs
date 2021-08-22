using System;
using System.Collections.Generic;
using System.Text;

namespace super_bank
{
    public class bankAccount
    {
        
        public string Number { get; }
        public string Owner { get; set; }

        public decimal Balance
        { 
            get
            {
               decimal balance = 0;
                foreach (var item in alltransaction)
                {
                    balance += item.Amount;
                }
                return balance;
            }
            set { }
            


            

        }

        private static int accountNumberseed = 1234567890;

        private List<Transaction> alltransaction = new List<Transaction>();

        public bankAccount(string name,decimal initialBalance)
        {
            // in this type [ this ] is not necessary .
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "intial Balance");
            this.Number = accountNumberseed.ToString();
            accountNumberseed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            alltransaction.Add(deposit);
        }

        public void Makewithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance + amount < 0)
            {
                throw new InvalidOperationException("not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            alltransaction.Add(withdrawal);



        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            //HEADER
            report.AppendLine("Date\tAmount\tNote");
            foreach (var item in alltransaction)
            {
                //ROWS
                report.AppendLine($"{item.Date.Year}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
            

        }
    }
}
