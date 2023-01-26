using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    /// <summary>
    /// Summary description for BankAccount
    /// </summary>
    public class BankAccount
    {
        private double balance;

        public BankAccount()
        {

        }

        public double Balance
        {
            get { return balance; }
        }

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Add(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            else
            {
                balance += amount;
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            else
            {
                balance -= amount;
            }
        }

        public void TransferFundsTo(BankAccount otherBankAccount, double amount)
        {
            if (otherBankAccount == null)
            {
                throw new ArgumentNullException(nameof(otherBankAccount));
            }
            else
            {
                Withdraw(amount);
                otherBankAccount.Add(amount);
            }

        }

    }
}
