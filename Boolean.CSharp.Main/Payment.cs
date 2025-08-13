using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Account { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public PaymentType Type { get; set; }
        public bool Credit { get; set; } = false;
        public bool Debit { get; set; } = false;

        public Payment(Guid account, decimal amount, PaymentType paymentType)
        {
            Account = account;
            Amount = amount;
            Type = paymentType;

            if (paymentType == PaymentType.Credit)
            {
                Credit = true;
            }
            if (paymentType == PaymentType.Debit)
            {
                Debit = true;
            }
        }
    }
}
