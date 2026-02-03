using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal interface IPrintable
    {
        void Print();
    }
    internal interface ITransactable
    {
        void deposit(double amount);
        void withdraw(double amount);
    }
    internal abstract class acccount : IPrintable, ITransactable
    {
        public double Balance { get; protected set; }
        public string OwnerName { get; protected set; }
        public double AccountNumber { get; protected set; }
        public acccount(string ownerName, double accountNumber, double initialBalance)
        {
            OwnerName = ownerName;
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        public virtual void deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"{amount} deposited. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }
        public virtual void withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"{amount} withdrawn. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance or invalid amount.");
            }
        }
        public abstract void CalculateInterest();
        public abstract void Print();
    }
    internal class SavingsAccount : acccount
    {
        double interestRate;
        public SavingsAccount(string ownerName, double accountNumber, double initialBalance, double interestRate)
            : base(ownerName, accountNumber, initialBalance)
        {
            this.interestRate = interestRate;
        }
        public override void CalculateInterest()
        {
            double interest = Balance * interestRate;
            Balance += interest;
        }
        public override void Print()
        {
            Console.WriteLine($"Savings Account - Owner: {OwnerName}, Account Number: {AccountNumber}, Balance: {Balance}, Interest Rate: {interestRate}");
        }
    }
    internal class CheckingAccount : acccount
    {
        double overdraftLimit;
        public CheckingAccount(string ownerName, double accountNumber, double initialBalance, double overdraftLimit)
            : base(ownerName, accountNumber, initialBalance)
        {
            this.overdraftLimit = overdraftLimit;
        }
        public override void CalculateInterest()
        {
            Console.WriteLine("Checking accounts do not earn interest.");
        }
        public override void withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance + overdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine($"{amount} withdrawn. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance or overdraft limit exceeded.");
            }
        }
        public override void Print()
        {
            Console.WriteLine($"Checking Account - Owner: {OwnerName}, Account Number: {AccountNumber}, Balance: {Balance}, Overdraft Limit: {overdraftLimit}");
        }

    }

}