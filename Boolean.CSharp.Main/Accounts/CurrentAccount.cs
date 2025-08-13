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
        public CurrentAccount()
        {

        }

        public void RequestOverdraft(int overdraftAmount)
        {
            throw new NotImplementedException();
        }
    }
}
