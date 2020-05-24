using ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ApplicationLogic.Tests.DataModel
{
    [TestClass]
    public class AccountTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            //this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Account CreateAccount()
        {
            return new Account();
        }

        [TestMethod]
        public void Create_Returns_ValidAccountObject()
        {
            // Arrange
            var account = this.CreateAccount();
            string IBAN = "12345";
            string balance = "100";

            // Act
            var result = Account.Create(
                IBAN,
                balance
                );

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(Guid.Empty, result.AccountID);
            Assert.AreEqual(IBAN, result.IBAN);
            Assert.AreEqual(balance, result.Balance);
            Assert.IsNotNull(result.Transactions);
            Assert.IsNotNull(result.Cards);
        }

        [TestMethod]
        public void Create_StateUnderTest_UnexpectedBehavior()
        {
            // Arrange
            var account = this.CreateAccount();
            string IBAN = "12345";
            string balance = "100";

            // Act
            var result = Account.Create(
                IBAN,
                balance
                );

            // Assert
            Assert.ThrowsException<AssertFailedException>(() => {
                Assert.IsNull(result);
                Assert.AreEqual(Guid.Empty, result.AccountID);
                Assert.AreNotEqual(IBAN, result.IBAN);
                Assert.AreNotEqual(balance, result.Balance);
                Assert.IsNull(result.Transactions);
                Assert.IsNull(result.Cards);
            });
        }
    }
}
