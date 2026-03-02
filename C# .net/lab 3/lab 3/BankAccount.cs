using System;

class BankAccount
{
    int accountNumber;
    string ownerName;
    double balance;

    public BankAccount(int accNum, string owner, double initialBalance)
    {
        accountNumber = accNum;
        ownerName = owner;
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
    }

    public bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }

    public bool Transfer(BankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            return true;
        }
        return false;
    }

    public double GetBalance()
    {
        return balance;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Owner Name: " + ownerName);
        Console.WriteLine("Balance: " + balance);
    }
}