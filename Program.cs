using System;
using classes2;

public class MyClass
{
    public static void TestMethod()
    {
        Console.WriteLine("My Class testMethod!");
    }

}

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {

            var account = new BankAccount("Rambo", 1000, "Default account");
            // var account = new BankAccount("Rambo", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
            Console.WriteLine(account.GetAccountHistory());

            var giftCard = new GiftCardAccount("Rocky Balboa", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("Tango", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("Marion Cobretti", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());

            //! Test that the initial balances must be positive.
            // BankAccount invalidAccount;
            // try
            // {
            //     invalidAccount = new BankAccount("invalid", -55);
            // }
            // catch (ArgumentOutOfRangeException e)
            // {
            //     Console.WriteLine("Exception caught creating account with negative balance");
            //     Console.WriteLine(e.ToString());
            //     return;
            // }

            //! Test for a negative balance.
            // try
            // {
            //     account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            // }
            // catch (InvalidOperationException e)
            // {
            //     Console.WriteLine("Exception caught trying to overdraw");
            //     Console.WriteLine(e.ToString());
            // }



            // MyClass.TestMethod();
            // Program.MyClass2.MyMethod();
            // MyClass3.HelloWorld();

            // if (args.Length > 0)
            // {
            //     foreach (var arg in args)
            //     {
            //         Console.WriteLine($"Argument={arg}");
            //     }
            // }
            // else
            // {
            //    Console.WriteLine("No arguments");
            // }
        }
        class MyClass2
        {
            public static void MyMethod()
            {
                Console.WriteLine("Hello World from MyNamespace.MyClass.MyMethod!");
            }
        }



    }


}



public class MyClass3
{
    public static void HelloWorld()
    {
        System.Random random = new System.Random();
        string message = "Hello World ";
        int randomDelay1 = random.Next(5, 35);
        foreach (char c in message)
        {
            Console.Write(c);
            Task.Delay(30 * randomDelay1).Wait();
        }
        Task.Delay(200).Wait();
        Console.WriteLine("");
        Task.Delay(300).Wait();
        Console.Write(".");
        Task.Delay(400).Wait();
        Console.Write(".");
        Task.Delay(100).Wait();
        Console.Write(".");
        Task.Delay(50).Wait();
        Console.Write(".");
        Task.Delay(70).Wait();
        Console.Write(".");
        Console.WriteLine("");

        string message2 = "There are no strings on me...";
        foreach (char c in message2)
        {
            int randomDelay2 = random.Next(10, 50);
            Console.Write(c);
            Task.Delay(20 * randomDelay2).Wait();
        }


    }

}