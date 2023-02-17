using System;
using SimplifiedSlotMachine.Interfaces;

namespace SimplifiedSlotMachine
{
    public class AccountManager : IAccountManager
    {
        private double _balance;

        public double GetBalance()
        {
            return this._balance;
        }

        public bool Deposit(double deposit)
        {
            if (deposit > Constants.ZERO_DOUBLE_VALUE)
            {
                this._balance += deposit;
                this.RoundBalance();
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Withdraw(double amount) 
        {
            this._balance -= amount;
            this.RoundBalance();

            return this._balance;
        }

        private void RoundBalance() 
        { 
            this._balance = Math.Round(this._balance, 2);
        }
    }
}
