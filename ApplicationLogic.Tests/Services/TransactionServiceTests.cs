using Abp.Domain.Entities;
using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ApplicationLogic.Tests.Services
{
    [TestClass]
    public class TransactionServiceTests
    {

        private Mock<ITransactionRepository> transactionRepoMock = new Mock<ITransactionRepository>();
        private Guid existingTransactionId = Guid.Parse("12345678-9ABC-DEF1-2345-6789ABCDEF12");

        [TestInitialize]
        public void TestInitialize()
        {
            var transaction = new Transaction
            {
                TransactionID = existingTransactionId,
                SenderIBAN = "1234123412341234",
                RecipentIBAN = "5678567856785678",
                Amount = 100,
                TransactionTime = DateTime.Today.AddDays(1),
                Status = TransactionStatus.Processing
            };
        }


        [TestMethod]
        public void GetTransactionByTransactionId_ThrowsException_WhenTransactionIdHasInvalidValue()
        {
            // Arrange
            var transactionService = new TransactionService(transactionRepoMock.Object);

            var badTransactionId = "dagbvnbf bdjsahruhan vdsakngbmb";
            // Act

            // Assert
            Assert.ThrowsException<Exception>(() => {
                transactionService.GetTransactionByTransactionId(badTransactionId);
            });
        }

        [TestMethod]
        public void GetTransactionByTransactionId_Returns_TransactionWhenExists()
        {

            Exception throwException = null;
            var transactionService = new TransactionService(transactionRepoMock.Object);
            Transaction transaction = null;
            //act   
            try
            {
                transaction = transactionService.GetTransactionByTransactionId(existingTransactionId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(transaction);
        }

        [TestMethod]
        public void GetTransactionByTransactionId_ThrowsEntityNotFound_CardDoesntExist()
        {
            var nonExistingTransaction = Guid.NewGuid().ToString();
            var existingTransaction = Guid.NewGuid();
            var transactionService = new TransactionService(transactionRepoMock.Object);

            var transaction = new Transaction
            {
                TransactionID = existingTransaction,
                SenderIBAN = "1234123412341234",
                RecipentIBAN = "5678567856785678",
                Amount = 100,
                TransactionTime = DateTime.Today.AddDays(1),
                Status = TransactionStatus.Processing
            };

            transactionRepoMock.Setup(clientRepo => clientRepo.GetTransactionByTransactionId(existingTransaction))
                .Returns(transaction);

            Assert.ThrowsException<EntityNotFoundException>(() => {
                transactionService.GetTransactionByTransactionId(nonExistingTransaction);
            });
        }
    }
}
