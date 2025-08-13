using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private CurrentAccount _account;
        private SavingsAccount _savingsAccount;

        public CoreTests()
        {
            _account = new CurrentAccount();
            _savingsAccount = new SavingsAccount();
        }

        [Test]
        public void CreateAccountTest()
        {
            Assert.That(_account, Is.Not.Null);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            Assert.That(_savingsAccount, Is.Not.Null);
        }

        [Test]
        public void BankStatementTest()
        {
            string statement = _account.PrintBankStatement();
            Assert.That(statement, Is.Not.Empty);
        }

        [Test]
        public void DepositTest()
        {
            Payment payment = new Payment(_account.AccountNumber, 100m);
            _account.Deposit(payment);
        }

        [Test]
        public void WithdrawTest()
        {
            Payment payment = new Payment(_account.AccountNumber, 100m);
            _account.Withdraw(payment);
        }
    }
}