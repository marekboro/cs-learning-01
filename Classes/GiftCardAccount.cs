
using classes2;
namespace classes;

// Can be refilled with a specified amount once each month, on the last day of the month.
public class GiftCardAccount : BankAccount
{
    private decimal _monthlyDeposit = 0m;

    public GiftCardAccount(string owner,decimal initialBalance,  decimal monthlyDeposit = 0, string description = "Gift Card Account") : base(owner, initialBalance, description)
        => _monthlyDeposit = monthlyDeposit;

    public override void PerformMonthEndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
        }
    }
}