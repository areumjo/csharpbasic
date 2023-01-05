// See https://aka.ms/new-console-template for more information
using System.Security.Principal;
using MyBank;

Console.WriteLine("*** Hello! Welcome to my Bank App. ***");


// `new` : creates a new instance of a type. (can create anonymous types too)
var account1 = new BankAccount("Ari", 1000);

Console.WriteLine($"Account created: {account1.Owner}, {account1.AccountNumber} with ${account1.Balance}.");

account1.MakeWithdrawal(500, DateTime.Now, "Buy a bag");
Console.WriteLine($"Account balance changed: {account1.Owner} : currently ${account1.Balance}.");

account1.MakeDeposit(250, DateTime.Now, "Part time job payment");
Console.WriteLine($"Account balance changed: {account1.Owner} : currently ${account1.Balance}.");

// test with try/catch
BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balace.");
    return;
}

// Test for a negative balance
try
{
    invalidAccount.MakeWithdrawal(11750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}

Console.WriteLine(account1.GetAccountHistory());


Console.ReadLine();
