# csharpbasic

## Object-Oriented Programming

- 4 basic principles of OOP

  1. `Abstraction` : modeling the relevant attributes and interactions of entities as classes.

  - to define an abstract representation of a system.

  2. `Encapsulation` : hiding the internal state and fuctionality of an object and only allowing access through a public set of unctions.
  3. `Inheritance` : ability to create new abstractions based on existing abstractions.

  - `: base()` indicates a call to base class constructor. It enables to pick which base class constructor you call.
  - `virtual` : declare a method in the base class that a derived class may override the behavior.
    - this is a method where any derived class may choose to reimplement. >> `override` on derived classes
    - `abstract` : derived classes 'must' override the behavior. (base class doesn't provide an implementation)

  4. `Polymorphism` : ability to implement inherited properties/methods in different ways across multiple abstractions.

  - `virtual` : derived classes could override to create specific behavior.

  ```c#
  // inheritance (derived class from BankAccount)
  public class InterestEarningAccount : BankAccount
    {
      public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
      {
      }

      public override void PerformMonthEndTransactions()
      {
        if (Balance > 500m)
        {
          decimal interest = Balance * 0.05m;
          MakeDeposit(interest, DateTime.Now, "apply monthly interest");
        }
      }
    }
  ```

## Requirements

- An interest earning account that accrues interest at the end of each month.
- A line of credit that can have a negative balance, but when there's a balance, there's an interest charge each month.
- A pre-paid gift card account that starts with a single deposit, and only can be paid off. It can be refilled once at the start of each month.

- An interest earning account:
  - Will get a credit of 2% of the month-ending-balance.
- A line of credit:
  - Can have a negative balance, but not be greater in absolute value than the credit limit.
  - Will incur an interest charge each month where the end of month balance isn't 0.
  - Will incur a fee on each withdrawal that goes over the credit limit.
- A gift card account:
  - Can be refilled with a specified amount once each month, on the last day of the month.
