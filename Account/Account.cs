using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class Account
    {
        public readonly string AccountNumber;

        public Account(string accountNumber)
        {
            this.AccountNumber = accountNumber;
        }

        private int balance;
        private int minimumBalance = 10000;

        public int Balance
        {
            get { return balance; }
        }

        public int MinimumBalance
        {
            get { return minimumBalance; }
        }

        public void Deposit(int amount)
        {
            this.balance += amount;
        }

        public void Withdraw(int amount)
        {
            this.balance -= amount;
        }

        public void TransferFunds(Account destination, int amount)
        {
            if ((this.balance - amount) < this.minimumBalance)
            { throw new InsufficientFundsException(string.Format("Insufficinet fund in {0}", this.GetType().Name)); }

            destination.Deposit(amount);

            this.Withdraw(amount);
        }


    }

    public class InsufficientFundsException : ApplicationException
    {
        public string ErrorMessage { get; private set; }

        public InsufficientFundsException(string message)
        {
            this.ErrorMessage = message;
        }
    }

}
