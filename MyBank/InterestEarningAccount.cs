using System;

namespace MyBank
{
	public class InterestEarningAccount : BankAccount
	{
		// `: base()` indicates a call to base class constructor. It enables to pick which base class constructor you call.
		public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
		{
		}

		public override void PerformMonthEndTransactions()
		{
			if (Balance > 500m)
			{
				decimal interest = Balance * 0.05m;
				MakeDeposit(interest, DateTime.Now, "Apply monthly interest");
			}
		}
	}
}

