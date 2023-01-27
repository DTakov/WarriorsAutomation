using NUnit.Framework;
using System.Security.Principal;

namespace Services.UnitTests
{
    public class BankAccountTests
    {

        [Test]
        public void Adding_Money_Updates_Balance_Test()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT
            account.Add(777);


            //ASSERT
            Assert.That(account.Balance, Is.EqualTo(1777));
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

        [Test]
        public void Transfer_FundsTo_Test() 
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


    }
}