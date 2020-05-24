using ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ApplicationLogic.Tests.DataModel
{
    [TestClass]
    public class TransactionTests
    {
    
        [TestInitialize]
        public void TestInitialize()
        {
            //this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Transaction CreateTransaction()
        {
            return new Transaction();
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transaction = this.CreateTransaction();
            string senderIBAN = "1234123412341234";
            string recipentIBAN = "5678567856785678";
            int amount = 100;
            DateTime transactionTime = DateTime.Today.AddDays(1);
            TransactionStatus status = TransactionStatus.Processing;

            // Act
            var result = Transaction.Create(
                senderIBAN,
                recipentIBAN,
                amount,
                transactionTime,
                status);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(Guid.Empty, result.TransactionID);
            Assert.AreEqual(senderIBAN, result.SenderIBAN);
            Assert.AreEqual(recipentIBAN, result.RecipentIBAN);
            Assert.AreEqual(amount, result.Amount);
            Assert.AreEqual(transactionTime, result.TransactionTime);
            Assert.AreEqual(status, result.Status);
        }

        [TestMethod]
        public void Create_StateUnderTest_UnexpectedBehavior()
        {
            // Arrange
            var card = this.CreateTransaction();
            string senderIBAN = "1234123412341234";
            string recipentIBAN = "5678567856785678";
            int amount = 100;
            DateTime transactionTime = DateTime.Today.AddDays(1);
            TransactionStatus status = TransactionStatus.Processing;

            // Act
            var result = Transaction.Create(
                senderIBAN,
                recipentIBAN,
                amount,
                transactionTime,
                status);

            // Assert
            Assert.ThrowsException<AssertFailedException>(() => {
                Assert.IsNull(result);
                Assert.AreEqual(Guid.Empty, result.TransactionID);
                Assert.AreNotEqual(senderIBAN, result.SenderIBAN);
                Assert.AreNotEqual(recipentIBAN, result.RecipentIBAN);
                Assert.AreNotEqual(amount, result.Amount);
                Assert.AreNotEqual(transactionTime, result.TransactionTime);
                Assert.AreNotEqual(status, result.Status);
            });
        }
    }
}
