// 
using classes2;
namespace classes;

// Will get a credit of 2% of the month-ending-balance.
public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string owner, decimal initialBalance, string description = "Savings Account") : base(owner, initialBalance, description)
    // public InterestEarningAccount(string owner, decimal initialBalance) : base(owner, initialBalance)
    {
       
        


    }
    public override void PerformMonthEndTransactions()
    {
        if (Balance > 500m)
        {
            var interest = Balance * 0.05m;
            MakeDeposit(interest, DateTime.Now, "applying monthly interest");
        }
    }
}