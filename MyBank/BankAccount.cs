using System;
namespace MyBank
{
	public class BankAccount
	{
		// properties : data elements && can have code that enforces validation or other rules.
		public string AccountNumber { get; }
		public string Owner { get; set; }
		public decimal Balance { get
			{
				decimal balance = 0;
				foreach (var item in transactionList)
				{
					balance += item.Amount;
				}
				return balance;
			} }

		// private property can be only accessed inside the BackAccount class.
		// static : it's shared by all of the BankAccount objects.
		// non-static : unique to each instance of the BankAccount obejct.
		private static int accountNumberSeed = 1234567890;

		// constructor : a member that has the same name as the class, initialize objects of that class type.
		public BankAccount(string name, decimal initialBalance)
		{
			this.AccountNumber = accountNumberSeed.ToString();
			accountNumberSeed++;
			this.Owner = name;
			//this.Balance = initialBalance;
			MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
		}


		// new instance of `Transaction` object to the BankAccount.
		private List<Transaction> transactionList = new List<Transaction>();

		// methods : blocks of code that perform a single function
		public void MakeDeposit(decimal amount, DateTime date, string note)
		{
			// we don't allow deposit when amount < 0 :: when we use `execption`, program won't crash with the exception case.
			if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be greater than 0.");
			var deposit = new Transaction(amount, date, note);
			transactionList.Add(deposit);
		}

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
			if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Widthdrawal amount must be positive.");
			if (Balance - amount < 0) throw new InvalidOperationException("Not enough funds.");

			var withdrawal = new Transaction(-amount, date, note);
			transactionList.Add(withdrawal);
        }

		public string GetAccountHistory()
		{
			var report = new System.Text.StringBuilder();

			decimal balace = 0;
			report.AppendLine("Date\t\tAmount\tBalace\tNote");
			foreach (var item in transactionList)
			{
				balace += item.Amount;
				report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{Balance}\t{item.Note}");
			}
			return report.ToString();
		}

	}
}

