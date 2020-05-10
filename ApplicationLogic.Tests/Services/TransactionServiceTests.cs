using ApplicationLogic.Abstractions;
using ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ApplicationLogic.Tests.Services
{
    [TestClass]
    public class TransactionServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ITransactionRepository> mockTransactionRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTransactionRepository = this.mockRepository.Create<ITransactionRepository>();
        }

        private TransactionService CreateService()
        {
            return new TransactionService(
                this.mockTransactionRepository.Object);
        }

        [TestMethod]
        public void GetTransactionByTransactionId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string transactionId = null;

            // Act
            var result = service.GetTransactionByTransactionId(
                transactionId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
