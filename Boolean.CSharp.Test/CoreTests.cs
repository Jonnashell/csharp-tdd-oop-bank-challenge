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

        [Test]
        public void CalculateBalanceTest()
        {
            // Arrange
            Payment payment = new Payment(_account.AccountNumber, 100m);
            _account.Deposit(payment);

            Payment withdraw_payment = new Payment(_account.AccountNumber, 50m);
            _account.Withdraw(withdraw_payment);

            // Act
            decimal balance = _account.CalculateBalance();

            // Assert
            Assert.That(balance, Is.EqualTo(50m));
        }

        [Test]
        public void BranchTest()
        {
            Assert.That(_account.BranchName, Is.EqualTo(Branch.Oslo));
        }

        [Test]
        public void RequestOverdraftTest()
        {
            // Arrange
            int overdraftAmount = 100;
            if (_account.RequestOverdraft(overdraftAmount))
            {
                Assert.That(_account.OverdraftBalance, Is.EqualTo(overdraftAmount));
            }
        }

        [Test]
        public void ApproveOrRejectOverdraftTest()
        {
            bool approveOverdraft = true;
            bool approved = _account.ApproveOrRejectOverdraft(approve: approveOverdraft);
            Assert.That(_account.OverdraftApproved, Is.EqualTo(approveOverdraft));

            bool approveOverdraft2 = false;
            bool approved2 = _account.ApproveOrRejectOverdraft(approve: approveOverdraft2);
            Assert.That(_account.OverdraftApproved, Is.EqualTo(approveOverdraft2));
        }

        [Test]
        public void UseOverdraftTest()
        {
            _account.RequestOverdraft(100);
            Payment payment = new Payment(_account.AccountNumber, 50m);
            _account.Withdraw(payment);

            Assert.That(_account.OverdraftBalance, Is.EqualTo(50m));
        }
    }
}