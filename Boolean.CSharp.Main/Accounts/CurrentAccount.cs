using Boolean.CSharp.Main.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : Account
    {
        private int _overdraftAmount = 0;
        private decimal _overdraftBalance = 0;
        public CurrentAccount(Branch branchName = Branch.Oslo) : base(branchName)
        {
            
        }

        public bool ApproveOrRejectOverdraft(bool approve)
        {
            if (OverdraftApproved)
            {
                OverdraftApproved = false;
                return false;
            }
            else
            {
                OverdraftApproved = true;
                return true;
            }
        }

        public bool RequestOverdraft(int overdraftAmount)
        {
            if (OverdraftApproved)
            {
                return false;
            }

            ApproveOrRejectOverdraft(!OverdraftApproved);

            _overdraftAmount = overdraftAmount;
            _balance += overdraftAmount; // update hidden balance
            return true;
        }

        public bool OverdraftApproved { get; set; } = false;
        public int OverdraftAmount { get { return _overdraftAmount; } }
        public decimal OverdraftBalance { get { return _overdraftBalance; } }
    }
}
