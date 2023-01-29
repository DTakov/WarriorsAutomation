using NUnit.Framework;
using System.Security.Principal;

namespace Services.UnitTests
{
    public class BankAccountTests
    {
        [TestCase(-1000)]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void Negative_Input_In_Balance_Constructor_TestCase(double balance)
        {
        
            if (balance < 0)
            {
                Assert.That(() => new BankAccount(balance), Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

        }

        [TestCase(1000, -777)]
        public void Negative_Input_Add_Method_TestCase(double balance, double addedMoney)
        {
            //ARRANGE
            var account = new BankAccount(balance);

            //ACT/ASSERT
            if (addedMoney < 0)
            {
                Assert.That(() => account.Add(addedMoney), Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

        }

        [TestCase(1000, -777)]
        public void Negative_Input_Withdraw_Method_TestCase(double balance, double withdrawedMoney)
        {
            
            //ARRANGE
            var account = new BankAccount(balance);

            //ACT/ASSERT
            if (withdrawedMoney < 0)
            {
                Assert.That(() => account.Withdraw(withdrawedMoney), Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

        }

        [TestCase(1000, 777, 1777)]
        [TestCase(500, 777, 1277)]
        [TestCase(1368.68, 269.20, 1637.88)]
        public void Adding_Money_Updates_Balance_TestCase(double balance, double addedMoney, double expected)
        {
            //ARRANGE
            var account = new BankAccount(balance);

            //ACT
            account.Add(addedMoney);
            double actual = account.Balance;

            //ASSERT
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Adding_Money_Updates_Balance_Test()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT
            account.Add(777);
            double actual = account.Balance;

            //ASSERT
            Assert.That(actual, Is.EqualTo(1777));

        }

        [Test]
        public void Withdraw_Money_Updates_Balance_Test()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT
            account.Withdraw(333);

            //ASSERT
            Assert.That(account.Balance, Is.EqualTo(667));
        }

        [TestCase(1000, 777, 223)]
        [TestCase(800, 777, 23)]
        [TestCase(1368.68, 269.20, 1099.48)]
        public void Withdraw_Money_Updates_Balance_TestCase(double balance, double withdrawedMoney, double expected)
        {
            //ARRANGE
            var account = new BankAccount(balance);

            //ACT
            account.Withdraw(withdrawedMoney);

            //ASSERT
            Assert.That(account.Balance, Is.EqualTo(expected));
        }


        [Test]
        public void Transfer_FundsTo_Another_Account_Test()
        {
            //ARRANGE
            var account = new BankAccount(1000);
            var anotherAccount = new BankAccount();

            //ACT
            account.TransferFundsTo(anotherAccount, 300);

            //ASSERT
            Assert.That(account.Balance, Is.EqualTo(700));
            Assert.That(anotherAccount.Balance, Is.EqualTo(300));
        }

        [TestCase(1000, 300, 700, 300)]
        [TestCase(100, 100, 0, 100)]
        [TestCase(Double.MaxValue, Double.MaxValue, 0, Double.MaxValue)]
        public void Transfer_FundsTo_Another_Account_TestCase(double balanceFirstAccount, double amountToTranfer, double expectedBalanceFirstAccount, double expectedBalanceSecondAccount)
        {
            //ARRANGE
            var account = new BankAccount(balanceFirstAccount);
            var anotherAccount = new BankAccount();

            //ACT
            account.TransferFundsTo(anotherAccount, amountToTranfer);

            //ASSERT
            Assert.That(account.Balance, Is.EqualTo(expectedBalanceFirstAccount));
            Assert.That(anotherAccount.Balance, Is.EqualTo(expectedBalanceSecondAccount));
        }
    }
}