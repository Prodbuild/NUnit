using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BankApplication;
using System.Reflection;


namespace NUnitTestDemo
{

    [TestFixture]
    [Category("Accounting")]
    public class AccountTest
    {
        private Account sourceAccount;
        private Account destinationAccount;


        [TestFixtureSetUp]
        public void Init()
        {
            // == Assemble ==
            this.sourceAccount = new Account("SB34589");
            this.sourceAccount.Deposit(40000);

            this.destinationAccount = new Account("SB85736");
            this.destinationAccount.Deposit(60000);
        }


        [Test]
        [Category("Deduction")]
        public void
            Account_TransferFundFromOneAccountToAnotherAccount_TrasferSuccessfull_SourceAccountContainsMoreMoneyThanDestinationAccount()
        {


            // == Act ==
            this.sourceAccount.TransferFunds(this.destinationAccount, 20000);

            // == Assert ==

            //Console.WriteLine("In {0} sourceAccountBalance is {1}",MethodBase.GetCurrentMethod().Name, this.sourceAccount.Balance);


            Assert.AreEqual(this.sourceAccount.Balance, 38000, "Failed {0} has not the same value", new object[] { "SourceAccount" });
            Assert.That(this.sourceAccount.Balance, Is.EqualTo(3800), "Failed {0} has not the same value", new object[] { "SourceAccount" });



            Assert.AreEqual(this.destinationAccount.Balance, 62000);

            Assert.That(this.sourceAccount.Balance, Is.EqualTo(3800), "Failed {0} has not the same value",
                new object[] { "SourceAccount" });

            Assert.That(this.sourceAccount.Balance, Is.EqualTo(3800).Or.EqualTo(60000), "Failed {0} has not the same value",
                new object[] { "SourceAccount" });


            Assert.Pass("Successfully passed");

            var count = 55;
            Assert.GreaterOrEqual(count, 50, "The values are not equal");
            Assert.That(count, Is.GreaterThanOrEqualTo(50), "The values are not equal");

        }


        [Test]
        [Category("FundTransfer")]
        public void Test_Transfer_Of_Funds_With_Insufficient_Funds_InAccounts(
            [Values(10000, 2000, 3000)]int amountTobeTransferred)
        {

            // == Assertion ==
            Assert.Throws(typeof(InsufficientFundsException), () =>
            {
                this.sourceAccount.TransferFunds(this.destinationAccount, amountTobeTransferred);
            });

            Assert.That(() =>
            {
                this.sourceAccount.TransferFunds(this.destinationAccount, amountTobeTransferred);
            }, Throws.TypeOf<InsufficientFundsException>());


            var sourceList = new List<int> { 321, 567, 873 };
            var targetList = new List<int> { 123, 456, 987 };

            CollectionAssert.IsSubsetOf(targetList, sourceList, "The lists are not equal");
            Assert.That(targetList, Is.SubsetOf(sourceList), "The lists are not equal");


        }

    }

    [SetUpFixture]
    public class AccountSetUp
    {
        [SetUp]
        public void RunBeforeAnyFixtureExecutes()
        {





        }

        [TearDown]
        public void RunAfterAnyFixtureExecutes()
        {

        }
    }
}
