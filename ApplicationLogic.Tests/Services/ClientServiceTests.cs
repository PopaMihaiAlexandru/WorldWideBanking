using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ApplicationLogic.Tests.Services
{
    [TestClass]
    public class ClientServiceTests
    {
        private Mock<IClientRepository> clientRepoMock = new Mock<IClientRepository>();
        private Guid existingClientId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");

        [TestInitialize]
        public void TestInitialize()
        {
            var client = new Client
            {
                ClientID = existingClientId,
                Name = "Name",
                Surname = "Surname",
                Address = "St. One, No. 10",
                PostalCode = "123456",
                CNP = "1234567890123",
                Country = "Romania",
                City = "Craiova",
                District = "CV9",
                PhoneNumber = "1234567890",
                Mail = "mail@mail.com"
            };

            clientRepoMock.Setup(clientRepo => clientRepo.GetClientByClientId(existingClientId))
                            .Returns(client);
        }

        [TestMethod]
        public void GetClientByClientId_ThrowsException_WhenClientIdHasInvalidValue()
        {
            // Arrange
            var clientService = new ClientService(clientRepoMock.Object);

            var badClientId = "dada dahdakfjkfngf jkl";
            // Act

            // Assert
            Assert.ThrowsException<Exception>(() => {
                clientService.GetClientByClientId(badClientId);
            });
        }

        [TestMethod]
        public void GetClientByClientId_Returns_AccountWhenExists()
        {
            Exception throwException = null;
            var clientService = new ClientService(clientRepoMock.Object);
            Client client = null;
            //act   
            try
            {
                client = clientService.GetClientByClientId(existingClientId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(client);
        }
    }
}
