using ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ApplicationLogic.Tests.DataModel
{
    [TestClass]
    public class TransactionTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            string senderIBAN = null;
            string recipentIBAN = null;
            int amount = 0;
            DateTime transactionTime = default(global::System.DateTime);
            TransactionStatus status = default(global::ApplicationLogic.DataModel.TransactionStatus);

            // Act
            var result = transaction.Create(
                senderIBAN,
                recipentIBAN,
                amount,
                transactionTime,
                status);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
