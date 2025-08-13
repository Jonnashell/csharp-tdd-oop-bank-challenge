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

        [Test]
        public void CreateAccountTest()
        {
            Assert.That(_account, Is.Not.Null);
        }

        [Test]
        public void CreateSavingsAccount()
        {
            SavingsAccount _savingsAccount = new SavingsAccount();
            Assert.That(_savingsAccount, Is.Not.Null);
        }

        [Test]
        public void BankStatementTest()
        {
            _account = new CurrentAccount();
            Payment payment = new Payment(_account.AccountNumber, 1000m, PaymentType.Credit);
            Payment payment2 = new Payment(_account.AccountNumber, 2000m, PaymentType.Credit);
            Payment payment3 = new Payment(_account.AccountNumber, 500m, PaymentType.Debit);

            _account.Deposit(payment);
            _account.Deposit(payment2);
            _account.Withdraw(payment3);

            string statement = _account.PrintBankStatement();
            Assert.That(statement, Is.Not.Empty);
        }

        [Test]
        public void BankStatementOverdraftTest()
        {
            _account = new CurrentAccount();
            Payment payment = new Payment(_account.AccountNumber, 1000m, PaymentType.Credit);
            Payment payment2 = new Payment(_account.AccountNumber, 900m, PaymentType.Debit);

            _account.RequestOverdraft(200);

            Payment payment3 = new Payment(_account.AccountNumber, 150m, PaymentType.Debit);

            _account.Deposit(payment);
            _account.Withdraw(payment2);
            _account.Withdraw(payment3);

            string statement = _account.PrintBankStatement();
            Assert.That(statement, Is.Not.Empty);
        }

        [Test]
        public void DepositTest()
        {
            _account = new CurrentAccount();
            Payment payment = new Payment(_account.AccountNumber, 100m, PaymentType.Credit);
            _account.Deposit(payment);

            decimal balance = _account.CalculateBalance();

            Assert.That(balance, Is.EqualTo(100m));
        }

        [Test]
        public void WithdrawTest()
        {
            _account = new CurrentAccount();
            Payment payment = new Payment(_account.AccountNumber, 100m, PaymentType.Credit);
            _account.Deposit(payment);

            Payment withdraw_payment = new Payment(_account.AccountNumber, 50m, PaymentType.Debit);
            _account.Withdraw(withdraw_payment);

            decimal balance = _account.CalculateBalance();

            Assert.That(balance, Is.EqualTo(50m));
        }

        [Test]
        public void CalculateBalanceTest()
        {
            _account = new CurrentAccount();
            // Arrange
            Payment payment = new Payment(_account.AccountNumber, 100m, PaymentType.Credit);
            _account.Deposit(payment);

            Payment withdraw_payment = new Payment(_account.AccountNumber, 50m, PaymentType.Debit);
            _account.Withdraw(withdraw_payment);

            // Act
            decimal balance = _account.CalculateBalance();

            // Assert
            Assert.That(balance, Is.EqualTo(50m));
        }

        [Test]
        public void BranchTest()
        {
            _account = new CurrentAccount();
            Assert.That(_account.BranchName, Is.EqualTo(Branch.Oslo));
        }

        [Test]
        public void RequestOverdraftTest()
        {
            _account = new CurrentAccount();
            int overdraftAmount = 100;
            _account.RequestOverdraft(overdraftAmount);

            Assert.That(_account.OverdraftApproved, Is.EqualTo(true));
        }

        [Test]
        public void ApproveOrRejectOverdraftTest()
        {
            _account = new CurrentAccount();
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
            // Arrange
            _account = new CurrentAccount();
            int overdraftAmount = 100;
            if (_account.RequestOverdraft(overdraftAmount))
            {
                Payment payment = new Payment(_account.AccountNumber, 50m, PaymentType.Debit);
                _account.Withdraw(payment);

                decimal balance = _account.CalculateBalance();

                Assert.That(balance, Is.EqualTo(-50m));
            }
        }

        [Test]
        public void TooMuchOverdraftTest()
        {
            // Arrange
            _account = new CurrentAccount();
            int overdraftAmount = 100;
            if (_account.RequestOverdraft(overdraftAmount))
            {
                Payment payment = new Payment(_account.AccountNumber, 120m, PaymentType.Debit);
                bool result = _account.Withdraw(payment);

                Assert.That(result, Is.EqualTo(false));
            }
        }
    }
}