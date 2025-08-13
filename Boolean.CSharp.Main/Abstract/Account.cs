using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        private protected decimal _balance { get; set; }
        private List<Payment> _payments = new List<Payment>();

        public Account(Branch branchName)
        {
            this.BranchName = branchName;
        }

        public bool Deposit(Payment payment)
        {
            // Make sure we have a credit payment
            if (!payment.Credit)
            {
                Console.WriteLine($"PaymentType '{payment.Type}' not allowed for deposits.");
                return false;
            }
            _balance += payment.Amount;
            _payments.Add(payment);
            return true;
        }

        public bool Withdraw(Payment payment)
        {
            // Make sure we have a debit payment
            if (!payment.Debit)
            {
                Console.WriteLine($"PaymentType '{payment.Type}' not allowed for withdrawals.");
                return false;
            }

            // Make sure we have enough in our balance to withdraw
            if (_balance >= payment.Amount)
            {
                _balance -= payment.Amount;
                _payments.Add(payment);
                return true;
            }
            // Add option to use OverdraftBalance
            Console.WriteLine("Not enough balance to withdraw!");
            return false;
        }

        public decimal CalculateBalance()
        {
            decimal balance = 0m;
            foreach (Payment payment in _payments)
            {
                if (payment.Credit)
                {
                    balance += payment.Amount;
                }
                else if (payment.Debit)
                {
                    balance -= payment.Amount;
                }
            }
            return balance;
        }

        public string PrintBankStatement()
        {
            StringBuilder sb = new StringBuilder();
            decimal balance = 0m;
            string line;
            foreach (Payment payment in _payments)
            {
                if (payment.Credit)
                {
                    balance += payment.Amount;
                    line = string.Format("{0, -10} || {1, -10:F2} || {2, -10:F2} || {3, -15:F2}\n",
                        payment.Date.ToString("MM/dd/yyyy"), payment.Amount, "", balance);
                }
                else if (payment.Debit)
                {
                    balance -= payment.Amount;
                    line = string.Format("{0, -10} || {1, -10:F2} || {2, -10:F2} || {3, -15:F2}\n",
                        payment.Date.ToString("MM/dd/yyyy"), "", payment.Amount, balance);
                }
                else
                {
                    continue;
                }

                sb.Insert(0, line);
            }
            sb.Insert(0, string.Format("{0, -10} || {1, -10} || {2, -10} || {3, -15}\n", "date", "credit", "debit", "balance"));
            Console.WriteLine(sb.ToString().Replace(",","."));
            return sb.ToString();
        }

        public Guid Id { get; set; }
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Branch BranchName { get; set; }
        public List<Payment> Payments { get { return _payments; } }
    }
}