using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        private decimal _balance { get; set; }

        public Account(Branch branchName)
        {
            this.BranchName = branchName;
        }

        public string PrintBankStatement()
        {
            throw new NotImplementedException();
        }

        public void Deposit(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(Payment payment)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateBalance()
        {
            throw new NotImplementedException();
        }

        public string SendBankStatement()
        {
            throw new NotImplementedException();
        }

        public Guid Id { get; set; }
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Branch BranchName { get; set; }
        public List<Payment> Payments = new List<Payment>();
    }
}