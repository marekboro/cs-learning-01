using System;
using System.Collections.Generic;
using classes;

namespace classes2
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }

        }
        public string Description { get; }

        private static int accountNumberSeed = 1234567890;
        private readonly decimal minimumBalance;
        public BankAccount(string owner, decimal initialBalance, string description) : this(owner, initialBalance, description, 0) { }
        public BankAccount(string owner, decimal initialBalance, string description, decimal minimumBalance)
        // public BankAccount(string owner, decimal initialBalance )
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            this.Owner = owner;
            this.Description = description;

            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            }

        }



        private List<Transaction> allTransactions = new List<Transaction>();

        public virtual void PerformMonthEndTransactions() { }
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine($"{this.Owner}'s {this.Description} : ");
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        // public void MakeWithdrawal(decimal amount, DateTime date, string note)
        // {
        //     if (amount <= 0)
        //     {
        //         throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        //     }
        //     if (Balance - amount < minimumBalance)
        //     {
        //         throw new InvalidOperationException($"Insufficient funds, maximum withdrawal: {Balance - 1}");
        //     }
        //     var withdrawal = new Transaction(-amount, date, note);
        //     allTransactions.Add(withdrawal);
        // }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            Console.WriteLine($"Balanace : {Balance}");
            Console.WriteLine($"amount : {amount}");
            Console.WriteLine($"minimumBalance : {minimumBalance}");
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }

    }
}