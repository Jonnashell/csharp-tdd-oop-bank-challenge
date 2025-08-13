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

        public Payment(Guid account, decimal amount)
        {
            Account = account;
            Amount = amount;
        }
    }
}
