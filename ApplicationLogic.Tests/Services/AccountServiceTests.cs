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
    public class AccountServiceTests
    {

        private Mock<IAccountRepository> accountRepoMock = new Mock<IAccountRepository>();
        private Guid existingAccountId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");

        [TestInitialize]
        public void TestInitialize()
        {
            var account = new Account
            {
                AccountID = existingAccountId,
                IBAN = "1111222233334444",
                Balance = "1234"
            };

            accountRepoMock.Setup(accountRepo => accountRepo.GetAccountByAccountId(existingAccountId))
                            .Returns(account);
        }

        [TestMethod]
        public void GetAccountByAccountId_ThrowsException_WhenAccountIdHasInvalidValue()
        {
            // Arrange
            var accountService = new AccountService(accountRepoMock.Object);

            var badAccountId = "dada dahdakfjkfngf jkl";
            // Act

            // Assert
            Assert.ThrowsException<Exception>(() => {
                accountService.GetAccountByAccountId(badAccountId);
            });
        }

        [TestMethod]
        public void GetAccountByAccountId_Returns_AccountWhenExists()
        {
            // Arrange
            Exception throwException = null;
            var accountService = new AccountService(accountRepoMock.Object);
            Account account = null;

            // Act   
            try
            {
                account = accountService.GetAccountByAccountId(existingAccountId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }

            // Assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void GetAccountByAccountId_ThrowsEntityNotFound_AccountDoesntExist()
        {
            // Arrange
            var nonExistingAccount = Guid.NewGuid().ToString();
            var existingAccount = Guid.NewGuid();
            var accountService = new AccountService(accountRepoMock.Object);

            // Act 
            var account = new Account
            {
                AccountID = existingAccount,
                IBAN = "1111222233334444",
                Balance = "1234"
            };

            accountRepoMock.Setup(clientRepo => clientRepo.GetAccountByAccountId(existingAccount))
                .Returns(account);

            // Assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                accountService.GetAccountByAccountId(nonExistingAccount);
            });
        }
    }
}
