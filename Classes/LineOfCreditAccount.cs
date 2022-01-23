
using classes2;
namespace classes;

/* 
Can have a negative balance, but not be greater in absolute value than the credit limit.
Will incur an interest charge each month where the end of month balance isn't 0.
Will incur a fee on each withdrawal that goes over the credit limit.
*/

public class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string owner, decimal initialBalance, decimal creditLimit,string description ="Credit Account") : base(owner, initialBalance,description,-creditLimit)
    {
    }

    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            // Negate the balance to get a positive interest charge:
            var interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
    isOverdrawn
    ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
    : default;

}