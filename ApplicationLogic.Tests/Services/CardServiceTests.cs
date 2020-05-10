using ApplicationLogic.Abstractions;
using ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using static ApplicationLogic.DataModel.Card;

namespace ApplicationLogic.Tests.Services
{
    [TestClass]
    public class CardServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ICardRepository> mockCardRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCardRepository = this.mockRepository.Create<ICardRepository>();
        }

        private CardService CreateService()
        {
            return new CardService(
                this.mockCardRepository.Object);
        }

        [TestMethod]
        public void GetCardByCardId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string cardId = null;

            // Act
            var result = service.GetCardByCardId(
                cardId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string ownerName = null;
            string serialNumber = null;
            DateTime expiryDate = default(global::System.DateTime);
            string cvv = null;
            CardType type = default(global::ApplicationLogic.DataModel.Card.CardType);

            // Act
            var result = service.Add(
                ownerName,
                serialNumber,
                expiryDate,
                cvv,
                type);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = service.GetAll();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
